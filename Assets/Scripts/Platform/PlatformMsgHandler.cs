using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using LuaInterface;
using ICSharpCode.SharpZipLib.Zip;

public class PlatformMsgHandler : MonoBehaviour
{

    private bool isPause = false;
    private bool isFocus = false;
    public static bool is_open_qdcrash = false;
    public static bool is_upload_last_log = false;

    public static bool is_upload_logcat = false;

    private static LuaFunction call_back;

    public static Int32 maxUploadSize = 1024 * 1024 * 4;

    public static PlatformMsgHandler instance = null;

    public static PlatformMsgHandler GetInstance()
    {
        if (instance == null)
        {
            GameObject MainObj = UnityEngine.GameObject.Find("GameMain");
            instance = MainObj.GetComponent<PlatformMsgHandler>();
        }

        return instance;
    }

    public static void Init()
    {
        GameObject MainObj = UnityEngine.GameObject.Find("GameMain");
        if (MainObj != null && MainObj.GetComponent(typeof(PlatformMsgHandler)) == null)
        {
            instance = MainObj.AddComponent(typeof(PlatformMsgHandler)) as PlatformMsgHandler;
        }
#if UNITY_ANDROID && !UNITY_EDITOR
        ReadPlatformConfigBool("open_qdcrash", ref PlatformMsgHandler.is_open_qdcrash);
        DLog.Log("PlatformMsgHandler Init, is_open_qdcrash: {0}", is_open_qdcrash);
        if(is_open_qdcrash)
        {
            DLog.Log("open_qdcrash");
            PlatformSDK.GetInstance().CallPlatformFunc("OpenCrashReport", "", "");
        }
#endif

    }

    #region SDK
    void LoginResult(string message)
    {
        PlatformSDK.GetInstance().nativeLoginCallback(message);
    }
    #endregion

    #region 上传头像回调
    void ImagePicker_OnPickFinish(string file_name)
    {
        DLog.Log(">>>>><<<<< ImagePicker_OnPickFinish -> {0}", file_name);
        //magePicker.GetInstance().OnPickFinish(file_name);
    }

    #endregion

    #region Java日志消息回调
    void AndroidJavaLog(string data)
    {
        DLog.Log("AndroidJavaLog : {0}", data);
    }
    #endregion

    #region ios日志消息回调
    void IosOcLog(string data)
    {
        DLog.Log("IosOcLog : {0}", data);
    }
    #endregion


    #region 语音回调
    void SoundRecorderHelper_OnRecordFinish(string result)
    {
        //SoundRecorder.GetInstance().nativeOnRecordFinish(result);
    }

    void SoundRecorderHelper_VolumeChanged(string volume)
    {
        //SoundRecorder.GetInstance().nativeOnVolumeChanged(volume);
    }
    #endregion
    void OnEnable()
    {
        this.isPause = false;
        this.isFocus = false;

    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPause = pauseStatus;
        DLog.Log("OnApplicationPause {0} {1}", isPause, isFocus);
        if (isPause)  // 强制暂停时，事件
        {
            Singleton<LuaScriptMgr>.GetInstance().CallLuaFunction("OnBackstageFlag", true);
            PlatformSDK.GetInstance().CallPauseEvent();
        }
        else
        {
            Singleton<LuaScriptMgr>.GetInstance().CallLuaFunction("OnBackstageFlag", false);
            PlatformSDK.GetInstance().CallReBackEvent();
        }
    }

    void OnApplicationFocus(bool focusStatus)
    {
        isFocus = focusStatus;
#if UNITY_IOS || UNITY_ANDROID
        Debug.Log("OnApplicationFocus  " + isPause + "  " + isFocus);
#endif
    }

    public void QuitGame(string str)
    {
        DLog.Log("QuitGame begin");

#if UNITY_ANDROID && ENABLE_PROFILER
        var performModule = GameObject.Find("GameMain").GetComponent<GamePerformTestModule>();
        if (performModule)
        {
            performModule.OnGameExit();
        }
        else
#endif
            Application.Quit();
    }

    void OnApplicationQuit()
    {
        //DLog.Log("OnApplicationQuit begin");
#if UNITY_IOS || UNITY_ANDROID
        //Debug.Log("OnApplicationFocus  "+isPause+"  "+isFocus);
        //Singleton<LuaScriptMgr>.GetInstance().CallLuaFunction("Stop"); 注：xclientProxy中的OnApplicationQuit已经调用一次，这里不需要再调用
#endif
        //DLog.QuitGame();
    }

#if UNITY_ANDROID
    #region Android生命周期回调事件
    public void OnStart()
    {
        DLog.Log("PlatformMsgHandler>>>>><<<<< OnStart -> ");
    }

    public void OnPause()
    {
        DLog.Log("PlatformMsgHandler>>>>><<<<< OnPause -> ");
        // Singleton<LuaScriptMgr>.GetInstance().CallLuaFunction("OnBackstageFlag");
    }

    public void OnStop()
    {
        DLog.Log("PlatformMsgHandler>>>>><<<<< OnStop -> ");
    }

    public void OnRestart()
    {
        DLog.Log("PlatformMsgHandler>>>>><<<<< OnRestart -> ");
    }

    public void OnResume()
    {
        DLog.Log("PlatformMsgHandler>>>>><<<<< OnResume -> ");
    }
    #endregion
#endif

    public static void ClearVersionFile()
    {
        //#if UNITY_EDITOR
        //SQLTools.Instance.RetDBTable();
        //#else
        //        SQLTools.Instance.CloseDB();
        //        if (Directory.Exists(Util.GetWritablePath("")))
        //        {
        //            DeleteDir(Util.GetWritablePath(""));
        //        }
        //#endif
        Application.Quit();
    }



    private void DeleteDir(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach (DirectoryInfo cdir in dir.GetDirectories("*"))
        {
            DirectoryInfo di = new DirectoryInfo(path + cdir.Name);
            di.Delete(true);
        }
        foreach (FileInfo f in dir.GetFiles("*"))
        {
            File.Delete(path + f.Name);
        }
    }
    private void BackUpDumpFile(ref CrashReport report)
    {
        if (report == null | report.text == null) return;
        string destinationDir = Util.GetWritablePath("dump");
        if (!Directory.Exists(destinationDir))
        {
            Directory.CreateDirectory(destinationDir);
        }
        string strTime = "" + report.time;
        strTime = strTime.Replace("/", "_").Replace(" ", "_").Replace(":", "_");
        string desPath = Path.Combine(destinationDir, "dump" + strTime + ".plcrash");


        FileStream fs = new FileStream(desPath, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(report.text);
        sw.Close();
        fs.Close();
    }


    public void StartPostUIProfilerFile(string url)
    {
#if UNITY_EDITOR
        string m_log_path = string.Format("{0}/..", Application.dataPath);
#else
        string m_log_path = Util.GetWritablePath("");
#endif

        string profiler_path = Path.Combine(m_log_path, "ProfilerReporter.json");

        StartPostProfilerFile(profiler_path, url);
    }

    public void StartPostNetProfilerFile()
    {
#if UNITY_EDITOR
        string m_log_path = string.Format("{0}/..", Application.dataPath);
#else
        string m_log_path = Util.GetWritablePath("");
#endif

        string profiler_path = Path.Combine(m_log_path, "RealTimeReporter.json");

        if (!File.Exists(profiler_path))
        {
            DLog.Log("StartPostNetProfilerFile: No RealTimeReporter.json found.");
            return;
        }

        string zipfile_path = Path.Combine(m_log_path, "RealTimeReporter.zip");
        string zip_src = Path.Combine(m_log_path, "RealTimeReporter");
        string zip_file = Path.Combine(zip_src, "RealTimeReporter.json");

        if (!Directory.Exists(zip_src))
        {
            Directory.CreateDirectory(zip_src);
        }

        System.IO.File.Copy(profiler_path, zip_file, true);

        FastZip fastzip = new FastZip();
        fastzip.CreateZip(zipfile_path, zip_src, true, null);

        StartPostProfilerFile(zipfile_path, "http://t4.develop.com/control/profiler_reporter_net.php");
    }

    public void StartPostProfilerFile(string path, string url)
    {
        // 安卓和苹果机器上的数据才有效
        // #if ENABLE_PROFILER && (UNITY_ANDROID || UNITY_IOS)
//        string request_url = url;

//        WindowMarker.AnalysisData();

//#if UNITY_ANDROID
//        string client_uid = XDevice.GetInstance().getDeviceId();
//#else
//        string client_uid = XDevice.GetInstance().getMacAddress();
//#endif
//        WWWForm wwwfrom = new WWWForm();
//        wwwfrom.AddField("app_version", ResService.Instance.GetGlobalVersion());
//        wwwfrom.AddField("client_uid", client_uid);
//        wwwfrom.AddField("device_name", XDevice.GetInstance().getDeviceModel());
//        wwwfrom.AddField("device_system", XDevice.GetInstance().GetPlatForm());
//        wwwfrom.AddField("game", "t19");

//        string profiler_path = path;
//        if (File.Exists(profiler_path))
//        {
//            FileInfo fi = new FileInfo(profiler_path);
//            Int32 iLen = (Int32)fi.Length;
//            FileStream fs = new FileStream(profiler_path, FileMode.Open);
//            byte[] buffer = new byte[iLen];
//            fs.Read(buffer, 0, (int)iLen);
//            fs.Close();
//            wwwfrom.AddBinaryData("profilerData", buffer);
//        }
//        else
//        {
//            DLog.Log("can't find profiler file!");
//            return;
//        }

//        WWW www = new WWW(request_url, wwwfrom);
//        xClientProxy.StartCoroutineFunc(PostData(www));
//        DLog.Log("upload profiler file ok!");
        //#endif
    }

    public string GetNetType()
    {
        string netType = "default";
        // bool type_2g = XDevice.GetInstance().is2GConnected();
        // bool type_3g = XDevice.GetInstance().is3GConnected();
        // bool type_4g = XDevice.GetInstance().is4GConnected();
        // bool type_wifi = XDevice.GetInstance().isWifiConnected();
        // if (type_2g)
        // {
        //     netType = "2g";
        // }
        // else if (type_3g)
        // {
        //     netType = "3g";
        // }
        // else if (type_4g)
        // {
        //     netType = "4g";
        // }
        // else if (type_wifi)
        // {
        //     netType = "wifi";
        // }
        return netType;
    }

    public void StartPostLogcat(string platUserName)
    {
#if UNITY_ANDROID
        //if (is_upload_logcat)
        //{
        //    DLog.Log("Upload logcat error, logcat has already uploaded, is_upload_logcat = {0}", is_upload_logcat);
        //    return;
        //}
        DLog.Log("upload logcat ===> StartPostLogcat");

        //string request_url = string.Empty;
        //if (!ClientInfo.upLoad_last_clientLog_flag)
        //{
        //    DLog.LogWarning("upload logcat error. ClientInfo.upLoad_last_clientLog_flag = {0}", ClientInfo.upLoad_last_clientLog_flag);
        //    return;
        //}
        //else
        //{
        //    request_url = ClientInfo.upLoad_clientLog_url;
        //}
        //if (string.IsNullOrEmpty(request_url))
        //{
        //    DLog.LogWarning("StartPostLogcat error, upLoad_logcat_url is null or empty");
        //    return;
        //}

        //string netType = GetNetType();

        //string client_uid = "default";

        //client_uid = XDevice.GetInstance().getDeviceId();

        //WWWForm wwwfrom = new WWWForm();
        //wwwfrom.AddField("appName", "龙吟大陆");
        //wwwfrom.AddField("appVersion", ResService.Instance.GetGlobalVersion());
        //wwwfrom.AddField("engineVersion", Version.ENGINE_VERSION);
        //wwwfrom.AddField("unityVersion", Application.unityVersion);
        //wwwfrom.AddField("client_uid", client_uid);
        //wwwfrom.AddField("deviceInfo", XDevice.GetInstance().getDeviceModel());
        //wwwfrom.AddField("ditch_name", ClientInfo.DitchName);
        //wwwfrom.AddField("fileType", "logcat");
        //wwwfrom.AddField("game", "x3dgame");
        //wwwfrom.AddField("netType", netType);
        //wwwfrom.AddField("problemMsg", "log upload");
        //wwwfrom.AddField("platUserName", platUserName);

        //string m_log_path = string.Empty;
        //m_log_path = Path.Combine(Application.persistentDataPath, "Documents");
        //string log_path = Path.Combine(m_log_path, "last_logcat.log");
        //DLog.Log("last logcat Report-last_log.log path[{0}]", log_path);
        //if (File.Exists(log_path))
        //{
        //    FileInfo fi = new FileInfo(log_path);
        //    Int32 iLen = (Int32)fi.Length;
        //    FileStream fs = new FileStream(log_path, FileMode.Open);
        //    byte[] buffer = new byte[iLen];
        //    fs.Read(buffer, 0, (int)iLen);
        //    fs.Close();
        //    wwwfrom.AddBinaryData("clientLog", buffer);
        //}
        //else
        //{
        //    DLog.LogWarning("upload logcat error. file not exist, log_path = {0}", log_path);
        //}
        //WWW www = new WWW(request_url, wwwfrom);
        //StartCoroutine(PostData(www));
        //is_upload_logcat = true;

        //DLog.Log("Upload logcat finished.");
#endif
    }

    public void StartPostUpload(string platUserName, bool reconnect = false)
    {
        DLog.Log("[Key Path] PostUpload Start Upload");
//        if (is_upload_last_log && !reconnect) return;

//        string request_url = string.Empty;

//        if (ClientInfo.DitchName == "78")
//        {
//            //内网日志上报
//            request_url = "http://log.engine.q-dazzle.com/report_t4game.php";
//        }
//        else if (!ClientInfo.upLoad_last_clientLog_flag)
//        {
//            DLog.Log("upload log ===> False Open");
//            return;
//        }
//        else if (ClientInfo.upLoad_last_clientLog_flag)
//        {
//            request_url = ClientInfo.upLoad_clientLog_url;
//        }
//        if (string.IsNullOrEmpty(request_url))
//        {
//            DLog.LogWarning("StartPostUpload error, request_url is null or empty");
//            return;
//        }

//        string netType = GetNetType();

//        string client_uid = "default";
//#if UNITY_ANDROID
//        client_uid = XDevice.GetInstance().getDeviceId();
//#else
//        client_uid = XDevice.GetInstance().getMacAddress();
//#endif

//        void PostLog(string logPath)
//        {
//            if (!File.Exists(logPath))
//                return;
//            WWWForm wwwfrom = new WWWForm();
//            wwwfrom.AddField("appName", "龙吟大陆");
//            wwwfrom.AddField("appVersion", ResService.Instance.GetGlobalVersion());
//            wwwfrom.AddField("engineVersion", Version.ENGINE_VERSION);
//            wwwfrom.AddField("unityVersion", Application.unityVersion);
//            wwwfrom.AddField("client_uid", client_uid);
//            wwwfrom.AddField("deviceInfo", XDevice.GetInstance().getDeviceModel());
//            wwwfrom.AddField("ditch_name", ClientInfo.DitchName);
//            wwwfrom.AddField("fileType", "log");
//            wwwfrom.AddField("game", "x3dgame");
//            wwwfrom.AddField("netType", netType);
//            wwwfrom.AddField("problemMsg", "log upload");
//            wwwfrom.AddField("platUserName", platUserName);
//            DLog.Log(" Upload Last GameLog " + logPath);
//            FileInfo fi = new FileInfo(logPath);

//            byte[] fileName = System.Text.Encoding.Default.GetBytes(logPath + "\n");

//            Int32 iLen = Mathf.Min(maxUploadSize, (Int32)fi.Length);
//            FileStream fs = new FileStream(logPath, FileMode.Open);

//            byte[] buffer = new byte[iLen + fileName.Length];
//            Array.Copy(fileName, buffer, fileName.Length);
//            fs.Read(buffer, fileName.Length, (int)iLen);
//            fs.Close();
//            wwwfrom.AddBinaryData("clientLog", buffer);

//#if UNITY_IOS
//            var reports = CrashReport.lastReport;
//            if (reports != null && reports.text != null && !reports.text.Equals(""))
//            {
//                byte[] dumpBuffer = System.Text.Encoding.Default.GetBytes(reports.text);
//                wwwfrom.AddBinaryData("dumpFile", dumpBuffer);
//                BackUpDumpFile(ref reports);
//                DLog.Log("upload log ===> CrashReport.lastReport");
//            }
//            CrashReport.RemoveAll();
//#endif

//            WWW www = new WWW(request_url, wwwfrom);
//            StartCoroutine(PostData(www));
//        }



//        string m_log_path = string.Empty;
//#if UNITY_EDITOR || UNITY_STANDALONE_WIN
//        m_log_path = Path.Combine(Util.m_data_path, "..");
//#else
//        m_log_path = Application.persistentDataPath;
//#endif
//        if (!reconnect) // 上传上次游戏日志
//        {
//            List<string> logfiles = new List<string>();
//            logfiles.AddRange(Directory.GetFiles(m_log_path, "*last_log*"));
//            logfiles.Sort((x, y) => { return x.CompareTo(y); });

//            foreach (var l in logfiles)
//                PostLog(l);
//        }
//        else // 上传当前游戏日志
//        {
//            List<string> logfiles = new List<string>();
//            string logName = DLog.m_log_name.Replace(".log", "");
//            string lastLogPath = Path.Combine(m_log_path, DLog.m_log_name);
//            string tempLogFileName = lastLogPath.Replace(".log", "_0.log");
//            if (File.Exists(lastLogPath))
//            {
//                File.Copy(lastLogPath, tempLogFileName);
//            }
//            logfiles.AddRange(Directory.GetFiles(m_log_path, "*" + logName + "_*"));
//            logfiles.Sort((x, y) => { return x.CompareTo(y); });

//            foreach (var l in logfiles)
//                PostLog(l);

//            if (File.Exists(tempLogFileName))
//                File.Delete(tempLogFileName);
//        }

//        is_upload_last_log = true;

//        DLog.Log("upload log ===> StartPostUpload");
    }

    IEnumerator PostData(WWW www)
    {
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            DLog.Log("[key path] PostData Error " + www.url + " Error:" + www.error);
        }
        else
        {
            DLog.Log("[key path] PostData " + www.url + " Success");
        }
    }

    //点击app游戏，发送php请求到后台记录
    public static void WebLog(string ac)
    {
        DLog.Log("[key path] PlatformMsgHandler.WebLog begin");

#if UNITY_ANDROID || UNITY_IOS
        if (!CommonConst.IsIosShenhe || "init_loading".Equals(ac))
        {
            HttpManager request = new HttpManager();

            request.SetUrl(ClientInfo.StaticUrl);
            request.SetParams("ditch_name", ClientInfo.DitchName);
            request.SetParams("client_uid", XDevice.Instance.getDeviceId());
            request.SetParams("static_deviceid", XDevice.Instance.getStaticDeviceid());
            request.SetParams("client_type", XDevice.Instance.getDeviceModel());
            request.SetParams("ac", ac);
            request.SetConnectTimeOut(10);
            request.SetRetryCount(3);
            request.AsyncHttpRequest();
        }
#else
        DLog.Log("[key path] Click app");
#endif
    }


    //android 和 ios http回调
    public static void SetHttpCallBack(LuaFunction callBack)
    {
        PlatformMsgHandler.call_back = callBack;
    }
    public void HttpGetResponse(string response)
    {
        DLog.Log("HttpGetResponse callback response = {0}", response);
        if (response == null || response == "" || response == "error")
        {
            response = "";
            if (PlatformMsgHandler.call_back != null)
            {
                PlatformMsgHandler.call_back.Call(-1, response, response.Length, true);
            }
        }
        else
        {
            if (PlatformMsgHandler.call_back != null)
            {
                PlatformMsgHandler.call_back.Call(1, response, response.Length, true);
            }
        }
    }

    void CallScriptFunc(string message)
    {
        DLog.Log("AndroidBaseLib CallBack message:" + message);
        PlatformSDK.GetInstance().DYJBHS(message);
    }

    void DYJBHS(string message)
    {
        DLog.Log("IOSBaseLib CallBack message:" + message);
        PlatformSDK.GetInstance().DYJBHS(message);
    }

    public static void ReadPlatformConfigBool(string key, ref bool num)
    {
        try
        {
            num = (Convert.ToInt32(Singleton<LuaScriptMgr>.Instance.GetLuaTable("PlatformTable.common")[key]) != 0);
        }
        catch (Exception e)
        {
            DLog.Log("Read Config Error: {0}", e);
        }
    }
}

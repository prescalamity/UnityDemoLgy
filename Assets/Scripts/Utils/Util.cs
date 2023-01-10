//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Security.Cryptography;
//using System.Text;
//using LuaInterface;
using System.Collections.Generic;
using UnityEngine;
//using System.Runtime.InteropServices;
//using System.Reflection;
//using UnityEngine.Video;
//using WeChatWASM;

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

///// <summary>
///// Util路径规则：
///// Editor的可读写目录为Assets同级的PersistentData， 只读目录为StreamingAssets
///// StandAlone(包括windows, mac, linux) 可读写目录为xxx_Data目录下的PersistentData， 只读目录为xxx_Data目录下的StreamingAssets目录
///// Android的可读写目录为unity原生的Application.persistentData， 只读目录为Application.streamingAssets
///// ios的可读写目录为Application.persistentData上一层的Library(目的是为了不让更新下来的东西icloud备份), 只读目录为Application.streamingAssets
///// WebGL只有可读目录，根目录是"网页根目录/streamingAssets"
///// </summary>

public class Util
{
    //    private static string _data_path;
    //    public static string m_data_path
    //    {
    //        set
    //        {
    //            _data_path = value;
    //        }
    //        get { return _data_path; }
    //    }

    //    private static bool _debugUILog = false;
    //    public static bool debugUILog
    //    {
    //        set
    //        {
    //            _debugUILog = value;
    //            QLog.debugUILog = _debugUILog;
    //        }
    //        get { return _debugUILog; }
    //    }

    /// <summary>
    /// 安装包文件所在路径
    /// </summary>
    public static string m_data_path = Application.dataPath;

    /// <summary>
    /// 系统持久化功能所在地址路径，如：window是在系统盘，android是在应用的沙盒环境中
    /// </summary>
    public static string m_persistent_data_path = Application.persistentDataPath;

    //"http://192.168.1.106/UnityDemoLgy/StreamingAssets";
    //"http://192.168.11.46/UnityDemoLgy/StreamingAssets";
    //"http://192.168.31.168//UnityDemoLgy/StreamingAssets";
    public static string m_streaming_assets_path = "http://192.168.11.46/UnityDemoLgy/StreamingAssets";

    public static string m_android_loadfromfile_path = string.Empty;

    public static string m_temporary_cache_path = Application.temporaryCachePath;


    private static bool m_gotAssetsPath = false;

    public static string m_lua_script_path = string.Empty;
    public static string sound_path = "sound";
    public static string lua_key_path = "";


    public static Dictionary<string, string> JsonStringToDict(string jsonStr)
    {
        jsonStr = jsonStr.Replace("\"", "");
        jsonStr = jsonStr.Replace("\\", "");
        string[] resStr = jsonStr.Split(new char[] { ',', '{', '}', '[', ']' }, System.StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> resDic = new Dictionary<string, string>();
        string[] temp;
        foreach (var v in resStr)
        {
            temp = v.Split(":");
            resDic.Add(temp[0], temp[1]);
        }
        return resDic;
    }

    public static string AddLocalFilePrex(string fileDestPath)
    {
        if (PlatformAdapter.mPlatform == PlatformType.AndroidRuntime)
        {
            fileDestPath = "file:///" + fileDestPath;
        }
        else
        {
            fileDestPath = "file://" + fileDestPath;
        }

        return fileDestPath;
    }

    //    [DoNotToLua]
    //    public static void Initpath()
    //    {
    //        //防止在非main thread调用Application路径报错;
    //        m_data_path = Application.dataPath;
    //        m_persistent_data_path = Application.persistentDataPath;
    //        m_streaming_assets_path = Application.streamingAssetsPath;
    //        m_android_loadfromfile_path = Application.dataPath + "!assets";
    //        m_temporary_cache_path = Application.temporaryCachePath;

    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    //            m_streaming_assets_path = "http://t14webgl.game.com/t14/Resource/StreamingAssets";
    //#else
    //            m_streaming_assets_path = GetWebResRootUrl();
    //            QLog.Log("当前域名下的资源根路径: {0}", m_streaming_assets_path);
    //#endif

    //#if UNITY_EDITOR
    //            //m_streaming_assets_path = "http://mobile-t14webtest-t14.q-dazzle.com/StreamingAssets";
    //            //m_streaming_assets_path = "http://192.168.11.90/t14/Resource/StreamingAssets";
    //            m_streaming_assets_path = "http://127.0.0.1/t14/Resource/StreamingAssets";
    //#endif
    //        }

    //        LuaScriptMgr.m_data_path = m_data_path;
    //        LuaScriptMgr.m_persistent_data_path = m_persistent_data_path;
    //        LuaScriptMgr.m_streaming_assets_path = m_streaming_assets_path;
    //        LuaScriptMgr.m_temporary_cache_path = m_temporary_cache_path;
    //    }

    //    public static string GetWebResRootUrl()
    //    {
    //        if (Application.streamingAssetsPath == "" || Application.streamingAssetsPath == string.Empty)
    //        {
    //            QLog.LogError("Application.streamingAssetsPath 为空");
    //        }

    //        if (!m_gotAssetsPath)
    //        {
    //            if (m_streaming_assets_path != null)
    //            {
    //                m_streaming_assets_path = m_streaming_assets_path.Replace("Release/StreamingAssets", "Resource/StreamingAssets");
    //            }
    //            else
    //            {
    //                m_streaming_assets_path = Application.streamingAssetsPath.Replace("Release/StreamingAssets", "Resource/StreamingAssets");
    //            }
    //            m_gotAssetsPath = true;
    //        }

    //        if (m_streaming_assets_path.Contains("webgl_web"))
    //        {
    //            m_streaming_assets_path = m_streaming_assets_path.Replace("webgl_web/StreamingAssets", "");
    //        }
    //        else if (m_streaming_assets_path.Contains("webgl_wx"))
    //        {
    //            m_streaming_assets_path = m_streaming_assets_path.Replace("webgl_wx/StreamingAssets", "");
    //        }

    //        return m_streaming_assets_path;
    //    }

    //#if UNITY_IPHONE || UNITY_XBOX360
    //    private const string QX3DLIB_DLL = "__Internal";
    //#else
    //    private const string QX3DLIB_DLL = "qx3dlib";
    //#endif

    //#if !UNITY_IPHONE
    //    [DllImport(QX3DLIB_DLL, EntryPoint = "GetEnctyptSeed", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //    public static extern UInt32 getEnctyptSeed();
    //#else
    //    public static UInt32 getEnctyptSeed()
    //    {
    //        return 0x001FF001;
    //    }
    //#endif

    //    private static StringBuilder sbmd5file = new StringBuilder();
    //    /// <summary>
    //    /// 计算文件的MD5值
    //    /// </summary>
    //    public static string Md5file(string file)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime)
    //        {
    //            QLog.Log("webgl环境兼容提示：Md5file");
    //        }

    //        return string.Empty;
    //    }

    //    public static string MD5Buffer(ref byte[] buffer)
    //    {
    //        try
    //        {
    //            MD5 md5 = new MD5CryptoServiceProvider();
    //            byte[] retVal = md5.ComputeHash(buffer);

    //            sbmd5file.Length = 0;
    //            for (int i = 0; i < retVal.Length; i++)
    //            {
    //                sbmd5file.Append(retVal[i].ToString("x2"));
    //            }
    //            return sbmd5file.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("MD5Buffer() fail, error:" + ex.Message);
    //        }
    //    }

    //    //会改变stream的position
    //    public static string MD5Stream(Stream stream)
    //    {
    //        try
    //        {
    //            MD5 md5 = new MD5CryptoServiceProvider();
    //            byte[] retVal = md5.ComputeHash(stream);

    //            sbmd5file.Length = 0;
    //            for (int i = 0; i < retVal.Length; i++)
    //            {
    //                sbmd5file.Append(retVal[i].ToString("x2"));
    //            }
    //            return sbmd5file.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("MD5Stream() fail, error:" + ex.Message);
    //        }
    //    }

    //    [DoNotToLua]
    //    public static void SetNoBackupFlag()
    //    {
    //#if UNITY_IPHONE
    //		UnityInterfaceAdapter.SetIOSNobackupFlag( m_streaming_assets_path );

    //        UnityInterfaceAdapter.SetIOSNobackupFlag(m_persistent_data_path + "/../Library");

    //        UnityInterfaceAdapter.SetIOSNobackupFlag( m_persistent_data_path );

    //        UnityInterfaceAdapter.SetIOSNobackupFlag(m_temporary_cache_path);

    //        UnityInterfaceAdapter.SetIOSNobackupFlag(m_data_path);
    //#endif
    //    }

    //    [DoNotToLua]
    //    public static void AddSearchPath()
    //    {
    //#if !UNITY_STANDALONE  && !UNITY_EDITOR
    //        string stream_asset_path = string.Empty;
    //        stream_asset_path = Util.GetWritablePath("");
    //		QLog.Log ("AddSearchPath : {0}", stream_asset_path);
    //        LuaScriptMgr.GetInstance().AddSearchPath(stream_asset_path);
    //#endif
    //    }

    //    [DoNotToLua]
    //    public static void SetParams()
    //    {
    //#if UNITY_EDITOR
    //        LuaScriptMgr.GetInstance().LoginMode = ClientInfo.LoginMode;

    //        m_lua_script_path = Convert.ToString(LuaScriptMgr.GetInstance().GetLuaTable("ConfigTable")["lua_script_path"]);

    //        if (!Directory.Exists(m_lua_script_path))
    //        {
    //            if (Directory.Exists(Application.dataPath + "/../3dscripts/lua_source"))
    //            {
    //                m_lua_script_path = Application.dataPath + "/../3dscripts/lua_source";
    //            }
    //            else if (Directory.Exists(Application.dataPath + "/../../../../src/mobile/3dscripts/lua_source"))
    //            {
    //                m_lua_script_path = Application.dataPath + "/../../../../src/mobile/3dscripts/lua_source";
    //            }
    //        }

    //        m_lua_script_path = m_lua_script_path.Trim();
    //        m_lua_script_path = m_lua_script_path.Replace('\\', '/');
    //        if (!m_lua_script_path.EndsWith("/"))
    //        {
    //            m_lua_script_path = m_lua_script_path + "/";
    //        }
    //#endif
    //#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
    //        LuaScriptMgr.GetInstance().LoginMode = ClientInfo.LoginMode;
    //#endif
    //    }

    //    [DoNotToLua]
    //    public static string GetLuaScriptPath()
    //    {
    //        if (!string.IsNullOrEmpty(m_lua_script_path))
    //        {
    //            return m_lua_script_path;
    //        }
    //        throw new Exception("load lua script failed, pls check your lua script path in platform.lua");
    //    }

    //    /// <summary>
    //    /// 取得Lua路径
    //    /// </summary>
    //    public static string LuaPath(string name)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            string webRet = string.Empty;
    //            if (name.EndsWith(".lua"))
    //            {
    //                webRet = "lua_source/" + name;
    //            }
    //            else
    //            {
    //                webRet = "lua_source/" + name + ".lua";
    //            }
    //            return webRet;
    //        }

    //        return string.Empty;
    //    }

    //    private static StringBuilder sbWritablePath = new StringBuilder(100);
    public static string GetWritablePath(string url)
    {
        return string.Empty;
    }

    //    private static StringBuilder sbReadOnlyPath = new StringBuilder(100);
    //    public static string GetReadOnlyPath(string url)
    //    {
    //        bool isNewPath = false;
    //        string confuseUrl = HandlePath(url, ref isNewPath);
    //        sbReadOnlyPath.Length = 0;
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            sbReadOnlyPath.Append(GetWebResRootUrl());
    //        }
    //        sbReadOnlyPath.Append(NormalizePath(confuseUrl));
    //        string result = sbReadOnlyPath.ToString();
    //        return result;
    //    }

    //    // unity loadfromfile接口的android路径很蛋疼，需要特殊处理
    //    public static string GetReadOnlyPathForLoadFromFile(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            return GetReadOnlyPath(url);
    //        }

    //        return GetReadOnlyPath(url);
    //    }

    //    public static string GetLocalIp()
    //    {
    //#if UNITY_2017
    //        return Network.player.ipAddress;
    //#elif UNITY_2018_1_OR_NEWER
    //        return "";
    //#endif
    //    }

    //    public static string GetReadablePath(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            return GetReadOnlyPath(url);
    //        }

    //        return GetReadOnlyPath(url);

    //    }

    //    public static string GetReadablePathForLoadFromFile(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            return GetReadOnlyPath(url);
    //        }

    //        return GetReadOnlyPath(url);

    //    }

    //    //添加混淆相关的代码
    //    public static Dictionary<string, string> resConfuseDirMap = null;  //混淆文件映射map
    //    public static bool isConfuse = false;  //是否混淆，默认不混淆，找到记录混淆文件映射的json时才混淆
    //    public static bool isCheckConfuse = false;  //是否已经判断是否存在混淆文件映射的json
    //    private static string HandlePath(string originalPath, ref bool isNewPath)
    //    {
    //        // QLog.Log("HandlePath  in "  + originalPath);
    //        isNewPath = false;

    //        if (WebGL_Confing.IsWebglRuntime)
    //        {
    //            return originalPath;
    //        }

    //        return originalPath;
    //    }

    //    //获取记录混淆文件映射的json文件路径，放在只读路径下
    //    public static string GetReadOnlyConfuseJsonPath(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            return GetReadOnlyPath(url);
    //        }

    //        return GetReadOnlyPath(url);
    //    }


    //    private static StringBuilder sbDownWritable = new StringBuilder(100);
    //    public static string GetDownWritablePath(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            QLog.Log("webgl环境兼容提示：GetDownWritablePath");
    //            return string.Empty;
    //        }

    //        return string.Empty;
    //    }

    //    private static StringBuilder sbDownReadOnly = new StringBuilder(100);
    //    public static string GetDownReadOnlyPath(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            QLog.Log("webgl环境兼容提示：GetDownReadOnlyPath");
    //            return string.Empty;
    //        }

    //        return string.Empty;
    //    }

    //    private static StringBuilder sbDownStreamPath = new StringBuilder(100);
    //    public static string GetDownStreamPath(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            QLog.Log("webgl环境兼容提示：GetDownStreamPath");
    //            return string.Empty;
    //        }
    //        return string.Empty;
    //    }

    //    public static string GetCachePath(string url)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            QLog.Log("webgl环境兼容提示：GetCachePath");
    //            return string.Empty;
    //        }
    //        return string.Empty;
    //    }

    //    public static string GetHTTPDownloadPath(string url, int version, bool useBakUrl = false)
    //    {
    //        if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            QLog.Log("webgl环境兼容提示：GetHTTPDownloadPath");
    //            return string.Empty;
    //        }

    //        return string.Empty;
    //    }

    //    public static string GetOsType()
    //    {
    //        return GetPlatForm();
    //    }

    //    public static string m_Platform = string.Empty;
    //    public static string GetPlatForm()
    //    {
    //        if (!string.IsNullOrEmpty(m_Platform))
    //        {
    //            return m_Platform;
    //        }

    //        if (IsWX()) { return "minigame"; }

    //#if UNITY_ANDROID
    //        return "android";
    //#elif UNITY_IPHONE
    //        return "ios";
    //#elif UNITY_WEBGL
    //        return "webgl";
    //#else
    //        return "windows";
    //#endif
    //    }

    //    public static string GetAssetPath(string resName)
    //    {
    //        CommonConst.StringBuffer.Length = 0;

    //        CommonConst.StringBuffer.AppendFormat("/assetbundle/{0}/{1}", ClientInfo.GetOsType(), resName);
    //#if UNITY_EDITOR
    //        if (DebugMobileResource.mSimulateMobileResMode || WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
    //        {
    //            if (resName.Contains("shader/") || resName.Contains("sound/"))
    //            {
    //                CommonConst.StringBuffer.Length = 0;
    //                CommonConst.StringBuffer.AppendFormat("/assetbundle/windows/{0}", resName);
    //            }
    //        }
    //#endif
    //        return CommonConst.StringBuffer.ToString();
    //    }

    //    public static float GetDeviceScreenSize()
    //    {
    //        return (float)(Math.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height) / (Screen.dpi == 0 ? 100 : Screen.dpi));
    //    }

    //    public static string NormalizePath(string path)
    //    {
    //        if (!StringUtil.CustomStartsWith(path, "/"))
    //        {
    //            path = "/" + path;
    //        }
    //        return path.Replace("//", "/");
    //    }

    //    public static string StripFirstSplash(string path)
    //    {
    //        if (StringUtil.CustomStartsWith(path, "/"))
    //        {
    //            path = path.Substring(1);
    //        }
    //        return path.Replace("//", "/");
    //    }

    //    public static Vector3 GetLastWorldPosition()
    //    {
    //        return UICamera.lastWorldPosition;
    //    }

    //    public static void ClearUrlCache()
    //    {
    //        //if (ResService.UrlCacheDict != null)
    //        //{
    //        //    ResService.UrlCacheDict.Clear();
    //        //}
    //    }

    //    public static string StackTrace()
    //    {
    //        return new StackTrace().ToString();
    //    }

    //    [DoNotToLua]
    //    public static void StartCoroutineFunc(IEnumerator func)
    //    {
    //        xClientProxy.StartCoroutineFunc(func);
    //    }

    //    public static void Iflog(bool flag, string content, params object[] args)
    //    {
    //        if (flag)
    //        {
    //            QLog.Log(content, args);
    //        }
    //    }

    //    // 特殊逻辑，加载更新界面的bundle多延迟几帧，因为这里非常关键，不能重复
    //    public static int DelayUnloadFrameConnt = 5;
    //    public static Texture GetPlatformBundleTexture(string path, string key)
    //    {
    //        path = Util.GetReadOnlyPathForLoadFromFile(path);
    //        AssetBundle bundle = DataEncrypt.LoadBundleFromEncryptFile(path);
    //        Texture texture = UnityInterfaceAdapter.Load(bundle, key, typeof(Texture)) as Texture;
    //        if (texture == null)
    //        {
    //            QLog.LogError("Load Texture From Bundle [" + path + "] get null");
    //        }
    //        DelayToUnload(bundle);
    //        return texture;
    //    }

    //    [NoToLua]
    //    public static void DelayToUnload(AssetBundle bundle)
    //    {
    //        if (Application.isPlaying)
    //            xClientProxy.StartCoroutineFunc(UnloadBundleAsync(bundle));
    //        else
    //            bundle.Unload(false);
    //    }

    //    private static IEnumerator UnloadBundleAsync(AssetBundle unloadBundle)
    //    {
    //        int frame = Time.frameCount;
    //        while (Time.frameCount - frame < CommonConst.BundleDelayUnLoadFrame + DelayUnloadFrameConnt)
    //            yield return null;

    //        if (unloadBundle != null)
    //        {
    //            unloadBundle.Unload(false);
    //        }
    //    }

    //    public static void SetUICameraDebug(bool v)
    //    {
    //        UICamera ca = GameUIManager.instance.camera.GetComponent<UICamera>();
    //        if (ca != null)
    //        {
    //            ca.debug = v;
    //        }
    //    }

    //    public static void SetObjectAndChildrenLayer(GameObject gObj, int layer)
    //    {
    //        if (gObj == null)
    //        {
    //            return;
    //        }
    //        Transform[] allChild = gObj.GetComponentsInChildren<Transform>(true);
    //        for (int i = 0; i < allChild.Length; i++)
    //        {
    //            allChild[i].gameObject.layer = layer;
    //        }
    //    }

    //    public static GameObject GetChild(GameObject go, string name, bool includeSelf = false)
    //    {
    //        if (go == null || string.IsNullOrEmpty(name))
    //        {
    //            return null;
    //        }

    //        Transform[] cs = go.GetComponentsInChildren<Transform>(true);
    //        for (int i = 0, iMax = cs.Length; i < iMax; ++i)
    //        {
    //            Transform c = cs[i];
    //            if (c != null && c.name.Equals(name, StringComparison.Ordinal))
    //            {
    //                return c.gameObject;
    //            }
    //        }

    //        return null;
    //    }

    //    public static Vector2 GetLastTouchPosition()
    //    {
    //        return UICamera.lastEventPosition;
    //    }

    //    public static UILabel GetChildUILabel(GameObject go, string name)
    //    {
    //        if (go == null || string.IsNullOrEmpty(name))
    //        {
    //            return null;
    //        }
    //        GameObject child = Util.GetChild(go, name, false);
    //        if (child != null)
    //        {
    //            return child.GetComponent(typeof(UILabel)) as UILabel;
    //        }
    //        return null;
    //    }

    //    public static UIButton GetChildUIButton(GameObject go, string name)
    //    {
    //        if (go == null || string.IsNullOrEmpty(name))
    //        {
    //            return null;
    //        }
    //        GameObject child = Util.GetChild(go, name, false);
    //        if (child != null)
    //        {
    //            return child.GetComponent(typeof(UIButton)) as UIButton;
    //        }
    //        return null;
    //    }

    //    public static UISprite GetChildUISprite(GameObject go, string name)
    //    {
    //        if (go == null || string.IsNullOrEmpty(name))
    //        {
    //            return null;
    //        }
    //        GameObject child = Util.GetChild(go, name, false);
    //        if (child != null)
    //        {
    //            return child.GetComponent(typeof(UISprite)) as UISprite;
    //        }
    //        return null;
    //    }

    //    //lua中导不出泛型函数，再写一个吧
    //    public static UISprite AddSlicedSpriteComponent(GameObject go, string name)
    //    {
    //        if (go == null || string.IsNullOrEmpty(name))
    //        {
    //            return (UISprite)((object)null);
    //        }
    //        GameObject child = Util.GetChild(go, name, false);
    //        if (!(child != null))
    //        {
    //            return (UISprite)((object)null);
    //        }
    //        UISprite component = child.GetComponent<UISprite>();
    //        if (component == null)
    //        {
    //            return child.AddComponent<UISprite>();
    //        }
    //        return component;
    //    }

    //    private static List<object> resultList = new List<object>();
    //    public static object[] GetControl(GameObject obj, params object[] args)
    //    {
    //        resultList.Clear();
    //        GameObject findObj = null;
    //        string objName = string.Empty;
    //        string objType = string.Empty;
    //        for (int i = 0; i < args.Length; i += 2)
    //        {
    //            objName = args[i].ToString();
    //            objType = args[i + 1].ToString();
    //            findObj = GetChild(obj, objName);
    //            if (findObj == null)
    //            {
    //                resultList.Clear();
    //                QLog.Log("Can't find Obj:" + objName);
    //                break;
    //            }

    //            var script = findObj.GetComponent(objType);
    //            if (script != null)
    //            {
    //                resultList.Add(script);
    //            }
    //            else
    //            {
    //                resultList.Clear();
    //                QLog.Log("Can't find " + objType + " int " + objName);
    //                break;
    //            }
    //        }

    //        return resultList.ToArray();
    //    }

    //    public static void LoadVideo(string video, GameObject parent, LuaFunction cb)
    //    {
    //        xClientProxy.StartCoroutineFunc(ExportVideo(video, parent, cb, null, null));
    //    }

    //    public static void LoadVideo(string video, GameObject parent, LuaFunction cb1, LuaFunction cb2)
    //    {
    //        xClientProxy.StartCoroutineFunc(ExportVideo(video, parent, cb1, cb2, null));
    //    }

    //    public static void LoadVideo(string video, GameObject parent, LuaFunction cb1, LuaFunction cb2, LuaFunction errcb)
    //    {
    //        xClientProxy.StartCoroutineFunc(ExportVideo(video, parent, cb1, cb1, errcb));
    //    }

    //    public static bool IsWX()
    //    {
    //        return Unity3DHelper.IsWX();
    //    }

    //    static IEnumerator ExportVideo(string video, GameObject parent, LuaFunction cb1, LuaFunction cb2, LuaFunction errcb)
    //    {
    //        string assetURL = video;
    //        if (!video.Contains("/"))
    //            assetURL = NormalizePath(string.Format("/assetbundle/{0}/videos/{1}.unity3d", Util.GetOsType(), video));

    //        if (Unity3DHelper.IsWX())
    //        {
    //            RenderTexture rt1 = RenderTexture.GetTemporary(Screen.width, Screen.height);
    //            UITexture tex1 = UITexture.Create(parent);
    //            tex1.mainTexture = rt1;
    //            tex1.OnDestroyCallback = () => { RenderTexture.ReleaseTemporary(rt1); };
    //            VideoPlayer vp1 = tex1.gameObject.AddComponent<VideoPlayer>();

    //            vp1.targetTexture = rt1;
    //            vp1.renderMode = VideoRenderMode.RenderTexture;
    //            vp1.playOnAwake = false;
    //            vp1.audioOutputMode = VideoAudioOutputMode.AudioSource;
    //            vp1.SetTargetAudioSource(0, tex1.gameObject.AddComponent<AudioSource>());

    //            vp1.prepareCompleted += (v) =>
    //            {
    //            };

    //            vp1.Prepare();

    //            // 使用微信接口播放视频
    //            QLog.Log("WX：使用微信接口播放视频  ");
    //            assetURL = assetURL.Replace("unity3d", "mp4");
    //            assetURL = WebResLoader.GetWebResUrl(assetURL);
    //            QLog.Log(string.Format("WebGL Video Path {0}", assetURL));
    //            WXCreateVideoParam wxVideoParam = new WXCreateVideoParam
    //            {
    //                width = 360,
    //                height = 720,
    //                objectFit = "fill",
    //                autoplay = true,
    //                src = assetURL,
    //                controls = false,
    //                showProgress = false,
    //                showProgressInControlMode = false,
    //                enableProgressGesture = false,
    //                enablePlayGesture = true,
    //            };

    //            WXVideo wxVideo = WX.CreateVideo(wxVideoParam);
    //            wxVideo.RequestFullScreen(0);

    //            wxVideo.OnPlay(() =>
    //            {
    //                if (cb1 != null)
    //                {
    //                    cb1.Call(tex1, vp1);
    //                }
    //            });

    //            wxVideo.OnPause(() =>
    //            {
    //                QLog.Log("WX：暂停播放视频[{0}]！销毁实例。", video);
    //                if (cb2 != null)
    //                {
    //                    cb2.Call();
    //                }
    //                wxVideo.Destroy();
    //            });

    //            wxVideo.OnProgress((myVideoProgress) =>
    //            {
    //                if (myVideoProgress.buffered == 100)
    //                {
    //                    QLog.Log("WX：视频缓冲完毕[" + video + "]");
    //                }
    //            });

    //            wxVideo.OnError(() =>
    //            {
    //                QLog.Log("WX：播放视频[{0}]出错！", video);
    //            });

    //            wxVideo.OnEnded(() =>
    //            {
    //                QLog.Log("WX：播放视频[{0}]结束！销毁实例。", video);
    //                wxVideo.Destroy();
    //            });

    //            yield break;
    //        }

    //        RenderTexture rt = RenderTexture.GetTemporary(Screen.width, Screen.height);
    //        UITexture tex = UITexture.Create(parent);
    //        tex.mainTexture = rt;
    //        tex.OnDestroyCallback = () => { RenderTexture.ReleaseTemporary(rt); };
    //        VideoPlayer vp = tex.gameObject.AddComponent<VideoPlayer>();

    //        vp.targetTexture = rt;
    //        vp.renderMode = VideoRenderMode.RenderTexture;
    //        vp.playOnAwake = false;
    //        vp.audioOutputMode = VideoAudioOutputMode.AudioSource;
    //        vp.SetTargetAudioSource(0, tex.gameObject.AddComponent<AudioSource>());

    //        if (WebGL_Confing.IsWebglRuntime)
    //        {
    //            assetURL = assetURL.Replace("unity3d", "mp4");
    //            assetURL = WebResLoader.GetWebResUrl(assetURL);
    //            if (!assetURL.StartsWith("http"))
    //            {
    //                assetURL = string.Format("http://{0}", assetURL);
    //            }
    //            QLog.Log(string.Format("WebGL Video Path {0}", assetURL));
    //        }

    //        vp.url = assetURL;

    //        vp.errorReceived += (v, s) =>
    //        {
    //            QLog.Log("播放视频[{0}]出错:{1}", video, s);
    //        };

    //        vp.prepareCompleted += (v) =>
    //        {
    //            QLog.Log("视频准备完毕[" + video + "]");
    //            if (cb1 != null)
    //            {
    //                cb1.Call(tex, v);
    //            }
    //        };
    //        vp.Prepare();
    //    }

    //    // 打印当前调用堆栈信息，外网调试时用
    //    public static string GetStackTraceModelName()
    //    {
    //        //当前堆栈信息
    //        System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
    //        System.Diagnostics.StackFrame[] sfs = st.GetFrames();
    //        //过虑的方法名称,以下方法将不会出现在返回的方法调用列表中
    //        string _filterdName = "ResponseWrite,ResponseWriteError,";
    //        string _fullName = string.Empty, _methodName = string.Empty;
    //        for (int i = 1; i < sfs.Length; ++i)
    //        {
    //            //非用户代码,系统方法及后面的都是系统调用，不获取用户代码调用结束
    //            if (System.Diagnostics.StackFrame.OFFSET_UNKNOWN == sfs[i].GetILOffset()) break;
    //            _methodName = sfs[i].GetMethod().Name;//方法名称
    //                                                  //sfs[i].GetFileLineNumber();//没有PDB文件的情况下将始终返回0
    //            if (_filterdName.Contains(_methodName)) continue;
    //            _fullName = _methodName + "()->" + _fullName;
    //        }
    //        st = null;
    //        sfs = null;
    //        _filterdName = _methodName = null;
    //        return _fullName.TrimEnd('-', '>');
    //    }

    //    //public static float GetStringWidth(string str, int size, bool isBold, bool isItalic)
    //    //{
    //    //    return 0;
    //    //        if (String.IsNullOrEmpty(str))
    //    //            return 0;
    //    //        CharacterInfo characterInfo;
    //    //        FontStyle s = FontStyle.Normal;
    //    //        if (isBold)
    //    //        {
    //    //            s = FontStyle.Bold;
    //    //        }

    //    //        if (isItalic)
    //    //        {
    //    //            s = FontStyle.Italic;
    //    //        }

    //    //        if (isItalic && isBold)
    //    //        {
    //    //            s = FontStyle.BoldAndItalic;
    //    //        }
    //    //        float pixelSizeAdjustment = GameUIManager.instance.uiRoot.GetComponent<UIRoot>().pixelSizeAdjustment;
    //    //        // 实际的显示字体大小肯定会做一次缩放
    //    //        int trueFontSize = Mathf.RoundToInt(size / pixelSizeAdjustment);
    //    //        if (UILabel.defaultFont == null)
    //    //        {
    //    //            return 0;
    //    //        }

    //    //#if ENABLE_PROFILER
    //    //        ProfilerHelper.BeginSample("UILabel.defaultFont.RequestCharactersInTexture");
    //    //#endif
    //    //        UILabel.defaultFont.RequestCharactersInTexture(str, trueFontSize, s);
    //    //#if ENABLE_PROFILER
    //    //        ProfilerHelper.EndSample();
    //    //        ProfilerHelper.BeginSample("UILabel.defaultFont.GetCharacterInfo");
    //    //#endif


    //    //        float w = 0.0f;
    //    //        for (int i = 0, iMax = str.Length; i < iMax; i++)
    //    //        {
    //    //            char c = str[i];
    //    //            UILabel.defaultFont.GetCharacterInfo(c, out characterInfo, trueFontSize, s);
    //    //            w += characterInfo.width * pixelSizeAdjustment;
    //    //        }
    //    //#if ENABLE_PROFILER
    //    //        ProfilerHelper.EndSample();
    //    //#endif
    //    //        return w;
    //    //}

    //    public static float GetMemoryVail()
    //    {
    //        return Unity3DHelper.get_memory_vail();
    //    }

    //    // 兼容外网专门暴露的一个函数
    //    // 以后判断函数是否存在直接在methodList里添加字段
    //    public static void Upgrade() { }

    //    static List<string> methodList = new List<string> {
    //        "test"
    //        , "SetRainArg"
    //        , "SetSnowArg"
    //        , "ScreenDistortionEffect2_p9"
    //        , "ButtonPlayDefaultSound"
    //        , "GetSpritesInAtlas"
    //        , "SetScreenResolution"
    //        , "BlurScreenPercent"
    //        , "SetLight"
    //        , "Scene3dPackPrefabs"
    //        , "ScrollViewUpdate1"
    //        , "ScreenEffectNew"
    //        , "UITextureUpdate"
    //        , "ReadFileByWWWCallback"
    //        , "TerrainCheckType"
    //        , "IsFullPackage"
    //        , "CanCacheSound"
    //        , "WeatherRegisterSoundFunc1"
    //        , "Fix3WLoadShaderBug"
    //        , "OpenWebview"
    //        , "CreatePlaneShadow"
    //        , "SetDecodeTextureThreadCount"
    //        , "FastBloom"
    //        , "AvatarUseWorldPosForFallOff"
    //        , "StartDownLoadPngFile"
    //        , "FadeMotionBlurEffect"
    //        , "ScreenWaveEffect"
    //        , "SetIconLossless"
    //        , "ModelOpenAsyncLoadAnimation"
    //        , "AddPriorResInfo"
    //        , "FixedGetTransparentVersion"
    //        , "UseArtFont"
    //        , "Play3DSoundWithInterval"
    //        , "ShowMapInfo"
    //        , "RemainFilesInOrder"
    //        , "SetSceneComponentVisible"
    //        , "TransitionKit.TransitionWindFX@6" //T6特效切场景
    //        , "UIScrollViewSystem.ForceToStop" //T6 SV复用停止滚动
    //        , "CommonConst.SceneTileResCacheTimeWhenCacheCntReachMax" //T7地块释放
    //        , "CommonConst.SceneTileReleaseNumPerFrame" //T7地块释放
    //        , "CheckSupportStencil"
    //        , "CommonConst.SceneTileResCacheTimeWhenCacheCntReachMax"
    //        , "CommonConst.SceneTileReleaseNumPerFrame"
    //        , "Iflytek.SetVoiceUseOpencoreCodec"
    //        , "GrepSceneWithoutBlur"
    //        , "PreloadModelAnimations"
    //        , "AddMustPreLoadAnims"
    //        , "SetCastRecevieShadow"
    //        , "isSkipStaticBatchCombine"
    //        , "CustomCameraPlaneShadow"
    //        , "PreLoadMainRoleFxTemplate"       //t9 预加载主角特效，可以指定实例化时的隐藏策略
    //        , "CinemaDirectorMgr.InitCamsEffectDelegateAfterLoaded" //t9, 模型摄像机的后处理回调

    //        , "UIScrollViewSystem.cameraOrthographicSize" //t9, SV创建增加设置cameraOrthographicSize
    //        , "CommonConst.AvatarUseAntiAliasing" //t9, 可以控制UI模型是否开启抗锯齿
    //		, "FxManager.GetAllDepenciesByPrefabName" //t9, 切场景下载剧情资源，获取特效依赖
    //        , "OpenWindowASyn"
    //        , "FixUIEffectActiveBug"
    //        , "Avatar3DCameraUse24Depth"        //t9, avatar 3d 相机是否使用24位深度
    //        , "CommonModelAnimationFadeTime" // t11， 通用动画融合时间
    //        , "HandleLowMemoryWarning"      // t12，是否处理低内存警告
    //        , "GetScreenSize"      // t12，添加一个避免gc的获取屏幕尺寸
    //        ,"GetSDCardAvailaleSize" //t12,获取SDCard的可用空间
    //        , "HasCompleteDynamic"   //t12,动态图集相关代码完善的标志
    //        , "EngineVersion"  //t13之后，引擎版本号接口
    //        , "QReflection" //水中倒影
    //        , "HandleLowMemoryWarningInterval" //控制处理低内存警告的频率，低于这个时间间隔内的不作处理
    //        , "ScrollViewOpenBorderTransparent" // Scrollview的边缘半透
    //        , "UICamera.Filter" // UI事件过滤
    //        , "HDRHelperPostExposure"
    //        , "Enable2DMapPathAnalysis"
    //        , "OpenScrollViewTextureAntiAliasing"
    //        , "SpineLoader.LoadManifest"
    //        , "OpenModelOutLine"
    //        , "NetManager.ConnectAsynOld" //旧逻辑的connect接口，原接口的android实现添加支持了ipv6网络，出问题的时候可以切回旧接口
    //        , "Remote Debug"
    //        , "Spine.SpineShader"
    //        , "GetBatteryLevel" // 获取电量接口
    //        , "GetIsBangScreen" //刘海屏兼容问题
    //    };

    //    public static bool IsFunExist(string funName)
    //    {
    //        return methodList.Contains(funName);
    //    }

    //    public static bool IsFunctionExist(string funName)
    //    {
    //        return LuaScriptMgr.GetInstance().IsFuncExists(funName);
    //    }

    //    public static bool IsMemExist(Type t, string m)
    //    {

    //        if (string.IsNullOrEmpty(m)) return false;
    //        MethodInfo mi = t.GetMethod(m);
    //        if (mi != null) return true;
    //        FieldInfo fi = t.GetField(m);
    //        if (fi != null) return true;
    //        PropertyInfo pi = t.GetProperty(m);
    //        if (pi != null) return true;
    //        return false;
    //    }

    //    public static void DoLuaString(string s)
    //    {
    //        LuaScriptMgr.GetInstance().DoString(s);
    //    }

    //    public static void ClearLuaPak()
    //    {
    //        Util.ClearLuaPak();
    //    }

    //    public static bool ObjectIsExisted(object o)
    //    {
    //        return LuaScriptMgr.GetInstance().ObjectIsExist(o);
    //    }

    //    public static void DoGCCollect()
    //    {
    //        xClientProxy.DoGCCollect();
    //    }

    //    public static void SetScreenResolution(int width, int height)
    //    {
    //        Screen.SetResolution(width, height, Screen.fullScreen);
    //        UIScrollViewSystem.ScreenSizeDirty = true;
    //    }

    //    public static int GetLuaObjectCount()
    //    {
    //        int ret = 0;
    //        if (LuaScriptMgr._translator != null)
    //        {
    //            ret = LuaScriptMgr._translator.GetObjCnt();
    //        }
    //        return ret;
    //    }

    //    public static int GetLuaNullObjectCount()
    //    {
    //        int ret = 0;
    //        if (LuaScriptMgr._translator != null)
    //        {
    //            ret = LuaScriptMgr._translator.GetNullObjCnt();
    //        }
    //        return ret;
    //    }

    //    public static void PrintLuaObject()
    //    {
    //        if (LuaScriptMgr._translator != null)
    //        {
    //            LuaScriptMgr._translator.PrintLuaObject();
    //        }
    //    }


    //    public static bool IsFullPackage { get { return ClientInfo.IsFullPackage; } }

    //    public static void SetPlayerLevel(int level)
    //    {
    //        ClientInfo.PlayerLevel = level;
    //    }

    //    public static void PauseEditor(bool flag)
    //    {
    //#if UNITY_EDITOR
    //        UnityEditor.EditorApplication.isPaused = flag;
    //#endif
    //    }

    //    public static void GetTransformPos(Transform trans, out float x, out float y, out float z)
    //    {
    //        Vector3 pos = trans.position;
    //        x = pos.x;
    //        y = pos.y;
    //        z = pos.z;
    //    }

    //    public static void GetTransformLocalPos(Transform trans, out float x, out float y, out float z)
    //    {
    //        Vector3 pos = trans.localPosition;
    //        x = pos.x;
    //        y = pos.y;
    //        z = pos.z;
    //    }

    //    public static void SetTransformPos(Transform trans, float x, float y, float z)
    //    {
    //        Vector3 pos = Vector3.zero;
    //        pos.x = x;
    //        pos.y = y;
    //        pos.z = z;

    //        trans.position = pos;
    //    }

    //    public static void SetTransformLocalPos(Transform trans, float x, float y, float z)
    //    {
    //        Vector3 pos = Vector3.zero;
    //        pos.x = x;
    //        pos.y = y;
    //        pos.z = z;

    //        trans.localPosition = pos;
    //    }

    //    public static void GetTransformRotation(Transform trans, out float x, out float y, out float z, out float w)
    //    {
    //        Quaternion qua = trans.rotation;
    //        x = qua.x;
    //        y = qua.y;
    //        z = qua.z;
    //        w = qua.w;
    //    }

    //    static Quaternion sq = Quaternion.identity;
    //    public static void SetTransformRotation(Transform trans, float x, float y, float z, float w)
    //    {
    //        sq.x = x;
    //        sq.y = y;
    //        sq.z = z;
    //        sq.w = w;

    //        trans.rotation = sq;
    //    }

    //    public static void GetTransformEulerAngles(Transform trans, out float x, out float y, out float z)
    //    {
    //        Vector3 eulerAngle = trans.rotation.eulerAngles;
    //        x = eulerAngle.x;
    //        y = eulerAngle.y;
    //        z = eulerAngle.z;
    //    }

    //    public static void SetTransformLocalRotation(Transform trans, float x, float y, float z, float w)
    //    {
    //        sq.x = x;
    //        sq.y = y;
    //        sq.z = z;
    //        sq.w = w;

    //        trans.localRotation = sq;
    //    }

    //    public static void GetTransformForward(Transform trans, out float x, out float y, out float z)
    //    {
    //        Vector3 pos = trans.forward;
    //        x = pos.x;
    //        y = pos.y;
    //        z = pos.z;
    //    }

    //    public static void SetTransformLocalScale(Transform trans, float x, float y, float z)
    //    {
    //        Vector3 scale = Vector3.zero;
    //        scale.x = x;
    //        scale.y = y;
    //        scale.z = z;

    //        trans.localScale = scale;
    //    }

    //    public static void GetTransformLocalScale(Transform trans, out float x, out float y, out float z)
    //    {
    //        Vector3 scale = trans.localScale;
    //        x = scale.x;
    //        y = scale.y;
    //        z = scale.z;
    //    }

    //    static Vector3 physicVectorStart = Vector3.zero;
    //    static Vector3 physicVectorDir = Vector3.zero;
    //    public static void PhysicRaycast(float x1, float y1, float z1, float x2, float y2, float z2, float distance, int layer, out int hit, out float px, out float py, out float pz)
    //    {
    //        physicVectorStart.x = x1;
    //        physicVectorStart.y = y1;
    //        physicVectorStart.z = z1;

    //        physicVectorDir.x = x2;
    //        physicVectorDir.y = y2;
    //        physicVectorDir.z = z2;

    //        RaycastHit castHit;
    //        bool h = Physics.Raycast(physicVectorStart, physicVectorDir, out castHit, distance, layer);

    //        hit = h ? 1 : 0;
    //        px = h ? castHit.point.x : 0;
    //        py = h ? castHit.point.y : 0;
    //        pz = h ? castHit.point.z : 0;
    //    }

    //    public static void SetGameScreenSize(int width, int height)
    //    {
    //#if UNITY_EDITOR
    //        PropertyInfo widthPro = null;
    //        PropertyInfo heightPro = null;
    //        object sizePro = null;
    //        System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
    //        System.Reflection.MethodInfo GetMainGameView = T.GetMethod("GetMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
    //        System.Object Res = GetMainGameView.Invoke(null, null);


    //        var gameView = (UnityEditor.EditorWindow)Res;
    //        var prop = gameView.GetType().GetProperty("currentGameViewSize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    //        sizePro = prop.GetValue(gameView, new object[0] { });
    //        var gvSizeType = sizePro.GetType();



    //        widthPro = gvSizeType.GetProperty("width", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    //        heightPro = gvSizeType.GetProperty("height", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

    //        gvSizeType.GetProperty("height", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).SetValue(sizePro, 1024, new object[0] { });
    //        gvSizeType.GetProperty("width", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).SetValue(sizePro, 1024, new object[0] { });

    //        widthPro.SetValue(sizePro, width, new object[0] { });
    //        heightPro.SetValue(sizePro, height, new object[0] { });
    //#endif
    //    }

    //    public static void GetScreenSize(out float w, out float h)
    //    {
    //        w = NGUITools.screenSize.x;
    //        h = NGUITools.screenSize.y;
    //    }

    //    public static long GetSDCardAvailaleSize()
    //    {
    //        return Unity3DHelper.getSDCardAvailaleSize();
    //    }

    //    //对于不需要切场景的项目，可以在某些时段调用回收资源
    //    public static void DoUnloadUnusedAssets()
    //    {
    //        TerrainHelper.GetInstance().UnLoadResourceInPoolInternal(false);
    //        xClientProxy.DoUnloadUnusedAssets(false);
    //    }

    //    // 获取android电量接口
    //    public static float GetBatteryLevel()
    //    {
    //        return 100;
    //    }

    //    public static void PauseEditor()
    //    {
    //#if UNITY_EDITOR
    //        UnityEngine.Debug.Break();
    //#endif
    //    }

    //    public static void InitEncryptKey()
    //    {
    //        string packageName = XDevice.GetInstance().GetPackageName();
    //        uint key = 0;
    //        System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
    //        for (int i = 0; i < packageName.Length; ++i)
    //        {

    //            key += (uint)asciiEncoding.GetBytes(packageName)[i];
    //        }

    //        TextEncrypt.Key = key + (uint)TextEncrypt.offset;

    //    }

}

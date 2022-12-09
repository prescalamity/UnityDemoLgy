using UnityEngine;
using System;
using System.Collections;
using LuaInterface;
using System.IO;
//using LitJson;

using System.Collections.Generic;

using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;
// using UnityEngine.UI;
using ZenFulcrum.EmbeddedBrowser;

//语音和讯飞翻译其实是两个功能，将其拆分为两个功能来看会更容易些

public class IflytekVoiceHelper //: Singleton<IflytekVoiceHelper>
{
    //--------------相关标识变量，包括结果码，开始和结束时间，锁住功能位---------------//
    /* 结果码说明：
        0     结果成功（录音成功/翻译成功）
        1     指定的麦克风不存在
        2   麦克风不支持指定的频率
        100   没有录音权限
        101   上一次录音没有结束，录音功能被锁住
        102   上一次语音翻译没有结束，翻译功能被锁住
        103   翻译服务Socket报错，尝试再进行一次录音翻译功能或者直接翻译功能
        104   没有找到麦克风设备进行录音 
        105   录音失败，如果出现频率高，需要找引擎排查问题   
        106   AudioClip数据出错，需要找引擎协助排查    
        107   没有录取到声音
        108   不支持的采样样本位数
        109   连接Socket异常
    */

    public delegate void RecordFinshCallback(ResultCode code, string filePath, int timeSecond);
    public delegate void RecordTranslateFinshCallback(ResultCode code, string words, int timeSecond);

    public enum ResultCode
    {
        SUCCESS = 0,
        MICROPHONE_NOT_EXIST = 1,
        FREQUENCY_NOT_SUPPORT = 2,
        PERMISSION_DENY = 100,
        RECORD_LOCK = 101,
        TRANSLATE_LOCK = 102,
        TRANSLATE_SOCKET_ERROR = 103,
        MICROPHONE_NOT_FOUND = 104,
        RECORD_ERROR= 105,
        AUDIOCLIP_ERROR = 106,
        RECORD_WITHOUT_VOICE = 107,
        SAMPLEBIT_NOT_SUPPORT = 108,
        SOCKET_ERROR = 109
    }    
    private static ResultCode recordCode = ResultCode.SUCCESS; 
    private static ResultCode translateCode = ResultCode.SUCCESS;
    private static float mRecordStartSecond = 0;
    private static float mRecordStopSecond = 0;
    private static float mTranslateStartSecond = 0;
    private static float mTranslateStopSecond = 0;
    private static bool recordLock = false;
    private static bool _enterRecord = false; //是否真的进入了录音，没有权限时，时不会马上进入录音的
    private static bool isRecordCallback = false;
    private static bool isTranslateCallback = false;
    //---------------------------end--------------------------//
    //-----------------------------讯飞参数和讯飞翻译过程需要的东西-----------------//
    private string Result = ""; //翻译后的文字
    private static string APPID = "";
    private static string APISecret = "";
    private static string APIKey = "";
    private ClientWebSocket IflyWebSocket = null;

    //160ms和1280是有关联的，采样频率8000，单声道，采样样本位数16的情况下，160ms产生的数据为8000 * 1 * 16 / 8 * 160 /1000 = 2560字节
    //所以，采样频率8000、单声道、采样位数16位、16ms、2560字节，是刚刚好的一个配置，虽然讯飞建议一次发送1280字节数据，但是经过测试，2560字节能够得到最快的翻译速度，其他数据配置或会导致翻译过快或过慢
    //sendLength之所以要减半，是因为我们从Unity的接口中拿到的数据是float类型，而非byte类型，一个长度数据为2字节
    private int waitTime = 160;//发送语音数据到讯飞接口的频率，虽然讯飞建议每隔40ms发送一次音频，不过经过实际验证，每次发送2560字节数据可以得到更快的翻译结果
    private int sendLength = 1280; //每次发送给讯飞的语音最大样本数，这里的1280是根据采样频率、声道、采样位数、发送间隔时间计算出来
    private int vadEos = 10000; //最大10000，讯飞语音检测到多长的空语音或问题语音，就断掉识别，这里设置10s

    //----------------------------end------------------------//
    //---------------------录音需要的相关功能和参数--------------------------------//
    private AudioClip RecordedClip = null;
    //下面这些参数都是跟录音音质相关的，写定一个值，不暴露到lua，但可以由引擎人员根据需要调整
    //调用unity的接口录音，他必须先确定好录制多少s  如果是60，但是你录音只录了5s，剩下的55s都为null，但是最后保存的录音文件，还是有60s。
    //这里是指录音的长度，单位为秒，这里设定为60秒，是因为讯飞语音只支持翻译最长60秒的语音
    private static int RecordLastTime = 8;
    private int m_frequency = 8000; //录音采样频率，只能取值16000和8000（常用的wave采样频率为11025,22050，44100，但因为讯飞只支持8000和16000，所以这里只能取8000和16000，这里为了减少语音的文件大小，选择8000
    private static int sampleBits = 16;//采样样本位数，只能取值16，采样样本位数可以取值4、8、16、32，但因为讯飞语音只能支持16位，故而这里只能取值16。存储在audioclip中的采样值是一个float，是4字节32位，最高保真这个值应该为32，取值越低保真率越低
    private static string m_path = ""; //录音保存目录名
    private static string recordDevice = null;
    private static string[] recordDevices = null;
    private static bool isTranslateConnect = false; 
    //---------------------------------end------------------------//    
    //--------------------------录音和翻译过程的回调----------------------------//
    //录音结束回调
    /*  第一个参数，录音结果异常码，为0时表示录音成功，其他异常码详细看异常码说明
        第二个参数，录音文件路径，如果第一个参数为不为0，该参数传入空字符串
        第三个参数，录音耗时，单位为秒，如果第一个参数为不为0，该参数传入0
    */
    //[DoNotToLua] public static LuaFunction m_record_finish_handler = null;
    [DoNotToLua] public static RecordFinshCallback m_record_finish_handler = null;
    
    //讯飞翻译结束回调
    /*  第一个参数，录音转文字结果异常码，为0表示转换成功，其他异常码详细看异常码说明
        第二个参数，录音翻译后的文字内容，字符串，如果第一个参数不为0，该参数传入空字符串
        第三个参数，翻译耗时，单位为秒，如果第一个参数不为0，该参数传入0
    */
    //[DoNotToLua] public static LuaFunction m_translate_finish_handler = null;
    [DoNotToLua] public static RecordTranslateFinshCallback m_translate_finish_handler = null;
    
    [DoNotToLua]
    public void OnRecordFinish(string fileName)
    {
        DLog.Log("OnRecordFinish");
        if (null != m_record_finish_handler)
        { 
            int recordTime = 0;
            if (ResultCode.SUCCESS == recordCode || ResultCode.MICROPHONE_NOT_EXIST == recordCode || ResultCode.FREQUENCY_NOT_SUPPORT == recordCode) 
            {
                recordTime= ((int)(mRecordStopSecond - mRecordStartSecond) * 1000 + 1000) / 1000; //向上取整秒
            } 
            else
            {
                fileName = "";
            }
            //m_record_finish_handler.Call(recordCode, fileName, recordTime);
            m_record_finish_handler(recordCode, fileName, recordTime);
        }
        isRecordCallback = true;
        if (isRecordCallback && isTranslateCallback)
        {
            Reset();
        }
    }
    
    [DoNotToLua]
    public void OnTranslateFinish()
    {
        DLog.Log("OnTranslateFinish");
        if (null != m_translate_finish_handler)
        {
            int translateTime = 0;
            if (ResultCode.SUCCESS == translateCode || ResultCode.MICROPHONE_NOT_EXIST == translateCode || ResultCode.FREQUENCY_NOT_SUPPORT == translateCode)
            {
                translateTime = ((int)(mTranslateStopSecond - mTranslateStartSecond) * 1000 + 1000) / 1000; //向上取整秒
            }
            else
            {
                Result = "";
            }
            //m_translate_finish_handler.Call(translateCode, Result, translateTime);
            m_translate_finish_handler(translateCode, Result, translateTime);
        }
        isTranslateCallback = true;
        if (isRecordCallback && isTranslateCallback)
        {
            Reset();
        }
    }
    //---------------------------end--------------------------------//
    //-----------------------------基础接口---------------------------//
    //public static IflytekVoiceHelper GetInstance()
    //{
    //    return Singleton<IflytekVoiceHelper>.GetInstance();
    //}
    //初始化 
    public void Init(string appID, string apiSecret, string apiKey, string recordPath)
    {
        APPID = appID;
        APIKey = apiKey;
        APISecret = apiSecret;
        VoiceSetPath(recordPath);
    }

    //设置录音保存路径
    public void VoiceSetPath(string path)
    {
        //录音默认保存在$(传入path)/record/local/record.wav       所有平台都会保存为wav文件格式，/record/local是固定的不能改，不然会导致lua那边也要改
        m_path = path + "/record/local";
    }

    //获取机器的麦克风列表
    public string[] GetDevices()
    {
        recordDevices = Microphone.devices;
        return recordDevices;
    }

    public int Frequency {
        get { 
            return m_frequency;
        }
        set {
            if (Microphone.IsRecording(recordDevice))
            {
                DLog.Log(LogType.error, "不能在录音的时候改变采样率");
                return;
            }
            if (value != m_frequency)
            {
                if (value != 8000 && value != 16000)
                {
                    DLog.Log(LogType.error,"录音功能只支持8000或者16000的采样率");
                    return;
                }
                m_frequency = value;
                waitTime = 2560 * 8 * 1000 / 16 / m_frequency;
            }
        }
    }

    public int RecordTime {
        get { 
            return RecordLastTime;
        }
        set {
            if (Microphone.IsRecording(recordDevice))
            {
                DLog.Log(LogType.error,"不能在录音的时候改变录音长度");
                return;
            }
            if (value != RecordLastTime)
            {
                if (value <= 0)
                {
                    DLog.Log(LogType.error,"录音长度不能设置为0或者小于0");
                    return;
                }
                if (value > 8)
                {
                    DLog.Log(LogType.warn, "录音长度超过8秒，可能会导致录音协议数据过大");
                }
                RecordLastTime = value;
            }
        }
    }

    public bool IsRecording 
    {
        get { return Microphone.IsRecording(recordDevice) || Microphone.IsRecording(null); }
    }

    public bool EnterRecord 
    {
        get {return _enterRecord;}
    }
    //------------------------end-------------------------//
    //--------------------------------开始录音---------------------//
    //开始录音，参数：录音结束回调，讯飞翻译结束回调，新增翻译文字回调，录音音量增加回调，使用的麦克风设备名（默认为null，使用默认设备）
    //public void VoiceStart(LuaFunction record_finish_handler, LuaFunction translate_finish_handler)
    
    //{
    //    VoiceStart(record_finish_handler, translate_finish_handler, null);
    //}
    
    //public void VoiceStart(LuaFunction record_finish_handler, LuaFunction translate_finish_handler, string device)
    
    //{
    //    DLog.Log("VoiceStart");
    //    //下面两个判断，为了避免发生前一次录音和翻译没有结束，又调用新的录音和翻译
    //    if (recordLock) //先判断当前有没有录音没有完成的操作，如果有，直接回调失败
    //    {
    //        LockErrorCall(record_finish_handler, translate_finish_handler, ResultCode.RECORD_LOCK);
    //        Reset();
    //        return;
    //    }
    //    if (IflyWebSocket != null && IflyWebSocket.State == WebSocketState.Open)//讯飞语音Socket连接着，而且是Open的，说明讯飞语音的翻译没有关闭，直接回调失败
    //    {
    //        LockErrorCall(record_finish_handler, translate_finish_handler, ResultCode.TRANSLATE_LOCK);
    //        Reset();
    //        return;
    //    }
    //    Reset();
    //    recordLock = true;
    //    m_record_finish_handler = record_finish_handler;
    //    m_translate_finish_handler = translate_finish_handler; //这几个回到必须先赋值再获取权限，否则在权限拒绝后会没有回调调用
    //    recordDevice = device;
    //    RequestPermission(); //获取权限，真正录音是在获取到权限后才做的事
    //}

    public void VoiceStart(RecordFinshCallback record_finish_handler, RecordTranslateFinshCallback translate_finish_handler, string device)

    {
        DLog.Log("VoiceStart");
        //下面两个判断，为了避免发生前一次录音和翻译没有结束，又调用新的录音和翻译
        if (recordLock) //先判断当前有没有录音没有完成的操作，如果有，直接回调失败
        {
            LockErrorCall(record_finish_handler, translate_finish_handler, ResultCode.RECORD_LOCK);
            Reset();
            return;
        }
        if (IflyWebSocket != null && IflyWebSocket.State == WebSocketState.Open)//讯飞语音Socket连接着，而且是Open的，说明讯飞语音的翻译没有关闭，直接回调失败
        {
            LockErrorCall(record_finish_handler, translate_finish_handler, ResultCode.TRANSLATE_LOCK);
            Reset();
            return;
        }
        Reset();
        recordLock = true;
        m_record_finish_handler = record_finish_handler;
        m_translate_finish_handler = translate_finish_handler; //这几个回到必须先赋值再获取权限，否则在权限拒绝后会没有回调调用
        recordDevice = device;
        RequestPermission(); //获取权限，真正录音是在获取到权限后才做的事
    }

    private void LockErrorCall(LuaFunction record_finish_handler, LuaFunction translate_finish_handler, ResultCode code)//避免将上一次的record_finish_handler覆盖，因此不能将record_finish_handler赋值给m_record_finish_handler，下同
    {
        DLog.Log("LockErrorCall");
        if (null != record_finish_handler)
        {
            record_finish_handler.Call(code, "", 0);
        }
        if (null != translate_finish_handler)
        {
            translate_finish_handler.Call(code, "", 0);
        }
    }

    private void LockErrorCall(RecordFinshCallback record_finish_handler, RecordTranslateFinshCallback translate_finish_handler, ResultCode code)//避免将上一次的record_finish_handler覆盖，因此不能将record_finish_handler赋值给m_record_finish_handler，下同
    {
        DLog.Log("LockErrorCall");
        if (null != record_finish_handler)
        {
            record_finish_handler(code, "", 0);
        }
        if (null != translate_finish_handler)
        {
            translate_finish_handler(code, "", 0);
        }
    }

    //初始化所有的参数
    public void Reset()
    {
        DLog.Log("Reset");
        mRecordStartSecond = 0;
        mRecordStopSecond = 0;
        mTranslateStartSecond = 0;
        mTranslateStopSecond = 0;
        recordCode = ResultCode.SUCCESS;
        translateCode = ResultCode.SUCCESS;
        Result = "";
        recordDevice = null;
        recordDevices = null;
        _enterRecord = false;
        isTranslateConnect = false;
        recordLock = false;
        isRecordCallback = false;
        isTranslateCallback = false;
        if (null != IflyWebSocket)
        {
            IflyWebSocket.Dispose();
            IflyWebSocket = null;
        }
        if (null != RecordedClip)
        {
            AudioClip.DestroyImmediate(RecordedClip, true);
            RecordedClip = null;
        }
    }   

    private void RequestPermission()
    {
        DLog.Log("RequestPermission");   
#if UNITY_ANDROID
        //获取权限后的回调，拒绝、允许、拒绝且不再提示的三个回调
        //TODO 安卓的权限接口，改为基础库的统一接口
        PermissionCallbacks permissionCallback = new PermissionCallbacks();
        permissionCallback.PermissionDenied += DenyPermission;
        permissionCallback.PermissionDeniedAndDontAskAgain += DenyPermission;
        permissionCallback.PermissionGranted += GrantePermission;
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone, permissionCallback);
        }
        else
        {
            GrantePermission(Permission.Microphone);
        }
#elif UNITY_IOS || UNITY_IPHONE 
        GrantePermission("");   
#else
        //windows平台下不需要获取权限
        GrantePermission("");
#endif

    }
    private void DenyPermission(string permission)
    {
        DLog.Log("申请麦克风权限被拒绝了");
        recordCode = ResultCode.PERMISSION_DENY;
        translateCode = ResultCode.PERMISSION_DENY;
        OnRecordFinish("");
        OnTranslateFinish();
        recordLock = false;
    }

    private void GrantePermission(string permission)
    {
        DLog.Log("GrantePermission");  
        _enterRecord = true;

        try {
            recordDevices = Microphone.devices; //先获取录音设备列表
            string[] devices = Microphone.devices;
            if (devices == null || devices.Length == 0)
            {
                DLog.Log(LogType.error,"没有找到麦克风");
                recordCode = ResultCode.MICROPHONE_NOT_FOUND;
                translateCode = ResultCode.MICROPHONE_NOT_FOUND;
                OnRecordFinish("");
                OnTranslateFinish();
                recordLock = false;
                return;
            }
            else
            {
                if (devices.Length == 1)
                {
                    recordDevice = devices[0];
                }
                else if (!string.IsNullOrEmpty(recordDevice))
                {
                    List<string> devicesList = new List<string>();
                    devicesList.AddRange(devices);
                    if (!devicesList.Contains(recordDevice))
                    {
                        DLog.Log(LogType.warn,"指定的麦克风 {0} 不存在", recordCode);
                        recordCode = ResultCode.MICROPHONE_NOT_EXIST;
                        translateCode = ResultCode.SUCCESS == translateCode ? ResultCode.MICROPHONE_NOT_EXIST : translateCode;
                        recordDevice = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            DLog.Log(LogType.error,"获取设备列表失败，失败信息{0}", ex.Message); 
        }
        int minFreq = 0;
        int maxFreq = 0;
        try
        {
            Microphone.GetDeviceCaps(recordDevice, out minFreq, out maxFreq);
        }
        catch (Exception ex)
        {
            DLog.Log(LogType.error,"获取设备支持频率失败，失败信息{0}", ex.Message); 
        }
        mRecordStartSecond = mTranslateStartSecond = Time.realtimeSinceStartup;// System.Environment.TickCount;
        ConnectIflyWebSocket(); //先连接上讯飞
        if (ResultCode.SUCCESS == translateCode)
        {
            
            try {
                RecordedClip = Microphone.Start(recordDevice, false, RecordLastTime, m_frequency);       
            }
            catch (Exception ex)
            {
                DLog.Log(LogType.error,"开始录音失败，失败信息{0}", ex.Message);
            }
        } else {
            DLog.Log(LogType.error,"这里连接讯飞后台就出错了");
        }
    }

    //-----------------------------------------------end-----------------------------------//
    //------------------------------------讯飞翻译功能---------------------------------//
    private async void ConnectIflyWebSocket()
    {
        DLog.Log("ConnectIflyWebSocket");  
        StringBuilder stringBuilder = new StringBuilder();
        CancellationToken ct;
        try 
        {
            if (IflyWebSocket == null || WebSocketState.Closed == IflyWebSocket.State)
            {
                IflyWebSocket = new ClientWebSocket();//https://docs.microsoft.com/zh-cn/dotnet/api/system.net.websockets.clientwebsocket?view=net-6.0 支持5, 6, Core 3.0, Core 3.1
            }
            isTranslateConnect = true;
            ct = new CancellationToken();
            Uri url = new Uri(GetUrl("wss://iat-api.xfyun.cn/v2/iat"));
            await IflyWebSocket.ConnectAsync(url, ct);
        
            Main.Instance.MainStartCoroutine(SendData(IflyWebSocket));
        }
        catch (Exception ex)
        {
            DLog.Log(LogType.error,"连接讯飞服务报错，错误信息为{0}", ex.Message);
            translateCode = ResultCode.SOCKET_ERROR;
            isTranslateConnect = false;
            return;
        }
        while (IflyWebSocket.State == WebSocketState.Open)
        {
            var result = new byte[4096];
            try {
                await IflyWebSocket.ReceiveAsync(new ArraySegment<byte>(result), ct);//接受数据
            } catch (Exception ex)
            {
                DLog.Log(LogType.error,"获取语音翻译数据报错 {0}", ex.Message);
                translateCode = ResultCode.SOCKET_ERROR;
                isTranslateConnect = false;
                return;
            }
            List<byte> list = new List<byte>(result); while (list[list.Count - 1] == 0x00) list.RemoveAt(list.Count - 1);//去除空字节
            string str = Encoding.UTF8.GetString(list.ToArray());
            string tempStr = GetResult(str);
            DLog.Log("接收到文字{0}", tempStr);
            stringBuilder.Append(tempStr);
            JSONNode js = JSONNode.Parse(str);
            JSONNode data = js["data"];
            try {
                if (data["status"] == (int)VoiceType.LAST) 
                {
                    IflyWebSocket.Abort(); 
                }
            }catch (Exception ex)
            {
                DLog.Log(LogType.error,"断开讯飞连接出错 {0}", ex.Message);
                translateCode = ResultCode.SOCKET_ERROR;
                isTranslateConnect = false;
                return;
            }
        }
        
        Result = stringBuilder.ToString();
        mTranslateStopSecond = Time.realtimeSinceStartup;// System.Environment.TickCount;        
    }
    
    private string GetUrl(string uriStr)
    {
        Uri uri = new Uri(uriStr);
        string date = DateTime.Now.ToString("r");
        string signature_origin = string.Format("host: " + uri.Host + "\ndate: " + date + "\nGET " + uri.AbsolutePath + " HTTP/1.1");
        HMACSHA256 mac = new HMACSHA256(Encoding.UTF8.GetBytes(APISecret));
        string signature = Convert.ToBase64String(mac.ComputeHash(Encoding.UTF8.GetBytes(signature_origin)));
        string authorization_origin = string.Format("api_key=\"{0}\",algorithm=\"hmac-sha256\",headers=\"host date request-line\",signature=\"{1}\"", APIKey, signature);
        string authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes(authorization_origin));
        string url = string.Format("{0}?authorization={1}&date={2}&host={3}", uri, authorization, date, uri.Host);
        return url;
    }
    
    private enum VoiceType
    {
        //请记住，这里的枚举数值不能改动，否则会影响到Send接口发送给Socket的status值
        FIRST = 0, //第一帧音频
        NORMAL = 1, //中间的音频
        LAST = 2 //最后一帧音频
    }
    private IEnumerator SendData(ClientWebSocket socket)
    {
        if (isTranslateConnect)
        {
            float waitSec = waitTime * 0.001f;
            yield return new WaitWhile(() => mRecordStartSecond <= 0 || Time.realtimeSinceStartup - mRecordStartSecond < waitSec); //等待开始录音并且录满了发送频率时间后再往下走
            int position = 0;
            VoiceType status = VoiceType.FIRST;  //第一帧
            int MaxRecordLength = RecordedClip.samples; //最长的录音长度，录音未结束时，直接赋值为RecordedClip.samples

            //进入循环发送的条件：socket开启的，新的截取位置比RecordClip.samples要小，新的截取位置比实际录音的样本数要小
            //这里的samples跟Microphone.Start传入的RecordLastTime有关，RecordedClip已经在创建时确定好了它的长度了
            while (position < RecordedClip.samples && position < MaxRecordLength && socket.State == WebSocketState.Open)  
            {
                int length = position + sendLength > MaxRecordLength ? MaxRecordLength - position : sendLength;// sendLength;// position > MaxRecordLength ? MaxRecordLength - lastPosition :  sendLength;
                byte[] data = getAudioParam(position, length, RecordedClip);
                Send(data, status, socket); //这句和下面这句顺序不能颠倒，先发送status为VoiceType.FIRST的再给status重新设置值
                status = VoiceType.NORMAL;
                position += length;
                if (!Microphone.IsRecording(recordDevice) && mRecordStopSecond != 0)
                {
                    int recordSec = ((int)(mRecordStopSecond - mRecordStartSecond) * 1000 + 1000) / 1000;
                    if (recordSec > RecordLastTime)// RecordedClip.length)
                    {
                        recordSec = RecordLastTime;
                    }
                    MaxRecordLength =  recordSec * RecordedClip.frequency * RecordedClip.channels;
                }
                yield return new WaitForSecondsRealtime(waitSec); //等要求的间隔时间才送一次数据，避免高频率发送数据
            }
            //关闭连接
            Send(null, VoiceType.LAST, socket);
        } else 
        {
            yield return null;
        }
    }
    
    private static byte[] getAudioParam(int star, int length, AudioClip recordedClip)
    {
        float[] soundata = new float[length];
        recordedClip.GetData(soundata, star);
        int rescaleFactor = 32767;
        byte[] outData = new byte[soundata.Length * 2];
        for (int i = 0; i < soundata.Length; i++)
        {
            short temshort = (short)(soundata[i] * rescaleFactor);
            byte[] temdata = BitConverter.GetBytes(temshort);
            outData[i * 2] = temdata[0];
            outData[i * 2 + 1] = temdata[1];
        }
        return outData;
    }

    private void Send(byte[] audio, VoiceType type, ClientWebSocket socket)
    {
        if (socket.State != WebSocketState.Open)
        {
            translateCode = ResultCode.TRANSLATE_SOCKET_ERROR;
            //这里应该理解为非正常断开了，要报翻译的错误，但是并不表示录音错误了
            return;
        }
        string formatStr = string.Format("audio/L16;rate={0}", m_frequency);
        JSONNode jn = new JSONNode
        {
            {
                "common",new JSONNode{{ "app_id",APPID}}},
            {
                "business",new JSONNode{
                    { "language","zh_cn"},//识别语音
                    {  "domain","iat"},
                    {  "accent","mandarin"},
                    { "vad_eos", vadEos}
                }
            },
            {
                "data",new JSONNode{
                    { "status",0 },
                    { "encoding","raw" },
                    { "format",formatStr}
                 }
            }
        };
        JSONNode data = jn["data"];
        if (type == VoiceType.FIRST || type == VoiceType.NORMAL)
        {
            data["audio"] = Convert.ToBase64String(audio);
        }
        data["status"] = (int)type; //第一帧发送音频值为0，往后发送音频值为1，最后一帧为2
        try {
            socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(jn)), WebSocketMessageType.Binary, true, new CancellationToken()); //发送数据
        }catch (Exception ex)
        {
            DLog.Log(LogType.error,"讯飞Socket发送数据报错 {0}", ex.Message);
            translateCode = ResultCode.SOCKET_ERROR;
            isTranslateConnect = false;
            return;
        }
    }
        
    private string GetResult(string str)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (!string.IsNullOrEmpty(str))
        {
            JSONNode recivejson = JSONNode.Parse(str);
            JSONNode ws = recivejson["data"]["result"]["ws"];
            foreach (JSONNode item in ws)
            {
                JSONNode cw = item["cw"];
                foreach (JSONNode item1 in cw)
                {
                    stringBuilder.Append((string)item1["w"]);
                }
            }
        }
        return stringBuilder.ToString();
    }
    //-----------------------------------end-------------------------------//
    //---------------------------------------结束录音-------------------------//
    //结束录音接口
    public void VoiceStop()
    {
        DLog.Log("VoiceStop");
        Main.Instance.MainStartCoroutine(Stop());
    }

    private IEnumerator Stop()
    {
        DLog.Log("Stop");  
        Microphone.End(recordDevice); 
        _enterRecord = false;
        mRecordStopSecond = Time.realtimeSinceStartup;// System.Environment.TickCount;  
        
        if (RecordedClip != null)
        {
            //TODO 这里向上去整秒，当实际录音描述不是整秒时，会在录音后面追加一定长度的空白音，后面考虑不要取整秒处理，改为实际多少就是多少
            int recordTime = ((int)(mRecordStopSecond - mRecordStartSecond) * 1000 + 1000) / 1000; //向上取整秒来截取录音的音频时间
            //如果要截取的长度比录音最大长度还长，只能取录音的最大长度，当实际录取时间刚好等于sameples时，此时向上取整秒就会多出1秒，就会发生这个条件
            if (recordTime > RecordLastTime)// RecordedClip.samples)
            {
                recordTime = RecordLastTime;// RecordedClip.samples;
            }
            
            //string path = Path.GetDirectoryName(m_path);
            if (!Directory.Exists(m_path))
            {
                Directory.CreateDirectory(m_path);
            }
            string recordPath = m_path;
            recordPath = recordPath + "/record.wav";

            //保存数据时，RecordedClip默认有5分钟的长度，如果没有录完5分钟，后面部分是需要截掉的
            //mRecordStopSecond和mRecordStartSecond记录了开始录音和结束录音的时间，可以算出实际录音的时间长度，由此来截取录音
            byte[] data = null;
            ResultCode ret = GetDataInAudioClip(ref RecordedClip, ref data, recordTime); 
            
            if (ret == ResultCode.SUCCESS && data != null)
            {
                recordCode = recordCode != ResultCode.SUCCESS ? recordCode :ret;
                using (FileStream fs = CreateEmpty(recordPath)) //这里是直接把录音文件保存为pcm文件了，而不是保存为wav文件，
                {
                    fs.Write(data, 0, data.Length);
                    //wav可以是用pcm格式存储录音数据的，wav文件头去掉，就是pcm文件了
                    WriteHeader(fs, RecordedClip, recordTime); //wav文件头，注释掉这句代码，得到的文件就是pcm文件
                    fs.Close();
                }
            }
            else
            {
                recordCode = ret;
            }
            yield return new WaitUntil(() => IflyWebSocket.State != WebSocketState.Open);
            isTranslateConnect = false;

            
            if (null != IflyWebSocket)
            {
                IflyWebSocket.Dispose();
                IflyWebSocket = null;
            }

            AudioClip.DestroyImmediate(RecordedClip, true);
            RecordedClip = null;
        }
        else
        {
            DLog.Log(LogType.error,"RecordedClip是空的");
            recordCode = ResultCode.RECORD_ERROR;
            translateCode = ResultCode.RECORD_ERROR;
        }
        
        OnRecordFinish("record.wav");  
        OnTranslateFinish();
        recordLock = false;
    }

    private static ResultCode GetDataInAudioClip(ref AudioClip recordedClip, ref byte[] data, int sec = 0)
    {
        if (recordedClip.samples != recordedClip.length * recordedClip.channels * recordedClip.frequency)
        {
            //如果不满足这个条件，显然recordedClip是有问题的，报错
            DLog.Log(LogType.error,"AudioClip的数据有异常");
            return ResultCode.AUDIOCLIP_ERROR;
        }
        int realSamples = recordedClip.frequency * recordedClip.channels * sec; //真正要取的样本数
        if (realSamples > recordedClip.samples) //要取的样本数超出范围了，也是有问题的，直接报错
        {
            DLog.Log(LogType.error,"需要的样本数比AudioClip的样本数还要大");
            return ResultCode.AUDIOCLIP_ERROR;
        }
        
        float[] soundData = new float[recordedClip.samples];
        recordedClip.GetData(soundData, 0); //取出所有音频数据
        int length = realSamples * sampleBits >> 3;//数据字节长度 = 频率 * 声道数 * 秒数 * 采样位数 / 8
        data = new byte[length];
        for (int i = 0; i < realSamples; ++i)
        {
            
            if (sampleBits == 4)
            {
                DLog.Log(LogType.warn,"暂未处理4位样本采样位数");
                return ResultCode.SAMPLEBIT_NOT_SUPPORT;
            }
            else if (sampleBits == 8) //float -> byte
            {
                DLog.Log(LogType.warn,"暂未处理8位样本采样位数");
                return ResultCode.SAMPLEBIT_NOT_SUPPORT;
            }
            
            else if (sampleBits == 16)//float -> short  //目前只处理了16位的样本采样位数
            {
                int rescaleFactor = 32767; //short表示的最大值为32767
                short tempShort = (short)(soundData[i] * rescaleFactor);
                byte[] tempBytes = BitConverter.GetBytes(tempShort);
                data[i * 2] = tempBytes[0];
                data[i * 2 + 1] = tempBytes[1];
            }
            else if (sampleBits == 32)//float -> float
            {
                DLog.Log(LogType.warn,"暂未处理32位样本采样位数");
                return ResultCode.SAMPLEBIT_NOT_SUPPORT;
            }
            else
            {
                DLog.Log(LogType.error,"不支持的采样样本位数");
                return ResultCode.SAMPLEBIT_NOT_SUPPORT;
            }
        }    
        return ResultCode.SUCCESS;
    }

    private static int waveHeaderBytes = 44; //wave文件头的字节数
    private FileStream CreateEmpty(string filepath)
    {
        FileStream fileStream = new FileStream(filepath, FileMode.Create);
        byte emptyByte = new byte();

        for (int i = 0; i < waveHeaderBytes; i++) //为wav文件头留出空间
        {
            fileStream.WriteByte(emptyByte);
        }
        return fileStream;
    }

    private static void WriteHeader(FileStream stream, AudioClip clip, int realTime)
    {
        /* wav文件格式：
               文件标识块
                   4字节  RIFF字符，表示该文件为RIFF格式文档
                   4字节  文件数据长度，从下一字段开始到文件结尾，36 + 实际数据字节数（除去实际数据，表头一般共44字节，下字段到表头结尾为36字节）
                   4字节  WAVE字符，表示该文件为WAV格式文件
                格式块标识
                   4字节  fmt字符，表示格式标识块开始
                   4字节  格式块长度，这里没有附带信息，取值16
                   2字节  取值1，表示使用PCM格式存储数据
                   2字节  1为单声道，2为双声道
                   4字节  采样频率
                   4字节  数据传输速率，声道数*采样频率*采样样本位数/8
                   2字节  采样帧大小，声道数*采样样本位数/8
                   2字节  采样样本位数（常用4、8、12、16、24、32）
                数据块标识
                   4字节   data字符，表示数据块开始
                   4字节   实际数据字节数大小，实际数据字节数=声道数 * 采样频率 * 采样样本位数 * 语音秒数 / 8
                   然后开始的就是实际数据了
        */
        int hz = clip.frequency; //采样频率
        int channels = clip.channels;  //声道数
        int frameLenght = channels * sampleBits >> 3; //采样帧大小=声道数*采样样本位数/8
        int frameRate = frameLenght * hz; //数据传输速率=采样帧大小 * 采样频率
        int dataLenght = channels * hz * sampleBits * realTime >> 3; //实际数据字节数 = 声道数 * 采样频率 * 采样样本位数 * 语音秒数 / 8
        

        stream.Seek(0, SeekOrigin.Begin);

        Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        stream.Write(riff, 0, 4);

        Byte[] chunkSize = BitConverter.GetBytes(waveHeaderBytes + dataLenght - 8);//文件头的字节数 + 数据字节数 - 8;
        stream.Write(chunkSize, 0, 4);

        Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        stream.Write(wave, 0, 4);

        Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        stream.Write(fmt, 0, 4);

        Byte[] subChunk1 = BitConverter.GetBytes(16);
        stream.Write(subChunk1, 0, 4);

        UInt16 one = 1;
        Byte[] audioFormat = BitConverter.GetBytes(one);
        stream.Write(audioFormat, 0, 2);

        Byte[] numChannels = BitConverter.GetBytes(channels);
        stream.Write(numChannels, 0, 2);

        Byte[] sampleRate = BitConverter.GetBytes(hz);
        stream.Write(sampleRate, 0, 4);

        Byte[] byteRate = BitConverter.GetBytes(frameRate);
        stream.Write(byteRate, 0, 4);

        UInt16 blockAlign = (ushort)(frameLenght);
        stream.Write(BitConverter.GetBytes(blockAlign), 0, 2);

        Byte[] bitsPerSample = BitConverter.GetBytes((ushort)sampleBits);
        stream.Write(bitsPerSample, 0, 2);

        Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
        stream.Write(datastring, 0, 4);

        Byte[] subChunk2 = BitConverter.GetBytes(dataLenght);
        stream.Write(subChunk2, 0, 4);
    }
    //---------------------------------------end----------------------------//
}


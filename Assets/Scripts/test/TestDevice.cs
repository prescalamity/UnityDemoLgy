using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// 检测安卓设备
/// </summary>
public class TestDevice : MonoBehaviour
{

    static List<TestBase> testDeviceBases = new List<TestBase>();

    public void Awake()
    {
        testDeviceBases.Add(new TestPower());
        //testDeviceBases.Add(new TestPermission());
        testDeviceBases.Add(new TestHeadPhoto());
        testDeviceBases.Add(new TestSoundRecord());
    }


    public static void setPanelSort()
    {
        //foreach (var v in testDeviceBases) v.setPanelSort();

    }

    public void MainButtonTestFunction(int stepID, string functionName = "")
    {
        //if(stepID % 3 == 0)
        foreach (var v in testDeviceBases) v.MainButtonTestFunction(stepID, functionName);
    }

    public void Start()
    {
        DLog.Log("TestDevice.Start");
        foreach (var v in testDeviceBases) v.Start();

    }


    private void Update()
    {
        foreach (var v in testDeviceBases) v.Update();

    }


}


class TestBase
{
    public GameObject mThePanelGo = null;

    public virtual void setPanelSort() {
        mThePanelGo?.transform.SetAsLastSibling();
    }

    public virtual void Start() {}

    public virtual void Update() {}

    public virtual void MainButtonTestFunction(int stepID, string functionName = "", string[] thePanelname = null) {

        if(!string.IsNullOrEmpty(functionName) && thePanelname != null && mThePanelGo != null)
        {
            //DLog.Log("TestBase.MainButtonTestFunction.1");
            bool isCurThePanle = false;

            for(int i=0; i< thePanelname.Length; i++)
            {
                if (functionName.ToLower().Equals(thePanelname[i].ToLower())) { isCurThePanle = true; break; }
            }
            //DLog.Log("TestBase.MainButtonTestFunction.2.functionName:"+ functionName + ", open:" + open);
            mThePanelGo.SetActive(isCurThePanle);

            if(isCurThePanle) setPanelSort();
        }


    }

    //public virtual void ElectedValueChange(int value) {}
}


/// <summary>
/// 检测安卓设备电量
/// </summary>
class TestPower : TestBase
{

    TMP_Text battery_capacity_value = null;
    TMP_Text battery_electricity_value = null;
    TMP_Text battery_voltage_value = null;
    TMP_Text battery_retain_value = null;
    TMP_Text battery_retain_time_value = null;
    TMP_Text battery_get_api_time_value = null;

    public override void MainButtonTestFunction(int stepID, string functionName = "", string[] thePanelname = null) {
        base.MainButtonTestFunction( stepID,  functionName, new string[] { "PowerPanel" });

        battery_capacity_value.text = Power.capacity.ToString();
        battery_voltage_value.text = Power.voltage.ToString();
        battery_retain_value.text = Power.batteryRetain.ToString();
    }

    public override void Start()
    {
        DLog.Log("AndroidDevicePower.Start");

        mThePanelGo = Main.Instance.UiRootCanvas.transform.Find("power").gameObject;

        battery_capacity_value = mThePanelGo.transform.Find("battery_capacity_value").GetComponent<TMP_Text>();
        battery_electricity_value = mThePanelGo.transform.Find("battery_electricity_value").GetComponent<TMP_Text>();
        battery_voltage_value = mThePanelGo.transform.Find("battery_voltage_value").GetComponent<TMP_Text>();
        battery_retain_value = mThePanelGo.transform.Find("battery_retain_value").GetComponent<TMP_Text>();
        battery_retain_time_value = mThePanelGo.transform.Find("battery_retain_time_value").GetComponent<TMP_Text>();
        battery_get_api_time_value = mThePanelGo.transform.Find("battery_get_api_time_value").GetComponent<TMP_Text>();


    }

    //private void OnGUI()
    //{
    //    GUILayout.Label(string.Format($"<size=80>电池总容量{Power.capacity}毫安,电压{Power.voltage}伏</size>"));
    //    GUILayout.Label(string.Format($"<size=80>实时电流{e}毫安,实时功率{(int)(e * Power.voltage)},满电量能玩{((Power.capacity / e).ToString("f2"))}小时</size>"));
    //}

    float e = 0f;
    float t = 0f;
    public override void Update()
    {
        if (!mThePanelGo.activeInHierarchy) return;

        if (Time.time - t > 0.1f)
        {
            t = Time.time;
            e = Power.electricity;
            battery_electricity_value.text = e.ToString();
            battery_get_api_time_value.text = Power.deltaTime.ToString();
            battery_retain_time_value.text = (Power.capacity * Power.batteryRetain / 100 / e).ToString("f2");
        }
    }


}


/// <summary>
/// 测试 android 权限，测试 V1平台版本 接口
/// </summary>
class TestPermission : TestBase
{

    public override void MainButtonTestFunction(int stepID, string functionName = "", string[] thePanelName = null)
    {
        //PlatformAdapter.CallPlatformFunc("openCamera", "", "");

#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass androidclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = androidclass.GetStatic<AndroidJavaObject>("currentActivity");

            jo.Call(functionName);
            androidclass.Dispose();
            jo.Dispose();

#elif UNITY_IOS && !UNITY_EDITOR
            //return QdHSSSFromLJB(key, data, lua_callback);
#endif
        


    }


}

/// <summary>
/// 测试头像功能（Android）
/// </summary>
class TestHeadPhoto : TestBase
{

    static Image image;

    Button btnOpenPhotoLib;
    Button btnOpenCamera;

    //GameObject _tempGo;

    public override void Start()
    {
        base.Start();

        DLog.Log("TestHeadPhoto.Start");

        mThePanelGo = Main.Instance.UiRootCanvas.transform.Find("head_photo").gameObject;

        image = mThePanelGo.transform.Find("image").GetComponent<Image>();

        btnOpenPhotoLib = mThePanelGo.transform.Find("open_photo_library").GetComponent<Button>();
        btnOpenPhotoLib.onClick.AddListener(()=> PlatformAdapter.CallPlatformFunc("OpenPhotoLibrary", "", "OpenHeadPhotoCB"));

        btnOpenCamera = mThePanelGo.transform.Find("open_camera").GetComponent<Button>();
        btnOpenCamera.onClick.AddListener(() => PlatformAdapter.CallPlatformFunc("OpenCamera", "", "OpenHeadPhotoCB"));

    }

    public override void MainButtonTestFunction(int stepID, string functionName = "", string[] thePanelName = null) {

        base.MainButtonTestFunction(stepID, functionName, new string[]{ "OpenCameraPanel", "OpenPhotoLibraryPanel" });

        
    }


    public static void OpenHeadPhotoCB(string cbData)
    {

        DLog.LogToUI("TestHeadPhoto.OpenPhotoLibraryCB-->" + cbData);

        Dictionary<string, string> resDic = Util.JsonStringToDict(cbData);
        string fileName = resDic["file_name"];

        string fileSrcPath = Util.m_temporary_cache_path + "/" + fileName;
        string fileDestPath = Util.m_temporary_cache_path + "/xxx_" + fileName;


        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        sb.Append("\"src_jpeg_file_path\":"+"\""+ fileSrcPath+"\",");
        sb.Append("\"dest_jpeg_file_path\":" + "\""+ fileDestPath + "\",");
        sb.Append("\"width\":\"200\",");
        sb.Append("\"height\":\"200\",");
        sb.Append("\"quality\":\"100\"");
        sb.Append("}");

        DLog.LogToUI("TestHeadPhoto.OpenPhotoLibraryCB.sb-->" + sb.ToString());


        string resizeRes = PlatformAdapter.CallPlatformFunc("CropJpegImage", sb.ToString(), "");

        if (resizeRes != null && resizeRes.Equals("true"))
        {
            DLog.LogToUI("TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:ok");


            DownloadResources.AsyncLoadTexture(Util.AddLocalFilePrex(fileDestPath), image);
        }
        else
        {
            DLog.LogToUI("TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:no");
        }

    }



}


/// <summary>
/// 测试录音
/// </summary>
class TestSoundRecord : TestBase
{

    int voiceCount = 10000;

    //string soundAddress = "";

    Button btnRecordSound;
    EventTrigger btnRecordSoundEvent;
    Button btnPlaySound;
    Button btnToWords;
    TMP_Text recordingTip;

    AudioSource audioSource;
    string audioName = "/record.wav";

    private IflytekVoiceHelper m_IflytekVoiceHelper;
    string appId = "90d09164";
    string apiSecret = "YTEwMjU2OTEwMTc3MzUwMjY5YjlmMTkx";
    string apiKey = "3287d1186dbe24add8a383230eb2d0d9";

    public override void Start()
    {
        base.Start();

        mThePanelGo = Main.Instance.UiRootCanvas.transform.Find("sound_record").gameObject;


        btnRecordSound = mThePanelGo.transform.Find("record").GetComponent<Button>();
        //btnRecordSound.onClick.AddListener( () => PlatformAdapter.CallPlatformFunc("", "", "") );

        btnRecordSoundEvent = btnRecordSound.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entryBtnDwon = new EventTrigger.Entry();
        entryBtnDwon.eventID = EventTriggerType.PointerDown;
        entryBtnDwon.callback.AddListener(VoiceStart);
        btnRecordSoundEvent.triggers.Add(entryBtnDwon);

        EventTrigger.Entry entryBtnUp = new EventTrigger.Entry();
        entryBtnUp.eventID = EventTriggerType.PointerUp;
        entryBtnUp.callback.AddListener(VoiceEnd);
        btnRecordSoundEvent.triggers.Add(entryBtnUp);


        btnPlaySound = mThePanelGo.transform.Find("play").GetComponent<Button>();
        btnPlaySound.onClick.AddListener(PlaySound);

        btnToWords = mThePanelGo.transform.Find("to_words").GetComponent<Button>();
        //btnToWords.onClick.AddListener(() => PlatformAdapter.CallPlatformFunc("", "", ""));

        recordingTip = mThePanelGo.transform.Find("recording_tip").GetComponent<TMP_Text>();

        audioSource = Main.Instance.GoRoot.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        //初始化录音功能范例
        m_IflytekVoiceHelper = new IflytekVoiceHelper();
        if (PlatformAdapter.mPlatform == PlatformType.AndroidRuntime)
        {
            m_IflytekVoiceHelper.Init(appId, apiSecret, apiKey, Util.m_persistent_data_path);// 初始化语音功能，调用一次即可
            m_IflytekVoiceHelper.Frequency = 8000;
            m_IflytekVoiceHelper.RecordTime = 8;
        }

    }


    public override void MainButtonTestFunction(int stepID, string functionName = "", string[] thePanelName = null)
    {
        base.MainButtonTestFunction(stepID, functionName, new string[] { "SoundPanel" });

    }


    public void VoiceStart(BaseEventData data)
    {
        DLog.LogToUI("lgy-->TestSoundRecord.VoiceStart, I am down.");

#if UNITY_ANDROID
        if ( Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            recordingTip.gameObject.SetActive(true);
            m_IflytekVoiceHelper.VoiceStart(RecordFinshCallbak, RecordTranslateFinshCallbak, "");
        }
        else
        {
            //请求权限
            RequestPermission();
        }
#elif UNITY_IOS

        recordingTip.gameObject.SetActive(true);
        m_IflytekVoiceHelper.VoiceStart(RecordFinshCallbak, RecordTranslateFinshCallbak, "");

#endif


    }
    private void RecordFinshCallbak(IflytekVoiceHelper.ResultCode code, string filePath, int timeSecond)
    {
        DLog.LogToUI("TestSoundRecord.recordFinshCallbak.code:{0}, filePath:{1}", code, filePath);
    }
    private void RecordTranslateFinshCallbak(IflytekVoiceHelper.ResultCode code, string word, int timeSecond)
    {
        DLog.LogToUI("TestSoundRecord.recordTranslateFinshCallbak.code:{0}, word:{1}", code, word);
    }


    public void VoiceEnd(BaseEventData data)
    {
        DLog.LogToUI("lgy-->TestSoundRecord.VoiceEnd, I am up.");
        recordingTip.gameObject.SetActive(false);
        m_IflytekVoiceHelper.VoiceStop();
    }

    public bool IsRecording()
    {
        return m_IflytekVoiceHelper.IsRecording;
    }

    public bool EnterRecord()
    {
        return m_IflytekVoiceHelper.EnterRecord;
    }

    public void Reset() 
    {
        m_IflytekVoiceHelper.Reset();
    }

    private void PlaySound()
    { 
        DLog.LogToUI("TestSoundRecord.PlaySound");

        DownloadResources.AsyncLoadAudio( Util.AddLocalFilePrex(m_IflytekVoiceHelper.GetVoicePath() + audioName), AudioType.WAV,
            data =>
            {
                if (data == null) return;
                audioSource.clip = data;
                audioSource.Play();
            }
        );
        
    }

    private void RequestPermission()
    {
        DLog.LogToUI("TestSoundRecord.RequestPermission");
#if UNITY_ANDROID
        //获取权限后的回调，拒绝、允许、拒绝且不再提示的三个回调
        //TODO 安卓的权限接口，改为基础库的统一接口
        PermissionCallbacks permissionCallback = new PermissionCallbacks();
        permissionCallback.PermissionDenied += data =>  DLog.Log("申请麦克风权限被拒绝了") ;
        permissionCallback.PermissionDeniedAndDontAskAgain += data => DLog.Log("申请麦克风权限被拒绝了");
        permissionCallback.PermissionGranted += data => DLog.Log("申请麦克风权限 通过");
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone, permissionCallback);
        }
#endif
    }

}



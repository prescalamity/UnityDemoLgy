using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
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
        //testDeviceBases.Add(new TestPower());
        //testDeviceBases.Add(new TestPermission());
        testDeviceBases.Add(new TestHeadPhoto());

    }


    public static void setPanelSort()
    {
        foreach (var v in testDeviceBases) v.setPanelSort();

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
    public virtual void setPanelSort() {}

    public virtual void Start() {}

    public virtual void Update() {}

    public virtual void MainButtonTestFunction(int stepID, string functionName = "") {}
}


/// <summary>
/// 检测安卓设备电量
/// </summary>
class TestPower : TestBase
{
    GameObject mGameObject = null;
    TMP_Text battery_capacity_value = null;
    TMP_Text battery_electricity_value = null;
    TMP_Text battery_voltage_value = null;
    TMP_Text battery_retain_value = null;
    TMP_Text battery_retain_time_value = null;
    TMP_Text battery_get_api_time_value = null;

    public override void setPanelSort()
    {
        mGameObject?.transform.SetAsLastSibling();
    }



    public override void Start()
    {
        DLog.Log("AndroidDevicePower.Start");

        mGameObject = GameObject.Find("Canvas/power");

        battery_capacity_value = GameObject.Find("Canvas/power/battery_capacity_value").GetComponent<TMP_Text>();
        battery_electricity_value = GameObject.Find("Canvas/power/battery_electricity_value").GetComponent<TMP_Text>();
        battery_voltage_value = GameObject.Find("Canvas/power/battery_voltage_value").GetComponent<TMP_Text>();
        battery_retain_value = GameObject.Find("Canvas/power/battery_retain_value").GetComponent<TMP_Text>();
        battery_retain_time_value = GameObject.Find("Canvas/power/battery_retain_time_value").GetComponent<TMP_Text>();
        battery_get_api_time_value = GameObject.Find("Canvas/power/battery_get_api_time_value").GetComponent<TMP_Text>();


        battery_capacity_value.text = Power.capacity.ToString();
        battery_voltage_value.text = Power.voltage.ToString();
        battery_retain_value.text = Power.batteryRetain.ToString();

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

    public override void MainButtonTestFunction(int stepID, string functionName = "")
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

    GameObject mHeadPhoto;

    static Image image;

    Button btnOpenPhotoLib;
    Button btnOpenCamera;

    //GameObject _tempGo;

    public override void Start()
    {
        base.Start();

        DLog.Log("TestHeadPhoto.Start");

        image = GameObject.Find("Canvas/head_photo/image").GetComponent<Image>();

        btnOpenPhotoLib = GameObject.Find("Canvas/head_photo/open_photo_library").GetComponent<Button>();
        btnOpenPhotoLib.onClick.AddListener(()=> PlatformAdapter.CallPlatformFunc("OpenPhotoLibrary", "", "OpenPhotoLibraryCB"));

        btnOpenCamera = GameObject.Find("Canvas/head_photo/open_camera").GetComponent<Button>();
        btnOpenCamera.onClick.AddListener(() => PlatformAdapter.CallPlatformFunc("OpenCamera", "", "OpenCameraCB"));

    }

    public static void OpenPhotoLibraryCB(string cbData)
    {

        DLog.LogToUI("TestHeadPhoto.OpenPhotoLibraryCB-->" + cbData);

        cbData = cbData.Replace("\"", "");
        cbData = cbData.Replace("\\", "");
        string[] resStr = cbData.Split(new char[] { ',', '{', '}', '[', ']' }, System.StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> resDic = new Dictionary<string, string>();
        string[] temp;
        foreach(var v in resStr)
        {
            temp = v.Split(":");
            resDic.Add(temp[0], temp[1]);
        }

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

        if (resizeRes.Equals("true"))
        {
            DLog.LogToUI("TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:ok");

            Main.Instance.MainStartCoroutine(DownloadResources.LoadTexture(fileDestPath, image));
        }
        else
        {
            DLog.LogToUI("TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:no");
        }

    }

    public static void OpenCameraCB(string cbData)
    {
        DLog.LogToUI("TestHeadPhoto.OpenCameraCB" + cbData);
    }



}

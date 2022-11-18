using UnityEngine;

public class getPower : MonoBehaviour
{
    /// <summary>
    /// ����
    /// </summary>
    float e = 0;


    private void OnGUI()
    {
        GUILayout.Label(string.Format($"<size=40><color=purple>��������� {Power.capacity} ����, ��ѹ {Power.voltage} ��</color></size>") );
        GUILayout.Label(string.Format(
            $"<size=40><color=purple>ʵʱ���� {e} ����,ʵʱ���� {(int)(e * Power.voltage)} , ���������� {((Power.capacity / e).ToString("f2"))} Сʱ</color></size>"
            ));
    }


    float t = 0f;
    private void Update()
    {
        if (Time.time - t > 1f)//ÿ 1 ���룬���µ�����ֵ
        {
            t = Time.time;
            e = Power.electricity;
        }
    }
}


public class Power
{


    /// <summary>
    /// ��ȡ������΢����
    /// </summary>
    static public float electricity
    {
        get
        {
#if UNITY_ANDROID

            //��ȡ������΢����������Ƶ����ȡ��ȡһ�δ��2����
            float electricity = (float)manager.Call<int>("getIntProperty", PARAM_BATTERY);

            //С��1W����Ϊ���ĵ�λ�Ǻ�����������Ϊ��΢��
            return ToMA(electricity);
#else
            return -1f;
#endif

        }
    }
    /// <summary>
    /// ��ȡ��ѹ ��
    /// </summary>
    static public float voltage { get; private set; }

    /// <summary>
    /// ��ȡ��������� ����
    /// </summary>
    static public int capacity { get; private set; }

    /// <summary>
    /// ��ȡʵʱ��������
    /// </summary>
    static object[] PARAM_BATTERY = new object[] { 2 }; //BatteryManager.BATTERY_PROPERTY_CURRENT_NOW)

    static AndroidJavaObject manager;
    static Power()
    {
#if UNITY_ANDROID
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        manager = currActivity.Call<AndroidJavaObject>("getSystemService", new object[] { "batterymanager" });

        //BATTERY_PROPERTY_CHARGE_COUNTER 1 BATTERY_PROPERTY_CAPACITY 4
        capacity = (int) ( ToMA( manager.Call<int>("getIntProperty", new object[] { 1 }) ) / 
                           ( manager.Call<int>("getIntProperty", new object[] { 4 }) / 100f ) 
                         );   
 
        AndroidJavaObject receive = currActivity.Call<AndroidJavaObject>( "registerReceiver", 
            new object[] { null, new AndroidJavaObject("android.content.IntentFilter", new object[] { "android.intent.action.BATTERY_CHANGED" }) }
            );
       
        if (receive != null)
        {  
            voltage = (float)receive.Call<int>("getIntExtra", new object[] { "voltage", 0 })/1000f; //BatteryManager.EXTRA_VOLTAGE
        }
#endif
    }

    static float ToMA(float maOrua)
    {
        return maOrua < 10000 ? maOrua : maOrua / 1000f;
    }
}
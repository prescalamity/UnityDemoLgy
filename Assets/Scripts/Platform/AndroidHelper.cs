using System;
using UnityEngine;


[DoNotToLua]
public class AndroidHelper
{
    public static void initAndroid()
    {

        ShowAndroidStatusBar();
        SetAndroidStatusBarColor();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.fullScreen = false;
        Screen.fullScreenMode = FullScreenMode.Windowed;

        PlatformAdapter.CallPlatformFunc("CloseSplashDialog", "", "");
    }

    /// <summary>
    ///  隐藏上方状态栏
    /// </summary>
    public static void HideAndroidStatusBar()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        SetStatusBarValue("addFlags", 1024); // WindowManager.LayoutParams.FLAG_FULLSCREEN; change this to 0 if unsatisfied
#endif
    }

    /// <summary>
    ///  显示上方状态栏
    /// </summary>
    public static void ShowAndroidStatusBar()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        SetStatusBarValue("clearFlags", 1024); // WindowManager.LayoutParams.FLAG_FORCE_NOT_FULLSCREEN
#endif
    }

    /// <summary>
    ///  设置上方状态栏背景颜色
    /// </summary>
    public static void SetAndroidStatusBarColor()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                activity.Call("runOnUiThread", new AndroidJavaRunnable(SetStatusBarColorInThread));
            }
        }
#endif
    }


    private static void SetStatusBarValue(string flagFunc, params object[] args)
    {
        if (args == null)
        {
            DLog.Log("AndroidHelper.SetStatusBarValue.flagFunc:{0}", flagFunc);
        }
        else
        {
            DLog.Log("AndroidHelper.SetStatusBarValue.flagFunc:{0}, args.length:{1}, args.0:{2}", flagFunc, args.Length.ToString(), args.Length > 0 ? args[0].ToString() : args.ToString());
        }

        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                    using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                    {
                        using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                        {
                            using (var window = activity.Call<AndroidJavaObject>("getWindow"))
                            {
                                window.Call(flagFunc, args);
                            }
                        }
                    }
                }));
            }
        }
    }

    private static void SetStatusBarColorInThread()
    {
        DLog.Log("AndroidHelper.setStatusBarColorInThread");
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                using (var window = activity.Call<AndroidJavaObject>("getWindow"))
                {
                    window.Call("addFlags", -2147483648);
                    window.Call("setStatusBarColor", -1);
                    using (var fnotColor = window.Call<AndroidJavaObject>("getDecorView"))
                    {
                        fnotColor.Call("setSystemUiVisibility", 1024 | 8192);   //实现状态栏图标和文字颜色暗色
                    }
                }
            }
        }
    }

}

public class Power
{
    //https://www.xuanyusong.com/archives/4753


    static public double deltaTime = -1;

    /// <summary>
    /// 获取电流（微安）
    /// </summary>
    static public float electricity
    {
        get
        {
#if UNITY_ANDROID&& !UNITY_EDITOR

            //获取电流（微安），避免频繁获取，取一次大概2毫秒
            //float electricity = (float)manager.Call<int>("getIntProperty", PARAM_BATTERY);

            DateTime startTime = DateTime.Now;

            float electricity = float.Parse(PlatformAdapter.CallPlatformFunc("GetBatteryElectricity", "", ""));

            deltaTime = (DateTime.Now - startTime).TotalMilliseconds; 

            //小于1W就认为它的单位是毫安，否则认为是微安
            return ToMA(electricity);
#else
            return -1f;
#endif

        }
    }

    /// <summary>
    /// 电池剩余电量
    /// </summary>
    static public int batteryRetain
    {
        get
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return int.Parse(PlatformAdapter.CallPlatformFunc("GetBatteryLevel", "", ""));
#else
            return -1;
#endif
        }
    }

    /// <summary>
    /// 获取电压 伏
    /// </summary>
    static public float voltage { get; private set; }

    /// <summary>
    /// 获取电池总容量 毫安
    /// </summary>
    static public int capacity { get; private set; }

    /// <summary>
    /// 获取实时电流参数
    /// </summary>
    static object[] PARAM_BATTERY = new object[] { 2 }; //BatteryManager.BATTERY_PROPERTY_CURRENT_NOW)

    static AndroidJavaObject manager;
    static Power()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        //AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaObject currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        //manager = currActivity.Call<AndroidJavaObject>("getSystemService", new object[] { "batterymanager" });

        ////BATTERY_PROPERTY_CHARGE_COUNTER 1 BATTERY_PROPERTY_CAPACITY 4
        //capacity = (int)(ToMA(manager.Call<int>("getIntProperty", new object[] { 1 })) /
        //                   (manager.Call<int>("getIntProperty", new object[] { 4 }) / 100f)
        //                 );

        //AndroidJavaObject receive = currActivity.Call<AndroidJavaObject>("registerReceiver",
        //    new object[] { null, new AndroidJavaObject("android.content.IntentFilter", new object[] { "android.intent.action.BATTERY_CHANGED" }) }
        //    );

        //if (receive != null)
        //{
        //    voltage = (float)receive.Call<int>("getIntExtra", new object[] { "voltage", 0 }) / 1000f; //BatteryManager.EXTRA_VOLTAGE
        //}


        string res = PlatformAdapter.CallPlatformFunc("GetBatteryCapacity", "", "");
        if (String.IsNullOrEmpty(res)) res = "-1";
        capacity = int.Parse(res);

        res = PlatformAdapter.CallPlatformFunc("GetBatteryVoltage", "", "");
        if (String.IsNullOrEmpty(res)) res = "-1";
        voltage = Power.ToMA(float.Parse(res));
#endif
    }

    public static float ToMA(float maOrua)
    {
        return maOrua < 10000 ? maOrua : maOrua / 1000f;
    }
}

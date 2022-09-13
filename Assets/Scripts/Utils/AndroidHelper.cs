using UnityEngine;

public class AndroidHelper
{

    private static int newStatusBarValue = 0;
    private static string mFlagFunc = "";

    /// <summary>
    ///  隐藏上方状态栏
    /// </summary>
    public static void HideAndroidStatusBar()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        setStatusBarValue(1024, "addFlags"); // WindowManager.LayoutParams.FLAG_FULLSCREEN; change this to 0 if unsatisfied
#endif
    }

    /// <summary>
    ///  显示上方状态栏
    /// </summary>
    public static void ShowAndroidStatusBar()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        setStatusBarValue(1024, "clearFlags"); // WindowManager.LayoutParams.FLAG_FORCE_NOT_FULLSCREEN
#endif
    }

    /// <summary>
    ///  设置上方状态栏背景颜色
    /// </summary>
    public static void SetAndroidStatusBarColor()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        //setStatusBarValue(-2147483648, "addFlags"); 
        //setStatusBarValue(-16776961, "setStatusBarColor"); 
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                activity.Call("runOnUiThread", new AndroidJavaRunnable(setStatusBarColorInThread));
            }
        }
#endif
    }


    private static void setStatusBarValue(int value, string flagFunc)
    {
        newStatusBarValue = value;
        mFlagFunc = flagFunc;
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                activity.Call("runOnUiThread", new AndroidJavaRunnable(setStatusBarValueInThread));
            }
        }
    }

    private static void setStatusBarValueInThread()
    {
        DLog.Log("AndroidHelper.setStatusBarValueInThread.mFlagFunc:{0}", mFlagFunc);
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                using (var window = activity.Call<AndroidJavaObject>("getWindow"))
                {
                    window.Call(mFlagFunc, newStatusBarValue);
                }
            }
        }
    }

    private static void setStatusBarColorInThread()
    {
        DLog.Log("AndroidHelper.setStatusBarColorInThread.mFlagFunc:{0}", mFlagFunc);
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

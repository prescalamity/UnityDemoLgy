using UnityEngine;

public class AndroidHelper
{

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

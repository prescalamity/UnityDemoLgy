using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void dele_rVoid_pVoid();
public delegate void dele_rVoid_pString(string data);


public enum PlatformType { 
    WindowsEditor,
    AndroidEditor,
    IosEditor,
    WebglEditor,
    WindowsRuntime,
    AndroidRuntime,
    IosRuntime,
    WebglRuntime,
}

public class PlatformAdapter
{

    static Dictionary<string, dele_rVoid_pString> dic_rVoid_pString = new Dictionary<string, dele_rVoid_pString>();
    static Dictionary<string, dele_rVoid_pVoid> dic_rVoid_pVoid = new Dictionary<string, dele_rVoid_pVoid>();

    public static PlatformType mPlatform = PlatformType.WindowsEditor;

    public static void init()
    {

#if UNITY_STANDALONE_WIN
        

#if UNITY_EDITOR
        mPlatform = PlatformType.WindowsEditor;
#else
        mPlatform = PlatformType.WindowsRuntime;
#endif
#endif


#if UNITY_ANDROID

        initAndroid();

#if UNITY_EDITOR
        mPlatform = PlatformType.AndroidEditor;
#else
        mPlatform = PlatformType.AndroidRuntime;
#endif

#endif


#if UNITY_WEBGL

        initWebGL();

#if UNITY_EDITOR
        mPlatform = PlatformType.WebglEditor;
#else
        mPlatform = PlatformType.WebglRuntime;
#endif

#endif



        //动态注册函数
        RegisyerAndroidFunction("funcName", testFuncNameAndroid);
        RegisyerWebGLFunction("funcName", testFuncNameWebGL);

#if UNITY_WEBG
        RegisyerWebGLFunction("Hello", JsHelper.Hello);
        RegisyerWebGLFunction("PlayVideo", JsHelper.PlayVideo);
#endif

    }


#region 注册平台函数

    /// <summary>
    /// 将函数注册到 WebGL 平台，需注册的函数 传入 和 返回 都为空
    /// </summary>
    /// <param name="funcName"></param>
    /// <param name="_dic_RVoid_PVoid"></param>
    private static void RegisyerWebGLFunction(string funcName, dele_rVoid_pVoid _dic_RVoid_PVoid) { 
        dic_rVoid_pVoid.Add(funcName + "WebGL", _dic_RVoid_PVoid); 
    }
    /// <summary>
    /// 将函数注册到 WebGL 平台，需注册的函数 传入字符串 和 返回空
    /// </summary>
    /// <param name="funcName"></param>
    /// <param name="_dele_rVoid_pString"></param>
    private static void RegisyerWebGLFunction(string funcName, dele_rVoid_pString _dele_rVoid_pString) { 
        dic_rVoid_pString.Add(funcName + "WebGL", _dele_rVoid_pString); 
    }

    private static void RegisyerAndroidFunction(string funcName, dele_rVoid_pVoid _dic_RVoid_PVoid) { 
        dic_rVoid_pVoid.Add(funcName + "Android", _dic_RVoid_PVoid); 
    }
    private static void RegisyerAndroidFunction(string funcName, dele_rVoid_pString _dele_rVoid_pString) { 
        dic_rVoid_pString.Add(funcName + "Android", _dele_rVoid_pString); 
    }

    private static void RegisyerWindowsFunction(string funcName, dele_rVoid_pVoid _dic_RVoid_PVoid)
    {
        dic_rVoid_pVoid.Add(funcName + "Windows", _dic_RVoid_PVoid);
    }
    private static void RegisyerWindowsFunction(string funcName, dele_rVoid_pString _dele_rVoid_pString)
    {
        dic_rVoid_pString.Add(funcName + "Windows", _dele_rVoid_pString);
    }
#endregion


    public static string CallPlatformFunc(string key, string data, string lua_callback)
    {
        if (!string.IsNullOrEmpty(key))
        {
            DLog.LogToUI("PlatformAdapter.CallPlatformFunc key={0}, data={1}, lua_callback={2}", key, data, lua_callback);
        }

#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass androidclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = androidclass.GetStatic<AndroidJavaObject>("currentActivity");
            string ret = jo.Call<string>("CallPlatformFunc", key, data, lua_callback);
            androidclass.Dispose();
            jo.Dispose();
            return ret;
            
#elif UNITY_IOS && !UNITY_EDITOR
            return QdHSSSFromLJB(key, data, lua_callback);
#endif

        return "";
    }



    /// <summary>
    /// 通过名字调用平台函数
    /// </summary>
    /// <param name="funcName"></param>
    public static void CallPlatformFuncByName(string funcName)
    {
        //DLog.Log("PlatformAdapter.CallFuncByName1: the funcName is {0}.", funcName);

        funcName = funcName + mPlatform;
        dele_rVoid_pVoid rVoid_pVoid = null;

        if (dic_rVoid_pVoid.TryGetValue(funcName, out rVoid_pVoid))
            rVoid_pVoid?.Invoke();
        else
            DLog.Log("PlatformAdapter.CallFuncByName: the funcName is null, {0}.", funcName);
    }
    public static void CallPlatformFuncByName(string funcName, string data)
    {
        funcName = funcName + mPlatform;
        dele_rVoid_pString rVoid_PString = null;

        if(dic_rVoid_pString.TryGetValue(funcName, out rVoid_PString)) 
            rVoid_PString?.Invoke(data);
        else 
            DLog.Log("PlatformAdapter.CallFuncByName: the funcName is null, {0}.", funcName);
    }



    private static void initAndroid()
    {
        AndroidHelper.ShowAndroidStatusBar();
        AndroidHelper.SetAndroidStatusBarColor();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private static void initWebGL()
    {

    }


    private static void testFuncNameAndroid(string data){
        DLog.Log("this is funcNameAndroid: " + data);
     }


    private static void testFuncNameWebGL(string data)
    {
    }



}

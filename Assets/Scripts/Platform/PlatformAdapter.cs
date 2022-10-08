using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void dele_rVoid_pVoid();
public delegate void dele_rVoid_pString(string data);

public class PlatformAdapter
{

    static Dictionary<string, dele_rVoid_pString> dic_rVoid_pString = new Dictionary<string, dele_rVoid_pString>();
    static Dictionary<string, dele_rVoid_pVoid> dic_rVoid_pVoid = new Dictionary<string, dele_rVoid_pVoid>();

    public static string mPlatform = "";

    public static void init()
    {

#if UNITY_EDITOR
        mPlatform = "Editor";
#endif

#if UNITY_ANDROID && ! UNITY_EDITOR

        initAndroid();

        mPlatform = "Android";
#endif

#if UNITY_WEBGL && ! UNITY_EDITOR

        initWebGL();

        mPlatform = "WebGL";
#endif

        //动态注册函数
        RegisyerAndroidFunction("funcName", testFuncNameAndroid);
        RegisyerWebGLFunction("funcName", testFuncNameWebGL);

        RegisyerWebGLFunction("Hello", JsHelper.Hello);

        RegisyerWebGLFunction("PlayVideo", JsHelper.PlayVideo);
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

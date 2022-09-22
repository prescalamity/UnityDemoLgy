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

#if UNITY_ANDROID
        initAndroid();

        mPlatform = "Android";
#endif

#if UNITY_WEBGL
        initWebGL();

        mPlatform = "WebGL";
#endif

        //��̬ע�ắ��
        dic_rVoid_pString.Add("funcNameAndroid", funcNameAndroid);
        dic_rVoid_pString.Add("funcNameWebGL", funcNameWebGL);

        dic_rVoid_pVoid.Add("HelloWebGL", JsHelper.Hello);
    }

    public static void CallFuncByName(string funcName)
    {
        //DLog.Log("PlatformAdapter.CallFuncByName1: the funcName is {0}.", funcName);

        funcName = funcName + mPlatform;
        dele_rVoid_pVoid rVoid_pVoid = null;

        if (dic_rVoid_pVoid.TryGetValue(funcName, out rVoid_pVoid))
            rVoid_pVoid?.Invoke();
        else
            DLog.Log("PlatformAdapter.CallFuncByName: the funcName is null, {0}.", funcName);
    }
    public static void CallFuncByName(string funcName, string data)
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


    private static void funcNameAndroid(string data){
        DLog.Log("this is funcNameAndroid: " + data);
     }


    private static void funcNameWebGL(string data)
    {
    }



}
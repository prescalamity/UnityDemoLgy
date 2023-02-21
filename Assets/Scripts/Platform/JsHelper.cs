using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class JsHelper
{


    public static void initWebGL()
    {
#if UNITY_WEBGL
        //动态注册函数
        //RegisyerFunction("Hello", JsHelper.Hello);
        //RegisyerFunction("PlayVideo", JsHelper.PlayVideo);
#endif

    }


    //这里必须加平台宏，否则出包报错
#if UNITY_WEBGL
    [DllImport("__Internal")]
    public static extern void Hello(string msg);

    [DllImport("__Internal")]
    public static extern void HelloString(string str);

    [DllImport("__Internal")]
    public static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    public static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    public static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    public static extern void BindWebGLTexture(int texture);


    [DllImport("__Internal")]
    public static extern void PlayVideo(string videoSrc);
#endif
}

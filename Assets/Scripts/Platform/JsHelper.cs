using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class JsHelper
{


    [DllImport("__Internal")]
    public static extern void Hello();

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


}

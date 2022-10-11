using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class DataConvert
{

#if UNITY_IPHONE || UNITY_XBOX360
    const string QX3DLIB_DLL = "__Internal";
#else
    const string QX3DLIB_DLL = "qx3dlib";
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
    [DllImport(QX3DLIB_DLL, EntryPoint = "Deflate", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
    public static extern UInt32 Deflate(byte[] compr, int comprLen, byte[] uncompr, int uncomprLen);

    [DllImport(QX3DLIB_DLL, EntryPoint = "Inflate", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
    public static extern UInt32 Inflate(byte[] compr, int comprLen, byte[] uncompr, int uncomprLen);
#else
    public static UInt32 Deflate(byte[] compr, int comprLen, byte[] uncompr, int uncomprLen)
    {
        return 0x001FF001;
    }
    public static UInt32 Inflate(byte[] compr, int comprLen, byte[] uncompr, int uncomprLen)
    {
         return 0x001FF001;
    }
#endif
}
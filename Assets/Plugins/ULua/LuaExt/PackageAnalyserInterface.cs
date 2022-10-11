using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Text;

public class PackageAnalyser
{
#if UNITY_IPHONE || UNITY_XBOX360 || UNITY_WEBGL
    const string PADLL = "__Internal";
#elif UNITY_EDITOR
    const string PADLL = "qx3dlib";
#elif UNITY_ANDROID
   const string PADLL = "qx3dlib";
#else 
    const string PADLL = "qx3dlib";
#endif

    [DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr PackageAnalyserNew();

    [DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool DestroyInstance(IntPtr Pa);

    [DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern bool ParsePackageFile(IntPtr pa, [MarshalAs(UnmanagedType.LPArray)] byte[] filename);

    [DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern  bool ParsePackageFile2(IntPtr pa, [MarshalAs(UnmanagedType.LPStr)] string data, uint data_length);

    [DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool GetFileBuff(IntPtr pa, [MarshalAs(UnmanagedType.LPStr)] string file_path, out IntPtr file_buff, out int file_len);

    [DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool ClearLuaPak(IntPtr pa);

	[DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern bool IsFileExist(IntPtr pa, [MarshalAs(UnmanagedType.LPStr)] string file_path );

	[DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern bool FreeHGlobal(IntPtr ptr);

    [DllImport(PADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetEncryptSeed(IntPtr pa, [MarshalAs(UnmanagedType.LPStr)] string file_path);

}
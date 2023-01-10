﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_ScreenCaptureWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("ScreenCapture");
		L.RegFunction("CaptureScreenshot", CaptureScreenshot);
		L.RegFunction("CaptureScreenshotAsTexture", CaptureScreenshotAsTexture);
		L.RegFunction("CaptureScreenshotIntoRenderTexture", CaptureScreenshotIntoRenderTexture);
		L.RegFunction("GetClassType", GetClassType);
		L.EndStaticLibs();
	}

	static Type classType = typeof(UnityEngine.ScreenCapture);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CaptureScreenshot(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.ScreenCapture.CaptureScreenshot");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				UnityEngine.ScreenCapture.CaptureScreenshot(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string arg0 = ToLua.ToString(L, 1);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
				UnityEngine.ScreenCapture.CaptureScreenshot(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(UnityEngine.ScreenCapture.StereoScreenCaptureMode)))
			{
				string arg0 = ToLua.ToString(L, 1);
				UnityEngine.ScreenCapture.StereoScreenCaptureMode arg1 = (UnityEngine.ScreenCapture.StereoScreenCaptureMode)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.ScreenCapture.CaptureScreenshot(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else
			{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.ScreenCapture.CaptureScreenshot");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CaptureScreenshotAsTexture(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.ScreenCapture.CaptureScreenshotAsTexture");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Texture2D o = UnityEngine.ScreenCapture.CaptureScreenshotAsTexture();
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				UnityEngine.Texture2D o = UnityEngine.ScreenCapture.CaptureScreenshotAsTexture(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.ScreenCapture.StereoScreenCaptureMode)))
			{
				UnityEngine.ScreenCapture.StereoScreenCaptureMode arg0 = (UnityEngine.ScreenCapture.StereoScreenCaptureMode)LuaDLL.luaL_checknumber(L, 1);
				UnityEngine.Texture2D o = UnityEngine.ScreenCapture.CaptureScreenshotAsTexture(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else
			{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.ScreenCapture.CaptureScreenshotAsTexture");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CaptureScreenshotIntoRenderTexture(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.ScreenCapture.CaptureScreenshotIntoRenderTexture");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.RenderTexture arg0 = (UnityEngine.RenderTexture)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.RenderTexture));
			UnityEngine.ScreenCapture.CaptureScreenshotIntoRenderTexture(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}


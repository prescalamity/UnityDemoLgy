﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_ScreenWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("Screen");
		L.RegFunction("SetResolution", SetResolution);
		L.RegFunction("GetDisplayLayout", GetDisplayLayout);
		L.RegFunction("MoveMainWindowTo", MoveMainWindowTo);
		L.RegVar("width", get_width, null);
		L.RegVar("height", get_height, null);
		L.RegVar("dpi", get_dpi, null);
		L.RegVar("currentResolution", get_currentResolution, null);
		L.RegVar("resolutions", get_resolutions, null);
		L.RegVar("fullScreen", get_fullScreen, set_fullScreen);
		L.RegVar("fullScreenMode", get_fullScreenMode, set_fullScreenMode);
		L.RegVar("safeArea", get_safeArea, null);
		L.RegVar("cutouts", get_cutouts, null);
		L.RegVar("autorotateToPortrait", get_autorotateToPortrait, set_autorotateToPortrait);
		L.RegVar("autorotateToPortraitUpsideDown", get_autorotateToPortraitUpsideDown, set_autorotateToPortraitUpsideDown);
		L.RegVar("autorotateToLandscapeLeft", get_autorotateToLandscapeLeft, set_autorotateToLandscapeLeft);
		L.RegVar("autorotateToLandscapeRight", get_autorotateToLandscapeRight, set_autorotateToLandscapeRight);
		L.RegVar("orientation", get_orientation, set_orientation);
		L.RegVar("sleepTimeout", get_sleepTimeout, set_sleepTimeout);
		L.RegVar("brightness", get_brightness, set_brightness);
		L.RegVar("mainWindowPosition", get_mainWindowPosition, null);
		L.RegVar("mainWindowDisplayInfo", get_mainWindowDisplayInfo, null);
		L.RegFunction("GetClassType", GetClassType);
		L.EndStaticLibs();
	}

	static Type classType = typeof(UnityEngine.Screen);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetResolution(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.SetResolution");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(UnityEngine.FullScreenMode)))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
				UnityEngine.FullScreenMode arg2 = (UnityEngine.FullScreenMode)LuaDLL.luaL_checknumber(L, 3);
				UnityEngine.Screen.SetResolution(arg0, arg1, arg2);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(bool)))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
				bool arg2 = LuaDLL.lua_toboolean(L, 3);
				UnityEngine.Screen.SetResolution(arg0, arg1, arg2);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(UnityEngine.FullScreenMode), typeof(int)))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
				UnityEngine.FullScreenMode arg2 = (UnityEngine.FullScreenMode)LuaDLL.luaL_checknumber(L, 3);
				int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
				UnityEngine.Screen.SetResolution(arg0, arg1, arg2, arg3);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(bool), typeof(int)))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
				bool arg2 = LuaDLL.lua_toboolean(L, 3);
				int arg3 = (int)LuaDLL.lua_tonumber(L, 4);
				UnityEngine.Screen.SetResolution(arg0, arg1, arg2, arg3);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Screen.SetResolution");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDisplayLayout(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.GetDisplayLayout");
#endif
			ToLua.CheckArgsCount(L, 1);
			System.Collections.Generic.List<UnityEngine.DisplayInfo> arg0 = (System.Collections.Generic.List<UnityEngine.DisplayInfo>)ToLua.CheckObject(L, 1, typeof(System.Collections.Generic.List<UnityEngine.DisplayInfo>));
			UnityEngine.Screen.GetDisplayLayout(arg0);
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveMainWindowTo(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.MoveMainWindowTo");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.DisplayInfo arg0 = StackTraits<UnityEngine.DisplayInfo>.Check(L, 1);
			UnityEngine.Vector2Int arg1 = StackTraits<UnityEngine.Vector2Int>.Check(L, 2);
			UnityEngine.AsyncOperation o = UnityEngine.Screen.MoveMainWindowTo(in arg0, arg1);
			ToLua.PushObject(L, o);
			ToLua.PushValue(L, arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 2;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_width(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.Screen.width);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.Screen.height);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dpi(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.Screen.dpi);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentResolution(IntPtr L)
	{
		ToLua.PushValue(L, UnityEngine.Screen.currentResolution);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resolutions(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Screen.resolutions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fullScreen(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Screen.fullScreen);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fullScreenMode(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Screen.fullScreenMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_safeArea(IntPtr L)
	{
		ToLua.PushValue(L, UnityEngine.Screen.safeArea);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cutouts(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Screen.cutouts);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToPortrait(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Screen.autorotateToPortrait);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToPortraitUpsideDown(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Screen.autorotateToPortraitUpsideDown);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToLandscapeLeft(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Screen.autorotateToLandscapeLeft);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autorotateToLandscapeRight(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Screen.autorotateToLandscapeRight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_orientation(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Screen.orientation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepTimeout(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.Screen.sleepTimeout);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_brightness(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.Screen.brightness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainWindowPosition(IntPtr L)
	{
		ToLua.PushValue(L, UnityEngine.Screen.mainWindowPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainWindowDisplayInfo(IntPtr L)
	{
		ToLua.PushValue(L, UnityEngine.Screen.mainWindowDisplayInfo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fullScreen(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.fullScreen");
#endif
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.Screen.fullScreen = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fullScreenMode(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.fullScreenMode");
#endif
			UnityEngine.FullScreenMode arg0 = (UnityEngine.FullScreenMode)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Screen.fullScreenMode = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToPortrait(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.autorotateToPortrait");
#endif
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.Screen.autorotateToPortrait = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToPortraitUpsideDown(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.autorotateToPortraitUpsideDown");
#endif
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.Screen.autorotateToPortraitUpsideDown = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToLandscapeLeft(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.autorotateToLandscapeLeft");
#endif
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.Screen.autorotateToLandscapeLeft = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autorotateToLandscapeRight(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.autorotateToLandscapeRight");
#endif
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.Screen.autorotateToLandscapeRight = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_orientation(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.orientation");
#endif
			UnityEngine.ScreenOrientation arg0 = (UnityEngine.ScreenOrientation)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Screen.orientation = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepTimeout(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.sleepTimeout");
#endif
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Screen.sleepTimeout = arg0;
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_brightness(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Screen.brightness");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Screen.brightness = arg0;
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


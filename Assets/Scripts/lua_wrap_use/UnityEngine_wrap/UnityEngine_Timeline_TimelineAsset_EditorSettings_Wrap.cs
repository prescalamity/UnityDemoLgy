﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_Timeline_TimelineAsset_EditorSettingsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Timeline.TimelineAsset.EditorSettings), typeof(System.Object), "EditorSettings");
		L.RegFunction("SetStandardFrameRate", SetStandardFrameRate);
		L.RegFunction("New", _CreateUnityEngine_Timeline_TimelineAsset_EditorSettings);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("frameRate", get_frameRate, set_frameRate);
		L.RegVar("scenePreview", get_scenePreview, set_scenePreview);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Timeline_TimelineAsset_EditorSettings(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Timeline.TimelineAsset.EditorSettings obj = new UnityEngine.Timeline.TimelineAsset.EditorSettings();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Timeline.TimelineAsset.EditorSettings.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(UnityEngine.Timeline.TimelineAsset.EditorSettings);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetStandardFrameRate(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.EditorSettings.SetStandardFrameRate");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.TimelineAsset.EditorSettings obj = (UnityEngine.Timeline.TimelineAsset.EditorSettings)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset.EditorSettings));
			UnityEngine.Timeline.StandardFrameRates arg0 = (UnityEngine.Timeline.StandardFrameRates)LuaDLL.luaL_checknumber(L, 2);
			obj.SetStandardFrameRate(arg0);
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
	static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);

		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frameRate(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.EditorSettings.frameRate");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset.EditorSettings obj = (UnityEngine.Timeline.TimelineAsset.EditorSettings)o;
			double ret = obj.frameRate;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index frameRate on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scenePreview(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.EditorSettings.scenePreview");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset.EditorSettings obj = (UnityEngine.Timeline.TimelineAsset.EditorSettings)o;
			bool ret = obj.scenePreview;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index scenePreview on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frameRate(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.EditorSettings.frameRate");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset.EditorSettings obj = (UnityEngine.Timeline.TimelineAsset.EditorSettings)o;
			double arg0 = (double)LuaDLL.luaL_checknumber(L, 2);
			obj.frameRate = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index frameRate on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scenePreview(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.EditorSettings.scenePreview");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset.EditorSettings obj = (UnityEngine.Timeline.TimelineAsset.EditorSettings)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.scenePreview = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index scenePreview on a nil value" : e.Message);
		}
	}
}

﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_Timeline_ActivationTrackWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Timeline.ActivationTrack), typeof(UnityEngine.Playables.PlayableAsset), "ActivationTrack");
		L.RegFunction("CreateTrackMixer", CreateTrackMixer);
		L.RegFunction("GatherProperties", GatherProperties);
		L.RegFunction("New", _CreateUnityEngine_Timeline_ActivationTrack);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("postPlaybackState", get_postPlaybackState, set_postPlaybackState);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Timeline_ActivationTrack(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Timeline.ActivationTrack obj = new UnityEngine.Timeline.ActivationTrack();
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Timeline.ActivationTrack.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(UnityEngine.Timeline.ActivationTrack);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateTrackMixer(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.ActivationTrack.CreateTrackMixer");
#endif
			ToLua.CheckArgsCount(L, 4);
			UnityEngine.Timeline.ActivationTrack obj = (UnityEngine.Timeline.ActivationTrack)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.ActivationTrack));
			UnityEngine.Playables.PlayableGraph arg0 = StackTraits<UnityEngine.Playables.PlayableGraph>.Check(L, 2);
			UnityEngine.GameObject arg1 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.GameObject));
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 4);
			UnityEngine.Playables.Playable o = obj.CreateTrackMixer(arg0, arg1, arg2);
			ToLua.PushValue(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GatherProperties(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.ActivationTrack.GatherProperties");
#endif
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Timeline.ActivationTrack obj = (UnityEngine.Timeline.ActivationTrack)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.ActivationTrack));
			UnityEngine.Playables.PlayableDirector arg0 = (UnityEngine.Playables.PlayableDirector)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Playables.PlayableDirector));
			UnityEngine.Timeline.IPropertyCollector arg1 = (UnityEngine.Timeline.IPropertyCollector)ToLua.CheckObject(L, 3, typeof(UnityEngine.Timeline.IPropertyCollector));
			obj.GatherProperties(arg0, arg1);
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
	static int op_Equality(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.ActivationTrack.op_Equality");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
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
	static int get_postPlaybackState(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.ActivationTrack.postPlaybackState");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.ActivationTrack obj = (UnityEngine.Timeline.ActivationTrack)o;
			UnityEngine.Timeline.ActivationTrack.PostPlaybackState ret = obj.postPlaybackState;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index postPlaybackState on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_postPlaybackState(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.ActivationTrack.postPlaybackState");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.ActivationTrack obj = (UnityEngine.Timeline.ActivationTrack)o;
			UnityEngine.Timeline.ActivationTrack.PostPlaybackState arg0 = (UnityEngine.Timeline.ActivationTrack.PostPlaybackState)LuaDLL.luaL_checknumber(L, 2);
			obj.postPlaybackState = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index postPlaybackState on a nil value" : e.Message);
		}
	}
}


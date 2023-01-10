﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_Timeline_TimelineAssetWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Timeline.TimelineAsset), typeof(UnityEngine.Playables.PlayableAsset), "TimelineAsset");
		L.RegFunction("GetRootTrack", GetRootTrack);
		L.RegFunction("GetRootTracks", GetRootTracks);
		L.RegFunction("GetOutputTrack", GetOutputTrack);
		L.RegFunction("GetOutputTracks", GetOutputTracks);
		L.RegFunction("CreatePlayable", CreatePlayable);
		L.RegFunction("GatherProperties", GatherProperties);
		L.RegFunction("CreateMarkerTrack", CreateMarkerTrack);
		L.RegFunction("CreateTrack", CreateTrack);
		L.RegFunction("DeleteClip", DeleteClip);
		L.RegFunction("DeleteTrack", DeleteTrack);
		L.RegFunction("New", _CreateUnityEngine_Timeline_TimelineAsset);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("editorSettings", get_editorSettings, null);
		L.RegVar("duration", get_duration, null);
		L.RegVar("fixedDuration", get_fixedDuration, set_fixedDuration);
		L.RegVar("durationMode", get_durationMode, set_durationMode);
		L.RegVar("outputs", get_outputs, null);
		L.RegVar("clipCaps", get_clipCaps, null);
		L.RegVar("outputTrackCount", get_outputTrackCount, null);
		L.RegVar("rootTrackCount", get_rootTrackCount, null);
		L.RegVar("markerTrack", get_markerTrack, null);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Timeline_TimelineAsset(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Timeline.TimelineAsset obj = new UnityEngine.Timeline.TimelineAsset();
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Timeline.TimelineAsset.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(UnityEngine.Timeline.TimelineAsset);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRootTrack(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.GetRootTrack");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Timeline.TrackAsset o = obj.GetRootTrack(arg0);
			ToLua.Push(L, o);
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
	static int GetRootTracks(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.GetRootTracks");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			System.Collections.Generic.IEnumerable<UnityEngine.Timeline.TrackAsset> o = obj.GetRootTracks();
			ToLua.PushObject(L, o);
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
	static int GetOutputTrack(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.GetOutputTrack");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Timeline.TrackAsset o = obj.GetOutputTrack(arg0);
			ToLua.Push(L, o);
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
	static int GetOutputTracks(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.GetOutputTracks");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			System.Collections.Generic.IEnumerable<UnityEngine.Timeline.TrackAsset> o = obj.GetOutputTracks();
			ToLua.PushObject(L, o);
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
	static int CreatePlayable(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.CreatePlayable");
#endif
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			UnityEngine.Playables.PlayableGraph arg0 = StackTraits<UnityEngine.Playables.PlayableGraph>.Check(L, 2);
			UnityEngine.GameObject arg1 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.GameObject));
			UnityEngine.Playables.Playable o = obj.CreatePlayable(arg0, arg1);
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
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.GatherProperties");
#endif
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
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
	static int CreateMarkerTrack(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.CreateMarkerTrack");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			obj.CreateMarkerTrack();
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
	static int CreateTrack(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.CreateTrack");
#endif
			ToLua.CheckArgsCount(L, 4);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
			UnityEngine.Timeline.TrackAsset arg1 = (UnityEngine.Timeline.TrackAsset)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.Timeline.TrackAsset));
			string arg2 = ToLua.CheckString(L, 4);
			UnityEngine.Timeline.TrackAsset o = obj.CreateTrack(arg0, arg1, arg2);
			ToLua.Push(L, o);
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
	static int DeleteClip(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.DeleteClip");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			UnityEngine.Timeline.TimelineClip arg0 = (UnityEngine.Timeline.TimelineClip)ToLua.CheckObject(L, 2, typeof(UnityEngine.Timeline.TimelineClip));
			bool o = obj.DeleteClip(arg0);
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
	static int DeleteTrack(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.DeleteTrack");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.TimelineAsset));
			UnityEngine.Timeline.TrackAsset arg0 = (UnityEngine.Timeline.TrackAsset)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Timeline.TrackAsset));
			bool o = obj.DeleteTrack(arg0);
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
	static int op_Equality(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.op_Equality");
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
	static int get_editorSettings(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.editorSettings");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			UnityEngine.Timeline.TimelineAsset.EditorSettings ret = obj.editorSettings;
			ToLua.PushObject(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index editorSettings on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_duration(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.duration");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			double ret = obj.duration;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index duration on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedDuration(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.fixedDuration");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			double ret = obj.fixedDuration;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fixedDuration on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_durationMode(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.durationMode");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			UnityEngine.Timeline.TimelineAsset.DurationMode ret = obj.durationMode;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index durationMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_outputs(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.outputs");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			System.Collections.Generic.IEnumerable<UnityEngine.Playables.PlayableBinding> ret = obj.outputs;
			ToLua.PushObject(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index outputs on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clipCaps(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.clipCaps");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			UnityEngine.Timeline.ClipCaps ret = obj.clipCaps;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index clipCaps on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_outputTrackCount(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.outputTrackCount");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			int ret = obj.outputTrackCount;
			LuaDLL.lua_pushinteger(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index outputTrackCount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rootTrackCount(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.rootTrackCount");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			int ret = obj.rootTrackCount;
			LuaDLL.lua_pushinteger(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index rootTrackCount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_markerTrack(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.markerTrack");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			UnityEngine.Timeline.MarkerTrack ret = obj.markerTrack;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index markerTrack on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fixedDuration(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.fixedDuration");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			double arg0 = (double)LuaDLL.luaL_checknumber(L, 2);
			obj.fixedDuration = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fixedDuration on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_durationMode(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.TimelineAsset.durationMode");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.TimelineAsset obj = (UnityEngine.Timeline.TimelineAsset)o;
			UnityEngine.Timeline.TimelineAsset.DurationMode arg0 = (UnityEngine.Timeline.TimelineAsset.DurationMode)LuaDLL.luaL_checknumber(L, 2);
			obj.durationMode = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index durationMode on a nil value" : e.Message);
		}
	}
}


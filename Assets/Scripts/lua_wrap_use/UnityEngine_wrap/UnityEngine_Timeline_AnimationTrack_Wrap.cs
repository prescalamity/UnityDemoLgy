//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_Timeline_AnimationTrackWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Timeline.AnimationTrack), typeof(UnityEngine.Playables.PlayableAsset), "AnimationTrack");
		L.RegFunction("CreateClip", CreateClip);
		L.RegFunction("CreateInfiniteClip", CreateInfiniteClip);
		L.RegFunction("CreateRecordableClip", CreateRecordableClip);
		L.RegFunction("GatherProperties", GatherProperties);
		L.RegFunction("New", _CreateUnityEngine_Timeline_AnimationTrack);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("position", get_position, set_position);
		L.RegVar("rotation", get_rotation, set_rotation);
		L.RegVar("eulerAngles", get_eulerAngles, set_eulerAngles);
		L.RegVar("trackOffset", get_trackOffset, set_trackOffset);
		L.RegVar("matchTargetFields", get_matchTargetFields, set_matchTargetFields);
		L.RegVar("infiniteClip", get_infiniteClip, null);
		L.RegVar("avatarMask", get_avatarMask, set_avatarMask);
		L.RegVar("applyAvatarMask", get_applyAvatarMask, set_applyAvatarMask);
		L.RegVar("outputs", get_outputs, null);
		L.RegVar("inClipMode", get_inClipMode, null);
		L.RegVar("infiniteClipOffsetPosition", get_infiniteClipOffsetPosition, set_infiniteClipOffsetPosition);
		L.RegVar("infiniteClipOffsetRotation", get_infiniteClipOffsetRotation, set_infiniteClipOffsetRotation);
		L.RegVar("infiniteClipOffsetEulerAngles", get_infiniteClipOffsetEulerAngles, set_infiniteClipOffsetEulerAngles);
		L.RegVar("infiniteClipPreExtrapolation", get_infiniteClipPreExtrapolation, set_infiniteClipPreExtrapolation);
		L.RegVar("infiniteClipPostExtrapolation", get_infiniteClipPostExtrapolation, set_infiniteClipPostExtrapolation);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Timeline_AnimationTrack(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Timeline.AnimationTrack obj = new UnityEngine.Timeline.AnimationTrack();
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Timeline.AnimationTrack.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(UnityEngine.Timeline.AnimationTrack);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateClip(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.CreateClip");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.AnimationTrack));
			UnityEngine.AnimationClip arg0 = (UnityEngine.AnimationClip)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.AnimationClip));
			UnityEngine.Timeline.TimelineClip o = obj.CreateClip(arg0);
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
	static int CreateInfiniteClip(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.CreateInfiniteClip");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.AnimationTrack));
			string arg0 = ToLua.CheckString(L, 2);
			obj.CreateInfiniteClip(arg0);
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
	static int CreateRecordableClip(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.CreateRecordableClip");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.AnimationTrack));
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.Timeline.TimelineClip o = obj.CreateRecordableClip(arg0);
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
	static int GatherProperties(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.GatherProperties");
#endif
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)ToLua.CheckObject(L, 1, typeof(UnityEngine.Timeline.AnimationTrack));
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
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.op_Equality");
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
	static int get_position(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.position");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 ret = obj.position;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index position on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.rotation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Quaternion ret = obj.rotation;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index rotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eulerAngles(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.eulerAngles");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 ret = obj.eulerAngles;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index eulerAngles on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_trackOffset(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.trackOffset");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.TrackOffset ret = obj.trackOffset;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index trackOffset on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_matchTargetFields(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.matchTargetFields");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.MatchTargetFields ret = obj.matchTargetFields;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index matchTargetFields on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_infiniteClip(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClip");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.AnimationClip ret = obj.infiniteClip;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClip on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_avatarMask(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.avatarMask");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.AvatarMask ret = obj.avatarMask;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index avatarMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_applyAvatarMask(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.applyAvatarMask");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			bool ret = obj.applyAvatarMask;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index applyAvatarMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_outputs(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.outputs");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
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
	static int get_inClipMode(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.inClipMode");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			bool ret = obj.inClipMode;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index inClipMode on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_infiniteClipOffsetPosition(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipOffsetPosition");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 ret = obj.infiniteClipOffsetPosition;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipOffsetPosition on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_infiniteClipOffsetRotation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipOffsetRotation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Quaternion ret = obj.infiniteClipOffsetRotation;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipOffsetRotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_infiniteClipOffsetEulerAngles(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipOffsetEulerAngles");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 ret = obj.infiniteClipOffsetEulerAngles;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipOffsetEulerAngles on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_infiniteClipPreExtrapolation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipPreExtrapolation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.TimelineClip.ClipExtrapolation ret = obj.infiniteClipPreExtrapolation;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipPreExtrapolation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_infiniteClipPostExtrapolation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipPostExtrapolation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.TimelineClip.ClipExtrapolation ret = obj.infiniteClipPostExtrapolation;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipPostExtrapolation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.position");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.position = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index position on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.rotation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);
			obj.rotation = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index rotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eulerAngles(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.eulerAngles");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.eulerAngles = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index eulerAngles on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_trackOffset(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.trackOffset");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.TrackOffset arg0 = (UnityEngine.Timeline.TrackOffset)LuaDLL.luaL_checknumber(L, 2);
			obj.trackOffset = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index trackOffset on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_matchTargetFields(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.matchTargetFields");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.MatchTargetFields arg0 = (UnityEngine.Timeline.MatchTargetFields)LuaDLL.luaL_checknumber(L, 2);
			obj.matchTargetFields = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index matchTargetFields on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_avatarMask(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.avatarMask");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.AvatarMask arg0 = (UnityEngine.AvatarMask)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.AvatarMask));
			obj.avatarMask = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index avatarMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_applyAvatarMask(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.applyAvatarMask");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.applyAvatarMask = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index applyAvatarMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_infiniteClipOffsetPosition(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipOffsetPosition");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.infiniteClipOffsetPosition = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipOffsetPosition on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_infiniteClipOffsetRotation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipOffsetRotation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Quaternion arg0 = ToLua.ToQuaternion(L, 2);
			obj.infiniteClipOffsetRotation = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipOffsetRotation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_infiniteClipOffsetEulerAngles(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipOffsetEulerAngles");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.infiniteClipOffsetEulerAngles = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipOffsetEulerAngles on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_infiniteClipPreExtrapolation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipPreExtrapolation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.TimelineClip.ClipExtrapolation arg0 = (UnityEngine.Timeline.TimelineClip.ClipExtrapolation)LuaDLL.luaL_checknumber(L, 2);
			obj.infiniteClipPreExtrapolation = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipPreExtrapolation on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_infiniteClipPostExtrapolation(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Timeline.AnimationTrack.infiniteClipPostExtrapolation");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Timeline.AnimationTrack obj = (UnityEngine.Timeline.AnimationTrack)o;
			UnityEngine.Timeline.TimelineClip.ClipExtrapolation arg0 = (UnityEngine.Timeline.TimelineClip.ClipExtrapolation)LuaDLL.luaL_checknumber(L, 2);
			obj.infiniteClipPostExtrapolation = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index infiniteClipPostExtrapolation on a nil value" : e.Message);
		}
	}
}


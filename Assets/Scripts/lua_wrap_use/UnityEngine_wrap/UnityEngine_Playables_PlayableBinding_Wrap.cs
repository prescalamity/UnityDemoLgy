//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_Playables_PlayableBindingWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Playables.PlayableBinding), typeof(System.Object), "PlayableBinding");
		L.RegFunction("New", _CreateUnityEngine_Playables_PlayableBinding);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("None", get_None, null);
		L.RegVar("DefaultDuration", get_DefaultDuration, null);
		L.RegVar("streamName", get_streamName, set_streamName);
		L.RegVar("sourceObject", get_sourceObject, set_sourceObject);
		L.RegVar("outputTargetType", get_outputTargetType, null);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Playables_PlayableBinding(IntPtr L)
	{
		UnityEngine.Playables.PlayableBinding obj = new UnityEngine.Playables.PlayableBinding();
		ToLua.PushValue(L, obj);
		return 1;
	}

	static Type classType = typeof(UnityEngine.Playables.PlayableBinding);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
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
	static int get_None(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Playables.PlayableBinding.None);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefaultDuration(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.Playables.PlayableBinding.DefaultDuration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamName(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Playables.PlayableBinding.streamName");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Playables.PlayableBinding obj = (UnityEngine.Playables.PlayableBinding)o;
			string ret = obj.streamName;
			LuaDLL.lua_pushstring(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index streamName on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sourceObject(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Playables.PlayableBinding.sourceObject");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Playables.PlayableBinding obj = (UnityEngine.Playables.PlayableBinding)o;
			UnityEngine.Object ret = obj.sourceObject;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sourceObject on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_outputTargetType(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Playables.PlayableBinding.outputTargetType");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Playables.PlayableBinding obj = (UnityEngine.Playables.PlayableBinding)o;
			System.Type ret = obj.outputTargetType;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index outputTargetType on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_streamName(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Playables.PlayableBinding.streamName");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Playables.PlayableBinding obj = (UnityEngine.Playables.PlayableBinding)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.streamName = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index streamName on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sourceObject(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Playables.PlayableBinding.sourceObject");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Playables.PlayableBinding obj = (UnityEngine.Playables.PlayableBinding)o;
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Object));
			obj.sourceObject = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sourceObject on a nil value" : e.Message);
		}
	}
}


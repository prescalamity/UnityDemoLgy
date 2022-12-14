//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_AI_NavMeshHitWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AI.NavMeshHit), typeof(System.Object), "NavMeshHit");
		L.RegFunction("New", _CreateUnityEngine_AI_NavMeshHit);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("position", get_position, set_position);
		L.RegVar("normal", get_normal, set_normal);
		L.RegVar("distance", get_distance, set_distance);
		L.RegVar("mask", get_mask, set_mask);
		L.RegVar("hit", get_hit, set_hit);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AI_NavMeshHit(IntPtr L)
	{
		UnityEngine.AI.NavMeshHit obj = new UnityEngine.AI.NavMeshHit();
		ToLua.PushValue(L, obj);
		return 1;
	}

	static Type classType = typeof(UnityEngine.AI.NavMeshHit);

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
	static int get_position(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.position");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
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
	static int get_normal(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.normal");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			UnityEngine.Vector3 ret = obj.normal;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index normal on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_distance(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.distance");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			float ret = obj.distance;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index distance on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mask(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.mask");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			int ret = obj.mask;
			LuaDLL.lua_pushinteger(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hit(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.hit");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			bool ret = obj.hit;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index hit on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.position");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.position = arg0;
			ToLua.SetBack(L, 1, obj);
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
	static int set_normal(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.normal");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.normal = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index normal on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_distance(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.distance");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.distance = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index distance on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mask(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.mask");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.mask = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hit(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshHit.hit");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshHit obj = (UnityEngine.AI.NavMeshHit)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.hit = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index hit on a nil value" : e.Message);
		}
	}
}


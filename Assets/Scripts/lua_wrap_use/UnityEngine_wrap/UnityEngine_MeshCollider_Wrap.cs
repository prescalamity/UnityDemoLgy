﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_MeshColliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.MeshCollider), typeof(UnityEngine.Collider), "MeshCollider");
		L.RegFunction("New", _CreateUnityEngine_MeshCollider);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("sharedMesh", get_sharedMesh, set_sharedMesh);
		L.RegVar("convex", get_convex, set_convex);
		L.RegVar("cookingOptions", get_cookingOptions, set_cookingOptions);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_MeshCollider(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.MeshCollider obj = new UnityEngine.MeshCollider();
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.MeshCollider.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(UnityEngine.MeshCollider);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.MeshCollider.op_Equality");
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
	static int get_sharedMesh(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.MeshCollider.sharedMesh");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.MeshCollider obj = (UnityEngine.MeshCollider)o;
			UnityEngine.Mesh ret = obj.sharedMesh;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sharedMesh on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_convex(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.MeshCollider.convex");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.MeshCollider obj = (UnityEngine.MeshCollider)o;
			bool ret = obj.convex;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index convex on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cookingOptions(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.MeshCollider.cookingOptions");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.MeshCollider obj = (UnityEngine.MeshCollider)o;
			UnityEngine.MeshColliderCookingOptions ret = obj.cookingOptions;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cookingOptions on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMesh(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.MeshCollider.sharedMesh");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.MeshCollider obj = (UnityEngine.MeshCollider)o;
			UnityEngine.Mesh arg0 = (UnityEngine.Mesh)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Mesh));
			obj.sharedMesh = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sharedMesh on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_convex(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.MeshCollider.convex");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.MeshCollider obj = (UnityEngine.MeshCollider)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.convex = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index convex on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cookingOptions(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.MeshCollider.cookingOptions");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.MeshCollider obj = (UnityEngine.MeshCollider)o;
			UnityEngine.MeshColliderCookingOptions arg0 = (UnityEngine.MeshColliderCookingOptions)LuaDLL.luaL_checknumber(L, 2);
			obj.cookingOptions = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cookingOptions on a nil value" : e.Message);
		}
	}
}


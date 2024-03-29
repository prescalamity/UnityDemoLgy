﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_AI_NavMeshTriangulationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AI.NavMeshTriangulation), typeof(System.Object), "NavMeshTriangulation");
		L.RegFunction("New", _CreateUnityEngine_AI_NavMeshTriangulation);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("vertices", get_vertices, set_vertices);
		L.RegVar("indices", get_indices, set_indices);
		L.RegVar("areas", get_areas, set_areas);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AI_NavMeshTriangulation(IntPtr L)
	{
		UnityEngine.AI.NavMeshTriangulation obj = new UnityEngine.AI.NavMeshTriangulation();
		ToLua.PushValue(L, obj);
		return 1;
	}

	static Type classType = typeof(UnityEngine.AI.NavMeshTriangulation);

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
	static int get_vertices(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshTriangulation.vertices");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshTriangulation obj = (UnityEngine.AI.NavMeshTriangulation)o;
			UnityEngine.Vector3[] ret = obj.vertices;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index vertices on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_indices(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshTriangulation.indices");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshTriangulation obj = (UnityEngine.AI.NavMeshTriangulation)o;
			int[] ret = obj.indices;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index indices on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_areas(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshTriangulation.areas");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshTriangulation obj = (UnityEngine.AI.NavMeshTriangulation)o;
			int[] ret = obj.areas;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index areas on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vertices(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshTriangulation.vertices");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshTriangulation obj = (UnityEngine.AI.NavMeshTriangulation)o;
			UnityEngine.Vector3[] arg0 = ToLua.CheckObjectArray<UnityEngine.Vector3>(L, 2);
			obj.vertices = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index vertices on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_indices(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshTriangulation.indices");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshTriangulation obj = (UnityEngine.AI.NavMeshTriangulation)o;
			int[] arg0 = ToLua.CheckNumberArray<int>(L, 2);
			obj.indices = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index indices on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_areas(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AI.NavMeshTriangulation.areas");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AI.NavMeshTriangulation obj = (UnityEngine.AI.NavMeshTriangulation)o;
			int[] arg0 = ToLua.CheckNumberArray<int>(L, 2);
			obj.areas = arg0;
			ToLua.SetBack(L, 1, obj);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index areas on a nil value" : e.Message);
		}
	}
}


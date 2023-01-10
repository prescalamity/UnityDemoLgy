﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_ComponentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Component), typeof(UnityEngine.Object), "Component");
		L.RegFunction("GetComponent", GetComponent);
		L.RegFunction("TryGetComponent", TryGetComponent);
		L.RegFunction("GetComponentInChildren", GetComponentInChildren);
		L.RegFunction("GetComponentsInChildren", GetComponentsInChildren);
		L.RegFunction("GetComponentInParent", GetComponentInParent);
		L.RegFunction("GetComponentsInParent", GetComponentsInParent);
		L.RegFunction("GetComponents", GetComponents);
		L.RegFunction("CompareTag", CompareTag);
		L.RegFunction("SendMessageUpwards", SendMessageUpwards);
		L.RegFunction("SendMessage", SendMessage);
		L.RegFunction("BroadcastMessage", BroadcastMessage);
		L.RegFunction("New", _CreateUnityEngine_Component);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("transform", get_transform, null);
		L.RegVar("gameObject", get_gameObject, null);
		L.RegVar("tag", get_tag, set_tag);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_Component(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Component obj = new UnityEngine.Component();
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Component.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(UnityEngine.Component);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.GetComponent");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
			System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
			UnityEngine.Component o = obj.GetComponent(arg0);
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
	static int TryGetComponent(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.TryGetComponent");
#endif
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
			System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
			UnityEngine.Component arg1 = null;
			bool o = obj.TryGetComponent(arg0, out arg1);
			LuaDLL.lua_pushboolean(L, o);
			ToLua.Push(L, arg1);
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
	static int GetComponentInChildren(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.GetComponentInChildren");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				UnityEngine.Component o = obj.GetComponentInChildren(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				UnityEngine.Component o = obj.GetComponentInChildren(arg0, arg1);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.GetComponentInChildren");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.GetComponentsInChildren");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				UnityEngine.Component[] o = obj.GetComponentsInChildren(arg0);
				ToLua.Push(L, o);
				int arrayLength = o.Length;
				LuaScriptMgr.Push(L, arrayLength);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 2;
			}
			else if (count == 3)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				UnityEngine.Component[] o = obj.GetComponentsInChildren(arg0, arg1);
				ToLua.Push(L, o);
				int arrayLength = o.Length;
				LuaScriptMgr.Push(L, arrayLength);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 2;
			}
			else
			{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.GetComponentsInChildren");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.GetComponentInParent");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				UnityEngine.Component o = obj.GetComponentInParent(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				UnityEngine.Component o = obj.GetComponentInParent(arg0, arg1);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.GetComponentInParent");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInParent(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.GetComponentsInParent");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				UnityEngine.Component[] o = obj.GetComponentsInParent(arg0);
				ToLua.Push(L, o);
				int arrayLength = o.Length;
				LuaScriptMgr.Push(L, arrayLength);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 2;
			}
			else if (count == 3)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				UnityEngine.Component[] o = obj.GetComponentsInParent(arg0, arg1);
				ToLua.Push(L, o);
				int arrayLength = o.Length;
				LuaScriptMgr.Push(L, arrayLength);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 2;
			}
			else
			{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.GetComponentsInParent");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponents(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.GetComponents");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				UnityEngine.Component[] o = obj.GetComponents(arg0);
				ToLua.Push(L, o);
				int arrayLength = o.Length;
				LuaScriptMgr.Push(L, arrayLength);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 2;
			}
			else if (count == 3)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				System.Collections.Generic.List<UnityEngine.Component> arg1 = (System.Collections.Generic.List<UnityEngine.Component>)ToLua.CheckObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Component>));
				obj.GetComponents(arg0, arg1);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.GetComponents");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.CompareTag");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.CompareTag(arg0);
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
	static int SendMessageUpwards(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.SendMessageUpwards");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				string arg0 = ToLua.CheckString(L, 2);
				obj.SendMessageUpwards(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(UnityEngine.SendMessageOptions)))
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 3);
				obj.SendMessageUpwards(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object)))
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.SendMessageUpwards(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 4)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				string arg0 = ToLua.CheckString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				UnityEngine.SendMessageOptions arg2 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 4);
				obj.SendMessageUpwards(arg0, arg1, arg2);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.SendMessageUpwards");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.SendMessage");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				string arg0 = ToLua.CheckString(L, 2);
				obj.SendMessage(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(UnityEngine.SendMessageOptions)))
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 3);
				obj.SendMessage(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object)))
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.SendMessage(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 4)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				string arg0 = ToLua.CheckString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				UnityEngine.SendMessageOptions arg2 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 4);
				obj.SendMessage(arg0, arg1, arg2);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.SendMessage");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.BroadcastMessage");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				string arg0 = ToLua.CheckString(L, 2);
				obj.BroadcastMessage(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(UnityEngine.SendMessageOptions)))
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 3);
				obj.BroadcastMessage(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Component), typeof(string), typeof(object)))
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.BroadcastMessage(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 4)
			{
				UnityEngine.Component obj = (UnityEngine.Component)ToLua.CheckObject(L, 1, typeof(UnityEngine.Component));
				string arg0 = ToLua.CheckString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				UnityEngine.SendMessageOptions arg2 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 4);
				obj.BroadcastMessage(arg0, arg1, arg2);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Component.BroadcastMessage");
			}
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
			//UIProfiler.Begin("UnityEngine.Component.op_Equality");
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
	static int get_transform(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.transform");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Component obj = (UnityEngine.Component)o;
			UnityEngine.Transform ret = obj.transform;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index transform on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameObject(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.gameObject");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Component obj = (UnityEngine.Component)o;
			UnityEngine.GameObject ret = obj.gameObject;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index gameObject on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tag(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.tag");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Component obj = (UnityEngine.Component)o;
			string ret = obj.tag;
			LuaDLL.lua_pushstring(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tag on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tag(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Component.tag");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.Component obj = (UnityEngine.Component)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.tag = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tag on a nil value" : e.Message);
		}
	}
}

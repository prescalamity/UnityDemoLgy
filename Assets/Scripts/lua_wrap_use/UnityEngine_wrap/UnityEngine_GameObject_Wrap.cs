//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_GameObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.GameObject), typeof(UnityEngine.Object), "GameObject");
		L.RegFunction("CreatePrimitive", CreatePrimitive);
		L.RegFunction("GetComponent", GetComponent);
		L.RegFunction("GetComponentInChildren", GetComponentInChildren);
		L.RegFunction("GetComponentInParent", GetComponentInParent);
		L.RegFunction("GetComponents", GetComponents);
		L.RegFunction("GetComponentsInChildren", GetComponentsInChildren);
		L.RegFunction("GetComponentsInParent", GetComponentsInParent);
		L.RegFunction("TryGetComponent", TryGetComponent);
		L.RegFunction("FindWithTag", FindWithTag);
		L.RegFunction("SendMessageUpwards", SendMessageUpwards);
		L.RegFunction("SendMessage", SendMessage);
		L.RegFunction("BroadcastMessage", BroadcastMessage);
		L.RegFunction("AddComponent", AddComponent);
		L.RegFunction("SetActive", SetActive);
		L.RegFunction("CompareTag", CompareTag);
		L.RegFunction("FindGameObjectWithTag", FindGameObjectWithTag);
		L.RegFunction("FindGameObjectsWithTag", FindGameObjectsWithTag);
		L.RegFunction("Find", Find);
		L.RegFunction("New", _CreateUnityEngine_GameObject);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("transform", get_transform, null);
		L.RegVar("layer", get_layer, set_layer);
		L.RegVar("activeSelf", get_activeSelf, null);
		L.RegVar("activeInHierarchy", get_activeInHierarchy, null);
		L.RegVar("isStatic", get_isStatic, set_isStatic);
		L.RegVar("tag", get_tag, set_tag);
		L.RegVar("scene", get_scene, null);
		L.RegVar("sceneCullingMask", get_sceneCullingMask, null);
		L.RegVar("gameObject", get_gameObject, null);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_GameObject(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.GameObject obj = new UnityEngine.GameObject();
				ToLua.Push(L, obj);
				return 1;
			}
			else if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				UnityEngine.GameObject obj = new UnityEngine.GameObject(arg0);
				ToLua.Push(L, obj);
				return 1;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Type[] arg1 = ToLua.CheckParamsObject<System.Type>(L, 2, count - 1);
				UnityEngine.GameObject obj = new UnityEngine.GameObject(arg0, arg1);
				ToLua.Push(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.GameObject.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(UnityEngine.GameObject);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreatePrimitive(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.CreatePrimitive");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.PrimitiveType arg0 = (UnityEngine.PrimitiveType)LuaDLL.luaL_checknumber(L, 1);
			UnityEngine.GameObject o = UnityEngine.GameObject.CreatePrimitive(arg0);
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
	static int GetComponent(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.GetComponent");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
	static int GetComponentInChildren(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.GetComponentInChildren");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentInChildren");
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
			//UIProfiler.Begin("UnityEngine.GameObject.GetComponentInParent");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentInParent");
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
			//UIProfiler.Begin("UnityEngine.GameObject.GetComponents");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponents");
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
			//UIProfiler.Begin("UnityEngine.GameObject.GetComponentsInChildren");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentsInChildren");
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
			//UIProfiler.Begin("UnityEngine.GameObject.GetComponentsInParent");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.GetComponentsInParent");
			}
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
			//UIProfiler.Begin("UnityEngine.GameObject.TryGetComponent");
#endif
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
	static int FindWithTag(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.FindWithTag");
#endif
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.GameObject o = UnityEngine.GameObject.FindWithTag(arg0);
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
	static int SendMessageUpwards(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.SendMessageUpwards");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				string arg0 = ToLua.CheckString(L, 2);
				obj.SendMessageUpwards(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(UnityEngine.SendMessageOptions)))
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 3);
				obj.SendMessageUpwards(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object)))
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.SendMessageUpwards");
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
			//UIProfiler.Begin("UnityEngine.GameObject.SendMessage");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				string arg0 = ToLua.CheckString(L, 2);
				obj.SendMessage(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(UnityEngine.SendMessageOptions)))
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 3);
				obj.SendMessage(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object)))
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.SendMessage");
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
			//UIProfiler.Begin("UnityEngine.GameObject.BroadcastMessage");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				string arg0 = ToLua.CheckString(L, 2);
				obj.BroadcastMessage(arg0);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(UnityEngine.SendMessageOptions)))
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checknumber(L, 3);
				obj.BroadcastMessage(arg0, arg1);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.GameObject), typeof(string), typeof(object)))
			{
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.ToObject(L, 1);
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
				UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.GameObject.BroadcastMessage");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddComponent(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.AddComponent");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
			UnityEngine.Component o = obj.AddComponent(arg0);
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
	static int SetActive(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.SetActive");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.SetActive(arg0);
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
	static int CompareTag(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.CompareTag");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
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
	static int FindGameObjectWithTag(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.FindGameObjectWithTag");
#endif
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.GameObject o = UnityEngine.GameObject.FindGameObjectWithTag(arg0);
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
	static int FindGameObjectsWithTag(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.FindGameObjectsWithTag");
#endif
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.GameObject[] o = UnityEngine.GameObject.FindGameObjectsWithTag(arg0);
			ToLua.Push(L, o);
			int arrayLength = o.Length;
			LuaScriptMgr.Push(L, arrayLength);
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
	static int Find(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.Find");
#endif
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.GameObject o = UnityEngine.GameObject.Find(arg0);
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
	static int op_Equality(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.op_Equality");
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
			//UIProfiler.Begin("UnityEngine.GameObject.transform");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
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
	static int get_layer(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.layer");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			int ret = obj.layer;
			LuaDLL.lua_pushinteger(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index layer on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeSelf(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.activeSelf");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			bool ret = obj.activeSelf;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index activeSelf on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeInHierarchy(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.activeInHierarchy");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			bool ret = obj.activeInHierarchy;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index activeInHierarchy on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isStatic(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.isStatic");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			bool ret = obj.isStatic;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isStatic on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tag(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.tag");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
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
	static int get_scene(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.scene");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			UnityEngine.SceneManagement.Scene ret = obj.scene;
			ToLua.PushValue(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index scene on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sceneCullingMask(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.sceneCullingMask");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			ulong ret = obj.sceneCullingMask;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sceneCullingMask on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameObject(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.gameObject");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
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
	static int set_layer(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.layer");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.layer = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index layer on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isStatic(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.isStatic");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isStatic = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isStatic on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tag(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.GameObject.tag");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.GameObject obj = (UnityEngine.GameObject)o;
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


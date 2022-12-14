//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Util), typeof(System.Object), "Util");
		L.RegFunction("JsonStringToDict", JsonStringToDict);
		L.RegFunction("AddLocalFilePrex", AddLocalFilePrex);
		L.RegFunction("GetWritablePath", GetWritablePath);
		L.RegFunction("New", _CreateUtil);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("m_data_path", get_m_data_path, set_m_data_path);
		L.RegVar("m_persistent_data_path", get_m_persistent_data_path, set_m_persistent_data_path);
		L.RegVar("m_streaming_assets_path", get_m_streaming_assets_path, set_m_streaming_assets_path);
		L.RegVar("m_android_loadfromfile_path", get_m_android_loadfromfile_path, set_m_android_loadfromfile_path);
		L.RegVar("m_temporary_cache_path", get_m_temporary_cache_path, set_m_temporary_cache_path);
		L.RegVar("m_lua_script_path", get_m_lua_script_path, set_m_lua_script_path);
		L.RegVar("sound_path", get_sound_path, set_sound_path);
		L.RegVar("lua_key_path", get_lua_key_path, set_lua_key_path);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUtil(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Util obj = new Util();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Util.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(Util);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int JsonStringToDict(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			System.Collections.Generic.Dictionary<string,string> o = Util.JsonStringToDict(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLocalFilePrex(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			string o = Util.AddLocalFilePrex(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetWritablePath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			string o = Util.GetWritablePath(arg0);
			LuaDLL.lua_pushstring(L, o);
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
	static int get_m_data_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.m_data_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_persistent_data_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.m_persistent_data_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_streaming_assets_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.m_streaming_assets_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_android_loadfromfile_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.m_android_loadfromfile_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_temporary_cache_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.m_temporary_cache_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_lua_script_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.m_lua_script_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sound_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.sound_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lua_key_path(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, Util.lua_key_path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_data_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.m_data_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_persistent_data_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.m_persistent_data_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_streaming_assets_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.m_streaming_assets_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_android_loadfromfile_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.m_android_loadfromfile_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_temporary_cache_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.m_temporary_cache_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_lua_script_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.m_lua_script_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sound_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.sound_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lua_key_path(IntPtr L)
	{
		try
		{
			string arg0 = ToLua.CheckString(L, 2);
			Util.lua_key_path = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}


﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class TMPro_TMP_Dropdown_OptionDataWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TMPro.TMP_Dropdown.OptionData), typeof(System.Object), "OptionData");
		L.RegFunction("New", _CreateTMPro_TMP_Dropdown_OptionData);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("text", get_text, set_text);
		L.RegVar("image", get_image, set_image);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTMPro_TMP_Dropdown_OptionData(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				TMPro.TMP_Dropdown.OptionData obj = new TMPro.TMP_Dropdown.OptionData();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string arg0 = ToLua.CheckString(L, 1);
				TMPro.TMP_Dropdown.OptionData obj = new TMPro.TMP_Dropdown.OptionData(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(UnityEngine.Sprite)))
			{
				UnityEngine.Sprite arg0 = (UnityEngine.Sprite)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Sprite));
				TMPro.TMP_Dropdown.OptionData obj = new TMPro.TMP_Dropdown.OptionData(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				UnityEngine.Sprite arg1 = (UnityEngine.Sprite)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Sprite));
				TMPro.TMP_Dropdown.OptionData obj = new TMPro.TMP_Dropdown.OptionData(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: TMPro.TMP_Dropdown.OptionData.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(TMPro.TMP_Dropdown.OptionData);

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
	static int get_text(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TMP_Dropdown.OptionData obj = (TMPro.TMP_Dropdown.OptionData)o;
			string ret = obj.text;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index text on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_image(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TMP_Dropdown.OptionData obj = (TMPro.TMP_Dropdown.OptionData)o;
			UnityEngine.Sprite ret = obj.image;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index image on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_text(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TMP_Dropdown.OptionData obj = (TMPro.TMP_Dropdown.OptionData)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.text = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index text on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_image(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			TMPro.TMP_Dropdown.OptionData obj = (TMPro.TMP_Dropdown.OptionData)o;
			UnityEngine.Sprite arg0 = (UnityEngine.Sprite)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Sprite));
			obj.image = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index image on a nil value" : e.Message);
		}
	}
}


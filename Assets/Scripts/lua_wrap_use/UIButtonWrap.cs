﻿////this source code was auto-generated by tolua#, do not modify it
//using System;
//using LuaInterface;

//public class UIButtonWrap
//{
//	public static void Register(LuaState L)
//	{
//		L.BeginClass(typeof(UIButton), typeof(UIWidgetContainer), "UIButton");
//		L.RegFunction("ClearAllEvent", ClearAllEvent);
//		L.RegFunction("EnableScale", EnableScale);
//		L.RegFunction("DisableScale", DisableScale);
//		L.RegFunction("BindClickEvent", BindClickEvent);
//		L.RegFunction("UnBindClickEvent", UnBindClickEvent);
//		L.RegFunction("BindPressEvent", BindPressEvent);
//		L.RegFunction("UnBindPressEvent", UnBindPressEvent);
//		L.RegFunction("BindPlaySoundEvent", BindPlaySoundEvent);
//		L.RegFunction("UnBindPlaySoundEvent", UnBindPlaySoundEvent);
//		L.RegFunction("BindReleaseEvent", BindReleaseEvent);
//		L.RegFunction("UnBindReleaseEvent", UnBindReleaseEvent);
//		L.RegFunction("Create", Create);
//		L.RegFunction("__eq", op_Equality);
//		L.RegFunction("__tostring", Lua_ToString);
//		L.RegVar("current", get_current, set_current);
//		L.RegVar("onPlayDefaultSound", get_onPlayDefaultSound, set_onPlayDefaultSound);
//		L.RegVar("pixelSnap", get_pixelSnap, set_pixelSnap);
//		L.RegVar("isReaponseClose", get_isReaponseClose, set_isReaponseClose);
//		L.RegVar("GlobalOpenReaponseClose", get_GlobalOpenReaponseClose, set_GlobalOpenReaponseClose);
//		L.RegVar("onClick", get_onClick, set_onClick);
//		L.RegVar("tweenScale", get_tweenScale, null);
//		L.RegVar("sprite", get_sprite, set_sprite);
//		L.RegVar("atlasName", get_atlasName, set_atlasName);
//		L.RegVar("ClickEvent", get_ClickEvent, set_ClickEvent);
//		L.RegVar("label", get_label, set_label);
//		L.RegVar("depth", get_depth, set_depth);
//		L.RegVar("LogicTag", get_LogicTag, set_LogicTag);
//		L.RegVar("isEnabled", get_isEnabled, set_isEnabled);
//		L.RegVar("normalSprite", get_normalSprite, set_normalSprite);
//		L.RegFunction("GetClassType", GetClassType);
//		L.EndClass();
//	}

//	static Type classType = typeof(UIButton);

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int GetClassType(IntPtr L)
//	{
//		ToLua.Push(L, classType);
//		return 1;
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int ClearAllEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.ClearAllEvent");
//#endif
//			ToLua.CheckArgsCount(L, 1);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			obj.ClearAllEvent();
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int EnableScale(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.EnableScale");
//#endif
//			ToLua.CheckArgsCount(L, 1);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			obj.EnableScale();
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int DisableScale(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.DisableScale");
//#endif
//			ToLua.CheckArgsCount(L, 1);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			obj.DisableScale();
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int BindClickEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.BindClickEvent");
//#endif
//			ToLua.CheckArgsCount(L, 2);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
//			obj.BindClickEvent(arg0);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int UnBindClickEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.UnBindClickEvent");
//#endif
//			ToLua.CheckArgsCount(L, 1);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			obj.UnBindClickEvent();
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int BindPressEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.BindPressEvent");
//#endif
//			ToLua.CheckArgsCount(L, 2);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
//			obj.BindPressEvent(arg0);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int UnBindPressEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.UnBindPressEvent");
//#endif
//			ToLua.CheckArgsCount(L, 1);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			obj.UnBindPressEvent();
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int BindPlaySoundEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.BindPlaySoundEvent");
//#endif
//			ToLua.CheckArgsCount(L, 2);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
//			obj.BindPlaySoundEvent(arg0);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int UnBindPlaySoundEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.UnBindPlaySoundEvent");
//#endif
//			ToLua.CheckArgsCount(L, 1);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			obj.UnBindPlaySoundEvent();
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int BindReleaseEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.BindReleaseEvent");
//#endif
//			ToLua.CheckArgsCount(L, 2);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
//			obj.BindReleaseEvent(arg0);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int UnBindReleaseEvent(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.UnBindReleaseEvent");
//#endif
//			ToLua.CheckArgsCount(L, 1);
//			UIButton obj = (UIButton)ToLua.CheckObject(L, 1, typeof(UIButton));
//			obj.UnBindReleaseEvent();
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int Create(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.Create");
//#endif
//			int count = LuaDLL.lua_gettop(L);

//			if (count == 1)
//			{
//				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.GameObject));
//				UIButton o = UIButton.Create(arg0);
//				ToLua.Push(L, o);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//				//UIProfiler.End();
//#endif
//				return 1;
//			}
//			else if (count == 8)
//			{
//				string arg0 = ToLua.CheckString(L, 1);
//				UnityEngine.GameObject arg1 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
//				string arg2 = ToLua.CheckString(L, 3);
//				string arg3 = ToLua.CheckString(L, 4);
//				string arg4 = ToLua.CheckString(L, 5);
//				int arg5 = (int)LuaDLL.luaL_checknumber(L, 6);
//				int arg6 = (int)LuaDLL.luaL_checknumber(L, 7);
//				bool arg7 = LuaDLL.luaL_checkboolean(L, 8);
//				UIButton o = UIButton.Create(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
//				ToLua.Push(L, o);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//				//UIProfiler.End();
//#endif
//				return 1;
//			}
//			else
//			{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//				return LuaDLL.luaL_throw(L, "invalid arguments to method: UIButton.Create");
//			}
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int op_Equality(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.op_Equality");
//#endif
//			ToLua.CheckArgsCount(L, 2);
//			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
//			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
//			bool o = arg0 == arg1;
//			LuaDLL.lua_pushboolean(L, o);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int Lua_ToString(IntPtr L)
//	{
//		object obj = ToLua.ToObject(L, 1);

//		if (obj != null)
//		{
//			LuaDLL.lua_pushstring(L, obj.ToString());
//		}
//		else
//		{
//			LuaDLL.lua_pushnil(L);
//		}

//		return 1;
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_current(IntPtr L)
//	{
//		ToLua.Push(L, UIButton.current);
//		return 1;
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_onPlayDefaultSound(IntPtr L)
//	{
//		ToLua.Push(L, UIButton.onPlayDefaultSound);
//		return 1;
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_pixelSnap(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.pixelSnap");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			bool ret = obj.pixelSnap;
//			LuaDLL.lua_pushboolean(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelSnap on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_isReaponseClose(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.isReaponseClose");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			bool ret = obj.isReaponseClose;
//			LuaDLL.lua_pushboolean(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isReaponseClose on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_GlobalOpenReaponseClose(IntPtr L)
//	{
//		LuaDLL.lua_pushboolean(L, UIButton.GlobalOpenReaponseClose);
//		return 1;
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_onClick(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.onClick");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			System.Collections.Generic.List<EventDelegate> ret = obj.onClick;
//			ToLua.PushObject(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index onClick on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_tweenScale(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.tweenScale");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			TweenScale ret = obj.tweenScale;
//			ToLua.Push(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tweenScale on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_sprite(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.sprite");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			UISprite ret = obj.sprite;
//			ToLua.Push(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sprite on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_atlasName(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.atlasName");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			string ret = obj.atlasName;
//			LuaDLL.lua_pushstring(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index atlasName on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_ClickEvent(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.ClickEvent");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			LuaInterface.LuaFunction ret = obj.ClickEvent;
//			ToLua.Push(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ClickEvent on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_label(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.label");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			UILabel ret = obj.label;
//			ToLua.Push(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index label on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_depth(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.depth");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			int ret = obj.depth;
//			LuaDLL.lua_pushinteger(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index depth on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_LogicTag(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.LogicTag");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			int ret = obj.LogicTag;
//			LuaDLL.lua_pushinteger(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index LogicTag on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_isEnabled(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.isEnabled");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			bool ret = obj.isEnabled;
//			LuaDLL.lua_pushboolean(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isEnabled on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int get_normalSprite(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.normalSprite");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			string ret = obj.normalSprite;
//			LuaDLL.lua_pushstring(L, ret);
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 1;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index normalSprite on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_current(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.current");
//#endif
//			UIButton arg0 = (UIButton)ToLua.CheckUnityObject(L, 2, typeof(UIButton));
//			UIButton.current = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_onPlayDefaultSound(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.onPlayDefaultSound");
//#endif
//			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
//			UIButton.onPlayDefaultSound = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_pixelSnap(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.pixelSnap");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
//			obj.pixelSnap = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelSnap on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_isReaponseClose(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.isReaponseClose");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
//			obj.isReaponseClose = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isReaponseClose on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_GlobalOpenReaponseClose(IntPtr L)
//	{
//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.GlobalOpenReaponseClose");
//#endif
//			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
//			UIButton.GlobalOpenReaponseClose = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_onClick(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.onClick");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			System.Collections.Generic.List<EventDelegate> arg0 = (System.Collections.Generic.List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<EventDelegate>));
//			obj.onClick = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index onClick on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_sprite(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.sprite");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			UISprite arg0 = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
//			obj.sprite = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sprite on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_atlasName(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.atlasName");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			string arg0 = ToLua.CheckString(L, 2);
//			obj.atlasName = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index atlasName on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_ClickEvent(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.ClickEvent");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
//			obj.ClickEvent = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ClickEvent on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_label(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.label");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			UILabel arg0 = (UILabel)ToLua.CheckUnityObject(L, 2, typeof(UILabel));
//			obj.label = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index label on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_depth(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.depth");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
//			obj.depth = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index depth on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_LogicTag(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.LogicTag");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
//			obj.LogicTag = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index LogicTag on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_isEnabled(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.isEnabled");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
//			obj.isEnabled = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isEnabled on a nil value" : e.Message);
//		}
//	}

//	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
//	static int set_normalSprite(IntPtr L)
//	{
//		object o = null;

//		try
//		{
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.Begin("UIButton.normalSprite");
//#endif
//			o = ToLua.ToObject(L, 1);
//			UIButton obj = (UIButton)o;
//			string arg0 = ToLua.CheckString(L, 2);
//			obj.normalSprite = arg0;
//#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
//			//UIProfiler.End();
//#endif
//			return 0;
//		}
//		catch(Exception e)
//		{
//			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index normalSprite on a nil value" : e.Message);
//		}
//	}
//}


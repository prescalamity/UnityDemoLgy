using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 手动定制 测试 wrap，不建议自动化清理
/// </summary>
public static class CustomWrap
{

	/// <summary>
	/// 测试注册给lua调用 类和函数，Debug.Log
	/// </summary>
	/// <param name="L"></param>
	public static void MyRegister(LuaState L)
	{
		L.BeginClass(typeof(Debug), typeof(System.Object), "Debug");

		L.RegFunction("Log", LuaLog);
		L.RegFunction("LogToUI", LogToUI);

		L.EndClass();


		L.BeginClass(typeof(PlatformAdapter), typeof(System.Object), "PlatformAdapter");

		L.RegFunction("CallPlatformFunc", CallPlatformFunc);

		L.EndClass();


		L.BeginClass(typeof(Main), typeof(System.Object), "Main");

		L.RegFunction("Instance_UiRootCanvas", Instance_UiRootCanvas);
		L.RegFunction("Instance_GoRoot", Instance_GoRoot);

		L.EndClass();



		L.BeginClass(typeof(Power), typeof(System.Object), "Power");

		L.RegFunction("GetElectricity", GetElectricity);
		L.RegFunction("GetCapacity", GetCapacity);
		L.RegFunction("GetVoltage", GetVoltage);
		L.RegFunction("GetBatteryRetain", GetBatteryRetain);
		L.RegFunction("GetApiDeltaTime", GetApiDeltaTime);

		L.EndClass();


	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetApiDeltaTime(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			double o = Power.deltaTime;
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBatteryRetain(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			float o = Power.batteryRetain;
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVoltage(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			float o = Power.voltage;
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCapacity(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			float o = Power.capacity;
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetElectricity(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			float o = Power.electricity;
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaLog(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg1 = ToLua.CheckString(L, 1);
			DLog.Log("[Lua] " + arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogToUI(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg1 = ToLua.CheckString(L, 1);
			DLog.LogToUI("[Lua] " + arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}

	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallPlatformFunc(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string arg0 = ToLua.CheckString(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			string arg2 = ToLua.CheckString(L, 3);
			string o = PlatformAdapter.CallPlatformFunc(arg0, arg1, arg2);
			LuaDLL.lua_pushstring(L, o);

			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instance_UiRootCanvas(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);

			UnityEngine.GameObject o = Main.Instance.UiRootCanvas;

            ToLua.Push(L, o);

			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instance_GoRoot(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);

			UnityEngine.GameObject o = Main.Instance.GoRoot;

			ToLua.Push(L, o);

			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

}

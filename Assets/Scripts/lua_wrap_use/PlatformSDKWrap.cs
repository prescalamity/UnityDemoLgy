//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class PlatformSDKWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PlatformSDK), typeof(Singleton<PlatformSDK>), "PlatformSDK");
		L.RegFunction("SetPauseCallback", SetPauseCallback);
		L.RegFunction("SetRebackCallback", SetRebackCallback);
		L.RegFunction("GetInstance", GetInstance);
		L.RegFunction("Free", Free);
		L.RegFunction("OpenLogin", OpenLogin);
		L.RegFunction("OpenYYBLogin", OpenYYBLogin);
		L.RegFunction("OpenPay", OpenPay);
		L.RegFunction("setUserInfo", setUserInfo);
		L.RegFunction("SendStatistic", SendStatistic);
		L.RegFunction("OpenUserPanel", OpenUserPanel);
		L.RegFunction("Logout", Logout);
		L.RegFunction("GetPlatForm", GetPlatForm);
		L.RegFunction("ShowLoadCircle", ShowLoadCircle);
		L.RegFunction("nativeLoginCallback", nativeLoginCallback);
		L.RegFunction("WebLog", WebLog);
		L.RegFunction("CheckClientUpdate", CheckClientUpdate);
		L.RegFunction("GetUserIPAddress", GetUserIPAddress);
		L.RegFunction("CallPlatformFunc", CallPlatformFunc);
		L.RegFunction("ReStartResourceUpdate", ReStartResourceUpdate);
		L.RegFunction("New", _CreatePlatformSDK);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePlatformSDK(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				PlatformSDK obj = new PlatformSDK();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: PlatformSDK.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	static Type classType = typeof(PlatformSDK);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPauseCallback(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.SetPauseCallback");
#endif
			ToLua.CheckArgsCount(L, 2);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.SetPauseCallback(arg0);
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
	static int SetRebackCallback(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.SetRebackCallback");
#endif
			ToLua.CheckArgsCount(L, 2);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.SetRebackCallback(arg0);
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
	static int GetInstance(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.GetInstance");
#endif
			ToLua.CheckArgsCount(L, 0);
			PlatformSDK o = PlatformSDK.GetInstance();
			ToLua.PushObject(L, o);
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
	static int Free(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.Free");
#endif
			ToLua.CheckArgsCount(L, 0);
			PlatformSDK.Free();
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
	static int OpenLogin(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.OpenLogin");
#endif
			ToLua.CheckArgsCount(L, 2);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.OpenLogin(arg0);
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
	static int OpenYYBLogin(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.OpenYYBLogin");
#endif
			ToLua.CheckArgsCount(L, 3);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaFunction arg1 = ToLua.CheckLuaFunction(L, 3);
			obj.OpenYYBLogin(arg0, arg1);
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
	static int OpenPay(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.OpenPay");
#endif
			ToLua.CheckArgsCount(L, 17);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 4);
			int arg3 = (int)LuaDLL.luaL_checknumber(L, 5);
			int arg4 = (int)LuaDLL.luaL_checknumber(L, 6);
			int arg5 = (int)LuaDLL.luaL_checknumber(L, 7);
			string arg6 = ToLua.CheckString(L, 8);
			string arg7 = ToLua.CheckString(L, 9);
			string arg8 = ToLua.CheckString(L, 10);
			string arg9 = ToLua.CheckString(L, 11);
			float arg10 = (float)LuaDLL.luaL_checknumber(L, 12);
			string arg11 = ToLua.CheckString(L, 13);
			string arg12 = ToLua.CheckString(L, 14);
			string arg13 = ToLua.CheckString(L, 15);
			string arg14 = ToLua.CheckString(L, 16);
			string arg15 = ToLua.CheckString(L, 17);
			obj.OpenPay(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
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
	static int setUserInfo(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.setUserInfo");
#endif
			ToLua.CheckArgsCount(L, 10);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 4);
			string arg3 = ToLua.CheckString(L, 5);
			string arg4 = ToLua.CheckString(L, 6);
			string arg5 = ToLua.CheckString(L, 7);
			string arg6 = ToLua.CheckString(L, 8);
			int arg7 = (int)LuaDLL.luaL_checknumber(L, 9);
			string arg8 = ToLua.CheckString(L, 10);
			obj.setUserInfo(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
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
	static int SendStatistic(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.SendStatistic");
#endif
			ToLua.CheckArgsCount(L, 3);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.SendStatistic(arg0, arg1);
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
	static int OpenUserPanel(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.OpenUserPanel");
#endif
			ToLua.CheckArgsCount(L, 1);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			obj.OpenUserPanel();
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
	static int Logout(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.Logout");
#endif
			ToLua.CheckArgsCount(L, 2);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			string arg0 = ToLua.CheckString(L, 2);
			obj.Logout(arg0);
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
	static int GetPlatForm(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.GetPlatForm");
#endif
			ToLua.CheckArgsCount(L, 1);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			bool o = obj.GetPlatForm();
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
	static int ShowLoadCircle(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.ShowLoadCircle");
#endif
			ToLua.CheckArgsCount(L, 2);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.ShowLoadCircle(arg0);
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
	static int nativeLoginCallback(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.nativeLoginCallback");
#endif
			ToLua.CheckArgsCount(L, 2);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			string arg0 = ToLua.CheckString(L, 2);
			obj.nativeLoginCallback(arg0);
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
	static int WebLog(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.WebLog");
#endif
			ToLua.CheckArgsCount(L, 2);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			string arg0 = ToLua.CheckString(L, 2);
			obj.WebLog(arg0);
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
	static int CheckClientUpdate(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.CheckClientUpdate");
#endif
			ToLua.CheckArgsCount(L, 1);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			bool o = obj.CheckClientUpdate();
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
	static int GetUserIPAddress(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.GetUserIPAddress");
#endif
			ToLua.CheckArgsCount(L, 1);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			string o = obj.GetUserIPAddress();
			LuaDLL.lua_pushstring(L, o);
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
	static int CallPlatformFunc(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.CallPlatformFunc");
#endif
			ToLua.CheckArgsCount(L, 4);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			string arg2 = ToLua.CheckString(L, 4);
			string o = obj.CallPlatformFunc(arg0, arg1, arg2);
			LuaDLL.lua_pushstring(L, o);
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
	static int ReStartResourceUpdate(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("PlatformSDK.ReStartResourceUpdate");
#endif
			ToLua.CheckArgsCount(L, 1);
			PlatformSDK obj = (PlatformSDK)ToLua.CheckObject(L, 1, typeof(PlatformSDK));
			obj.ReStartResourceUpdate();
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
}


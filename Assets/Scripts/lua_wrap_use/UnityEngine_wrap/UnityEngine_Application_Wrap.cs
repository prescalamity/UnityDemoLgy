﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_ApplicationWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("Application");
		L.RegFunction("Quit", Quit);
		L.RegFunction("Unload", Unload);
		L.RegFunction("CanStreamedLevelBeLoaded", CanStreamedLevelBeLoaded);
		L.RegFunction("IsPlaying", IsPlaying);
		L.RegFunction("GetBuildTags", GetBuildTags);
		L.RegFunction("SetBuildTags", SetBuildTags);
		L.RegFunction("HasProLicense", HasProLicense);
		L.RegFunction("RequestAdvertisingIdentifierAsync", RequestAdvertisingIdentifierAsync);
		L.RegFunction("OpenURL", OpenURL);
		L.RegFunction("GetStackTraceLogType", GetStackTraceLogType);
		L.RegFunction("SetStackTraceLogType", SetStackTraceLogType);
		L.RegFunction("RequestUserAuthorization", RequestUserAuthorization);
		L.RegFunction("HasUserAuthorization", HasUserAuthorization);
		L.RegVar("isPlaying", get_isPlaying, null);
		L.RegVar("isFocused", get_isFocused, null);
		L.RegVar("buildGUID", get_buildGUID, null);
		L.RegVar("runInBackground", get_runInBackground, set_runInBackground);
		L.RegVar("isBatchMode", get_isBatchMode, null);
		L.RegVar("dataPath", get_dataPath, null);
		L.RegVar("streamingAssetsPath", get_streamingAssetsPath, null);
		L.RegVar("persistentDataPath", get_persistentDataPath, null);
		L.RegVar("temporaryCachePath", get_temporaryCachePath, null);
		L.RegVar("absoluteURL", get_absoluteURL, null);
		L.RegVar("unityVersion", get_unityVersion, null);
		L.RegVar("version", get_version, null);
		L.RegVar("installerName", get_installerName, null);
		L.RegVar("identifier", get_identifier, null);
		L.RegVar("installMode", get_installMode, null);
		L.RegVar("sandboxType", get_sandboxType, null);
		L.RegVar("productName", get_productName, null);
		L.RegVar("companyName", get_companyName, null);
		L.RegVar("cloudProjectId", get_cloudProjectId, null);
		L.RegVar("targetFrameRate", get_targetFrameRate, set_targetFrameRate);
		L.RegVar("consoleLogPath", get_consoleLogPath, null);
		L.RegVar("backgroundLoadingPriority", get_backgroundLoadingPriority, set_backgroundLoadingPriority);
		L.RegVar("genuine", get_genuine, null);
		L.RegVar("genuineCheckAvailable", get_genuineCheckAvailable, null);
		L.RegVar("platform", get_platform, null);
		L.RegVar("isMobilePlatform", get_isMobilePlatform, null);
		L.RegVar("isConsolePlatform", get_isConsolePlatform, null);
		L.RegVar("systemLanguage", get_systemLanguage, null);
		L.RegVar("internetReachability", get_internetReachability, null);
		L.RegVar("isEditor", get_isEditor, null);
		L.RegVar("lowMemory", get_lowMemory, set_lowMemory);
		L.RegVar("logMessageReceived", get_logMessageReceived, set_logMessageReceived);
		L.RegVar("logMessageReceivedThreaded", get_logMessageReceivedThreaded, set_logMessageReceivedThreaded);
		L.RegVar("onBeforeRender", get_onBeforeRender, set_onBeforeRender);
		L.RegVar("focusChanged", get_focusChanged, set_focusChanged);
		L.RegVar("deepLinkActivated", get_deepLinkActivated, set_deepLinkActivated);
		L.RegVar("wantsToQuit", get_wantsToQuit, set_wantsToQuit);
		L.RegVar("quitting", get_quitting, set_quitting);
		L.RegVar("unloading", get_unloading, set_unloading);
		L.RegFunction("AdvertisingIdentifierCallback", UnityEngine_Application_AdvertisingIdentifierCallback);
		L.RegFunction("LogCallback", UnityEngine_Application_LogCallback);
		L.RegFunction("LowMemoryCallback", UnityEngine_Application_LowMemoryCallback);
		L.RegFunction("GetClassType", GetClassType);
		L.EndStaticLibs();
	}

	static Type classType = typeof(UnityEngine.Application);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Quit(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.Quit");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.Application.Quit();
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 0;
			}
			else if (count == 1)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				UnityEngine.Application.Quit(arg0);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.Quit");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Unload(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.Unload");
#endif
			ToLua.CheckArgsCount(L, 0);
			UnityEngine.Application.Unload();
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
	static int CanStreamedLevelBeLoaded(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.CanStreamedLevelBeLoaded");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				bool o = UnityEngine.Application.CanStreamedLevelBeLoaded(arg0);
				LuaDLL.lua_pushboolean(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string arg0 = ToLua.ToString(L, 1);
				bool o = UnityEngine.Application.CanStreamedLevelBeLoaded(arg0);
				LuaDLL.lua_pushboolean(L, o);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Application.CanStreamedLevelBeLoaded");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsPlaying(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.IsPlaying");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.CheckUnityObject(L, 1, typeof(UnityEngine.Object));
			bool o = UnityEngine.Application.IsPlaying(arg0);
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
	static int GetBuildTags(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.GetBuildTags");
#endif
			ToLua.CheckArgsCount(L, 0);
			string[] o = UnityEngine.Application.GetBuildTags();
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
	static int SetBuildTags(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.SetBuildTags");
#endif
			ToLua.CheckArgsCount(L, 1);
			string[] arg0 = ToLua.CheckStringArray(L, 1);
			UnityEngine.Application.SetBuildTags(arg0);
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
	static int HasProLicense(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.HasProLicense");
#endif
			ToLua.CheckArgsCount(L, 0);
			bool o = UnityEngine.Application.HasProLicense();
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
	static int RequestAdvertisingIdentifierAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.RequestAdvertisingIdentifierAsync");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Application.AdvertisingIdentifierCallback arg0 = null;
			LuaTypes funcType1 = LuaDLL.lua_type(L, 1);

			if (funcType1 != LuaTypes.LUA_TFUNCTION)
			{
				 arg0 = (UnityEngine.Application.AdvertisingIdentifierCallback)ToLua.CheckObject(L, 1, typeof(UnityEngine.Application.AdvertisingIdentifierCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 1);
				arg0 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Application.AdvertisingIdentifierCallback), func) as UnityEngine.Application.AdvertisingIdentifierCallback;
			}

			bool o = UnityEngine.Application.RequestAdvertisingIdentifierAsync(arg0);
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
	static int OpenURL(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.OpenURL");
#endif
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.Application.OpenURL(arg0);
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
	static int GetStackTraceLogType(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.GetStackTraceLogType");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.LogType arg0 = (UnityEngine.LogType)LuaDLL.luaL_checknumber(L, 1);
			UnityEngine.StackTraceLogType o = UnityEngine.Application.GetStackTraceLogType(arg0);
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
	static int SetStackTraceLogType(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.SetStackTraceLogType");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.LogType arg0 = (UnityEngine.LogType)LuaDLL.luaL_checknumber(L, 1);
			UnityEngine.StackTraceLogType arg1 = (UnityEngine.StackTraceLogType)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Application.SetStackTraceLogType(arg0, arg1);
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
	static int RequestUserAuthorization(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.RequestUserAuthorization");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UserAuthorization arg0 = (UnityEngine.UserAuthorization)LuaDLL.luaL_checknumber(L, 1);
			UnityEngine.AsyncOperation o = UnityEngine.Application.RequestUserAuthorization(arg0);
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
	static int HasUserAuthorization(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.HasUserAuthorization");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UserAuthorization arg0 = (UnityEngine.UserAuthorization)LuaDLL.luaL_checknumber(L, 1);
			bool o = UnityEngine.Application.HasUserAuthorization(arg0);
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
	static int get_isPlaying(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFocused(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.isFocused);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buildGUID(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.buildGUID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_runInBackground(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.runInBackground);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isBatchMode(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.isBatchMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dataPath(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.dataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingAssetsPath(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.streamingAssetsPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_persistentDataPath(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.persistentDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_temporaryCachePath(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.temporaryCachePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_absoluteURL(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.absoluteURL);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unityVersion(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.unityVersion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_version(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.version);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_installerName(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.installerName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_identifier(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.identifier);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_installMode(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Application.installMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sandboxType(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Application.sandboxType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_productName(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.productName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_companyName(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.companyName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cloudProjectId(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.cloudProjectId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetFrameRate(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.Application.targetFrameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_consoleLogPath(IntPtr L)
	{
		LuaDLL.lua_pushstring(L, UnityEngine.Application.consoleLogPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backgroundLoadingPriority(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Application.backgroundLoadingPriority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_genuine(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.genuine);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_genuineCheckAvailable(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.genuineCheckAvailable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_platform(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Application.platform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isMobilePlatform(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.isMobilePlatform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isConsolePlatform(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.isConsolePlatform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_systemLanguage(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Application.systemLanguage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_internetReachability(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.Application.internetReachability);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isEditor(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.Application.isEditor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lowMemory(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.lowMemory"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_logMessageReceived(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.logMessageReceived"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_logMessageReceivedThreaded(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.logMessageReceivedThreaded"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onBeforeRender(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.onBeforeRender"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_focusChanged(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.focusChanged"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deepLinkActivated(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.deepLinkActivated"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wantsToQuit(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.wantsToQuit"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_quitting(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.quitting"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unloading(IntPtr L)
	{
		ToLua.Push(L, new EventObject("UnityEngine.Application.unloading"));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_runInBackground(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.runInBackground");
#endif
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.Application.runInBackground = arg0;
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
	static int set_targetFrameRate(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.targetFrameRate");
#endif
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Application.targetFrameRate = arg0;
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
	static int set_backgroundLoadingPriority(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.Application.backgroundLoadingPriority");
#endif
			UnityEngine.ThreadPriority arg0 = (UnityEngine.ThreadPriority)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Application.backgroundLoadingPriority = arg0;
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
	static int set_lowMemory(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.lowMemory' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				UnityEngine.Application.LowMemoryCallback ev = (UnityEngine.Application.LowMemoryCallback)DelegateFactory.CreateDelegate(typeof(UnityEngine.Application.LowMemoryCallback), arg0.func);
				UnityEngine.Application.lowMemory += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				UnityEngine.Application.LowMemoryCallback ev = (UnityEngine.Application.LowMemoryCallback)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "lowMemory");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (UnityEngine.Application.LowMemoryCallback)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.lowMemory -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_logMessageReceived(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.logMessageReceived' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				UnityEngine.Application.LogCallback ev = (UnityEngine.Application.LogCallback)DelegateFactory.CreateDelegate(typeof(UnityEngine.Application.LogCallback), arg0.func);
				UnityEngine.Application.logMessageReceived += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				UnityEngine.Application.LogCallback ev = (UnityEngine.Application.LogCallback)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "logMessageReceived");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (UnityEngine.Application.LogCallback)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.logMessageReceived -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_logMessageReceivedThreaded(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.logMessageReceivedThreaded' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				UnityEngine.Application.LogCallback ev = (UnityEngine.Application.LogCallback)DelegateFactory.CreateDelegate(typeof(UnityEngine.Application.LogCallback), arg0.func);
				UnityEngine.Application.logMessageReceivedThreaded += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				UnityEngine.Application.LogCallback ev = (UnityEngine.Application.LogCallback)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "logMessageReceivedThreaded");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (UnityEngine.Application.LogCallback)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.logMessageReceivedThreaded -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onBeforeRender(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.onBeforeRender' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				UnityEngine.Events.UnityAction ev = (UnityEngine.Events.UnityAction)DelegateFactory.CreateDelegate(typeof(UnityEngine.Events.UnityAction), arg0.func);
				UnityEngine.Application.onBeforeRender += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				UnityEngine.Events.UnityAction ev = (UnityEngine.Events.UnityAction)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "onBeforeRender");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (UnityEngine.Events.UnityAction)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.onBeforeRender -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_focusChanged(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.focusChanged' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				System.Action<bool> ev = (System.Action<bool>)DelegateFactory.CreateDelegate(typeof(System.Action<bool>), arg0.func);
				UnityEngine.Application.focusChanged += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				System.Action<bool> ev = (System.Action<bool>)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "focusChanged");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (System.Action<bool>)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.focusChanged -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_deepLinkActivated(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.deepLinkActivated' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				System.Action<string> ev = (System.Action<string>)DelegateFactory.CreateDelegate(typeof(System.Action<string>), arg0.func);
				UnityEngine.Application.deepLinkActivated += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				System.Action<string> ev = (System.Action<string>)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "deepLinkActivated");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (System.Action<string>)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.deepLinkActivated -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wantsToQuit(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.wantsToQuit' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				System.Func<bool> ev = (System.Func<bool>)DelegateFactory.CreateDelegate(typeof(System.Func<bool>), arg0.func);
				UnityEngine.Application.wantsToQuit += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				System.Func<bool> ev = (System.Func<bool>)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "wantsToQuit");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (System.Func<bool>)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.wantsToQuit -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_quitting(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.quitting' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				System.Action ev = (System.Action)DelegateFactory.CreateDelegate(typeof(System.Action), arg0.func);
				UnityEngine.Application.quitting += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				System.Action ev = (System.Action)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "quitting");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (System.Action)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.quitting -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_unloading(IntPtr L)
	{
		try
		{
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'UnityEngine.Application.unloading' can only appear on the left hand side of += or -= when used outside of the type 'UnityEngine.Application'");
			}

			if (arg0.op == EventOp.Add)
			{
				System.Action ev = (System.Action)DelegateFactory.CreateDelegate(typeof(System.Action), arg0.func);
				UnityEngine.Application.unloading += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				System.Action ev = (System.Action)LuaMisc.GetEventHandler(null, typeof(UnityEngine.Application), "unloading");
				Delegate[] ds = ev.GetInvocationList();
				LuaState state = LuaState.Get(L);

				for (int i = 0; i < ds.Length; i++)
				{
					ev = (System.Action)ds[i];
					LuaDelegate ld = ev.Target as LuaDelegate;

					if (ld != null && ld.func == arg0.func)
					{
						UnityEngine.Application.unloading -= ev;
						state.DelayDispose(ld.func);
						break;
					}
				}

				arg0.func.Dispose();
			}

			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Application_AdvertisingIdentifierCallback(IntPtr L)
	{
		try
		{
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			Delegate arg1 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Application.AdvertisingIdentifierCallback), func);
			ToLua.Push(L, arg1);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Application_LogCallback(IntPtr L)
	{
		try
		{
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			Delegate arg1 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Application.LogCallback), func);
			ToLua.Push(L, arg1);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Application_LowMemoryCallback(IntPtr L)
	{
		try
		{
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			Delegate arg1 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Application.LowMemoryCallback), func);
			ToLua.Push(L, arg1);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}


//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_AssetBundleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AssetBundle), typeof(UnityEngine.Object), "AssetBundle");
		L.RegFunction("UnloadAllAssetBundles", UnloadAllAssetBundles);
		L.RegFunction("GetAllLoadedAssetBundles", GetAllLoadedAssetBundles);
		L.RegFunction("LoadFromFileAsync", LoadFromFileAsync);
		L.RegFunction("LoadFromFile", LoadFromFile);
		L.RegFunction("LoadFromMemoryAsync", LoadFromMemoryAsync);
		L.RegFunction("LoadFromMemory", LoadFromMemory);
		L.RegFunction("LoadFromStreamAsync", LoadFromStreamAsync);
		L.RegFunction("LoadFromStream", LoadFromStream);
		L.RegFunction("Contains", Contains);
		L.RegFunction("LoadAsset", LoadAsset);
		L.RegFunction("LoadAssetAsync", LoadAssetAsync);
		L.RegFunction("LoadAssetWithSubAssets", LoadAssetWithSubAssets);
		L.RegFunction("LoadAssetWithSubAssetsAsync", LoadAssetWithSubAssetsAsync);
		L.RegFunction("LoadAllAssets", LoadAllAssets);
		L.RegFunction("LoadAllAssetsAsync", LoadAllAssetsAsync);
		L.RegFunction("Unload", Unload);
		L.RegFunction("UnloadAsync", UnloadAsync);
		L.RegFunction("GetAllAssetNames", GetAllAssetNames);
		L.RegFunction("GetAllScenePaths", GetAllScenePaths);
		L.RegFunction("RecompressAssetBundleAsync", RecompressAssetBundleAsync);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("isStreamedSceneAssetBundle", get_isStreamedSceneAssetBundle, null);
		L.RegVar("memoryBudgetKB", get_memoryBudgetKB, set_memoryBudgetKB);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	static Type classType = typeof(UnityEngine.AssetBundle);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadAllAssetBundles(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.UnloadAllAssetBundles");
#endif
			ToLua.CheckArgsCount(L, 1);
			bool arg0 = LuaDLL.luaL_checkboolean(L, 1);
			UnityEngine.AssetBundle.UnloadAllAssetBundles(arg0);
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
	static int GetAllLoadedAssetBundles(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.GetAllLoadedAssetBundles");
#endif
			ToLua.CheckArgsCount(L, 0);
			System.Collections.Generic.IEnumerable<UnityEngine.AssetBundle> o = UnityEngine.AssetBundle.GetAllLoadedAssetBundles();
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
	static int LoadFromFileAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadFromFileAsync");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromFileAsync(arg0);
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromFileAsync(arg0, arg1);
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				string arg0 = ToLua.CheckString(L, 1);
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				ulong arg2 = (ulong)LuaDLL.luaL_checknumber(L, 3);
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromFileAsync(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromFileAsync");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromFile(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadFromFile");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromFile(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromFile(arg0, arg1);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				string arg0 = ToLua.CheckString(L, 1);
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				ulong arg2 = (ulong)LuaDLL.luaL_checknumber(L, 3);
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromFile(arg0, arg1, arg2);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromFile");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromMemoryAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadFromMemoryAsync");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromMemoryAsync(arg0);
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 2)
			{
				byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromMemoryAsync(arg0, arg1);
				ToLua.PushObject(L, o);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromMemoryAsync");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromMemory(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadFromMemory");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromMemory(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 2)
			{
				byte[] arg0 = ToLua.CheckByteBuffer(L, 1);
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromMemory(arg0, arg1);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromMemory");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromStreamAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadFromStreamAsync");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				System.IO.Stream arg0 = (System.IO.Stream)ToLua.CheckObject(L, 1, typeof(System.IO.Stream));
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromStreamAsync(arg0);
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 2)
			{
				System.IO.Stream arg0 = (System.IO.Stream)ToLua.CheckObject(L, 1, typeof(System.IO.Stream));
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromStreamAsync(arg0, arg1);
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				System.IO.Stream arg0 = (System.IO.Stream)ToLua.CheckObject(L, 1, typeof(System.IO.Stream));
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				uint arg2 = (uint)LuaDLL.luaL_checknumber(L, 3);
				UnityEngine.AssetBundleCreateRequest o = UnityEngine.AssetBundle.LoadFromStreamAsync(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromStreamAsync");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFromStream(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadFromStream");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				System.IO.Stream arg0 = (System.IO.Stream)ToLua.CheckObject(L, 1, typeof(System.IO.Stream));
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromStream(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 2)
			{
				System.IO.Stream arg0 = (System.IO.Stream)ToLua.CheckObject(L, 1, typeof(System.IO.Stream));
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromStream(arg0, arg1);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				System.IO.Stream arg0 = (System.IO.Stream)ToLua.CheckObject(L, 1, typeof(System.IO.Stream));
				uint arg1 = (uint)LuaDLL.luaL_checknumber(L, 2);
				uint arg2 = (uint)LuaDLL.luaL_checknumber(L, 3);
				UnityEngine.AssetBundle o = UnityEngine.AssetBundle.LoadFromStream(arg0, arg1, arg2);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadFromStream");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.Contains");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.Contains(arg0);
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
	static int LoadAsset(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadAsset");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				UnityEngine.Object o = obj.LoadAsset(arg0);
				ToLua.Push(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				System.Type arg1 = (System.Type)ToLua.CheckObject(L, 3, typeof(System.Type));
				UnityEngine.Object o = obj.LoadAsset(arg0, arg1);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAsset");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadAssetAsync");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				UnityEngine.AssetBundleRequest o = obj.LoadAssetAsync(arg0);
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				System.Type arg1 = (System.Type)ToLua.CheckObject(L, 3, typeof(System.Type));
				UnityEngine.AssetBundleRequest o = obj.LoadAssetAsync(arg0, arg1);
				ToLua.PushObject(L, o);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAssetAsync");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetWithSubAssets(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadAssetWithSubAssets");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				UnityEngine.Object[] o = obj.LoadAssetWithSubAssets(arg0);
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
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				System.Type arg1 = (System.Type)ToLua.CheckObject(L, 3, typeof(System.Type));
				UnityEngine.Object[] o = obj.LoadAssetWithSubAssets(arg0, arg1);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAssetWithSubAssets");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetWithSubAssetsAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadAssetWithSubAssetsAsync");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				UnityEngine.AssetBundleRequest o = obj.LoadAssetWithSubAssetsAsync(arg0);
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 3)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				string arg0 = ToLua.CheckString(L, 2);
				System.Type arg1 = (System.Type)ToLua.CheckObject(L, 3, typeof(System.Type));
				UnityEngine.AssetBundleRequest o = obj.LoadAssetWithSubAssetsAsync(arg0, arg1);
				ToLua.PushObject(L, o);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAssetWithSubAssetsAsync");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAllAssets(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadAllAssets");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				UnityEngine.Object[] o = obj.LoadAllAssets();
				ToLua.Push(L, o);
				int arrayLength = o.Length;
				LuaScriptMgr.Push(L, arrayLength);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 2;
			}
			else if (count == 2)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				UnityEngine.Object[] o = obj.LoadAllAssets(arg0);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAllAssets");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAllAssetsAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.LoadAllAssetsAsync");
#endif
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				UnityEngine.AssetBundleRequest o = obj.LoadAllAssetsAsync();
				ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
				//UIProfiler.End();
#endif
				return 1;
			}
			else if (count == 2)
			{
				UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
				System.Type arg0 = (System.Type)ToLua.CheckObject(L, 2, typeof(System.Type));
				UnityEngine.AssetBundleRequest o = obj.LoadAllAssetsAsync(arg0);
				ToLua.PushObject(L, o);
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
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.AssetBundle.LoadAllAssetsAsync");
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
			//UIProfiler.Begin("UnityEngine.AssetBundle.Unload");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.Unload(arg0);
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
	static int UnloadAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.UnloadAsync");
#endif
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.AsyncOperation o = obj.UnloadAsync(arg0);
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
	static int GetAllAssetNames(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.GetAllAssetNames");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
			string[] o = obj.GetAllAssetNames();
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
	static int GetAllScenePaths(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.GetAllScenePaths");
#endif
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)ToLua.CheckObject(L, 1, typeof(UnityEngine.AssetBundle));
			string[] o = obj.GetAllScenePaths();
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
	static int RecompressAssetBundleAsync(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.RecompressAssetBundleAsync");
#endif
			ToLua.CheckArgsCount(L, 5);
			string arg0 = ToLua.CheckString(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			UnityEngine.BuildCompression arg2 = StackTraits<UnityEngine.BuildCompression>.Check(L, 3);
			uint arg3 = (uint)LuaDLL.luaL_checknumber(L, 4);
			UnityEngine.ThreadPriority arg4 = (UnityEngine.ThreadPriority)LuaDLL.luaL_checknumber(L, 5);
			UnityEngine.AssetBundleRecompressOperation o = UnityEngine.AssetBundle.RecompressAssetBundleAsync(arg0, arg1, arg2, arg3, arg4);
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
	static int op_Equality(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.op_Equality");
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
	static int get_isStreamedSceneAssetBundle(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.isStreamedSceneAssetBundle");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.AssetBundle obj = (UnityEngine.AssetBundle)o;
			bool ret = obj.isStreamedSceneAssetBundle;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isStreamedSceneAssetBundle on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_memoryBudgetKB(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.AssetBundle.memoryBudgetKB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_memoryBudgetKB(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.AssetBundle.memoryBudgetKB");
#endif
			uint arg0 = (uint)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.AssetBundle.memoryBudgetKB = arg0;
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
}


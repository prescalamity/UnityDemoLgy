//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_RenderSettingsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("RenderSettings");
		L.RegFunction("__eq", op_Equality);
		L.RegVar("fog", get_fog, set_fog);
		L.RegVar("fogStartDistance", get_fogStartDistance, set_fogStartDistance);
		L.RegVar("fogEndDistance", get_fogEndDistance, set_fogEndDistance);
		L.RegVar("fogMode", get_fogMode, set_fogMode);
		L.RegVar("fogColor", get_fogColor, set_fogColor);
		L.RegVar("fogDensity", get_fogDensity, set_fogDensity);
		L.RegVar("ambientMode", get_ambientMode, set_ambientMode);
		L.RegVar("ambientSkyColor", get_ambientSkyColor, set_ambientSkyColor);
		L.RegVar("ambientEquatorColor", get_ambientEquatorColor, set_ambientEquatorColor);
		L.RegVar("ambientGroundColor", get_ambientGroundColor, set_ambientGroundColor);
		L.RegVar("ambientIntensity", get_ambientIntensity, set_ambientIntensity);
		L.RegVar("ambientLight", get_ambientLight, set_ambientLight);
		L.RegVar("subtractiveShadowColor", get_subtractiveShadowColor, set_subtractiveShadowColor);
		L.RegVar("skybox", get_skybox, set_skybox);
		L.RegVar("sun", get_sun, set_sun);
		L.RegVar("ambientProbe", get_ambientProbe, set_ambientProbe);
		L.RegVar("customReflection", get_customReflection, set_customReflection);
		L.RegVar("reflectionIntensity", get_reflectionIntensity, set_reflectionIntensity);
		L.RegVar("reflectionBounces", get_reflectionBounces, set_reflectionBounces);
		L.RegVar("defaultReflectionMode", get_defaultReflectionMode, set_defaultReflectionMode);
		L.RegVar("defaultReflectionResolution", get_defaultReflectionResolution, set_defaultReflectionResolution);
		L.RegVar("haloStrength", get_haloStrength, set_haloStrength);
		L.RegVar("flareStrength", get_flareStrength, set_flareStrength);
		L.RegVar("flareFadeSpeed", get_flareFadeSpeed, set_flareFadeSpeed);
		L.RegFunction("GetClassType", GetClassType);
		L.EndStaticLibs();
	}

	static Type classType = typeof(UnityEngine.RenderSettings);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.op_Equality");
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
	static int get_fog(IntPtr L)
	{
		LuaDLL.lua_pushboolean(L, UnityEngine.RenderSettings.fog);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogStartDistance(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.fogStartDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogEndDistance(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.fogEndDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogMode(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.fogMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogColor(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.fogColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogDensity(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.fogDensity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientMode(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.ambientMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientSkyColor(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.ambientSkyColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientEquatorColor(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.ambientEquatorColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientGroundColor(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.ambientGroundColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientIntensity(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.ambientIntensity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientLight(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.ambientLight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_subtractiveShadowColor(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.subtractiveShadowColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skybox(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.skybox);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sun(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.sun);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientProbe(IntPtr L)
	{
		ToLua.PushValue(L, UnityEngine.RenderSettings.ambientProbe);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_customReflection(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.customReflection);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reflectionIntensity(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.reflectionIntensity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reflectionBounces(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.RenderSettings.reflectionBounces);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultReflectionMode(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.RenderSettings.defaultReflectionMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultReflectionResolution(IntPtr L)
	{
		LuaDLL.lua_pushinteger(L, UnityEngine.RenderSettings.defaultReflectionResolution);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_haloStrength(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.haloStrength);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flareStrength(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.flareStrength);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flareFadeSpeed(IntPtr L)
	{
		LuaDLL.lua_pushnumber(L, UnityEngine.RenderSettings.flareFadeSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fog(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.fog");
#endif
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.RenderSettings.fog = arg0;
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
	static int set_fogStartDistance(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.fogStartDistance");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.fogStartDistance = arg0;
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
	static int set_fogEndDistance(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.fogEndDistance");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.fogEndDistance = arg0;
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
	static int set_fogMode(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.fogMode");
#endif
			UnityEngine.FogMode arg0 = (UnityEngine.FogMode)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.fogMode = arg0;
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
	static int set_fogColor(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.fogColor");
#endif
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			UnityEngine.RenderSettings.fogColor = arg0;
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
	static int set_fogDensity(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.fogDensity");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.fogDensity = arg0;
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
	static int set_ambientMode(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.ambientMode");
#endif
			UnityEngine.Rendering.AmbientMode arg0 = (UnityEngine.Rendering.AmbientMode)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.ambientMode = arg0;
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
	static int set_ambientSkyColor(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.ambientSkyColor");
#endif
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			UnityEngine.RenderSettings.ambientSkyColor = arg0;
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
	static int set_ambientEquatorColor(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.ambientEquatorColor");
#endif
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			UnityEngine.RenderSettings.ambientEquatorColor = arg0;
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
	static int set_ambientGroundColor(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.ambientGroundColor");
#endif
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			UnityEngine.RenderSettings.ambientGroundColor = arg0;
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
	static int set_ambientIntensity(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.ambientIntensity");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.ambientIntensity = arg0;
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
	static int set_ambientLight(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.ambientLight");
#endif
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			UnityEngine.RenderSettings.ambientLight = arg0;
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
	static int set_subtractiveShadowColor(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.subtractiveShadowColor");
#endif
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			UnityEngine.RenderSettings.subtractiveShadowColor = arg0;
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
	static int set_skybox(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.skybox");
#endif
			UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Material));
			UnityEngine.RenderSettings.skybox = arg0;
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
	static int set_sun(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.sun");
#endif
			UnityEngine.Light arg0 = (UnityEngine.Light)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Light));
			UnityEngine.RenderSettings.sun = arg0;
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
	static int set_ambientProbe(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.ambientProbe");
#endif
			UnityEngine.Rendering.SphericalHarmonicsL2 arg0 = StackTraits<UnityEngine.Rendering.SphericalHarmonicsL2>.Check(L, 2);
			UnityEngine.RenderSettings.ambientProbe = arg0;
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
	static int set_customReflection(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.customReflection");
#endif
			UnityEngine.Texture arg0 = (UnityEngine.Texture)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Texture));
			UnityEngine.RenderSettings.customReflection = arg0;
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
	static int set_reflectionIntensity(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.reflectionIntensity");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.reflectionIntensity = arg0;
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
	static int set_reflectionBounces(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.reflectionBounces");
#endif
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.reflectionBounces = arg0;
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
	static int set_defaultReflectionMode(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.defaultReflectionMode");
#endif
			UnityEngine.Rendering.DefaultReflectionMode arg0 = (UnityEngine.Rendering.DefaultReflectionMode)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.defaultReflectionMode = arg0;
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
	static int set_defaultReflectionResolution(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.defaultReflectionResolution");
#endif
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.defaultReflectionResolution = arg0;
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
	static int set_haloStrength(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.haloStrength");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.haloStrength = arg0;
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
	static int set_flareStrength(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.flareStrength");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.flareStrength = arg0;
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
	static int set_flareFadeSpeed(IntPtr L)
	{
		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.RenderSettings.flareFadeSpeed");
#endif
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.RenderSettings.flareFadeSpeed = arg0;
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


﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Singleton_IflytekVoiceHelperWrap
{
    public static void Register(LuaState L)
    {
        L.BeginClass(typeof(Singleton<IflytekVoiceHelper>), typeof(System.Object), "Singleton_IflytekVoiceHelper");
        L.RegFunction("GetInstance", GetInstance);
        L.RegFunction("CreateInstance", CreateInstance);
        L.RegFunction("DestroyInstance", DestroyInstance);
        L.RegFunction("New", _CreateSingleton_IflytekVoiceHelper);
        L.RegFunction("__tostring", Lua_ToString);
        L.RegVar("Instance", get_Instance, null);
        L.RegFunction("GetClassType", GetClassType);
        L.EndClass();
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int _CreateSingleton_IflytekVoiceHelper(IntPtr L)
    {
        try
        {
            int count = LuaDLL.lua_gettop(L);

            if (count == 0)
            {
                Singleton<IflytekVoiceHelper> obj = new Singleton<IflytekVoiceHelper>();
                ToLua.PushObject(L, obj);
                return 1;
            }
            else
            {
                return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Singleton<IflytekVoiceHelper>.New");
            }
        }
        catch (Exception e)
        {
            return LuaDLL.toluaL_exception(L, e);
        }
    }

    static Type classType = typeof(Singleton<IflytekVoiceHelper>);

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetClassType(IntPtr L)
    {
        ToLua.Push(L, classType);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetInstance(IntPtr L)
    {
        try
        {
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
            //UIProfiler.Begin("Singleton<IflytekVoiceHelper>.GetInstance");
#endif
            int count = LuaDLL.lua_gettop(L);

            if (count == 0)
            {
                IflytekVoiceHelper o = Singleton<IflytekVoiceHelper>.GetInstance();
                ToLua.PushObject(L, o);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
                //UIProfiler.End();
#endif
                return 1;
            }
            else if (count == 1)
            {
                int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
                IflytekVoiceHelper o = Singleton<IflytekVoiceHelper>.GetInstance(arg0);
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
                return LuaDLL.luaL_throw(L, "invalid arguments to method: Singleton<IflytekVoiceHelper>.GetInstance");
            }
        }
        catch (Exception e)
        {
            return LuaDLL.toluaL_exception(L, e);
        }
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int CreateInstance(IntPtr L)
    {
        try
        {
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
            //UIProfiler.Begin("Singleton<IflytekVoiceHelper>.CreateInstance");
#endif
            ToLua.CheckArgsCount(L, 0);
            Singleton<IflytekVoiceHelper>.CreateInstance();
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
            //UIProfiler.End();
#endif
            return 0;
        }
        catch (Exception e)
        {
            return LuaDLL.toluaL_exception(L, e);
        }
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int DestroyInstance(IntPtr L)
    {
        try
        {
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
            //UIProfiler.Begin("Singleton<IflytekVoiceHelper>.DestroyInstance");
#endif
            ToLua.CheckArgsCount(L, 0);
            Singleton<IflytekVoiceHelper>.DestroyInstance();
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
            //UIProfiler.End();
#endif
            return 0;
        }
        catch (Exception e)
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
    static int get_Instance(IntPtr L)
    {
        ToLua.PushObject(L, Singleton<IflytekVoiceHelper>.Instance);
        return 1;
    }
}

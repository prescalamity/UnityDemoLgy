//#define MULTI_STATE
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using System.Collections;
using Debug = UnityEngine.Debug;

//using Debugger = System.Diagnostics.Debugger;

//using SimpleFramework;

public class LuaScriptMgr
{
    private static LuaScriptMgr mInstance;
    public static LuaScriptMgr GetInstance()
    {
        if (mInstance == null)
        {
            mInstance = Activator.CreateInstance<LuaScriptMgr>();
        }
        return mInstance;
    }

    public static string m_data_path = String.Empty;
    public static string m_persistent_data_path = String.Empty;
    public static string m_streaming_assets_path = string.Empty;
    public static string m_temporary_cache_path = string.Empty;

    //public delegate void LuaBindExDelegate(LuaState L);
    public delegate string LuaPathDelegate(string name);

	public delegate byte[] LuaGetBuffDelegate(string file_path,  out IntPtr ptrFileBuff, out int fileLen);

    //private static LuaBindExDelegate mLuaBindEx;
    private static LuaPathDelegate mLuaPath;
    private static LuaGetBuffDelegate mLuaGetBuf;

    public static string m_lua_script_path = string.Empty;

    private int mLoginMode;

    public  LuaState lua;
    public HashSet<string> fileList = null;


    //Dictionary<string, IAssetFile> dictBundle = null;    
    LuaFunction updateFunc = null;
    LuaFunction lateUpdateFunc = null;
    LuaFunction fixedUpdateFunc = null;    
    LuaFunction levelLoaded = null;

    public static ObjectTranslator _translator = null;

    static HashSet<Type> checkBaseType = new HashSet<Type>();

    private Dictionary<string, LuaBaseRef> dict; 

    private float last_gc_time = Time.realtimeSinceStartup;

    private bool is_in_gc_state = false;

#if MULTI_STATE
    static List<LuaScriptMgr> mgrList = new List<LuaScriptMgr>();
    static int mgrPos = 0;
#else
    static LuaFunction traceback = null;
#endif

    //public LuaBindExDelegate LuaBindEx
    //{
    //    set
    //    {
    //        if (mLuaBindEx == null)
    //        {
    //            mLuaBindEx = value;
    //        }
    //    }
    //}

    public LuaPathDelegate LuaPath
    {
        get
        {
            return mLuaPath;
        }
        set
        {
            if (mLuaPath == null)
            {
                mLuaPath = value;
            }
        }
    }

    public LuaGetBuffDelegate LuaGetBuf
    {
        set
        {
            if (mLuaGetBuf == null)
            {
                mLuaGetBuf = value;
            }
        }
    }

    public int LoginMode
    {
        set
        {
            mLoginMode = value;
        }
        get
        {
            return mLoginMode;
        }
    }



    public LuaScriptMgr()
    {
        Debug.Log("LuaScriptMgr.LuaScriptMgr()");

        dict = new Dictionary<string, LuaBaseRef>();
        lua = new LuaState();
        _translator = LuaState.GetTranslator(lua.L);
        fileList = new HashSet<string>(new List<string>(1600));
        fileList.Clear();
        
#if MULTI_STATE
        mgrList.Add(this);
        LuaDLL.lua_pushnumber(lua.L, mgrPos);
        LuaDLL.lua_setglobal(lua.L, "_LuaScriptMgr");           

        ++mgrPos;
#else
        LuaDLL.lua_pushnumber(lua.L, 0);
        LuaDLL.lua_setglobal(lua.L, "_LuaScriptMgr");                
#endif
     
    }

    void RegisertPrint()
    {
        LuaDLL.lua_pushcfunction(lua.L, EnginePrint);
        LuaDLL.lua_setglobal(lua.L, "print");
    }
    void RegisertError()
    {
        LuaDLL.lua_pushcfunction(lua.L, EngineError);
        LuaDLL.lua_setglobal(lua.L, "error");
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int EnginePrint(IntPtr luaState)
    {
        LuaTable enconfig_table = GetInstance().GetLuaTable("ConfigTable");
        if (enconfig_table != null)
        {
            string open_lua_print = enconfig_table["open_lua_print"].ToString();
            if (!open_lua_print.Equals("1")) return 0;
        }
        string buff = string.Empty;
        int n = LuaDLL.lua_gettop(luaState);
        int i;
        LuaDLL.lua_getglobal(luaState, "tostring");
        for (i = 1; i <= n; ++i)
        {
            LuaDLL.lua_pushvalue(luaState, -1);
            LuaDLL.lua_pushvalue(luaState, i);
            LuaDLL.lua_call(luaState, 1, 1);

            string s = LuaDLL.lua_tostring(luaState, -1);
            if (s == null)
            {
                LuaDLL.luaL_error(luaState, "must return a string to print");
                return -1;
            }
            if (i > 1)
            {
                buff += "\t";
            }
            buff += s;
            LuaDLL.lua_pop(luaState, 1);  /* pop result */
        }
        Debugger.LuaLog(4, buff );
        return 0;
    }

    public  bool PushGlobalIndexToLua(string name, bool val)
    {
        if (string.IsNullOrEmpty(name)) return false;
        LuaDLL.lua_pushboolean(lua.L, val );
        LuaDLL.lua_setfield(lua.L, LuaIndexes.LUA_GLOBALSINDEX, name);
        return true;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int EngineError(IntPtr luaState)
    {
        string buff = string.Empty;
        int n = LuaDLL.lua_gettop(luaState);
        int i;
        LuaDLL.lua_getglobal(luaState, "tostring");
        for (i = 1; i <= n; ++i)
        {
            LuaDLL.lua_pushvalue(luaState, -1);
            LuaDLL.lua_pushvalue(luaState, i);
            LuaDLL.lua_call(luaState, 1, 1);

            string s = LuaDLL.lua_tostring(luaState, -1);
            if (s == null)
            {
                LuaDLL.luaL_error(luaState, "must return a string to print");
                return -1;
            }
            if (i > 1)
            {
                buff += "\t";
            }
            buff += s;
            LuaDLL.lua_pop(luaState, 1);  /* pop result */
        }

        string str_traceback = LuaScriptMgr.GetInstance().InvokeLuaFunction<string, string>("traceback", "");
        if (str_traceback != null)
        {
            buff += str_traceback;
        }

        Debugger.LuaLog(1 ,buff);
        return 0;
    }

    public void AddSearchPath(string path)
    {
        LuaDLL.lua_getglobal(lua.L, "package");                                  /* stack: package */
        LuaDLL.lua_getfield(lua.L, -1, "path");                /* get package.path, stack: package path */
        string cur_path = LuaDLL.lua_tostring(lua.L, -1);
        cur_path += ";" + path + "/?.lua";
        LuaDLL.lua_pop(lua.L, 1);                                                /* stack: package */
        LuaDLL.lua_pushstring(lua.L, cur_path);            /* stack: package newpath */
        LuaDLL.lua_setfield(lua.L, -2, "path");          /* package.path = newpath, stack: package */
        LuaDLL.lua_pop(lua.L, 1);
    }


    public void ClearLuaDict()
    {
        dict.Clear();
    }


    public void ClearTable(string tableName)
    {
        // if (string.IsNullOrEmpty(tableName)) return;
        // CallLuaFunction("DeleteTabel", tableName);

        // RemoveLuaRes(tableName);
    }


    public void ClearLuaStack()
    {
        fileList.Clear();

        //清空package.loaded
        LuaDLL.lua_getglobal(lua.L, "package");
        LuaDLL.lua_pushstring(lua.L, "loaded");
        LuaDLL.lua_gettable(lua.L, -2);

        int nIndex = LuaDLL.lua_gettop(lua.L);				// 取table索引值;
        LuaDLL.lua_pushnil(lua.L);							// nil入栈作为初始key;
        while (0 != LuaDLL.lua_next(lua.L, nIndex))
        {
            // 现在栈顶（-1）是value，-2位置是对应的key ;
            // 这里可以判断key是什么并且对value进行各种处理 ;
            LuaDLL.lua_pushvalue(lua.L, -2);
            LuaDLL.lua_pushnil(lua.L);
            LuaDLL.lua_settable(lua.L, nIndex);
            LuaDLL.lua_pop(lua.L, 1);						// 弹出value，让key留在栈顶 ;
        }

        LuaDLL.lua_pop(lua.L, 2);

        Debugger.Log( "Reload lua files over");
    }

    public void ReloadFile(string fileName)
    {
        // DoFile("reload");
        this.ClearLuaStack();
        DoFile("reload");
        //this.DoFile(fileName);
    }

    public void ReloadAllFile()
    {
        fileList.Clear();
        CallLuaFunction("require", "reload");
    }
    void SendGMmsg(params string[] param)
    {
        Debugger.Log("SendGMmsg");
        string str = "";
        int i = 0;

        foreach (string p in param)
        {
            if (i >0)
            {
                str = str +" "+ p;
                Debugger.Log(p);
            }
            i++;
        }

        CallLuaFunction("GMMsg", str);
    }


    void InitLayers(IntPtr L)
    {
        //LuaTable layers = GetLuaTable("Layer");
        //if (layers == null || layers.Equals(null))
        //{
        //    Debugger.LuaLog(1, "require layer file failed!");
        //    return;
        //}
        //layers.push(L);

        //for (int i = 0; i < 32; i++)
        //{
        //    string str = LayerMask.LayerToName(i);

        //    if (str != string.Empty)
        //    {
        //        LuaDLL.lua_pushstring(L, str);
        //        Push(L, i);
        //        LuaDLL.lua_rawset(L, -3);
        //    }
        //}

        //LuaDLL.lua_settop(L, 0);
    }

    public void Bind()
    {
        //IntPtr L = lua.L;
        //BindArray(L);
        //DelegateFactory.Register(L);
        //LuaBinder.Bind(L);
    }

    public IntPtr GetL()
    {
        return lua.L;
    }

    void PrintLua(params string[] param)
    {
        if (param.Length != 2)
        {
            Debugger.Log("PrintLua [ModuleName]");
            return;
        }
        
        CallLuaFunction("PrintLua", param[1]);
    }

    public void LuaGC(params string[] param)
    {        
        LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);        
    }


    public int LuaGCCount()
    {
        return LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCCOUNT, 0);    
    }

    void LuaMem(params string[] param)
    {               
        CallLuaFunction("mem_report");
    }

    public void Start()
    {

        //lua.Start();   //暂时 不使用 不加载，大量的lua库

        OnBundleLoaded();

        //enumMetaRef = GetTypeMetaRef(typeof(System.Enum));
        //typeMetaRef = GetTypeMetaRef(typeof(System.Type));
        //delegateMetaRef = GetTypeMetaRef(typeof(System.Delegate));
        //iterMetaRef = GetTypeMetaRef(typeof(IEnumerator));

        //LuaDLL.luaL_getmetatable(lua.L, "luaNet_array");
        //arrayMetaRef = LuaDLL.luaL_ref(lua.L, LuaIndexes.LUA_REGISTRYINDEX);

        //foreach (Type t in checkBaseType)
        //{
        //    if (!t.FullName.Contains("Singleton") )
        //        Debugger.LogWarning("BaseType {0} not register to lua", t.FullName);
        //}
        //checkBaseType.Clear();

    }

    int GetLuaReference(string str)
    {
        LuaFunction func = GetLuaFunction(str);

        if (func != null)
        {
            return func.GetReference();
        }

        return -1;
    }

    int GetTypeMetaRef(Type t)
    {
        string metaName = t.AssemblyQualifiedName;
        LuaDLL.luaL_getmetatable(lua.L, metaName);
        return LuaDLL.luaL_ref(lua.L, LuaIndexes.LUA_REGISTRYINDEX);
    }

    void OnBundleLoaded()
    {
        RegisertPrint();
        RegisertError();
        //DoFile("core/global");

#if !MULTI_STATE
        traceback = GetLuaFunction("traceback");
#endif                       
    }

    public int GetCRTLuaObjCount()
    {
        return _translator.objects.Count;
    }

    public void SetLuaUpdateFun(string updateName)
    {
        if (string.IsNullOrEmpty(updateName))
        {
            this.updateFunc = null;
        }
        else
        {
            this.updateFunc = this.GetLuaFunction(updateName);
        }   
    }
   

    public void OnLevelLoaded(int level)
    {
        levelLoaded.Call(level);
    }

    public void Update()
    {
        if (updateFunc != null)
        {
            updateFunc.BeginPCall();
            updateFunc.Push(Time.deltaTime);
            //updateFunc.Push(Time.unscaledDeltaTime);
            updateFunc.PCall();
            updateFunc.EndPCall();

            lua.Collect();
        }

//        if (lua.L != null)
//        {
//          LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCSTEP, 5);
//        }
          
        //2min 检查一次lua运行时栈大小; 大于30M时 调长步长摊帧回收;
        //以下逻辑暂时不开启；
        //if (!is_in_gc_state)
        //{
        //    float now_time = Time.realtimeSinceStartup;
        //    if (now_time - last_gc_time > 120)
        //    {
        //        last_gc_time = Time.realtimeSinceStartup;
        //        if (LuaGCCount() > 30 * 1024)
        //        {
        //            is_in_gc_state = true;
        //        }
        //    }
        //}

        //if (is_in_gc_state)
        //{
        //    if ( LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCSTEP, 100) != 0 )
        //    {
        //        is_in_gc_state = false;
        //        last_gc_time = Time.realtimeSinceStartup;
        //    }
        //}

        //if (LuaDLL.lua_gettop(lua.L) != 0)
        //{
        //    Debugger.Log("stack top {0}", LuaDLL.lua_gettop(lua.L));
        //}
    }

    public void LateUpate()
    {
        if (lateUpdateFunc != null)
        {
            lateUpdateFunc.Call();
        }        
    }

    public void FixedUpdate()
    {
        if (fixedUpdateFunc != null)
        {
            fixedUpdateFunc.Call(Time.fixedDeltaTime);            
        }

    }


    void SafeRelease(ref LuaFunction func)
    {
        if (func != null)
        {
            func.Dispose();
            func = null;
        }
    }
    
    void SafeUnRef(ref int reference)
    {
        if (reference > 0)
        {
            LuaDLL.lua_unref(lua.L, reference);
            reference = -1;
        }
    }

    public void Destroy()
    {                                              
        SafeRelease(ref updateFunc);
        SafeRelease(ref lateUpdateFunc);
        SafeRelease(ref fixedUpdateFunc);       

        LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);

        fileList.Clear();

        lua.Dispose();
        lua = null;


        Debugger.Log("Lua module destroy");        
    }

    public object[] DoString(string str)
    {
        return lua.DoString(str);
    }

    public object[] DoFile(string fileName)
    {        
        if (!fileList.Contains(fileName))
        {                            
            return lua.DoFile(fileName);                  
        }

        return null;
    }

    public object[] DoFile(ref byte[] text, ref string fileName)
    {
        if (!fileList.Contains(fileName) && text != null )
        {
            //DataEncrypt.LoadEncryptBufferFromMemory(ref text);
            string err = string.Empty;
            return lua.LuaLoadBuffer(text, fileName, ref err);
        }
        return null;
    }

    public object[] DoFile(ref byte[] text, ref string fileName, ref string err)
    {
        if (!fileList.Contains(fileName) && text != null )
        {
            //DataEncrypt.LoadEncryptBufferFromMemory(ref text);
            return lua.LuaLoadBuffer(text, fileName, ref err);
        }
        return null;
    }


    //有gc，慎用
    public object[] LazyCallLuaFunction(string name, params object[] args)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return null;
        }
        return func.LazyCall(args);
    }

    public void CallLuaFunction(string name)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call();
    }

    public void CallLuaFunction<T1>(string name, T1 arg1)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1>(arg1);
    }

    public void CallLuaFunction<T1, T2>(string name, T1 arg1, T2 arg2)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1, T2>(arg1, arg2);
    }

    public void CallLuaFunction<T1, T2, T3>(string name, T1 arg1, T2 arg2, T3 arg3)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1, T2, T3>(arg1, arg2, arg3);
    }

    public void CallLuaFunction<T1, T2, T3, T4>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1, T2, T3, T4>(arg1, arg2, arg3, arg4);
    }

    public void CallLuaFunction<T1, T2, T3, T4, T5>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1, T2, T3, T4, T5>(arg1, arg2, arg3, arg4, arg5);
    }

    public void CallLuaFunction<T1, T2, T3, T4, T5, T6>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1, T2, T3, T4, T5, T6>(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    public void CallLuaFunction<T1, T2, T3, T4, T5, T6, T7>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1, T2, T3, T4, T5, T6, T7>(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    public void CallLuaFunction<T1, T2, T3, T4, T5, T6, T7, T8>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return;
        }
        func.Call<T1, T2, T3, T4, T5, T6, T7, T8>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }


    public R InvokeLuaFunction<R>(string name)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<R>();
    }

    public R InvokeLuaFunction<T1, R>(string name, T1 arg1)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, R>(arg1);
    }

    public R InvokeLuaFunction<T1, T2, R>(string name, T1 arg1, T2 arg2)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, T2, R>(arg1, arg2);
    }

    public R InvokeLuaFunction<T1, T2, T3, R>(string name, T1 arg1, T2 arg2, T3 arg3)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, T2, T3, R>(arg1, arg2, arg3);
    }

    public R InvokeLuaFunction<T1, T2, T3, T4, R>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, T2, T3, T4, R>(arg1, arg2, arg3, arg4);
    }

    public R InvokeLuaFunction<T1, T2, T3, T4, T5, R>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, T2, T3, T4, T5, R>(arg1, arg2, arg3, arg4, arg5);
    }

    public R InvokeLuaFunction<T1, T2, T3, T4, T5, T6, R>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, T2, T3, T4, T5, T6, R>(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    public R InvokeLuaFunction<T1, T2, T3, T4, T5, T6, T7, R>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, T2, T3, T4, T5, T6, T7, R>(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    public R InvokeLuaFunction<T1, T2, T3, T4, T5, T6, T7, T8, R>(string name, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            Debugger.LogWarning(string.Format("Lua function {0} not exists", name));
            return default(R);
        }
        return func.Invoke<T1, T2, T3, T4, T5, T6, T7, T8, R>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }

    public LuaFunction GetLuaFunction(string name)
    {
        LuaFunction func = lua.GetFunction(name, false);
        if (func == null)
        {
            throw new LuaException(string.Format("Lua function {0} not exists", name));
        }
         return func;
    }

    

    public bool IsFuncExists(string name)
    {
        IntPtr L = lua.L;
        int oldTop = LuaDLL.lua_gettop(L);

        if (PushLuaFunction(L, name))
        {
            LuaDLL.lua_settop(L, oldTop);
            return true;
        }

        return false;
    }
	
	public byte[] Loader(string name, out IntPtr ptrFileBuff, out int fileLen)
	{
		byte[] str = null;
		string path = name;

		ptrFileBuff = IntPtr.Zero;
		fileLen = 0;
		
		if (mLuaPath != null)
		{
			path = mLuaPath(name);
		}
		
		if (path.Equals(string.Empty))
		{
#if UNITY_EDITOR
            if (!string.IsNullOrEmpty(name) && name.Contains("global.lua"))
            {
                Debugger.LuaLog(1, String.Format("lua error\n loader {0} lua file faild\n 检查一下engineconfig_debug里lua脚本路径配置是否正确.", name));
            }
            else
            {
                Debugger.LuaLog(1, String.Format("lua error\n loader {0} lua file faild", name));
            }
#elif UNITY_STANDALONE_WIN
            if (!string.IsNullOrEmpty(name) && name.Contains("global.lua"))
            {
                Debugger.LuaLog(1, String.Format("lua error\n loader {0} lua file faild\n 检查一下游戏是否放在包含中文目录的路径下.", name));
            }
            else
            {
                Debugger.LuaLog(1, String.Format("lua error\n loader {0} lua file faild", name));
            }
#else   
            Debugger.LuaLog(1, String.Format("lua error\n loader {0} lua file faild", name));
#endif
			return null;
		}
		
		if (mLoginMode == 3)
		{
			str = mLuaGetBuf(path, out ptrFileBuff, out fileLen);
			fileList.Add(name);
			return str;
		}

#if UNITY_WEBGL
        str = mLuaGetBuf(path, out ptrFileBuff, out fileLen);
        fileList.Add(name);
        return str;
#endif

#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
		if ( !string.IsNullOrEmpty( m_lua_script_path )  )
		{
			if (mLoginMode == 6)
            {
                if(path.Contains("config/"))
                {
                    str = File.ReadAllBytes(path); 
                }
                else
                {
                    str = mLuaGetBuf(path, out ptrFileBuff, out fileLen);
                }
            }
            else
            {  
                str = File.ReadAllBytes(path);
            }
			fileList.Add(name);
			return str;
		}
		
#endif

        str = mLuaGetBuf(path, out ptrFileBuff, out fileLen);
        
		fileList.Add(name);
		return str;
	}
	
	
	static bool  PushLuaTable(IntPtr L, string fullPath) 
	{
		string[] path = fullPath.Split(new char[] { '.' });
		
		int oldTop = LuaDLL.lua_gettop(L);
       // LuaDLL.lua_getglobal(L, path[0]);
        LuaDLL.lua_pushstring(L, path[0]);
        LuaDLL.lua_rawget(L, LuaIndexes.LUA_GLOBALSINDEX);   

        LuaTypes type = LuaDLL.lua_type(L, -1);

        if (type != LuaTypes.LUA_TTABLE)
        {
            LuaDLL.lua_settop(L, oldTop);
            LuaDLL.lua_pushnil(L);
            Debugger.LuaLog(1, string.Format("Push lua table {0} failed", path[0]));
            return false;
        }

        for (int i = 1; i < path.Length; i++)
        {
            LuaDLL.lua_pushstring(L, path[i]);
            LuaDLL.lua_rawget(L, -2);
            type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TTABLE)
            {
                LuaDLL.lua_settop(L, oldTop);
                Debugger.LuaLog(1, string.Format("Push lua table {0} failed", fullPath));
                return false;
            }
        }

        if (path.Length > 1)
        {
            LuaDLL.lua_insert(L, oldTop + 1);
            LuaDLL.lua_settop(L, oldTop + 1);
        }

        return true;
    }

    static bool PushLuaFunction(IntPtr L, string fullPath)
    {
        int oldTop = LuaDLL.lua_gettop(L);
        int pos = fullPath.LastIndexOf('.');

        if (pos > 0)
        {
            string tableName = fullPath.Substring(0, pos);

            if (PushLuaTable(L, tableName))
            {
                string funcName = fullPath.Substring(pos + 1);
                LuaDLL.lua_pushstring(L, funcName);
                LuaDLL.lua_rawget(L, -2);
            }

            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TFUNCTION)
            {
                LuaDLL.lua_settop(L, oldTop);
                return false;
            }

            LuaDLL.lua_insert(L, oldTop + 1);
            LuaDLL.lua_settop(L, oldTop + 1);
        }
        else
        {
            LuaDLL.lua_getglobal(L, fullPath);
            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TFUNCTION)
            {
                LuaDLL.lua_settop(L, oldTop);
                return false;
            }
        }

        return true;
    }

   public int get_registerindex_count()
   {
       return count_table(LuaIndexes.LUA_REGISTRYINDEX);
   }

    public   int count_table(int idx)
    {
        int n = 0;
        IntPtr L = lua.L;
        LuaDLL.lua_pushnil(L);
        while (LuaDLL.lua_next(L, idx) != 0)
        {
            ++n;
            LuaDLL.lua_pop(L, 1);
        }
        return n;
    }

    public LuaTable GetLuaTable(string tableName, bool beLogMiss = true)
    {
        LuaTable lt = lua.GetTable(tableName, beLogMiss);
        return lt as LuaTable;
    }

    public void RemoveLuaRes(string name)
    {
        dict.Remove(name);
    }

    static void CreateTable(IntPtr L, string fullPath)
    {        
        string[] path = fullPath.Split(new char[] { '.' });
        int oldTop = LuaDLL.lua_gettop(L);

        if (path.Length > 1)
        {            
            LuaDLL.lua_getglobal(L, path[0]);
            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TNIL)
            {
                LuaDLL.lua_pop(L, 1);
                LuaDLL.lua_createtable(L, 0, 0);
                LuaDLL.lua_pushstring(L, path[0]);
                LuaDLL.lua_pushvalue(L, -2);
                LuaDLL.lua_settable(L, LuaIndexes.LUA_GLOBALSINDEX);
            }

            for (int i = 1; i < path.Length - 1; i++)
            {
                LuaDLL.lua_pushstring(L, path[i]);
                LuaDLL.lua_rawget(L, -2);

                type = LuaDLL.lua_type(L, -1);

                if (type == LuaTypes.LUA_TNIL)
                {
                    LuaDLL.lua_pop(L, 1);
                    LuaDLL.lua_createtable(L, 0, 0);
                    LuaDLL.lua_pushstring(L, path[i]);
                    LuaDLL.lua_pushvalue(L, -2);
                    LuaDLL.lua_rawset(L, -4);
                }
            }

            LuaDLL.lua_pushstring(L, path[path.Length - 1]);
            LuaDLL.lua_rawget(L, -2);

            type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TNIL)
            {
                LuaDLL.lua_pop(L, 1);
                LuaDLL.lua_createtable(L, 0, 0);
                LuaDLL.lua_pushstring(L, path[path.Length - 1]);
                LuaDLL.lua_pushvalue(L, -2);           
                LuaDLL.lua_rawset(L, -4);
            }            
        }
        else
        {
            LuaDLL.lua_getglobal(L, path[0]);
            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TNIL)
            {
                LuaDLL.lua_pop(L, 1);
                LuaDLL.lua_createtable(L, 0, 0);
                LuaDLL.lua_pushstring(L, path[0]);
                LuaDLL.lua_pushvalue(L, -2);                
                LuaDLL.lua_settable(L, LuaIndexes.LUA_GLOBALSINDEX);
            }
        }

        LuaDLL.lua_insert(L, oldTop + 1);
        LuaDLL.lua_settop(L, oldTop + 1);
    }

    public static void RegisterLib(IntPtr L, string libName, LuaMethod[] regs)
    {
        CreateTable(L, libName);

        for (int i = 0; i < regs.Length; i++)
        {
            LuaDLL.lua_pushstring(L, regs[i].name);
            LuaDLL.lua_pushcfunction(L, regs[i].func);
            LuaDLL.lua_rawset(L, -3);
        }

        LuaDLL.lua_settop(L, 0);
    }
    

    public static double GetNumber(IntPtr L, int stackPos)
    {           
           return LuaDLL.lua_tonumber(L, stackPos);
    }

   

    public static string GetString(IntPtr L, int stackPos)
    {
        return ToLua.CheckString(L, stackPos);
    }

    public static LuaFunction GetFunction(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype != LuaTypes.LUA_TFUNCTION)
        {
            return null;
        }

        LuaDLL.lua_pushvalue(L, stackPos);        
        return new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaState.Get(L) );        
    }

    public static LuaFunction ToLuaFunction(IntPtr L, int stackPos)
    {
        LuaDLL.lua_pushvalue(L, stackPos);
        return new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaState.Get(L) );
    }

    public static LuaFunction GetLuaFunction(IntPtr L, int stackPos)
    {
        LuaFunction func = GetFunction(L, stackPos);        

        if (func == null)
        {            
            LuaDLL.luaL_typerror(L, stackPos, "function");
            return null;
        }

        return func;
    }

    static LuaTable ToLuaTable(IntPtr L, int stackPos)
    {
        LuaDLL.lua_pushvalue(L, stackPos);
        return new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaState.Get(L));
    }

    static LuaTable GetTable(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);        

        if (luatype != LuaTypes.LUA_TTABLE)
        {
            return null;
        }

        LuaDLL.lua_pushvalue(L, stackPos);
        return new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaState.Get(L)  );
    }

    public static LuaTable GetLuaTable(IntPtr L, int stackPos)
    {
        LuaTable table = GetTable(L, stackPos);

        if (table == null)
        {            
            LuaDLL.luaL_typerror(L, stackPos, "table");
            return null;
        }

        return table;
    }

    public  bool ObjectIsExist( object o)
    {
        //if (o == null || o.Equals(null) || !ObjectTranslator.objectIsExist(o))
        //{
        //    return false;
        //}
        return true;
    }

    //注册到lua中的object类型对象, 存放在ObjectTranslator objects 池中
    public static object GetLuaObject(IntPtr L, int stackPos)
    {                   
        return GetTranslator(L).getRawNetObject(L, stackPos);      
    }

    //System object类型匹配正确, 只需判断会否为null. 获取对象本身时使用
    public static object GetNetObjectSelf(IntPtr L, int stackPos, string type)
    {
        object obj = GetTranslator(L).getRawNetObject(L, stackPos);

        if (obj == null || obj.Equals(null) )
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type));
            return null;
        }

        return obj;
    }

    private static bool IsNull(object o)
    {
        if (o == null || o.Equals(null))
            return true;
        return false;
    }
    //Unity object类型匹配正确, 只需判断会否为null. 获取对象本身时使用
    public static object GetUnityObjectSelf(IntPtr L, int stackPos, string type)
    {
        object obj = GetTranslator(L).getRawNetObject(L, stackPos);
        UnityEngine.Object uObj = (UnityEngine.Object)obj;

        if (IsNull(uObj) )
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type));
            return null;
        }

        return obj;
    }

    public static object GetTrackedObjectSelf(IntPtr L, int stackPos, string type)
    {
        object obj = GetTranslator(L).getRawNetObject(L, stackPos);
        UnityEngine.TrackedReference uObj = (UnityEngine.TrackedReference)obj;

        if (uObj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type));
            return null;
        }

        return obj;
    }    

    public static T GetNetObject<T>(IntPtr L, int stackPos)
    {
        return (T)GetNetObject(L, stackPos, typeof(T));
    }

    public static object GetNetObject(IntPtr L, int stackPos, Type type)
    {
        if (LuaDLL.lua_isnil(L, stackPos))
        {
            return null;
        }

        object obj = GetLuaObject(L, stackPos);


        if (obj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
            return null;
        }

        Type objType = obj.GetType();

        if (type == objType || type.IsAssignableFrom(objType))
        {
            return obj;
        }

        LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.Name, objType.Name));
        return null;
    }

    public static T GetUnityObject<T>(IntPtr L, int stackPos) where T : UnityEngine.Object
    {
        return (T)GetUnityObject(L, stackPos, typeof(T));
    }

    public static UnityEngine.Object GetUnityObject(IntPtr L, int stackPos, Type type)
    {
        if (LuaDLL.lua_isnil(L, stackPos))
        {
            return null;
        }

        object obj = GetLuaObject(L, stackPos);        

        if (obj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
            return null;
        }        

        UnityEngine.Object uObj = (UnityEngine.Object)obj; // as UnityEngine.Object;        

        if (uObj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
            return null;
        }
        
        Type objType = uObj.GetType();

        if (type == objType || objType.IsSubclassOf(type))
        {
            return uObj;
        }

        LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.Name, objType.Name));
        return null;
    }

    public static T GetTrackedObject<T>(IntPtr L, int stackPos) where T : UnityEngine.TrackedReference
    {
        return (T)GetTrackedObject(L, stackPos, typeof(T));    
    }

    public static UnityEngine.TrackedReference GetTrackedObject(IntPtr L, int stackPos, Type type)
    {
        if (LuaDLL.lua_isnil(L, stackPos))
        {
            return null;
        }

        object obj = GetLuaObject(L, stackPos);        

        if (obj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
            return null;
        }        

        UnityEngine.TrackedReference uObj = obj as UnityEngine.TrackedReference;

        if (uObj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
            return null;
        }

        Type objType = obj.GetType();

        if (type == objType || objType.IsSubclassOf(type))
        {
            return uObj;
        }

        LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.Name, objType.Name));
        return null;
    }

    public static Type GetTypeObject(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);

        if (obj == null || obj.GetType() != monoType)
        {            
            LuaDLL.luaL_argerror(L, stackPos, string.Format("Type expected, got {0}", obj == null ? "nil" : obj.GetType().Name));
        }

        return (Type)obj;    
    }

    public static bool IsClassOf(Type child, Type parent)
    {
        return child == parent || parent.IsAssignableFrom(child);
    }

    static ObjectTranslator GetTranslator(IntPtr L)
    {
#if MULTI_STATE
            return ObjectTranslator.FromState(L);
#else            
            if (_translator == null)
            {
                return ObjectTranslator.Get(L);
            }

            return _translator;
#endif        
    }


    public static bool CheckTypes(IntPtr L, int begin, Type type0)
    {
        return CheckType(L, type0, begin);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9);
    }

    //当进入这里时势必会有一定的gc alloc, 因为params Type[]会分配内存, 可以像上面扩展来避免gc alloc
    public static bool CheckTypes(IntPtr L, int begin, params Type[] types)
    {
        for (int i = 0; i < types.Length; i++)
        {            
            if (!CheckType(L, types[i], i + begin))
            {
                return false;
            }
        }

        return true;
    }

    public static bool CheckParamsType(IntPtr L, Type t, int begin, int count)
    {        
        //默认都可以转 object
        if (t == typeof(object))
        {
            return true;
        }

        for (int i = 0; i < count; i++)
        {            
            if (!CheckType(L, t, i + begin))
            {
                return false;
            }
        }

        return true;
    }

    static bool CheckTableType(IntPtr L, Type t, int stackPos)
    {
        if (t.IsArray)
        {
            return true;
        }
        else if (t == typeof(LuaTable))
        {
            return true;
        }
        else if (t.IsValueType)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            LuaDLL.lua_pushvalue(L, stackPos);
            LuaDLL.lua_pushstring(L, "class");
            LuaDLL.lua_gettable(L, -2);

            string cls = LuaDLL.lua_tostring(L, -1);
            LuaDLL.lua_settop(L, oldTop);

            if (cls == "Vector3")
            {
                return t == typeof(Vector3);
            }
            else if (cls == "Vector2")
            {
                return t == typeof(Vector2);
            }
            else if (cls == "Quaternion")
            {
                return t == typeof(Quaternion);
            }
            else if (cls == "Color")
            {
                return t == typeof(Color);
            }
            else if (cls == "Vector4")
            {
                return t == typeof(Vector4);
            }
            else if (cls == "Ray")
            {
                return t == typeof(Ray);
            }
        }

        return false;
    }

    public static bool CheckType(IntPtr L, Type t, int pos)
    {
        //默认都可以转 object
        if (t == typeof(object))
        {
            return true;
        }

        LuaTypes luaType = LuaDLL.lua_type(L, pos);

        switch (luaType)
        {
            case LuaTypes.LUA_TNUMBER:
                return t.IsPrimitive;
            case LuaTypes.LUA_TSTRING:
                return t == typeof(string);
            case LuaTypes.LUA_TUSERDATA:
                return CheckUserData(L, luaType, t, pos);
            case LuaTypes.LUA_TBOOLEAN:
                return t == typeof(bool);
            case LuaTypes.LUA_TFUNCTION:
                return t == typeof(LuaFunction);
            case LuaTypes.LUA_TTABLE:
                return CheckTableType(L, t, pos);
            case LuaTypes.LUA_TNIL:
                return t == null;
            default:
                break;
        }

        return false;
    }

    static Type monoType = typeof(Type).GetType();

    static bool CheckUserData(IntPtr L, LuaTypes luaType, Type t, int pos)
    {
        object obj = GetLuaObject(L, pos);
        if (obj == null || obj.Equals(null)) return false;
        Type type = obj.GetType();

        if (t == type)
        {
            return true;
        }

        if (t == typeof(Type))
        {                                    
            return type == monoType;
        }  
        else
        {
            return t.IsAssignableFrom(type);            
        }        
    }

    public static T[] GetParamsObject<T>(IntPtr L, int stackPos, int count)
    {
        List<T> list = new List<T>();        
        T obj = default(T);

        while (count > 0)
        {            
            object tmp = GetLuaObject(L, stackPos);

            ++stackPos;
            --count;

            if (tmp != null && tmp.GetType() == typeof(T))
            {
                obj = (T)tmp;
                list.Add(obj);
            }
            else
            {                
                LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", typeof(T).Name));        
                break;
            }
        } 

        return list.ToArray();
    }    


    public static string GetErrorFunc(int skip)
    {
        StackFrame sf = null;
        string file = string.Empty;
        StackTrace st = new StackTrace(skip, true);

        int cnt = st.FrameCount;
        for (int i = 0; i < cnt; ++i)
        {
            sf = st.GetFrame(i);
            if (sf == null || sf.Equals(null)) continue;
            file = sf.GetFileName();
            if (!string.IsNullOrEmpty(file))
            {
                file = Path.GetFileName(file);
                if (file.Contains("Wrap.")) break;
            }
        }

        if ( string.IsNullOrEmpty(file) || sf == null ) return string.Empty;

        int index1 = file.LastIndexOf('\\');
        int index2 = file.LastIndexOf("Wrap.");
        string className = index2 - index1 - 1 > 0 ?  file.Substring(index1 + 1, index2 - index1 - 1) : "";
        return string.Format("{0}.{1}", className, sf.GetMethod().Name);                
    }

    public static string GetLuaString(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);
        string retVal = null;

        if (luatype == LuaTypes.LUA_TSTRING)
        {
            retVal = LuaDLL.lua_tostring(L, stackPos);
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            object obj = GetLuaObject(L, stackPos);

            if (obj == null)
            {                
                LuaDLL.luaL_argerror(L, stackPos, "string expected, got nil");                
                return string.Empty;
            }

            if (obj.GetType() == typeof(string))
            {
                retVal = (string)obj;
            }
            else
            {
                retVal = obj.ToString();
            }
        }
        else if (luatype == LuaTypes.LUA_TNUMBER)
        {
            double d = LuaDLL.lua_tonumber(L, stackPos);
            retVal = d.ToString();
        }
        else if (luatype == LuaTypes.LUA_TBOOLEAN)
        {
            bool b = LuaDLL.lua_toboolean(L, stackPos);
            retVal = b.ToString();
        }
        else if (luatype == LuaTypes.LUA_TNIL)
        {
            return retVal;
        }
        else
        {
            LuaDLL.lua_getglobal(L, "tostring");
            LuaDLL.lua_pushvalue(L, stackPos);
            LuaDLL.lua_call(L, 1, 1);
            retVal = LuaDLL.lua_tostring(L, -1);
            LuaDLL.lua_pop(L, 1);
        }

        return retVal;
    }

    public static string[] GetParamsString(IntPtr L, int stackPos, int count)
    {
        List<string> list = new List<string>();
        string obj = null;

        while (count > 0)
        {
            obj = GetLuaString(L, stackPos);
            ++stackPos;
            --count;

            if (obj == null)
            {                
                LuaDLL.luaL_argerror(L, stackPos, "string expected, got nil");    
                break;
            }

            list.Add(obj);
        } 

        return list.ToArray();
    }

    public static string[] GetArrayString(IntPtr L, int stackPos)
    {        
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            string retVal = null;
            List<string> list = new List<string>();
            LuaDLL.lua_pushvalue(L, stackPos);

            while(true)
            {                
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    LuaDLL.lua_pop(L, 1);
                    return list.ToArray();
                }
                else
                {
                    retVal = GetLuaString(L, -1);
                }
                
                list.Add(retVal);
                LuaDLL.lua_pop(L, 1);
                ++index;
            }
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            string[] ret = GetNetObject<string[]>(L, stackPos);

            if (ret != null)
            {
                return (string[])ret;
            }
        }
        else if (luatype == LuaTypes.LUA_TNIL)
        {
            return null;
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", GetErrorFunc(1), stackPos));           
        return null;
    }

    public static T[] GetArrayNumber<T>(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            T ret = default(T);
            List<T> list = new List<T>();
            LuaDLL.lua_pushvalue(L, stackPos);

            while(true)
            {
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    LuaDLL.lua_pop(L, 1);
                    return list.ToArray();
                }
                else if (luatype != LuaTypes.LUA_TNUMBER)
                {
                    break;
                }

                ret = (T)Convert.ChangeType(LuaDLL.lua_tonumber(L, -1), typeof(T));
                list.Add(ret);
                LuaDLL.lua_pop(L, 1);
                ++index;
            }
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            T[] ret = GetNetObject<T[]>(L, stackPos);

            if (ret != null)
            {
                return (T[])ret;
            }            
        }
        else if (luatype == LuaTypes.LUA_TNIL)
        {
            return null;
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", GetErrorFunc(1), stackPos));   
        return null;
    }

    public static bool[] GetArrayBool(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;            
            List<bool> list = new List<bool>();
            LuaDLL.lua_pushvalue(L, stackPos);

            while (true)
            {
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    LuaDLL.lua_pop(L, 1);
                    return list.ToArray();
                }
                else if (luatype != LuaTypes.LUA_TNUMBER)
                {
                    break;
                }

                bool ret = LuaDLL.lua_toboolean(L, -1);
                list.Add(ret);
                LuaDLL.lua_pop(L, 1);
                ++index;
            }
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            bool[] ret = GetNetObject<bool[]>(L, stackPos);

            if (ret != null)
            {
                return (bool[])ret;
            }
        }
        else if (luatype == LuaTypes.LUA_TNIL)
        {
            return null;
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", GetErrorFunc(1), stackPos));
        return null;
    }    

    public static LuaStringBuffer GetStringBuffer(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TNIL)
        {
            return null;
        }
        else if (luatype != LuaTypes.LUA_TSTRING)
        {            
            LuaDLL.luaL_typerror(L, stackPos, "string");
            return null;
        }

        int len = 0;
        IntPtr buffer = LuaDLL.lua_tolstring(L, stackPos, out len);
        return new LuaStringBuffer(buffer, (int)len);                
    }

    //public static void SetValueObject(IntPtr L, int pos, object obj)
    //{
    //    GetTranslator(L).SetValueObject(L, pos, obj);
    //}

    public static bool CheckArgsCount(IntPtr L, int count)
    {
        int c = LuaDLL.lua_gettop(L);

        if (c != count)
        {
            string str = string.Format("no overload for method '{0}' takes '{1}' arguments", GetErrorFunc(1), c);
            LuaDLL.luaL_error(L, str);
            return false;
        }
        return true;
    }



    //[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    //public static int Xml_read (IntPtr L) 
    //{
    //    string xml = GetLuaString(L, 1);
    //    Debugger.Log("read {0}", xml);
    //    TextAsset ta = Resources.Load(xml, typeof(TextAsset)) as TextAsset;
    //    IntPtr buffer = LuaDLL.lua_tocbuffer(ta.bytes, ta.bytes.Length);        
    //    LuaDLL.lua_pushlightuserdata(L, buffer);
    //    return 1;
    //}

   

    public static void DumpStack(IntPtr L)
    {
        int top = LuaDLL.lua_gettop(L);

        for (int i = 1; i <= top; i++)
        {
            LuaTypes t = LuaDLL.lua_type(L, i);

            switch(t)
            {
                case LuaTypes.LUA_TSTRING:
                    Debugger.Log(LuaDLL.lua_tostring(L, i));
                    break;
                case LuaTypes.LUA_TBOOLEAN:
                    Debugger.Log(LuaDLL.lua_toboolean(L, i).ToString());
                    break;
                case LuaTypes.LUA_TNUMBER:
                    Debugger.Log(LuaDLL.lua_tonumber(L, i).ToString());
                    break;                
                default:
                    Debugger.Log(t.ToString());
                    break;
            }
        }
    }

    static Dictionary<Enum, object> enumMap = new Dictionary<Enum, object>();

    static object GetEnumObj(Enum e)
    {
        object o = null;

        if (!enumMap.TryGetValue(e, out o))
        {
            o = e;
            enumMap.Add(e, o);
        }

        return o;
    }

    public static void Push(IntPtr L, sbyte d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, byte d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, LuaStringBuffer lsb)
    {
        if (lsb != null  && lsb.buffer != null )
        {
            LuaDLL.lua_pushlstring(L, lsb.buffer, lsb.buffer.Length);
        }
        else
        {
            LuaDLL.lua_pushnil(L);
        }
    }

    public static void Push(IntPtr L, short d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, ushort d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, int d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, uint d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, long d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, ulong d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, float d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, double d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, byte[] byteArray, int len)
    {
        LuaDLL.lua_pushlstring(L, byteArray, len);
    }

    public static void Push(IntPtr L, string str)
    {
        LuaDLL.lua_pushstring(L, str);
    }

    public static LuaScriptMgr GetMgrFromLuaState(IntPtr L)
    {
#if MULTI_STATE      
        
        LuaDLL.lua_getglobal(L, "_LuaScriptMgr");
        int pos = (int)GetNumber(L, -1);
        LuaDLL.lua_pop(L, 1);        
        return mgrList[pos];        
#else
        return mInstance;
#endif        
    }

    public static void ThrowLuaException(IntPtr L)
    {
        string err = LuaDLL.lua_tostring(L, -1);        
        if (err == null) err = "Unknown Lua Error";
        //LuaScriptException(err.ToString(), "");    
        Debugger.LuaLog(1, err);
    }

    // 一些c#会复用的对象，在c#自己或者lua 调用destroy后，就主动断掉与lua的关联（不等到lua的gc), 防止一个对象被多次
    // 调用destroy, 导致后面复用的对象被误销毁
    public static void ReleaseLuaObj(object o)
    {    
        int index;
        _translator.Getudata(o, out index);
        _translator.Destroy(index);
    } 
}

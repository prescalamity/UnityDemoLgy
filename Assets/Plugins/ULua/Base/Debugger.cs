using UnityEngine;
using System.Collections;
using System.Text;

public static class Debugger
{
    public static bool useLog = false;
    public delegate void QLog(string log, params object[] args);
    public static QLog log;
    public static QLog logError;
    public static QLog logWarning;

    public delegate void LuaLogDG(int level, string log);
    public static LuaLogDG luaLog;

    public static void Log(string log, params object[] args)
    {
        if (Debugger.log != null)
        {
            Debugger.log(log, args);
        }
    }

    public static void LogWarning(string log, params object[] args)
    {
        if (Debugger.logWarning != null)
        {
            Debugger.logWarning(log, args);
        }
    }

    public static void LogError(string log, params object[] args)
    {
        if (Debugger.logError != null)
        {
            string lua_stack_trace = LuaScriptMgr.GetInstance().InvokeLuaFunction<string, string>("traceback", "");
            log = string.Format("{0} \n Lua statck trace:  {1}", log, lua_stack_trace);
            Debugger.logError(log, args);
        }
    }

    public static void LuaLog(int level, string log)
    {
        if (luaLog != null)
        {
            if (level == 1)
            {
                string lua_stack_trace = LuaScriptMgr.GetInstance().InvokeLuaFunction<string, string>("traceback", "");
                log = string.Format("{0} \nstatck trace:  {1}", log, lua_stack_trace);
            }
            luaLog(level, log);
        }
    }
}

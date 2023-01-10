using UnityEngine;
using System.Collections;
using System.Text;

public delegate void PluginDLogType(LogType logType, string log, params object[] args);
public delegate void LuaLogDG(int level, string log);

public static class Debugger
{
    public static bool useLog = false;

    public static PluginDLogType log;

    public static LuaLogDG luaLog;

    public static void Log(string log, params object[] args)
    {
        if (Debugger.log != null)
        {
            Debugger.log( LogType.Log, log, args);
        }
    }

    public static void LogWarning(string log, params object[] args)
    {
        if (Debugger.log != null)
        {
            Debugger.log(LogType.Warning,log, args);
        }
    }

    public static void LogError(string log, params object[] args)
    {
        if (Debugger.log != null)
        {
            string lua_stack_trace = LuaScriptMgr.GetInstance().InvokeLuaFunction<string, string>("traceback", "");
            log = string.Format("{0} \n Lua statck trace:  {1}", log, lua_stack_trace);
            Debugger.log(LogType.Error, log, args);
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

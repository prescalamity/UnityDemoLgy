using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

//public enum LogType
//{
//    info = 0,
//    warn = 1,
//    error = 2,
//}

public class DLog
{

    private static string LogPath = "";
    private static string LogFileName = "DLog.log";
    private static string LogFilePath = "";

    //private static string tempCommonStr = "";



    public static StringBuilder gameUISB = new StringBuilder();


    static DLog()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        LogPath = Util.m_data_path + "/..";
#else
        LogPath = Util.m_persistent_data_path;
#endif

        if (!Directory.Exists(LogPath)) Directory.CreateDirectory(LogPath);

        LogFilePath = LogPath + "/" + LogFileName;

        File.WriteAllText(LogFilePath, "", Encoding.UTF8);

        Debugger.log = Log;
        Debugger.luaLog = LuaLog;
        //Debug.Log("DLog.LogFilePath:" + LogFilePath); 
    }

    public static void Log(LogType logType, string centent, params object[] args)
    {
        if (args.Length > 0) centent = string.Format(centent, args);

        File.AppendAllText(LogFilePath, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + centent + Environment.NewLine);

#if UNITY_EDITOR || UNITY_WEBGL
        if (logType == LogType.Error) 
        {
            Debug.LogError(centent);
        }
        else if(logType == LogType.Warning)
        {
            Debug.LogWarning(centent);
        }
        else
        {
            Debug.Log(centent);
        }
#endif

    }

    public static void Log(string centent, params object[] args)
    {
        if (args.Length > 0) centent = string.Format(centent, args);

        File.AppendAllText(LogFilePath, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + centent + Environment.NewLine);

#if UNITY_EDITOR || UNITY_WEBGL
        Debug.Log(centent);
#endif

    }


    public static void LogToUI(string centent, params object[] args)
    {
        if(args.Length > 0) centent = string.Format(centent, args);

        showInGameUI(centent);

        Log(centent);

    }

    public static void LogToUI(LogType logType, string centent,  params object[] args)
    {
        if (args.Length > 0) centent = string.Format(centent, args);

        showInGameUI(centent);

        Log(logType, centent);

    }


    private static void showInGameUI(string contentStr)
    {
        gameUISB.Append(contentStr + Environment.NewLine);
        Main.OutputTextTMP_text = gameUISB.ToString();

    }


    public static void LuaLog(int level, string log)
    {
        //WriteConsole(level, content);

        //if (level.Equals((int)LogManagerInterface.LogLevel.LL_ERROR))
        //{
        //    if (alertWindow != null)
        //    {
        //        alertWindow("lua", content);   //µ¯´°¾¯¸æ
        //    }
        //}

        //ios
        //if (m_log_by_stream_write)
        //{
        //    string levelStr = mErrorMap.ContainsKey(level) ? mErrorMap[level] : "Info";
        //    logStringBuffer.Length = 0;
        //    logStringBuffer.AppendFormat("[{0} {1}] Lua ({2}): {3}", ymd, DateTime.Now.ToLongTimeString().ToString(), levelStr, content);
        //    content = logStringBuffer.ToString();
        //    logStringBuffer.Length = 0;
        //}

        //WriteLog(m_lua_log_agent, level, content);

        if (level == 1)
        {
            LogToUI(LogType.Error, log);
        }
        else
        {
            Log(log);
        }

    }


}

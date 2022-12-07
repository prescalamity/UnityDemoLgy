using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public enum LogType
{
    info = 0,
    warn = 1,
    error = 2,
}

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

        //Debug.Log("DLog.LogFilePath:" + LogFilePath); 
    }

    public static void Log(LogType logType, string centent, params string[] args)
    {
        if (args.Length > 0) centent = string.Format(centent, args);

        File.AppendAllText(LogFilePath, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + centent + Environment.NewLine);

#if UNITY_EDITOR || UNITY_WEBGL
        if (logType == LogType.error) 
        {
            Debug.LogError(centent);
        }
        else if(logType == LogType.warn)
        {
            Debug.LogWarning(centent);
        }
        else
        {
            Debug.Log(centent);
        }
#endif

    }

    public static void Log(string centent, params string[] args)
    {
        if (args.Length > 0) centent = string.Format(centent, args);

        File.AppendAllText(LogFilePath, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + centent + Environment.NewLine);

#if UNITY_EDITOR || UNITY_WEBGL
        Debug.Log(centent);
#endif

    }


    public static void LogToUI(string centent, params string[] args)
    {
        if(args.Length > 0) centent = string.Format(centent, args);

        showInGameUI(centent);

        Log(centent);

    }

    public static void LogToUI(LogType logType, string centent,  params string[] args)
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

}

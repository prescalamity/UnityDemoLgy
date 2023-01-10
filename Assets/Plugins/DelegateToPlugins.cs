using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate byte[] String_ByteArray_Delegate(string str);
public delegate string String3_String_Delegate(string key, string data, string lua_callback);

public class DelegateToPlugins
{
    private static DelegateToPlugins instance = null;
    public static DelegateToPlugins Instance {
        get
        {
            if (instance == null)
            {
                instance = new DelegateToPlugins();
            }
            return instance;
        }
    }

    public String_ByteArray_Delegate getLuaFileByteData = null;
    public String3_String_Delegate callPlatformFunc = null;

}

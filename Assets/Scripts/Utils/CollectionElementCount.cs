using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public static class CollectionElementCount
{
    private static List<object> allInstance = new List<object>();
    private static Dictionary<object, Dictionary<string, int>> instanceListCapcityBegin = new Dictionary<object, Dictionary<string, int>>();
    private static Dictionary<object, Dictionary<string, int>> instanceListMaxCount = new Dictionary<object, Dictionary<string, int>>();
    private static Dictionary<object, Dictionary<string, int>> instanceListCapcityEnd = new Dictionary<object, Dictionary<string, int>>();
    private static Dictionary<object, Dictionary<string, int>> instanceDictMaxCount = new Dictionary<object, Dictionary<string, int>>();
    private static bool onlyPrintInfoWhenNeeded = false;
    private static bool OpenCollectionElementCount = false;

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void AddOneNewInstance(object o)
    {
        if (OpenCollectionElementCount)
        {
            if (o != null && !FilterClassName(o) && !allInstance.Contains(o))
            {
                allInstance.Add(o);
                instanceListCapcityBegin[o] = new Dictionary<string, int>(20);
                instanceListMaxCount[o] = new Dictionary<string, int>(20);
                instanceListCapcityEnd[o] = new Dictionary<string, int>(20);
                instanceDictMaxCount[o] = new Dictionary<string, int>(20);
                GetOneInstanceInfoWhenGameBegin(o);
                AddInstanceRecursive(o);
            }
        }   
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void AnalyzeCollectionElementCount()
    {
        if (OpenCollectionElementCount)
        {
            UpdateCollectionElementInfo();
            PrintAllInstanceCollectionInfo();
        }
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void UpdateCollectionElementInfo()
    {
        if (OpenCollectionElementCount)
        {
            List<object> tmpList = new List<object>(instanceListCapcityBegin.Keys);
            foreach(var o in tmpList)
            {
                AddInstanceRecursive(o);
            }
            foreach (var item in instanceListCapcityBegin)
            {
                GetOneInstanceInfoWhenGameRun(item.Key);
            }
        }
    }

    private static bool FilterClassName(object o)
    {
        string typeName = o.GetType().Name;
        if(typeName.Contains("LinkedListNode") || typeName.Contains("LuaFunction") || typeName.Contains("BetterList"))
        {
            return true;
        }
        return false;
    }

    private static void AddInstanceRecursive(object o)
    {
        Type t = o.GetType();
        FieldInfo[] fis = t.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic);
        for(int i = 0; i < fis.Length; i++)
        {
            FieldInfo fi = fis[i];
            if (fi.FieldType.IsClass)
            {
                object fiobj = fi.GetValue(o);
                AddOneNewInstance(fiobj);
            }
        }
    }

    private static void PrintAllInstanceCollectionInfo()
    {
        DLog.Log("\n\nBegin Print Instance collection capacity and count, onlyPrintInfoWhenNeeded = {0}", onlyPrintInfoWhenNeeded);
        foreach (var item in instanceListCapcityBegin)
        {
            if (item.Key != null)
            {
                Dictionary<string, int> dictmaxcountInfo = instanceDictMaxCount[item.Key];
                Dictionary<string, int> capacityInfoBegin = item.Value;
                Dictionary<string, int> capacityInfoEnd = instanceListCapcityEnd[item.Key];
                Dictionary<string, int> listmaxCountInfo = instanceListMaxCount[item.Key];
                if (dictmaxcountInfo.Count > 0 || capacityInfoBegin.Count > 0)
                {
                    DLog.Log("ClassName : {0}", item.Key.GetType().Name);
                    DLog.Log("\tList field is below:");
                    foreach(var info in capacityInfoBegin)
                    {
                        string fieldName = info.Key;
                        int capacityBegin = info.Value;
                        int capacityEnd = -1;
                        int maxCount = -1;
                        if (capacityInfoEnd.TryGetValue(fieldName, out capacityEnd))
                        {
                            listmaxCountInfo.TryGetValue(fieldName, out maxCount);
                            if (!onlyPrintInfoWhenNeeded || capacityBegin < capacityEnd)
                            {
                                DLog.Log("\t\t{0}, beginCapacity = {1}, endCapacity = {2}, maxCount = {3}", fieldName, capacityBegin, capacityEnd, maxCount);
                            }
                        }
                    }
                    DLog.Log("\tOther Collection field is below:"); 
                    foreach(var info in dictmaxcountInfo)
                    {
                        string fieldName = info.Key;
                        int countEnd = info.Value;
                        DLog.Log("\t\t{0}, maxCount = {1}", fieldName, countEnd);
                    }
                }
            }
           
        }  
        DLog.Log("End Print Instance collection capacity and count");
    }

    private static void GetOneInstanceInfoWhenGameBegin(object o)
	{
        int count = -1;
        int capacity = -1;
		Type t = o.GetType();
		FieldInfo[] fis = t.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic);
		for(int i=0; i<fis.Length; i++)
		{
            FieldInfo fi = fis[i];
            if (typeof(ICollection).IsAssignableFrom(fi.FieldType) && fi.FieldType.IsGenericType)
            {
                GetOneCollectionInfo(fi, o, ref count, ref capacity);
                if (typeof(IList).IsAssignableFrom(fi.FieldType))
                {
                    instanceListCapcityBegin[o].Add(fi.Name, capacity);
                } 
            }
		}	
	}

    private static void GetOneInstanceInfoWhenGameRun(object o)
	{
        if (o != null)
        {
            int count = -1;
            int capacity = -1;
            Type t = o.GetType();
            FieldInfo[] fis = t.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic);
            for(int i=0; i<fis.Length; i++)
            {
                FieldInfo fi = fis[i];
                if (typeof(ICollection).IsAssignableFrom(fi.FieldType) && fi.FieldType.IsGenericType)
                {
                    GetOneCollectionInfo(fi, o, ref count, ref capacity);
                    if (typeof(IList).IsAssignableFrom(fi.FieldType))
                    {
                        instanceListCapcityEnd[o][fi.Name] = capacity;
                        int oldCount;
                        if (instanceListMaxCount[o].TryGetValue(fi.Name, out oldCount))
                        {
                            if (count > oldCount)
                            {
                                instanceListMaxCount[o][fi.Name] = count;
                            }
                        }
                        else
                        {
                            instanceListMaxCount[o].Add(fi.Name, count);
                        }
                    } 
                    else
                    {
                        int oldCount;
                        if (instanceDictMaxCount[o].TryGetValue(fi.Name, out oldCount))
                        {
                            if (count > oldCount)
                            {
                                instanceDictMaxCount[o][fi.Name] = count;
                            }
                        }
                        else
                        {
                            instanceDictMaxCount[o].Add(fi.Name, count);
                        }
                    }
                }
            }
        }
	}

    private static void GetOneCollectionInfo(FieldInfo fi, object o, ref int count, ref int capacity)
    {
        object fiobj = fi.GetValue(o);
        if (fiobj != null)
        {
            PropertyInfo countInfo = fi.FieldType.GetProperty("Count");
            PropertyInfo capacityInfo = fi.FieldType.GetProperty("Capacity");
            if (countInfo != null)
            {
                count = (int)countInfo.GetValue(fiobj, null);
            }
            if (capacityInfo != null)
            {
                capacity = (int)capacityInfo.GetValue(fiobj, null);
            }
        }
    }
}

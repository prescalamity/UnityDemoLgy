﻿/*
Copyright (c) 2015-2016 topameng(topameng@qq.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;
using System;
using System.Collections;
using System.Text;
using System.Reflection;
using System.Collections.Generic;


#if DEV_BRANCH
#else
using LuaInterface;
using Object = UnityEngine.Object;
using System.IO;
using System.Text.RegularExpressions;


public enum MetaOp
{
    None = 0,
    Add = 1,
    Sub = 2,
    Mul = 4,
    Div = 8,
    Eq = 16,
    Neg = 32,
    ToStr = 64,
    ALL = Add | Sub | Mul | Div | Eq | Neg | ToStr,
}

public enum ObjAmbig
{
    None = 0,
    U3dObj = 1,
    NetObj = 2,
    All = 3
}

public class DelegateType
{
    public string name;
    public Type type;
    public string abr = null;

    public string strType = "";

    public DelegateType(Type t)
    {
        type = t;
        strType = ToLuaExport.GetTypeStr(t);
        name = ToLuaExport.ConvertToLibSign(strType);
    }

    public DelegateType SetAbrName(string str)
    {
        abr = str;
        return this;
    }
}

public static class ToLuaExport
{
    public static string className = string.Empty;
    public static Type type = null;
    public static Type baseType = null;
    public static bool isUnityEngineType = false;

    public static bool isStaticClass = true;

    static HashSet<string> usingList = new HashSet<string>();
    static MetaOp op = MetaOp.None;
    static StringBuilder sb = null;
    static List<MethodInfo> methods = new List<MethodInfo>();
    static Dictionary<string, int> nameCounter = new Dictionary<string, int>();
    static Dictionary<int, int> paramCounter = new Dictionary<int, int>(); //记录参数数量，参数数量相同的重载
    static FieldInfo[] fields = null;
    static PropertyInfo[] props = null;
    static List<PropertyInfo> propList = new List<PropertyInfo>();  //非静态属性
    static List<PropertyInfo> allProps = new List<PropertyInfo>();
    static EventInfo[] events = null;
    static List<EventInfo> eventList = new List<EventInfo>();
    static List<ConstructorInfo> ctorList = new List<ConstructorInfo>();
    static List<ConstructorInfo> ctorExtList = new List<ConstructorInfo>();
    static PropertyInfo ItemProperty = null;   //特殊属性

    static BindingFlags binding = BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase;

    static ObjAmbig ambig = ObjAmbig.NetObj;
    //wrapClaaName + "Wrap" = 导出文件名，导出类名
    public static string wrapClassName = "";

    public static string libClassName = "";
    public static string extendName = "";
    public static Type extendType = null;

    public static HashSet<Type> eventSet = new HashSet<Type>();

    private static bool csenumlua = false;

    //严格的移除数组，用作处理无用重载，避免常用方法频繁typechecker
    public static List<string> strictRemoveList = new List<string>
    {
        "GameObject.UnityEngine.Component GetComponent(System.String)",
        "Component.UnityEngine.Component GetComponent(System.String)",
        "Physics.UnityEngine.RaycastHit[] RaycastAll(UnityEngine.Ray, Single, Int32, UnityEngine.QueryTriggerInteraction)",
        "NavMesh.Boolean SamplePosition(UnityEngine.Vector3, UnityEngine.AI.NavMeshHit ByRef, Single, UnityEngine.AI.NavMeshQueryFilter)",
        "NavMesh.Boolean CalculatePath(UnityEngine.Vector3, UnityEngine.Vector3, UnityEngine.AI.NavMeshQueryFilter, UnityEngine.AI.NavMeshPath)",
        "Input.Boolean GetKey(System.String)",
    };

    public static List<string> memberFilter = new List<string>
    {
        "String.Chars",
        "AnimationClip.averageDuration",
        "AnimationClip.averageAngularSpeed",
        "AnimationClip.averageSpeed",
        "AnimationClip.apparentSpeed",
        "AnimationClip.isLooping",
        "AnimationClip.isAnimatorMotion",
        "AnimationClip.isHumanMotion",
        "AnimatorOverrideController.PerformOverrideClipListCleanup",
        "Caching.SetNoBackupFlag",
        "Caching.ResetNoBackupFlag",
        "Light.areaSize",
        "Security.GetChainOfTrustValue",
        "Texture2D.alphaIsTransparency",
        "WWW.movie",
        "WebCamTexture.MarkNonReadable",
        "WebCamTexture.isReadable",
        "Graphic.OnRebuildRequested",
        "Text.OnRebuildRequested",
        "Resources.LoadAssetAtPath",
        "Application.ExternalEval",         
        //NGUI
        "UIInput.ProcessEvent",
        "UIWidget.showHandlesWithMoveTool",
        "UIWidget.showHandles",
        "Input.IsJoystickPreconfigured",
        "UIDrawCall.isActive",
        "Light.SetLightDirty",
        "MeshRenderer.scaleInLightmap",
        "MeshRenderer.receiveGI",
        "MeshRenderer.stitchLightmapSeams",
        "MonoBehaviour.runInEditMode",
        "ParticleSystemRenderer.supportsMeshInstancing",
        "Light.shadowRadius",
        "Light.lightmapBakeType",
        "Light.shadowAngle",
        "AnimationPlayableAsset.LiveLink",
        "Texture.imageContentsHash",
        "SkeletonRenderer.EditorSkipSkinSync",
        "AssetBundle.SetAssetBundleDecryptKey"
    };

    static List<string> classFilter = new List<string>()
    {
        "SkeletonAnimation",
        "SkeletonRenderer",
        "Skeleton"
    };

    public static bool IsMemberFilter(MemberInfo mi)
    {
        return memberFilter.Contains(type.Name + "." + mi.Name);
    }

    public static bool IsStrictRemove(MemberInfo mi)
    {
        return strictRemoveList.Contains(type.Name + "." + mi.ToString());
    }

    static ToLuaExport()
    {
        Debugger.useLog = true;
    }

    public static void Clear()
    {
        className = null;
        type = null;
        baseType = null;
        isStaticClass = false;
        usingList.Clear();
        op = MetaOp.None;
        sb = new StringBuilder();
        fields = null;
        props = null;
        methods.Clear();
        allProps.Clear();
        propList.Clear();
        eventList.Clear();
        ctorList.Clear();
        ctorExtList.Clear();
        ambig = ObjAmbig.NetObj;
        wrapClassName = "";
        libClassName = "";
        extendName = "";
        eventSet.Clear();
        extendType = null;
        nameCounter.Clear();
        events = null;
        ItemProperty = null;
    }

    private static MetaOp GetOp(string name)
    {
        if (name == "op_Addition")
        {
            return MetaOp.Add;
        }
        else if (name == "op_Subtraction")
        {
            return MetaOp.Sub;
        }
        else if (name == "op_Equality")
        {
            return MetaOp.Eq;
        }
        else if (name == "op_Multiply")
        {
            return MetaOp.Mul;
        }
        else if (name == "op_Division")
        {
            return MetaOp.Div;
        }
        else if (name == "op_UnaryNegation")
        {
            return MetaOp.Neg;
        }
        else if (name == "ToString" && !isStaticClass)
        {
            return MetaOp.ToStr;
        }

        return MetaOp.None;
    }

    //操作符函数无法通过继承metatable实现
    static void GenBaseOpFunction(List<MethodInfo> list)
    {
        Type baseType = type.BaseType;

        while (baseType != null)
        {
            MethodInfo[] methods = baseType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);

            for (int i = 0; i < methods.Length; i++)
            {
                MetaOp baseOp = GetOp(methods[i].Name);

                if (baseOp != MetaOp.None && (op & baseOp) == 0)
                {
                    if (baseOp != MetaOp.ToStr)
                    {
                        list.Add(methods[i]);
                    }

                    op |= baseOp;
                }
            }

            baseType = baseType.BaseType;
        }
    }

    public static StringBuilder WrapTypeAll = new StringBuilder();
    public static StringBuilder TWrapTypeAll = new StringBuilder();
    public static void Generate(string dir)
    {
        if (type.IsInterface && type != typeof(System.Collections.IEnumerator))
        {
            return;
        }

        if(classFilter.Contains(type.Name))
        {
            return;
        }

        Debugger.Log("Begin Generate lua Wrap for class {0}", className);
        sb = new StringBuilder();
        usingList.Add("System");

        if (wrapClassName == "")
        {
            wrapClassName = className;
        }

        if (type.IsEnum)
        {
            GenEnumLua();
            return;
        }

        List<MethodInfo> list = new List<MethodInfo>();

        if (baseType != null || isStaticClass)
        {
            binding |= BindingFlags.DeclaredOnly;
        }

        list.AddRange(type.GetMethods(BindingFlags.Instance | binding));

        for (int i = list.Count - 1; i >= 0; --i)
        {
            //去掉操作符函数
            if (list[i].Name.Contains("op_") || list[i].Name.Contains("add_") || list[i].Name.Contains("remove_"))
            {
                if (!IsNeedOp(list[i].Name))
                {
                    list.RemoveAt(i);
                }

                continue;
            }

            //扔掉 unity3d 废弃的函数                
            if (IsObsolete(list[i]))
            {
                list.RemoveAt(i);
            }
        }

        PropertyInfo[] ps = type.GetProperties();

        for (int i = 0; i < ps.Length; i++)
        {
            if (IsObsolete(ps[i]))
            {
                list.RemoveAll((p) => { return p == ps[i].GetGetMethod() || p == ps[i].GetSetMethod(); });
            }
            else
            {
                MethodInfo md = ps[i].GetGetMethod();

                if (md != null)
                {
                    int index = list.FindIndex((m) => { return m == md; });

                    if (index >= 0)
                    {
                        if (md.GetParameters().Length == 0)
                        {
                            list.RemoveAt(index);
                        }
                        else if (md.Name == "get_Item")
                        {
                            ItemProperty = ps[i];
                        }
                    }
                }

                md = ps[i].GetSetMethod();

                if (md != null)
                {
                    int index = list.FindIndex((m) => { return m == md; });

                    if (index >= 0)
                    {
                        if (md.GetParameters().Length == 1)
                        {
                            list.RemoveAt(index);
                        }
                        else if (md.Name == "set_Item")
                        {
                            ItemProperty = ps[i];
                        }
                    }
                }
            }
        }

        if (!className.Contains("LuaInterface") && !className.Contains("Singleton"))
        {
            if (className.IndexOf('.') > 0)
            {
                string[] cc = className.Split('.');
                WrapTypeAll.AppendFormat("T{0, -30} = {1}.GetClassType()\n", className.Substring(className.LastIndexOf('.') + 1), cc.Length > 2 ? cc[cc.Length - 2] + "." + cc[cc.Length - 1] : className);
                TWrapTypeAll.AppendFormat("\t[\"{0}\"]{1} = T{2},\n", cc[cc.Length - 1], RepStr(" ", 30 - cc[cc.Length - 1].Length), cc[cc.Length - 1]);
            }
            else
            {
                WrapTypeAll.AppendFormat("T{0, -30} = {1}.GetClassType()\n", className, className);
                TWrapTypeAll.AppendFormat("\t[\"{0}\"]{1} = T{2},\n", className, RepStr(" ", 30 - className.Length), className);
            }


        }

        for (int i = 0; i < list.Count; i++)
        {
            GetDelegateTypeFromMethodParams(list[i]);
        }

        ProcessExtends(list);
        GenBaseOpFunction(list);
        methods = list;
        InitPropertyList();
        InitCtorList();

        sb.AppendFormat("public class {0}Wrap\r\n", wrapClassName);
        sb.AppendLine("{");

        GenRegisterFunction();
        GenConstructFunction();
        GenItemPropertyFunction();
        GenGetType();
        GenFunctions();
        GenToStringFunction();
        GenIndexFunc();
        GenNewIndexFunc();
        GenOutFunction();
        GenEventFunctions();

        sb.AppendLine("}\r\n");
        //SaveFile(dir + wrapClassName + "Wrap.cs");
        SaveFile(dir, wrapClassName);
    }

    static string RepStr(string s, int n)
    {
        string ret = "";
        for (int i = 0; i < n; ++i)
        {
            ret += s;
        }

        return ret;
    }
    static void InitPropertyList()
    {
        props = type.GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Instance | binding);
        propList.AddRange(type.GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase));
        fields = type.GetFields(BindingFlags.GetField | BindingFlags.SetField | BindingFlags.Instance | binding);
        events = type.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        eventList.AddRange(type.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public));

        List<FieldInfo> fieldList = new List<FieldInfo>();
        fieldList.AddRange(fields);

        for (int i = fieldList.Count - 1; i >= 0; i--)
        {
            if (IsObsolete(fieldList[i]))
            {
                fieldList.RemoveAt(i);
            }
            else if (typeof(System.Delegate).IsAssignableFrom(fieldList[i].FieldType))
            {
                eventSet.Add(fieldList[i].FieldType);
            }
        }

        fields = fieldList.ToArray();

        List<PropertyInfo> piList = new List<PropertyInfo>();
        piList.AddRange(props);

        for (int i = piList.Count - 1; i >= 0; i--)
        {
            if (IsObsolete(piList[i]))
            {
                piList.RemoveAt(i);
            }
            else if (piList[i].Name == "Item" && IsItemThis(piList[i]))
            {
                piList.RemoveAt(i);
            }
            else if (typeof(System.Delegate).IsAssignableFrom(piList[i].PropertyType))
            {
                eventSet.Add(piList[i].PropertyType);
            }
        }

        props = piList.ToArray();

        for (int i = propList.Count - 1; i >= 0; i--)
        {
            if (IsObsolete(propList[i]))
            {
                propList.RemoveAt(i);
            }
        }

        allProps.AddRange(props);
        allProps.AddRange(propList);

        List<EventInfo> evList = new List<EventInfo>();
        evList.AddRange(events);

        for (int i = evList.Count - 1; i >= 0; i--)
        {
            if (IsObsolete(evList[i]))
            {
                evList.RemoveAt(i);
            }
            else if (typeof(System.Delegate).IsAssignableFrom(evList[i].EventHandlerType))
            {
                eventSet.Add(evList[i].EventHandlerType);
            }
        }

        events = evList.ToArray();

        for (int i = eventList.Count - 1; i >= 0; i--)
        {
            if (IsObsolete(eventList[i]))
            {
                eventList.RemoveAt(i);
            }
        }
    }

    static void SaveFile(string dir, string fileName)
    {
        if (fileName.Contains("UnityEngine_"))
        {
            isUnityEngineType = true;
        }

        if (isUnityEngineType)
        {
            fileName = "/UnityEngine_wrap/" + fileName + "_Wrap.cs";
        }
        else
        {
            fileName = fileName + "Wrap.cs";
        }

        string parentDir = dir + "/UnityEngine_wrap";
        if (!Directory.Exists(parentDir))
        {
            Directory.CreateDirectory(parentDir);
        }

        string file = dir + fileName;

        using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
        {
            StringBuilder usb = new StringBuilder();
            usb.AppendLine("//this source code was auto-generated by tolua#, do not modify it");

            foreach (string str in usingList)
            {
                usb.AppendFormat("using {0};\r\n", str);
            }

            usb.AppendLine("using LuaInterface;");

            if (ambig == ObjAmbig.All)
            {
                usb.AppendLine("using Object = UnityEngine.Object;");
            }

            usb.AppendLine();

            textWriter.Write(usb.ToString());
            textWriter.Write(sb.ToString());

            textWriter.Flush();
            textWriter.Close();


            isUnityEngineType = false;
        }
    }

    static void GenRegisterFuncItems()
    {
        //注册库函数
        for (int i = 0; i < methods.Count; i++)
        {
            MethodInfo m = methods[i];
            int count = 1;

            if (m.IsGenericMethod)
            {
                continue;
            }

            if (!nameCounter.TryGetValue(m.Name, out count))
            {
                if (!m.Name.Contains("op_"))
                {
                    sb.AppendFormat("\t\tL.RegFunction(\"{0}\", {1});\r\n", m.Name, m.Name == "Register" ? "_Register" : m.Name);
                }

                nameCounter[m.Name] = 1;
            }
            else
            {
                nameCounter[m.Name] = count + 1;
            }
        }

        if (ctorList.Count > 0 || type.IsValueType || ctorExtList.Count > 0)
        {
            sb.AppendFormat("\t\tL.RegFunction(\"New\", _Create{0});\r\n", wrapClassName);
        }

        if (ItemProperty != null)
        {
            sb.AppendLine("\t\tL.RegVar(\"this\", _this, null);");
        }
    }

    static void GenRegisterOpItems()
    {
        if ((op & MetaOp.Add) != 0)
        {
            sb.AppendLine("\t\tL.RegFunction(\"__add\", op_Addition);");
        }

        if ((op & MetaOp.Sub) != 0)
        {
            sb.AppendLine("\t\tL.RegFunction(\"__sub\", op_Subtraction);");
        }

        if ((op & MetaOp.Mul) != 0)
        {
            sb.AppendLine("\t\tL.RegFunction(\"__mul\", op_Multiply);");
        }

        if ((op & MetaOp.Div) != 0)
        {
            sb.AppendLine("\t\tL.RegFunction(\"__div\", op_Division);");
        }

        if ((op & MetaOp.Eq) != 0)
        {
            sb.AppendLine("\t\tL.RegFunction(\"__eq\", op_Equality);");
        }

        if ((op & MetaOp.Neg) != 0)
        {
            sb.AppendLine("\t\tL.RegFunction(\"__unm\", op_UnaryNegation);");
        }

        if ((op & MetaOp.ToStr) != 0)
        {
            sb.AppendLine("\t\tL.RegFunction(\"__tostring\", Lua_ToString);");
        }
    }

    static bool IsItemThis(PropertyInfo info)
    {
        MethodInfo md = info.GetGetMethod();

        if (md != null)
        {
            return md.GetParameters().Length != 0;
        }

        md = info.GetSetMethod();

        if (md != null)
        {
            return md.GetParameters().Length != 1;
        }

        return true;
    }

    static void GenRegisterVariables()
    {
        if (fields.Length == 0 && props.Length == 0 && events.Length == 0 && isStaticClass && baseType == null)
        {
            return;
        }

        for (int i = 0; i < fields.Length; i++)
        {
            if (fields[i].IsLiteral || fields[i].IsPrivate || fields[i].IsInitOnly)
            {
                if (fields[i].IsLiteral && fields[i].FieldType.IsPrimitive && !fields[i].FieldType.IsEnum)
                {
                    double d = Convert.ToDouble(fields[i].GetValue(null));
                    sb.AppendFormat("\t\tL.RegConstant(\"{0}\", {1});\r\n", fields[i].Name, d);
                }
                else
                {
                    sb.AppendFormat("\t\tL.RegVar(\"{0}\", get_{0}, null);\r\n", fields[i].Name);
                }
            }
            else
            {
                sb.AppendFormat("\t\tL.RegVar(\"{0}\", get_{0}, set_{0});\r\n", fields[i].Name);
            }
        }

        for (int i = 0; i < props.Length; i++)
        {
            if (props[i].CanRead && props[i].CanWrite && props[i].GetSetMethod(true).IsPublic)
            {
                MethodInfo md = methods.Find((p) => { return p.Name == "get_" + props[i].Name; });
                string get = md == null ? "get" : "_get";
                md = methods.Find((p) => { return p.Name == "set_" + props[i].Name; });
                string set = md == null ? "set" : "_set";
                sb.AppendFormat("\t\tL.RegVar(\"{0}\", {1}_{0}, {2}_{0});\r\n", props[i].Name, get, set);
            }
            else if (props[i].CanRead)
            {
                MethodInfo md = methods.Find((p) => { return p.Name == "get_" + props[i].Name; });
                sb.AppendFormat("\t\tL.RegVar(\"{0}\", {1}_{0}, null);\r\n", props[i].Name, md == null ? "get" : "_get");
            }
            else if (props[i].CanWrite)
            {
                MethodInfo md = methods.Find((p) => { return p.Name == "set_" + props[i].Name; });
                sb.AppendFormat("\t\tL.RegVar(\"{0}\", null, {1}_{0});\r\n", props[i].Name, md == null ? "set" : "_set");
            }
        }

        for (int i = 0; i < events.Length; i++)
        {
            sb.AppendFormat("\t\tL.RegVar(\"{0}\", get_{0}, set_{0});\r\n", events[i].Name);
        }
    }

    static void GenRegisterEventTypes()
    {
        List<Type> list = new List<Type>();

        foreach (Type t in eventSet)
        {
            string funcName = null;
            string space = GetNameSpace(t, out funcName);

            if (space != className)
            {
                list.Add(t);
                continue;
            }

            funcName = ConvertToLibSign(funcName);
            int index = Array.FindIndex<DelegateType>(CustomSettings.customDelegateList, (p) => { return p.type == t; });
            string abr = null;
            if (index >= 0) abr = CustomSettings.customDelegateList[index].abr;
            abr = abr == null ? funcName : abr;
            funcName = ConvertToLibSign(space) + "_" + funcName;

            sb.AppendFormat("\t\tL.RegFunction(\"{0}\", {1});\r\n", abr, funcName);
        }

        for (int i = 0; i < list.Count; i++)
        {
            eventSet.Remove(list[i]);
        }
    }

    static void GenOtherSpecialFun()
    {
        sb.AppendLine("\t\tL.RegFunction(\"GetClassType\", GetClassType);");
    }

    static void GenRegisterFunction()
    {
        sb.AppendLine("\tpublic static void Register(LuaState L)");
        sb.AppendLine("\t{");

        if (isStaticClass)
        {
            sb.AppendFormat("\t\tL.BeginStaticLibs(\"{0}\");\r\n", libClassName);
        }
        else if (!type.IsGenericType)
        {
            if (baseType == null)
            {
                sb.AppendFormat("\t\tL.BeginClass(typeof({0}), null, \"{1}\");\r\n", className, className.Substring(className.LastIndexOf('.') + 1));
            }
            else
            {
                sb.AppendFormat("\t\tL.BeginClass(typeof({0}), typeof({1}), \"{2}\");\r\n", className, GetBaseTypeStr(baseType), className.Substring(className.LastIndexOf('.') + 1));
            }
        }
        else
        {
            if (baseType == null)
            {
                sb.AppendFormat("\t\tL.BeginClass(typeof({0}), null, \"{1}\");\r\n", className, libClassName);
            }
            else
            {
                sb.AppendFormat("\t\tL.BeginClass(typeof({0}), typeof({1}), \"{2}\");\r\n", className, GetBaseTypeStr(baseType), libClassName);
            }
        }

        GenRegisterFuncItems();
        GenRegisterOpItems();
        GenRegisterVariables();
        GenRegisterEventTypes();            //注册事件类型
        GenOtherSpecialFun();

        if (!isStaticClass)
        {
            if (CustomSettings.outList.IndexOf(type) >= 0)
            {
                sb.AppendLine("\t\tL.RegVar(\"out\", get_out, null);");
            }

            sb.AppendFormat("\t\tL.EndClass();\r\n");
        }
        else
        {
            sb.AppendFormat("\t\tL.EndStaticLibs();\r\n");
        }

        sb.AppendLine("\t}");
    }

    static bool IsParams(ParameterInfo param)
    {
        return param.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0;
    }

    static void GenGetType()
    {
        sb.AppendFormat("\r\n\tstatic Type classType = typeof({0});\r\n", className);

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", "GetClassType");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tToLua.Push(L, classType);");
        sb.AppendLine("\t\treturn 1;");
        sb.AppendLine("\t}");
    }

    static void GenFunction(MethodInfo m)
    {
        if(m.Name == "GetPositions")
            Debug.Log("");
        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", m.Name == "Register" ? "_Register" : m.Name);
        sb.AppendLine("\t{");

        if (HasAttribute(m, typeof(UseDefinedAttribute)))
        {
            FieldInfo field = extendType.GetField(m.Name + "Defined");
            string strfun = field.GetValue(null) as string;
            sb.AppendLine(strfun);
            sb.AppendLine("\t}");
            return;
        }

        bool canProfiler = !HasAttribute(m, typeof(DoNotProfiler));

        ParameterInfo[] paramInfos = m.GetParameters();
        int offset = m.IsStatic ? 0 : 1;
        bool haveParams = HasOptionalParam(paramInfos);
        int rc = m.ReturnType == typeof(void) ? 0 : 1;

        BeginTry();

        //if (canProfiler)
        //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.Begin(\"{0}.{1}\");\n#endif\n", className, m.Name);
        if (!haveParams)
        {
            int count = paramInfos.Length + offset;
            sb.AppendFormat("\t\t\tToLua.CheckArgsCount(L, {0});\r\n", count);
        }
        else
        {
            sb.AppendLine("\t\t\tint count = LuaDLL.lua_gettop(L);");
        }

        rc += ProcessParams(m, 3, false);
        //if (canProfiler)
        //    sb.AppendLine("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.End();\n#endif");
        sb.AppendFormat("\t\t\treturn {0};\r\n", rc);
        EndTry();
        sb.AppendLine("\t}");
    }
     
    static void GenFunctions()
    {
        HashSet<string> set = new HashSet<string>();

        for (int i = 0; i < methods.Count; i++)
        {
            MethodInfo m = methods[i];

            if (m.IsGenericMethod)
            {
                Debugger.Log("Generic Method {0} cannot be export to lua", m.Name);
                continue;
            }

            if (nameCounter[m.Name] > 1)
            {
                if (!set.Contains(m.Name))
                {
                    MethodInfo mi = GenOverrideFunc(m.Name);

                    if (mi == null)
                    {
                        set.Add(m.Name);
                        continue;
                    }
                    else
                    {
                        m = mi;     //非重载函数，或者折叠之后只有一个函数
                    }
                }
                else
                {
                    continue;
                }
            }

            set.Add(m.Name);
            GenFunction(m);
        }
    }

    static string GetPushFunction(Type t, bool isByteBuffer = false)
    {
        if (t.IsEnum || t == typeof(bool) || t.IsPrimitive || t == typeof(string) || t == typeof(LuaTable) || t == typeof(LuaCSFunction)
            || t == typeof(LuaFunction) || typeof(UnityEngine.Object).IsAssignableFrom(t) || t == typeof(Type) || t == typeof(IntPtr)
            || typeof(Delegate).IsAssignableFrom(t) || t == typeof(LuaByteBuffer) || t == typeof(Vector3) || t == typeof(Vector2) || t == typeof(Vector4)
            || t == typeof(Quaternion) || t == typeof(Color) || t == typeof(RaycastHit) || t == typeof(Ray) || t == typeof(Touch) || t == typeof(Bounds)
            || t == typeof(object) || typeof(IEnumerator).IsAssignableFrom(t) || typeof(UnityEngine.TrackedReference).IsAssignableFrom(t))
        {
            return "Push";
        }
        else if (t.IsArray || t == typeof(System.Array))
        {
            return "Push";
        }
        else if (t == typeof(LayerMask))
        {
            return "PushLayerMask";
        }
        else if (t == typeof(LuaInteger64))
        {
            return "PushInt64";
        }
        else if (t.IsValueType)
        {
            return "PushValue";
        }

        return "PushObject";
    }

    static void DefaultConstruct()
    {
        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int _Create{0}(IntPtr L)\r\n", wrapClassName);
        sb.AppendLine("\t{");
        sb.AppendFormat("\t\t{0} obj = new {0}();\r\n", className);
        GenPushStr(type, "obj", "\t\t");
        sb.AppendLine("\t\treturn 1;");
        sb.AppendLine("\t}");
    }

    static string GetCountStr(int count)
    {
        if (count != 0)
        {
            return string.Format("count - {0}", count);
        }

        return "count";
    }

    static void GenOutFunction()
    {
        if (isStaticClass || CustomSettings.outList.IndexOf(type) < 0)
        {
            return;
        }

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendLine("\tstatic int get_out(IntPtr L)");
        sb.AppendLine("\t{");
        sb.AppendFormat("\t\tToLua.PushOut<{0}>(L, new LuaOut<{0}>());\r\n", className);
        sb.AppendLine("\t\treturn 1;");
        sb.AppendLine("\t}");
    }

    static void InitCtorList()
    {
        if (isStaticClass || typeof(MonoBehaviour).IsAssignableFrom(type))
        {
            return;
        }

        ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | binding);

        if (extendType != null)
        {
            ConstructorInfo[] ctorExtends = extendType.GetConstructors(BindingFlags.Instance | binding);

            if (HasAttribute(ctorExtends[0], typeof(UseDefinedAttribute)))
            {
                ctorExtList.AddRange(ctorExtends);
            }
        }

        if (constructors.Length == 0)
        {
            return;
        }

        for (int i = 0; i < constructors.Length; i++)
        {
            //c# decimal 参数类型扔掉了
            if (HasDecimal(constructors[i].GetParameters())) continue;

            if (IsObsolete(constructors[i]))
            {
                continue;
            }

            ConstructorInfo r = constructors[i];
            int index = ctorList.FindIndex((p) => { return CompareMethod(p, r) >= 0; });

            if (index >= 0)
            {
                if (CompareMethod(ctorList[index], r) == 2)
                {
                    ctorList.RemoveAt(index);
                    ctorList.Add(r);
                }
            }
            else
            {
                ctorList.Add(r);
            }
        }
    }

    static void GenConstructFunction()
    {
        if (ctorExtList.Count > 0)
        {
            if (HasAttribute(ctorExtList[0], typeof(UseDefinedAttribute)))
            {
                sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
                sb.AppendFormat("\tstatic int _Create{0}(IntPtr L)\r\n", wrapClassName);
                sb.AppendLine("\t{");

                FieldInfo field = extendType.GetField(extendName + "Defined");
                string strfun = field.GetValue(null) as string;
                sb.AppendLine(strfun);
                sb.AppendLine("\t}");
                return;
            }
        }

        if (ctorList.Count == 0)
        {
            if (type.IsValueType)
            {
                DefaultConstruct();
            }

            return;
        }

        ctorList.Sort(Compare);
        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int _Create{0}(IntPtr L)\r\n", wrapClassName);
        sb.AppendLine("\t{");

        BeginTry();
        sb.AppendLine("\t\t\tint count = LuaDLL.lua_gettop(L);");
        sb.AppendLine();

        List<ConstructorInfo> countList = new List<ConstructorInfo>();

        for (int i = 0; i < ctorList.Count; i++)
        {
            int index = ctorList.FindIndex((p) => { return p != ctorList[i] && p.GetParameters().Length == ctorList[i].GetParameters().Length; });

            if (index >= 0 || (HasOptionalParam(ctorList[i].GetParameters()) && ctorList[i].GetParameters().Length > 1))
            {
                countList.Add(ctorList[i]);
            }
        }

        paramCounter.Clear();
        foreach (var ctor in ctorList)
        {
            int paramLength = ctor.GetParameters().Length;
            if (!paramCounter.ContainsKey(paramLength))
            {
                paramCounter.Add(paramLength,0);
            }
            paramCounter[paramLength] += 1;
        }

        MethodBase md = ctorList[0];
        bool hasEmptyCon = ctorList[0].GetParameters().Length == 0 ? true : false;

        //处理重载构造函数
        if (HasOptionalParam(md.GetParameters()))
        {
            ParameterInfo[] paramInfos = md.GetParameters();
            ParameterInfo param = paramInfos[paramInfos.Length - 1];
            string str = GetTypeStr(param.ParameterType.GetElementType());

            if (paramInfos.Length > 1)
            {
                string strParams = GenParamTypes(paramInfos, true);
                sb.AppendFormat("\t\t\tif (TypeChecker.CheckTypes(L, 1, {0}) && TypeChecker.CheckParamsType(L, typeof({1}), {2}, {3}))\r\n", strParams, str, paramInfos.Length, GetCountStr(paramInfos.Length - 1));
            }
            else
            {
                sb.AppendFormat("\t\t\tif (TypeChecker.CheckParamsType(L, typeof({0}), {1}, {2}))\r\n", str, paramInfos.Length, GetCountStr(paramInfos.Length - 1));
            }
        }
        else
        {
            ParameterInfo[] paramInfos = md.GetParameters();

            if (ctorList.Count == 1 || md.GetParameters().Length != ctorList[1].GetParameters().Length)
            {
                sb.AppendFormat("\t\t\tif (count == {0})\r\n", paramInfos.Length);
            }
            else
            {
                string strParams = GenParamTypes(paramInfos, true);
                sb.AppendFormat("\t\t\tif (count == {0} && TypeChecker.CheckTypes(L, 1, {1}))\r\n", paramInfos.Length, strParams);
            }
        }

        sb.AppendLine("\t\t\t{");
        int rc = ProcessParams(md, 4, true);
        sb.AppendFormat("\t\t\t\treturn {0};\r\n", rc);
        sb.AppendLine("\t\t\t}");

        for (int i = 1; i < ctorList.Count; i++)
        {
            var paramLength = ctorList[i].GetParameters().Length;
            hasEmptyCon = paramLength == 0 ? true : hasEmptyCon;
            md = ctorList[i];
            ParameterInfo[] paramInfos = md.GetParameters();

            if (paramCounter[paramLength] == 1)
            {
                sb.AppendFormat("\t\t\telse if (count == {0})\r\n", paramInfos.Length);
            }
            else if (!HasOptionalParam(md.GetParameters()))
            {
                string strParams = GenParamTypes(paramInfos, true);
                sb.AppendFormat("\t\t\telse if (count == {0} && TypeChecker.CheckTypes(L, 1, {1}))\r\n", paramInfos.Length, strParams);
            }
            else
            {
                ParameterInfo param = paramInfos[paramInfos.Length - 1];
                string str = GetTypeStr(param.ParameterType.GetElementType());

                if (paramInfos.Length > 1)
                {
                    string strParams = GenParamTypes(paramInfos, true);
                    sb.AppendFormat("\t\t\telse if (TypeChecker.CheckTypes(L, 1, {0}) && TypeChecker.CheckParamsType(L, typeof({1}), {2}, {3}))\r\n", strParams, str, paramInfos.Length, GetCountStr(paramInfos.Length - 1));
                }
                else
                {
                    sb.AppendFormat("\t\t\telse if (TypeChecker.CheckParamsType(L, typeof({0}), {1}, {2}))\r\n", str, paramInfos.Length, GetCountStr(paramInfos.Length - 1));
                }
            }

            sb.AppendLine("\t\t\t{");
            rc = ProcessParams(md, 4, true);
            sb.AppendFormat("\t\t\t\treturn {0};\r\n", rc);
            sb.AppendLine("\t\t\t}");
        }

        if (type.IsValueType && !hasEmptyCon)
        {
            sb.AppendLine("\t\t\telse if (count == 0)");
            sb.AppendLine("\t\t\t{");
            sb.AppendFormat("\t\t\t\t{0} obj = new {0}();\r\n", className);
            GenPushStr(type, "obj", "\t\t\t\t");
            sb.AppendLine("\t\t\t\treturn 1;");
            sb.AppendLine("\t\t\t}");
        }

        sb.AppendLine("\t\t\telse");
        sb.AppendLine("\t\t\t{");
        sb.AppendFormat("\t\t\t\treturn LuaDLL.luaL_throw(L, \"invalid arguments to ctor method: {0}.New\");\r\n", className);
        sb.AppendLine("\t\t\t}");

        EndTry();
        sb.AppendLine("\t}");
    }


    //this[] 非静态函数
    static void GenItemPropertyFunction()
    {
        if (ItemProperty == null)
        {
            return;
        }

        int flag = 0;

        if (ItemProperty.CanRead)
        {
            MethodInfo m = ItemProperty.GetGetMethod();
            sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
            sb.AppendLine("\tstatic int _get_this(IntPtr L)");
            sb.AppendLine("\t{");
            BeginTry();

            bool canProfiler = !HasAttribute(m, typeof(DoNotProfiler));

            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.Begin(\"{0}.{1}\");\n#endif\n", className, m.Name);
            int count = m.GetParameters().Length + 1;
            sb.AppendFormat("\t\t\tToLua.CheckArgsCount(L, {0});\r\n", count);
            ProcessParams(m, 3, false, false);
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.End();\n#endif\n");
            sb.AppendLine("\t\t\treturn 1;\r\n");
            EndTry();
            sb.AppendLine("\t}");
            flag |= 1;
        }

        if (ItemProperty.CanWrite)
        {
            MethodInfo m = ItemProperty.GetSetMethod();
            bool canProfiler = !HasAttribute(m, typeof(DoNotProfiler));

            sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
            sb.AppendLine("\tstatic int _set_this(IntPtr L)");
            sb.AppendLine("\t{");
            BeginTry();
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.Begin(\"{0}.{1}\");\n#endif\n", className, m.Name);
            int count = m.GetParameters().Length + 1;
            sb.AppendFormat("\t\t\tToLua.CheckArgsCount(L, {0});\r\n", count);
            ProcessParams(m, 3, false, false);
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.End();\n#endif\n");
            sb.AppendLine("\t\t\treturn 0;\r\n");
            EndTry();
            sb.AppendLine("\t}");
            flag |= 2;
        }

        if (flag != 0)
        {
            sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
            sb.AppendLine("\tstatic int _this(IntPtr L)");
            sb.AppendLine("\t{");
            BeginTry();
            sb.AppendLine("\t\t\tLuaDLL.lua_pushvalue(L, 1);");
            sb.AppendFormat("\t\t\tLuaDLL.tolua_bindthis(L, {0}, {1});\r\n", (flag & 1) == 1 ? "_get_this" : "null", (flag & 2) == 2 ? "_set_this" : "null");
            sb.AppendLine("\t\t\treturn 1;");
            EndTry();
            sb.AppendLine("\t}");
        }
    }

    static int GetOptionalParamPos(ParameterInfo[] infos)
    {
        for (int i = 0; i < infos.Length; i++)
        {
            if (IsParams(infos[i]))
            {
                return i;
            }
        }

        return -1;
    }

    static int Compare(MethodBase lhs, MethodBase rhs)
    {
        int off1 = lhs.IsStatic ? 0 : 1;
        int off2 = rhs.IsStatic ? 0 : 1;

        ParameterInfo[] lp = lhs.GetParameters();
        ParameterInfo[] rp = rhs.GetParameters();

        int pos1 = GetOptionalParamPos(lp);
        int pos2 = GetOptionalParamPos(rp);

        if (pos1 >= 0 && pos2 < 0)
        {
            return 1;
        }
        else if (pos1 < 0 && pos2 >= 0)
        {
            return -1;
        }
        else if (pos1 >= 0 && pos2 >= 0)
        {
            pos1 += off1;
            pos2 += off2;

            if (pos1 != pos2)
            {
                return pos1 > pos2 ? -1 : 1;
            }
            else
            {
                pos1 -= off1;
                pos2 -= off2;

                if (lp[pos1].ParameterType.GetElementType() == typeof(object) && rp[pos2].ParameterType.GetElementType() != typeof(object))
                {
                    return 1;
                }
                else if (lp[pos1].ParameterType.GetElementType() != typeof(object) && rp[pos2].ParameterType.GetElementType() == typeof(object))
                {
                    return -1;
                }
            }
        }

        int c1 = off1 + lp.Length;
        int c2 = off2 + rp.Length;

        if (c1 > c2)
        {
            return 1;
        }
        else if (c1 == c2)
        {
            List<ParameterInfo> list1 = new List<ParameterInfo>(lp);
            List<ParameterInfo> list2 = new List<ParameterInfo>(rp);

            if (list1.Count > list2.Count)
            {
                if (list1[0].ParameterType == typeof(object))
                {
                    return 1;
                }

                list1.RemoveAt(0);
            }
            else if (list2.Count > list1.Count)
            {
                if (list2[0].ParameterType == typeof(object))
                {
                    return -1;
                }

                list2.RemoveAt(0);
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].ParameterType == typeof(object) && list2[i].ParameterType != typeof(object))
                {
                    return 1;
                }
                else if (list1[i].ParameterType != typeof(object) && list2[i].ParameterType == typeof(object))
                {
                    return -1;
                }
            }

            return 0;
        }
        else
        {
            return -1;
        }
    }

    static bool HasOptionalParam(ParameterInfo[] infos)
    {
        for (int i = 0; i < infos.Length; i++)
        {
            if (IsParams(infos[i]))
            {
                return true;
            }
        }

        return false;
    }

    static void CheckObject(string head, Type type, string className, int pos)
    {
        if (type == typeof(System.Enum))
        {
            sb.AppendFormat("{0}{1} obj = ({1})LuaDLL.luaL_checknumber(L, {2});\r\n", head, className, pos);
        }
        else
        if (type == typeof(object))
        {
            sb.AppendFormat("{0}object obj = ToLua.CheckObject(L, {1});\r\n", head, pos);
        }
        else
        {
            sb.AppendFormat("{0}{1} obj = ({1})ToLua.CheckObject(L, {2}, typeof({1}));\r\n", head, className, pos);
        }
    }

    static void ToObject(string head, Type type, string className, int pos)
    {
        if (type == typeof(object))
        {
            sb.AppendFormat("{0}object obj = ToLua.ToObject(L, {1});\r\n", head, pos);
        }
        else
        {
            sb.AppendFormat("{0}{1} obj = ({1})ToLua.ToObject(L, {2});\r\n", head, className, pos);
        }
    }

    static void BeginTry()
    {
        sb.AppendLine("\t\ttry");
        sb.AppendLine("\t\t{");
    }

    static void EndTry()
    {
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t\tcatch(Exception e)");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\treturn LuaDLL.toluaL_exception(L, e);");
        sb.AppendLine("\t\t}");
    }

    static Type GetRefBaseType(Type argType)
    {
        if (argType.IsByRef)
        {
            return argType.GetElementType();
        }

        return argType;
    }

    static void ProcessArg(Type varType, string head, string arg, int stackPos, bool beCheckTypes = false, bool beParams = false, bool beOutArg = false)
    {
        varType = GetRefBaseType(varType);
        string str = GetTypeStr(varType);
        string checkStr = beCheckTypes ? "To" : "Check";

        if (beOutArg)
        {
            if (varType.IsValueType)
            {
                sb.AppendFormat("{0}{1} {2};\r\n", head, str, arg);
            }
            else
            {
                sb.AppendFormat("{0}{1} {2} = null;\r\n", head, str, arg);
            }
        }
        else if (varType.BaseType == typeof(Enum))
        {
            sb.AppendFormat("{0}{1} {2} = ({1})LuaDLL.luaL_checknumber(L, {3});\r\n", head, str, arg, stackPos);
        }
        else if (varType == typeof(bool))
        {
            string chkstr = beCheckTypes ? "lua_toboolean" : "luaL_checkboolean";
            sb.AppendFormat("{0}bool {1} = LuaDLL.{2}(L, {3});\r\n", head, arg, chkstr, stackPos);
        }
        else if (varType == typeof(string))
        {
            sb.AppendFormat("{0}string {1} = ToLua.{2}String(L, {3});\r\n", head, arg, checkStr, stackPos);
        }
        else if (varType == typeof(IntPtr))
        {
            sb.AppendFormat("{0}{1} {2} = ({1})LuaDLL.lua_touserdata(L, {3});\r\n", head, str, arg, stackPos);
        }
        else if (varType.IsPrimitive)
        {
            string chkstr = beCheckTypes ? "lua_tonumber" : "luaL_checknumber";
            sb.AppendFormat("{0}{1} {2} = ({1})LuaDLL.{3}(L, {4});\r\n", head, str, arg, chkstr, stackPos);
        }
        else if (varType == typeof(LuaFunction))
        {
            sb.AppendFormat("{0}LuaFunction {1} = ToLua.{2}LuaFunction(L, {3});\r\n", head, arg, checkStr, stackPos);
        }
        else if (varType.IsSubclassOf(typeof(System.MulticastDelegate)))
        {
            sb.AppendFormat("{0}{1} {2} = null;\r\n", head, str, arg);
            sb.AppendFormat("{0}LuaTypes funcType{1} = LuaDLL.lua_type(L, {1});\r\n", head, stackPos);
            sb.AppendLine();
            sb.AppendFormat("{0}if (funcType{1} != LuaTypes.LUA_TFUNCTION)\r\n", head, stackPos);
            sb.AppendLine(head + "{");

            if (beCheckTypes)
            {
                sb.AppendFormat("{3} {1} = ({0})ToLua.ToObject(L, {2});\r\n", str, arg, stackPos, head + "\t");
            }
            else
            {
                sb.AppendFormat("{3} {1} = ({0})ToLua.CheckObject(L, {2}, typeof({0}));\r\n", str, arg, stackPos, head + "\t");
            }

            sb.AppendFormat("{0}}}\r\n{0}else\r\n{0}{{\r\n", head);
            sb.AppendFormat("{0}\tLuaFunction func = ToLua.ToLuaFunction(L, {1});\r\n", head, stackPos);
            sb.AppendFormat("{0}\t{1} = DelegateFactory.CreateDelegate(typeof({2}), func) as {2};\r\n", head, arg, GetTypeStr(varType));

            sb.AppendLine(head + "}");
            sb.AppendLine();
        }
        else if (varType == typeof(LuaTable))
        {
            sb.AppendFormat("{0}LuaTable {1} = ToLua.{2}LuaTable(L, {3});\r\n", head, arg, checkStr, stackPos);
        }
        else if (varType == typeof(Vector2))
        {
            sb.AppendFormat("{0}UnityEngine.Vector2 {1} = ToLua.ToVector2(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(Vector3))
        {
            sb.AppendFormat("{0}UnityEngine.Vector3 {1} = ToLua.ToVector3(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(Vector4))
        {
            sb.AppendFormat("{0}UnityEngine.Vector4 {1} = ToLua.ToVector4(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(Quaternion))
        {
            sb.AppendFormat("{0}UnityEngine.Quaternion {1} = ToLua.ToQuaternion(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(Color))
        {
            sb.AppendFormat("{0}UnityEngine.Color {1} = ToLua.ToColor(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(Ray))
        {
            sb.AppendFormat("{0}UnityEngine.Ray {1} = ToLua.ToRay(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(Bounds))
        {
            sb.AppendFormat("{0}UnityEngine.Bounds {1} = ToLua.ToBounds(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(LayerMask))
        {
            sb.AppendFormat("{0}UnityEngine.LayerMask {1} = ToLua.ToLayerMask(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(LuaInteger64))
        {
            string chkstr = beCheckTypes ? "LuaDLL.tolua_toint64" : "ToLua.CheckLuaInteger64";
            sb.AppendFormat("{0}LuaInteger64 {1} = {2}(L, {3});\r\n", head, arg, chkstr, stackPos);
        }
        else if (varType == typeof(object))
        {
            sb.AppendFormat("{0}object {1} = ToLua.ToVarObject(L, {2});\r\n", head, arg, stackPos);
        }
        else if (varType == typeof(LuaByteBuffer))
        {
            sb.AppendFormat("{0}LuaByteBuffer {1} = new LuaByteBuffer(ToLua.{2}ByteBuffer(L, {3}));\r\n", head, arg, checkStr, stackPos);
        }
        else if (varType.IsArray && varType.GetArrayRank() == 1)
        {
            Type et = varType.GetElementType();
            string atstr = GetTypeStr(et);
            string fname;
            bool flag = false;                          //是否模版函数
            bool isObject = false;

            if (et.IsPrimitive && !et.IsEnum)
            {
                if (beParams)
                {
                    if (et == typeof(bool))
                    {
                        fname = beCheckTypes ? "ToParamsBool" : "CheckParamsBool";
                    }
                    else if (et == typeof(char))
                    {
                        //char用的多些，特殊处理一下减少gcalloc
                        fname = beCheckTypes ? "ToParamsChar" : "CheckParamsChar";
                    }
                    else
                    {
                        flag = true;
                        fname = beCheckTypes ? "ToParamsNumber" : "CheckParamsNumber";
                    }
                }
                else if (et == typeof(char))
                {
                    fname = "CheckCharBuffer";      //使用Table传数组，CheckType只是简单匹配。需要读取函数继续匹配
                }
                else if (et == typeof(byte))
                {
                    fname = "CheckByteBuffer";
                }
                else
                {
                    fname = "CheckNumberArray";
                    flag = true;
                }
            }
            else if (et == typeof(string))
            {
                if (beParams)
                {
                    fname = "ToParamsString";
                }
                else
                {
                    fname = "CheckStringArray";
                }
            }
            else //if (et == typeof(object))
            {
                flag = true;

                if (et == typeof(object))
                {
                    isObject = true;
                    flag = false;
                }

                if (beParams)
                {
                    fname = (isObject || beCheckTypes) ? "ToParamsObject" : "CheckParamsObject";
                }
                else
                {
                    fname = "CheckObjectArray";
                }

                if (et == typeof(UnityEngine.Object))
                {
                    ambig |= ObjAmbig.U3dObj;
                }
            }

            if (flag)
            {
                if (beParams)
                {
                    if (!isObject)
                    {
                        sb.AppendFormat("{0}{1}[] {2} = ToLua.{3}<{1}>(L, {4}, {5});\r\n", head, atstr, arg, fname, stackPos, GetCountStr(stackPos - 1));
                    }
                    else
                    {
                        sb.AppendFormat("{0}object[] {1} = ToLua.{2}(L, {3}, {4});\r\n", head, arg, fname, stackPos, GetCountStr(stackPos - 1));
                    }
                }
                else
                {
                    sb.AppendFormat("{0}{1}[] {2} = ToLua.{3}<{1}>(L, {4});\r\n", head, atstr, arg, fname, stackPos);
                }
            }
            else
            {
                if (beParams)
                {
                    sb.AppendFormat("{0}{1}[] {2} = ToLua.{3}(L, {4}, {5});\r\n", head, atstr, arg, fname, stackPos, GetCountStr(stackPos - 1));
                }
                else
                {
                    sb.AppendFormat("{0}{1}[] {2} = ToLua.{3}(L, {4});\r\n", head, atstr, arg, fname, stackPos);
                }
            }
        }
        else if (varType.IsValueType && !varType.IsEnum)
        {
            string func = beCheckTypes ? "To" : "Check";
            sb.AppendFormat("{0}{1} {2} = StackTraits<{1}>.{3}(L, {4});\r\n", head, str, arg, func, stackPos);
        }
        else //从object派生但不是object
        {
            if (beCheckTypes)
            {
                sb.AppendFormat("{0}{1} {2} = ({1})ToLua.ToObject(L, {3});\r\n", head, str, arg, stackPos);
            }
            else if (varType == typeof(UnityEngine.TrackedReference) || typeof(UnityEngine.TrackedReference).IsAssignableFrom(varType))
            {
                sb.AppendFormat("{3}{0} {1} = ({0})ToLua.CheckTrackedReference(L, {2}, typeof({0}));\r\n", str, arg, stackPos, head);
            }
            else if (varType.BaseType == typeof(Enum))
            {
                sb.AppendFormat("{0}{1} {2} = ({1})LuaDLL.luaL_checknumber(L, {3});\r\n", head, str, arg, stackPos);
            }
            else if (typeof(UnityEngine.Object).IsAssignableFrom(varType))
            {
                sb.AppendFormat("{3}{0} {1} = ({0})ToLua.CheckUnityObject(L, {2}, typeof({0}));\r\n", str, arg, stackPos, head);
            }
            else
            {
                sb.AppendFormat("{0}{1} {2} = ({1})ToLua.CheckObject(L, {3}, typeof({1}));\r\n", head, str, arg, stackPos);
            }
        }
    }

    static int GetMethodType(MethodBase md, out PropertyInfo pi)
    {
        int methodType = 0;
        pi = null;
        int pos = allProps.FindIndex((p) => { return p.GetGetMethod() == md || p.GetSetMethod() == md; });

        if (pos >= 0)
        {
            methodType = 1;
            pi = allProps[pos];

            if (md == pi.GetGetMethod())
            {
                if (md.GetParameters().Length > 0)
                {
                    methodType = 2;
                }
            }
            else if (md == pi.GetSetMethod())
            {
                if (md.GetParameters().Length > 1)
                {
                    methodType = 2;
                }
            }
        }

        return methodType;
    }

    static int ProcessParams(MethodBase md, int tab, bool beConstruct, bool beCheckTypes = false)
    {
        ParameterInfo[] paramInfos = md.GetParameters();
        int count = paramInfos.Length;
        string head = string.Empty;
        PropertyInfo pi = null;
        int methodType = GetMethodType(md, out pi);
        int offset = (md.IsStatic || beConstruct) ? 1 : 2;

        if (md.Name == "op_Equality")
        {
            beCheckTypes = true;
        }

        for (int i = 0; i < tab; i++)
        {
            head += "\t";
        }

        if (!md.IsStatic && !beConstruct)
        {
            if (md.Name == "Equals")
            {
                if (!type.IsValueType && !beCheckTypes)
                {
                    CheckObject(head, type, className, 1);
                }
                else
                {
                    sb.AppendFormat("{0}{1} obj = ({1})ToLua.ToObject(L, 1);\r\n", head, className);
                }
            }
            else if (!beCheckTypes)// && methodType == 0)
            {
                CheckObject(head, type, className, 1);
            }
            else
            {
                ToObject(head, type, className, 1);
            }
        }

        for (int j = 0; j < count; j++)
        {
            ParameterInfo param = paramInfos[j];
            string arg = "arg" + j;
            bool beOutArg = param.ParameterType.IsByRef && ((param.Attributes & ParameterAttributes.Out) != ParameterAttributes.None);
            bool beParams = IsParams(param);
            ProcessArg(param.ParameterType, head, arg, offset + j, beCheckTypes, beParams, beOutArg);
        }

        StringBuilder sbArgs = new StringBuilder();
        List<string> refList = new List<string>();
        List<Type> refTypes = new List<Type>();

        for (int j = 0; j < count; j++)
        {
            ParameterInfo param = paramInfos[j];

            if (!param.ParameterType.IsByRef)
            {
                sbArgs.Append("arg");
            }
            else
            {
                if (param.Attributes == ParameterAttributes.Out)
                {
                    sbArgs.Append("out arg");
                }
                else if(param.Attributes == ParameterAttributes.In)
                {
                    sbArgs.Append("in arg");
                }
                else
                {
                    sbArgs.Append("ref arg");
                }

                refList.Add("arg" + j);
                refTypes.Add(GetRefBaseType(param.ParameterType));
            }

            sbArgs.Append(j);

            if (j != count - 1)
            {
                sbArgs.Append(", ");
            }
        }

        if (beConstruct)
        {
            sb.AppendFormat("{2}{0} obj = new {0}({1});\r\n", className, sbArgs.ToString(), head);
            string str = GetPushFunction(type);
            sb.AppendFormat("{0}ToLua.{1}(L, obj);\r\n", head, str);

            for (int i = 0; i < refList.Count; i++)
            {
                GenPushStr(refTypes[i], refList[i], head);
            }

            return refList.Count + 1;
        }

        string obj = md.IsStatic ? className : "obj";
        MethodInfo m = md as MethodInfo;

        if (m.ReturnType == typeof(void))
        {
            if (md.Name == "set_Item")
            {
                if (methodType == 2)
                {
                    sb.AppendFormat("{0}{1}[arg0] = arg1;\r\n", head, obj);
                }
                else if (methodType == 1)
                {
                    sb.AppendFormat("{0}{1}.Item = arg0;\r\n", head, obj, pi.Name);
                }
                else
                {
                    sb.AppendFormat("{0}{1}.{2}({3});\r\n", head, obj, md.Name, sbArgs.ToString());
                }
            }
            else if (methodType == 1)
            {
                sb.AppendFormat("{0}{1}.{2} = arg0;\r\n", head, obj, pi.Name);
            }
            else
            {
                sb.AppendFormat("{3}{0}.{1}({2});\r\n", obj, md.Name, sbArgs.ToString(), head);
            }
        }
        else
        {
            string ret = GetTypeStr(m.ReturnType);

            if (md.Name.Contains("op_"))
            {
                CallOpFunction(md.Name, tab, ret);
            }
            else if (md.Name == "get_Item")
            {
                if (methodType == 2)
                {
                    sb.AppendFormat("{0}{1} o = {2}[{3}];\r\n", head, ret, obj, sbArgs.ToString());
                }
                else if (methodType == 1)
                {
                    sb.AppendFormat("{0}{1} o = {2}.Item;\r\n", head, ret, obj);
                }
                else
                {
                    sb.AppendFormat("{0}{1} o = {2}.{3}({4});\r\n", head, ret, obj, md.Name, sbArgs.ToString());
                }
            }
            else if (md.Name == "Equals")
            {
                if (type.IsValueType)
                {
                    sb.AppendFormat("{0}{1} o = obj.Equals({2});\r\n", head, ret, sbArgs.ToString());
                }
                else
                {
                    sb.AppendFormat("{0}{1} o = obj != null ? obj.Equals({2}) : arg0 == null;\r\n", head, ret, sbArgs.ToString());
                }
            }
            else if (methodType == 1)
            {
                sb.AppendFormat("{0}{1} o = {2}.{3};\r\n", head, ret, obj, pi.Name);
            }
            else
            {
                sb.AppendFormat("{0}{1} o = {2}.{3}({4});\r\n", head, ret, obj, md.Name, sbArgs.ToString());
            }

            bool isbuffer = IsByteBuffer(m);
            GenPushStr(m.ReturnType, "o", head, isbuffer);
            if (m.ReturnType.IsArray)
            {
                string str = GetPushFunction(typeof(System.Int16));
                sb.AppendFormat("{0}int arrayLength = o.Length;\r\n", head);
                sb.AppendFormat("{0}LuaScriptMgr.{1}(L, arrayLength);\r\n", head, str);
            }
        }

        for (int i = 0; i < refList.Count; i++)
        {
            GenPushStr(refTypes[i], refList[i], head);
        }

        if (!md.IsStatic && type.IsValueType)
        {
            sb.Append(head + "ToLua.SetBack(L, 1, obj);\r\n");
        }

        if (m.ReturnType.IsArray)
            return refList.Count + 1;
        else
            return refList.Count;

        return refList.Count;
    }

    static void GenPushStr(Type t, string arg, string head, bool isByteBuffer = false)
    {
        if (t == typeof(int))
        {
            sb.AppendFormat("{0}LuaDLL.lua_pushinteger(L, {1});\r\n", head, arg);
        }
        else if (t == typeof(bool))
        {
            sb.AppendFormat("{0}LuaDLL.lua_pushboolean(L, {1});\r\n", head, arg);
        }
        else if (t == typeof(string))
        {
            sb.AppendFormat("{0}LuaDLL.lua_pushstring(L, {1});\r\n", head, arg);
        }
        else if (t == typeof(IntPtr))
        {
            sb.AppendFormat("{0}LuaDLL.lua_pushlightuserdata(L, {1});\r\n", head, arg);
        }
        else if (t == typeof(LuaInteger64))
        {
            sb.AppendFormat("{0}LuaDLL.tolua_pushint64(L, {1});\r\n", head, arg);
        }
        else if (t.IsPrimitive && !t.IsEnum)
        {
            sb.AppendFormat("{0}LuaDLL.lua_pushnumber(L, {1});\r\n", head, arg);
        }
        else
        {
            string str = GetPushFunction(t);

            if (isByteBuffer && t == typeof(byte[]))
            {
                sb.AppendFormat("{0}ToLua.{1}(L, new LuaByteBuffer({2}));\r\n", head, str, arg);
            }
            else
            {
                sb.AppendFormat("{0}ToLua.{1}(L, {2});\r\n", head, str, arg);
            }
        }
    }

    static bool CompareParmsCount(MethodBase l, MethodBase r)
    {
        if (l == r)
        {
            return false;
        }

        int c1 = l.IsStatic ? 0 : 1;
        int c2 = r.IsStatic ? 0 : 1;

        c1 += l.GetParameters().Length;
        c2 += r.GetParameters().Length;

        return c1 == c2;
    }

    //decimal 类型扔掉了
    static Dictionary<Type, int> typeSize = new Dictionary<Type, int>()
    {
        { typeof(bool), 1 },
        { typeof(char), 2 },
        { typeof(byte), 3 },
        { typeof(sbyte), 4 },
        { typeof(ushort),5 },
        { typeof(short), 6 },
        { typeof(uint), 7 },
        { typeof(int), 8 },
        { typeof(float), 9 },
        { typeof(ulong), 10 },
        { typeof(long), 11 },
        { typeof(double), 12 },

    };

    //-1 不存在替换, 1 保留左面， 2 保留右面
    static int CompareMethod(MethodBase l, MethodBase r)
    {
        int s = 0;

        if (!CompareParmsCount(l, r))
        {
            return -1;
        }
        else
        {
            ParameterInfo[] lp = l.GetParameters();
            ParameterInfo[] rp = r.GetParameters();

            List<Type> ll = new List<Type>();
            List<Type> lr = new List<Type>();

            if (!l.IsStatic)
            {
                ll.Add(type);
            }

            if (!r.IsStatic)
            {
                lr.Add(type);
            }

            for (int i = 0; i < lp.Length; i++)
            {
                ll.Add(lp[i].ParameterType);
            }

            for (int i = 0; i < rp.Length; i++)
            {
                lr.Add(rp[i].ParameterType);
            }

            for (int i = 0; i < ll.Count; i++)
            {
                if (!typeSize.ContainsKey(ll[i]) || !typeSize.ContainsKey(lr[i]))
                {
                    if (ll[i] == lr[i])
                    {
                        continue;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (ll[i].IsPrimitive && lr[i].IsPrimitive && s == 0)
                {
                    s = typeSize[ll[i]] >= typeSize[lr[i]] ? 1 : 2;
                }
                else if (ll[i] != lr[i])
                {
                    return -1;
                }
            }

            if (s == 0 && l.IsStatic)
            {
                s = 2;
            }
        }

        return s;
    }

    static void Push(List<MethodInfo> list, MethodInfo r)
    {
        int index = list.FindIndex((p) => { return p.Name == r.Name && CompareMethod(p, r) >= 0; });

        if (index >= 0)
        {
            if (CompareMethod(list[index], r) == 2)
            {
                list.RemoveAt(index);
                list.Add(r);
                return;
            }
            else
            {
                return;
            }
        }

        list.Add(r);
    }

    static bool HasDecimal(ParameterInfo[] pi)
    {
        for (int i = 0; i < pi.Length; i++)
        {
            if (pi[i].ParameterType == typeof(decimal))
            {
                return true;
            }
        }

        return false;
    }

    public static void GenOverrideFuncBody(MethodInfo md, bool beIf)
    {
        bool beCheckTypes = true;
        int offset = md.IsStatic ? 0 : 1;
        int ret = md.ReturnType == typeof(void) ? 0 : 1;
        string strIf = beIf ? "if " : "else if ";
        var paramInfos = md.GetParameters();

        if (paramCounter[paramInfos.Length] == 1)
        {
            beCheckTypes = false;
            sb.AppendFormat("\t\t\t{0}(count == {1})\r\n", strIf, paramInfos.Length + offset);
        }
        else if (HasOptionalParam(paramInfos))
        {
            ParameterInfo param = paramInfos[paramInfos.Length - 1];
            string str = GetTypeStr(param.ParameterType.GetElementType());

            if (paramInfos.Length > 1)
            {
                string strParams = GenParamTypes(paramInfos, md.IsStatic);
                sb.AppendFormat("\t\t\t{0}(TypeChecker.CheckTypes(L, 1, {1}) && TypeChecker.CheckParamsType(L, typeof({2}), {3}, {4}))\r\n", strIf, strParams, str, paramInfos.Length + offset, GetCountStr(paramInfos.Length + offset - 1));
            }
            else
            {
                sb.AppendFormat("\t\t\t{0}(TypeChecker.CheckParamsType(L, typeof({1}), {2}, {3}))\r\n", strIf, str, paramInfos.Length + offset, GetCountStr(paramInfos.Length + offset - 1));
            }
        }
        else
        {

            if (paramInfos.Length + offset > 0)
            {
                string strParams = GenParamTypes(paramInfos, md.IsStatic);
                sb.AppendFormat("\t\t\t{0}(count == {1} && TypeChecker.CheckTypes(L, 1, {2}))\r\n", strIf, paramInfos.Length + offset, strParams);
            }
            else
            {
                beCheckTypes = false;
                sb.AppendFormat("\t\t\t{0}(count == {1})\r\n", strIf, paramInfos.Length + offset);
            }
        }

        sb.AppendLine("\t\t\t{");
        int count = ProcessParams(md, 4, false, beCheckTypes);
        //sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\t\tUIProfiler.End();\n#endif\n");
        sb.AppendFormat("\t\t\t\treturn {0};\r\n", ret + count);
        sb.AppendLine("\t\t\t}");
    }

    public static MethodInfo GenOverrideFunc(string name)
    {
        List<MethodInfo> list = new List<MethodInfo>();

        for (int i = 0; i < methods.Count; i++)
        {
            if (methods[i].Name == name && !methods[i].IsGenericMethod && !HasDecimal(methods[i].GetParameters()))
            {
                Push(list, methods[i]);
            }
        }

        if (list.Count == 1)
        {
            return list[0];
        }

        list.Sort(Compare);

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", name == "Register" ? "_Register" : name);
        sb.AppendLine("\t{");

        BeginTry();
        //sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.Begin(\"{0}.{1}\");\n#endif\n", className, name);
        sb.AppendLine("\t\t\tint count = LuaDLL.lua_gettop(L);");

        sb.AppendLine();

        paramCounter.Clear();
        foreach (var method in list)
        {
            var paramLength = method.GetParameters().Length;
            if (!paramCounter.ContainsKey(paramLength))
            {
                paramCounter.Add(paramLength, 0);
            }
            paramCounter[paramLength] += 1;
        }
        for (int i = 0; i < list.Count; i++)
        {
            GenOverrideFuncBody(list[i], i == 0);
        }

        sb.AppendLine("\t\t\telse");
        sb.AppendLine("\t\t\t{");
        //sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.End();\n#endif\n");
        sb.AppendFormat("\t\t\t\treturn LuaDLL.luaL_throw(L, \"invalid arguments to method: {0}.{1}\");\r\n", className, name);
        sb.AppendLine("\t\t\t}");

        EndTry();
        sb.AppendLine("\t}");
        return null;
    }

    public static string CombineTypeStr(string space, string name)
    {
        if (string.IsNullOrEmpty(space))
        {
            return name;
        }
        else
        {
            return space + "." + name;
        }
    }

    public static string GetBaseTypeStr(Type t)
    {
        if (t.IsGenericType)
        {
            return LuaMisc.GetTypeName(t);
        }
        else
        {
            return t.FullName;
        }
    }

    //获取类型名字
    public static string GetTypeStr(Type t)
    {
        if (t.IsByRef)
        {
            t = t.GetElementType();
            return GetTypeStr(t);
        }
        else if (t == extendType)
        {
            return GetTypeStr(type);
        }

        return LuaMisc.GetTypeName(t);
    }

    static string GetTypeOf(Type t, string sep)
    {
        string str;

        if (t == null)
        {
            str = string.Format("null{0}", sep);
        }
        else
        {
            if (t.IsByRef)
            {
                t = t.GetElementType();
            }

            str = string.Format("typeof({0}){1}", GetTypeStr(t), sep);
        }

        return str;
    }

    //生成 CheckTypes() 里面的参数列表
    static string GenParamTypes(ParameterInfo[] p, bool isStatic)
    {
        StringBuilder sb = new StringBuilder();
        List<Type> list = new List<Type>();

        if (!isStatic)
        {
            list.Add(type);
        }

        for (int i = 0; i < p.Length; i++)
        {
            if (IsParams(p[i]))
            {
                continue;
            }

            if (p[i].ParameterType.IsByRef && ((p[i].Attributes & ParameterAttributes.Out) != ParameterAttributes.None || (p[i].Attributes & ParameterAttributes.In) != ParameterAttributes.None) )
            {
                Type genericClass = typeof(LuaOut<>);
                Type t = genericClass.MakeGenericType(p[i].ParameterType.GetElementType());
                list.Add(t);
            }
            else
            {
                list.Add(p[i].ParameterType);
            }
        }

        for (int i = 0; i < list.Count - 1; i++)
        {
            sb.Append(GetTypeOf(list[i], ", "));
        }

        sb.Append(GetTypeOf(list[list.Count - 1], ""));
        return sb.ToString();
    }

    static void CheckObjectNull()
    {
        if (type.IsValueType)
        {
            sb.AppendLine("\t\t\tif (o == null)");
        }
        else
        {
            sb.AppendLine("\t\t\tif (obj == null)");
        }
    }

    static void GenGetFieldStr(string varName, Type varType, bool isStatic, bool isByteBuffer, bool beOverride = false, bool canProfiler = true)
    {
        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}_{1}(IntPtr L)\r\n", beOverride ? "_get" : "get", varName);
        sb.AppendLine("\t{");

        if (isStatic)
        {
            string arg = string.Format("{0}.{1}", className, varName);
            GenPushStr(varType, arg, "\t\t", isByteBuffer);
            sb.AppendLine("\t\treturn 1;");
        }
        else
        {
            sb.AppendLine("\t\tobject o = null;\r\n");
            BeginTry();
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.Begin(\"{0}.{1}\");\n#endif\n", className, varName);
            sb.AppendLine("\t\t\to = ToLua.ToObject(L, 1);");
            sb.AppendFormat("\t\t\t{0} obj = ({0})o;\r\n", className);
            sb.AppendFormat("\t\t\t{0} ret = obj.{1};\r\n", GetTypeStr(varType), varName);
            GenPushStr(varType, "ret", "\t\t\t", isByteBuffer);
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.End();\n#endif\n");
            sb.AppendLine("\t\t\treturn 1;");

            sb.AppendLine("\t\t}");
            sb.AppendLine("\t\tcatch(Exception e)");
            sb.AppendLine("\t\t{");

            sb.AppendFormat("\t\t\treturn LuaDLL.toluaL_exception(L, e, o == null ? \"attempt to index {0} on a nil value\" : e.Message);\r\n", varName);
            sb.AppendLine("\t\t}");
        }

        sb.AppendLine("\t}");
    }

    static void GenGetEventStr(string varName, Type varType)
    {
        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int get_{0}(IntPtr L)\r\n", varName);
        sb.AppendLine("\t{");
        sb.AppendFormat("\t\tToLua.Push(L, new EventObject(\"{0}.{1}\"));\r\n", GetTypeStr(type), varName);
        sb.AppendLine("\t\treturn 1;");
        sb.AppendLine("\t}");
    }

    static void GenIndexFunc()
    {
        for (int i = 0; i < fields.Length; i++)
        {
            if (fields[i].IsLiteral && fields[i].FieldType.IsPrimitive && !fields[i].FieldType.IsEnum)
            {
                continue;
            }

            bool canProfiler = !HasAttribute(fields[i], typeof(DoNotProfiler));

            bool beBuffer = IsByteBuffer(fields[i]);
            GenGetFieldStr(fields[i].Name, fields[i].FieldType, fields[i].IsStatic, beBuffer, false, canProfiler);
        }

        for (int i = 0; i < props.Length; i++)
        {
            if (!props[i].CanRead)
            {
                continue;
            }

            bool isStatic = true;
            int index = propList.IndexOf(props[i]);

            if (index >= 0)
            {
                isStatic = false;
            }
            bool canProfiler = !HasAttribute(props[i], typeof(DoNotProfiler));

            MethodInfo md = methods.Find((p) => { return p.Name == "get_" + props[i].Name; });
            bool beBuffer = IsByteBuffer(props[i]);
            GenGetFieldStr(props[i].Name, props[i].PropertyType, isStatic, beBuffer, md != null, canProfiler);
        }

        for (int i = 0; i < events.Length; i++)
        {
            GenGetEventStr(events[i].Name, events[i].EventHandlerType);
        }
    }

    static void GenSetFieldStr(string varName, Type varType, bool isStatic, bool beOverride = false, bool canProfiler = true)
    {
        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}_{1}(IntPtr L)\r\n", beOverride ? "_set" : "set", varName);
        sb.AppendLine("\t{");

        if (!isStatic)
        {
            sb.AppendLine("\t\tobject o = null;\r\n");
            BeginTry();
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.Begin(\"{0}.{1}\");\n#endif\n", className, varName);
            sb.AppendLine("\t\t\to = ToLua.ToObject(L, 1);");
            sb.AppendFormat("\t\t\t{0} obj = ({0})o;\r\n", className);
            ProcessArg(varType, "\t\t\t", "arg0", 2);
            sb.AppendFormat("\t\t\tobj.{0} = arg0;\r\n", varName);

            if (type.IsValueType)
            {
                sb.AppendLine("\t\t\tToLua.SetBack(L, 1, obj);");

            }
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.End();\n#endif\n");
            sb.AppendLine("\t\t\treturn 0;");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t\tcatch(Exception e)");
            sb.AppendLine("\t\t{");
            sb.AppendFormat("\t\t\treturn LuaDLL.toluaL_exception(L, e, o == null ? \"attempt to index {0} on a nil value\" : e.Message);\r\n", varName);
            sb.AppendLine("\t\t}");
        }
        else
        {
            BeginTry();
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.Begin(\"{0}.{1}\");\n#endif\n", className, varName);
            ProcessArg(varType, "\t\t\t", "arg0", 2);
            sb.AppendFormat("\t\t\t{0}.{1} = arg0;\r\n", className, varName);
            //if (canProfiler)
            //    sb.AppendFormat("#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN\n\t\t\tUIProfiler.End();\n#endif\n");
            sb.AppendLine("\t\t\treturn 0;");
            EndTry();
        }

        sb.AppendLine("\t}");
    }

    static void GenSetEventStr(string varName, Type varType, bool isStatic)
    {
        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int set_{0}(IntPtr L)\r\n", varName);
        sb.AppendLine("\t{");
        BeginTry();

        if (!isStatic)
        {
            sb.AppendFormat("\t\t\t{0} obj = ({0})ToLua.CheckObject(L, 1, typeof({0}));\r\n", className);
        }

        string strVarType = GetTypeStr(varType);
        string objStr = isStatic ? className : "obj";

        sb.AppendLine("\t\t\tEventObject arg0 = null;\r\n");
        sb.AppendLine("\t\t\tif (LuaDLL.lua_isuserdata(L, 2) != 0)");
        sb.AppendLine("\t\t\t{");
        sb.AppendLine("\t\t\t\targ0 = (EventObject)ToLua.ToObject(L, 2);");
        sb.AppendLine("\t\t\t}");
        sb.AppendLine("\t\t\telse");
        sb.AppendLine("\t\t\t{");
        sb.AppendFormat("\t\t\t\treturn LuaDLL.luaL_throw(L, \"The event '{0}.{1}' can only appear on the left hand side of += or -= when used outside of the type '{0}'\");\r\n", className, varName);
        sb.AppendLine("\t\t\t}\r\n");

        sb.AppendLine("\t\t\tif (arg0.op == EventOp.Add)");
        sb.AppendLine("\t\t\t{");
        sb.AppendFormat("\t\t\t\t{0} ev = ({0})DelegateFactory.CreateDelegate(typeof({0}), arg0.func);\r\n", strVarType);
        sb.AppendFormat("\t\t\t\t{0}.{1} += ev;\r\n", objStr, varName);
        sb.AppendLine("\t\t\t}");
        sb.AppendLine("\t\t\telse if (arg0.op == EventOp.Sub)");
        sb.AppendLine("\t\t\t{");
        sb.AppendFormat("\t\t\t\t{0} ev = ({0})LuaMisc.GetEventHandler({1}, typeof({2}), \"{3}\");\r\n", strVarType, isStatic ? "null" : "obj", className, varName);
        sb.AppendFormat("\t\t\t\tDelegate[] ds = ev.GetInvocationList();\r\n");
        sb.AppendLine("\t\t\t\tLuaState state = LuaState.Get(L);");
        sb.AppendLine();

        sb.AppendLine("\t\t\t\tfor (int i = 0; i < ds.Length; i++)");
        sb.AppendLine("\t\t\t\t{");
        sb.AppendFormat("\t\t\t\t\tev = ({0})ds[i];\r\n", strVarType);
        sb.AppendLine("\t\t\t\t\tLuaDelegate ld = ev.Target as LuaDelegate;\r\n");

        sb.AppendLine("\t\t\t\t\tif (ld != null && ld.func == arg0.func)");
        sb.AppendLine("\t\t\t\t\t{");
        sb.AppendFormat("\t\t\t\t\t\t{0}.{1} -= ev;\r\n", objStr, varName);
        sb.AppendLine("\t\t\t\t\t\tstate.DelayDispose(ld.func);");
        sb.AppendLine("\t\t\t\t\t\tbreak;");
        sb.AppendLine("\t\t\t\t\t}");
        sb.AppendLine("\t\t\t\t}\r\n");

        sb.AppendLine("\t\t\t\targ0.func.Dispose();");
        sb.AppendLine("\t\t\t}\r\n");

        sb.AppendLine("\t\t\treturn 0;");
        EndTry();

        sb.AppendLine("\t}");
    }

    static void GenNewIndexFunc()
    {
        for (int i = 0; i < fields.Length; i++)
        {
            if (fields[i].IsLiteral || fields[i].IsInitOnly || fields[i].IsPrivate)
            {
                continue;
            }

            bool canProfiler = !HasAttribute(fields[i], typeof(DoNotProfiler));
            GenSetFieldStr(fields[i].Name, fields[i].FieldType, fields[i].IsStatic, false, canProfiler);
        }

        for (int i = 0; i < props.Length; i++)
        {
            if (!props[i].CanWrite || !props[i].GetSetMethod(true).IsPublic)
            {
                continue;
            }

            bool isStatic = true;
            int index = propList.IndexOf(props[i]);

            if (index >= 0)
            {
                isStatic = false;
            }

            bool canProfiler = !HasAttribute(props[i], typeof(DoNotProfiler));

            MethodInfo md = methods.Find((p) => { return p.Name == "set_" + props[i].Name; });
            GenSetFieldStr(props[i].Name, props[i].PropertyType, isStatic, md != null, canProfiler);
        }

        for (int i = 0; i < events.Length; i++)
        {
            bool isStatic = eventList.IndexOf(events[i]) < 0;
            GenSetEventStr(events[i].Name, events[i].EventHandlerType, isStatic);
        }
    }

    static void GenDefaultDelegate(Type t, string head, string strType)
    {
        if (t.IsPrimitive && !t.IsEnum)
        {
            if (t == typeof(bool))
            {
                sb.AppendFormat("{0}{1} fn = delegate {{ return false; }};\r\n", head, strType);
            }
            else if (t == typeof(char))
            {
                sb.AppendFormat("{0}{1} fn = delegate {{ return '\\0'; }};\r\n", head, strType);
            }
            else
            {
                sb.AppendFormat("{0}{1} fn = delegate {{ return 0; }};\r\n", head, strType);
            }
        }
        else if (!t.IsValueType)
        {
            sb.AppendFormat("{0}{1} fn = delegate {{ return null; }};\r\n", head, strType);
        }
        else
        {
            sb.AppendFormat("{0}{1} fn = delegate {{ return default({2}); }};\r\n", head, strType, GetTypeStr(t));
        }
    }

    static void GenLuaFunctionRetValue(StringBuilder sb, Type t, string head, string name, bool beDefined = false)
    {
        if (t.IsPrimitive && !t.IsEnum)
        {
            if (t == typeof(bool))
            {
                name = beDefined ? name : "bool " + name;
                sb.AppendFormat("{0}{1} = func.CheckBoolean();\r\n", head, name);
            }
            else
            {
                string type = GetTypeStr(t);
                name = beDefined ? name : type + " " + name;
                sb.AppendFormat("{0}{1} = ({2})func.CheckNumber();\r\n", head, name, type);
            }
        }
        else if (t == typeof(string))
        {
            name = beDefined ? name : "string " + name;
            sb.AppendFormat("{0}{1} = func.CheckString();\r\n", head, name);
        }
        else if (typeof(System.MulticastDelegate).IsAssignableFrom(t))
        {
            name = beDefined ? name : GetTypeStr(t) + " " + name;
            sb.AppendFormat("{0}{1} = func.CheckDelegate();\r\n", head, name);
        }
        else if (t == typeof(Vector3))
        {
            name = beDefined ? name : "UnityEngine.Vector3 " + name;
            sb.AppendFormat("{0}{1} = func.CheckVector3();\r\n", head, name);
        }
        else if (t == typeof(Quaternion))
        {
            name = beDefined ? name : "UnityEngine.Quaternion " + name;
            sb.AppendFormat("{0}{1} = func.CheckQuaternion();\r\n", head, name);
        }
        else if (t == typeof(Vector2))
        {
            name = beDefined ? name : "UnityEngine.Vector2 " + name;
            sb.AppendFormat("{0}{1} = func.CheckVector2();\r\n", head, name);
        }
        else if (t == typeof(Vector4))
        {
            name = beDefined ? name : "UnityEngine.Vector4 " + name;
            sb.AppendFormat("{0}{1} = func.CheckVector4();\r\n", head, name);
        }
        else if (t == typeof(Color))
        {
            name = beDefined ? name : "UnityEngine.Color " + name;
            sb.AppendFormat("{0}{1} = func.CheckColor();\r\n", head, name);
        }
        else if (t == typeof(Ray))
        {
            name = beDefined ? name : "UnityEngine.Ray " + name;
            sb.AppendFormat("{0}{1} = func.CheckRay();\r\n", head, name);
        }
        else if (t == typeof(Bounds))
        {
            name = beDefined ? name : "UnityEngine.Bounds " + name;
            sb.AppendFormat("{0}{1} = func.CheckBounds();\r\n", head, name);
        }
        else if (t == typeof(LayerMask))
        {
            name = beDefined ? name : "UnityEngine.LayerMask " + name;
            sb.AppendFormat("{0}{1} = func.CheckLayerMask();\r\n", head, name);
        }
        else if (t == typeof(LuaInteger64))
        {
            name = beDefined ? name : "LuaInteger64 " + name;
            sb.AppendFormat("{0}{1} = func.CheckInteger64();\r\n", head, name);
        }
        else if (t == typeof(object))
        {
            name = beDefined ? name : "object " + name;
            sb.AppendFormat("{0}{1} = func.CheckVariant();\r\n", head, name);
        }
        else if (t == typeof(byte[]))
        {
            name = beDefined ? name : "byte[] " + name;
            sb.AppendFormat("{0}{1} = func.CheckByteBuffer();\r\n", head, name);
        }
        else if (t == typeof(char[]))
        {
            name = beDefined ? name : "char[] " + name;
            sb.AppendFormat("{0}{1} = func.CheckCharBuffer();\r\n", head, name);
        }
        else
        {
            string type = GetTypeStr(t);
            name = beDefined ? name : type + " " + name;
            sb.AppendFormat("{0}{1} = ({2})func.CheckObject(typeof({2}));\r\n", head, name, type);

            //Debugger.LogError("GenLuaFunctionCheckValue undefined type:" + t.FullName);
        }
    }

    public static bool IsByteBuffer(Type type)
    {
        object[] attrs = type.GetCustomAttributes(true);

        for (int j = 0; j < attrs.Length; j++)
        {
            Type t = attrs[j].GetType();

            if (t == typeof(LuaByteBufferAttribute)) // || t.ToString() == "UnityEngine.WrapperlessIcall")
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsByteBuffer(MemberInfo mb)
    {
        object[] attrs = mb.GetCustomAttributes(true);

        for (int j = 0; j < attrs.Length; j++)
        {
            Type t = attrs[j].GetType();

            if (t == typeof(LuaByteBufferAttribute)) // || t.ToString() == "UnityEngine.WrapperlessIcall")
            {
                return true;
            }
        }

        return false;
    }

    static void LuaFuncToDelegate(Type t, string head)
    {
        MethodInfo mi = t.GetMethod("Invoke");
        ParameterInfo[] pi = mi.GetParameters();
        int n = pi.Length;

        if (n == 0)
        {
            sb.AppendLine("() =>");

            if (mi.ReturnType == typeof(void))
            {
                sb.AppendFormat("{0}{{\r\n{0}\tfunc.Call();\r\n{0}}};\r\n", head);
            }
            else
            {
                sb.AppendFormat("{0}{{\r\n{0}\tfunc.Call();\r\n", head);
                GenLuaFunctionRetValue(sb, mi.ReturnType, head, "ret");
                sb.AppendLine(head + "\treturn ret;");
                sb.AppendFormat("{0}}};\r\n", head);
            }

            return;
        }

        sb.AppendFormat("(param0");

        for (int i = 1; i < n; i++)
        {
            sb.AppendFormat(", param{0}", i);
        }

        sb.AppendFormat(") =>\r\n{0}{{\r\n{0}", head);
        sb.AppendLine("\tfunc.BeginPCall();");

        for (int i = 0; i < n; i++)
        {
            string push = GetPushFunction(pi[i].ParameterType);

            if (!IsParams(pi[i]))
            {
                if (pi[i].ParameterType == typeof(byte[]) && IsByteBuffer(t))
                {
                    sb.AppendFormat("{2}\tfunc.{0}(new LuaByteBuffer(param{1}));\r\n", push, i, head);
                }
                else
                {
                    sb.AppendFormat("{2}\tfunc.{0}(param{1});\r\n", push, i, head);
                }
            }
            else
            {
                sb.AppendLine();
                sb.AppendFormat("{0}\tfor (int i = 0; i < param{1}.Length; i++)\r\n", head, i);
                sb.AppendLine(head + "\t{");
                sb.AppendFormat("{2}\t\tfunc.{0}(param{1}[i]);\r\n", push, i, head);
                sb.AppendLine(head + "\t}\r\n");
            }
        }

        sb.AppendFormat("{0}\tfunc.PCall();\r\n", head);

        if (mi.ReturnType == typeof(void))
        {
            for (int i = 0; i < pi.Length; i++)
            {
                if ((pi[i].Attributes & ParameterAttributes.Out) != ParameterAttributes.None)
                {
                    GenLuaFunctionRetValue(sb, pi[i].ParameterType, head + "\t", "param" + i, true);
                }
            }

            sb.AppendFormat("{0}\tfunc.EndPCall();\r\n", head);
        }
        else
        {
            GenLuaFunctionRetValue(sb, mi.ReturnType, head + "\t", "ret");

            for (int i = 0; i < pi.Length; i++)
            {
                if ((pi[i].Attributes & ParameterAttributes.Out) != ParameterAttributes.None)
                {
                    GenLuaFunctionRetValue(sb, pi[i].ParameterType, head + "\t", "param" + i, true);
                }
            }

            sb.AppendFormat("{0}\tfunc.EndPCall();\r\n", head);
            sb.AppendLine(head + "\treturn ret;");
        }

        sb.AppendFormat("{0}}};\r\n", head);
    }

    static void GenDelegateBody(StringBuilder sb, Type t, string head)
    {
        MethodInfo mi = t.GetMethod("Invoke");
        ParameterInfo[] pi = mi.GetParameters();
        int n = pi.Length;

        if (n == 0)
        {
            if (mi.ReturnType == typeof(void))
            {
                sb.AppendFormat("{0}{{\r\n{0}\tfunc.Call();\r\n{0}}}\r\n", head);
            }
            else
            {
                sb.AppendFormat("{0}{{\r\n{0}\tfunc.Call();\r\n", head);
                GenLuaFunctionRetValue(sb, mi.ReturnType, head, "ret");
                sb.AppendLine(head + "\treturn ret;");
                sb.AppendFormat("{0}}}\r\n", head);
            }

            return;
        }

        sb.AppendFormat("{0}{{\r\n{0}", head);
        sb.AppendLine("\tfunc.BeginPCall();");

        for (int i = 0; i < n; i++)
        {
            string push = GetPushFunction(pi[i].ParameterType);

            if (!IsParams(pi[i]))
            {
                if (pi[i].ParameterType == typeof(byte[]) && IsByteBuffer(t))
                {
                    sb.AppendFormat("{2}\tfunc.{0}(new LuaByteBuffer(param{1}));\r\n", push, i, head);
                }
                else
                {
                    sb.AppendFormat("{2}\tfunc.{0}(param{1});\r\n", push, i, head);
                }
            }
            else
            {
                sb.AppendLine();
                sb.AppendFormat("{0}\tfor (int i = 0; i < param{1}.Length; i++)\r\n", head, i);
                sb.AppendLine(head + "\t{");
                sb.AppendFormat("{2}\t\tfunc.{0}(param{1}[i]);\r\n", push, i, head);
                sb.AppendLine(head + "\t}\r\n");
            }
        }

        sb.AppendFormat("{0}\tfunc.PCall();\r\n", head);

        if (mi.ReturnType == typeof(void))
        {
            for (int i = 0; i < pi.Length; i++)
            {
                if ((pi[i].Attributes & ParameterAttributes.Out) != ParameterAttributes.None)
                {
                    GenLuaFunctionRetValue(sb, pi[i].ParameterType, head + "\t", "param" + i, true);
                }
            }

            sb.AppendFormat("{0}\tfunc.EndPCall();\r\n", head);
        }
        else
        {
            GenLuaFunctionRetValue(sb, mi.ReturnType, head + "\t", "ret");

            for (int i = 0; i < pi.Length; i++)
            {
                if ((pi[i].Attributes & ParameterAttributes.Out) != ParameterAttributes.None)
                {
                    GenLuaFunctionRetValue(sb, pi[i].ParameterType, head + "\t", "param" + i, true);
                }
            }

            sb.AppendFormat("{0}\tfunc.EndPCall();\r\n", head);
            sb.AppendLine(head + "\treturn ret;");
        }

        sb.AppendFormat("{0}}}\r\n", head);
    }

    static void GenToStringFunction()
    {
        if ((op & MetaOp.ToStr) == 0)
        {
            return;
        }

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendLine("\tstatic int Lua_ToString(IntPtr L)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tobject obj = ToLua.ToObject(L, 1);\r\n");

        sb.AppendLine("\t\tif (obj != null)");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tLuaDLL.lua_pushstring(L, obj.ToString());");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t\telse");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tLuaDLL.lua_pushnil(L);");
        sb.AppendLine("\t\t}");
        sb.AppendLine();
        sb.AppendLine("\t\treturn 1;");
        sb.AppendLine("\t}");
    }

    static bool IsNeedOp(string name)
    {
        if (name == "op_Addition")
        {
            op |= MetaOp.Add;
        }
        else if (name == "op_Subtraction")
        {
            op |= MetaOp.Sub;
        }
        else if (name == "op_Equality")
        {
            op |= MetaOp.Eq;
        }
        else if (name == "op_Multiply")
        {
            op |= MetaOp.Mul;
        }
        else if (name == "op_Division")
        {
            op |= MetaOp.Div;
        }
        else if (name == "op_UnaryNegation")
        {
            op |= MetaOp.Neg;
        }
        else if (name == "ToString" && !isStaticClass)
        {
            op |= MetaOp.ToStr;
        }
        else
        {
            return false;
        }


        return true;
    }

    static void CallOpFunction(string name, int count, string ret)
    {
        string head = string.Empty;

        for (int i = 0; i < count; i++)
        {
            head += "\t";
        }

        if (name == "op_Addition")
        {
            sb.AppendFormat("{0}{1} o = arg0 + arg1;\r\n", head, ret);
        }
        else if (name == "op_Subtraction")
        {
            sb.AppendFormat("{0}{1} o = arg0 - arg1;\r\n", head, ret);
        }
        else if (name == "op_Equality")
        {
            sb.AppendFormat("{0}{1} o = arg0 == arg1;\r\n", head, ret);
        }
        else if (name == "op_Multiply")
        {
            sb.AppendFormat("{0}{1} o = arg0 * arg1;\r\n", head, ret);
        }
        else if (name == "op_Division")
        {
            sb.AppendFormat("{0}{1} o = arg0 / arg1;\r\n", head, ret);
        }
        else if (name == "op_UnaryNegation")
        {
            sb.AppendFormat("{0}{1} o = -arg0;\r\n", head, ret);
        }
    }

    public static bool IsObsolete(MemberInfo mb)
    {
        object[] attrs = mb.GetCustomAttributes(true);

        for (int j = 0; j < attrs.Length; j++)
        {
            Type t = attrs[j].GetType();
            
            if (t == typeof(System.ObsoleteAttribute) || t == typeof(NoToLuaAttribute) || t == typeof(DoNotToLua) || t.ToString().Contains("NativeConditionalAttribute")) // || t.ToString() == "UnityEngine.WrapperlessIcall")
            {
                return true;
            }
        }

        if (IsMemberFilter(mb) || IsStrictRemove(mb))
        {
            return true;
        }

        return false;
    }

    public static bool HasAttribute(MemberInfo mb, Type atrtype)
    {
        object[] attrs = mb.GetCustomAttributes(true);

        for (int j = 0; j < attrs.Length; j++)
        {
            Type t = attrs[j].GetType();

            if (t == atrtype)
            {
                return true;
            }
        }

        return false;
    }

    static void GenEnumLua()
    {
#if !DEV_BRANCH
        fields = type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static);
        List<FieldInfo> list = new List<FieldInfo>(fields);

        for (int i = list.Count - 1; i > 0; i--)
        {
            if (IsObsolete(list[i]))
            {
                list.RemoveAt(i);
            }
        }

        string luaPath = CustomSettings.mLuaPath;
        luaPath = luaPath + "config/csenum";
        if (File.Exists(luaPath + "/csenum.lua") && !csenumlua)
        {
            csenumlua = true;
            File.Delete(luaPath + "/csenum.lua");
        }
        else
        {
            if (!Directory.Exists(luaPath))
            {
                Directory.CreateDirectory(luaPath);
            }

        }

        luaPath += "/csenum.lua";

        StringBuilder sbex = new StringBuilder();
        string libClassNameEx = className.Replace(".", "");


        fields = list.ToArray();
        sbex.AppendFormat("--{0}\n", className);
        sbex.AppendFormat("{0} = {1}", libClassNameEx, "{\n");

        for (int i = 0; i < fields.Length; i++)
        {
            Type t = fields[i].FieldType;
            int a = (int)Enum.Parse(t, fields[i].Name);
            sbex.AppendFormat("\t{0} = {1},\r\n", fields[i].Name, a);
        }
        sbex.AppendLine("}\n");

        UTF8Encoding encodingWithoutBom = new UTF8Encoding(false);
        using (StreamWriter textWriter = new StreamWriter(luaPath, true, encodingWithoutBom))
        {
            textWriter.Write(sbex.ToString());
            textWriter.Flush();
            textWriter.Close();
        }
#endif

    }

    static void GenEnum()
    {
        fields = type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static);
        List<FieldInfo> list = new List<FieldInfo>(fields);

        for (int i = list.Count - 1; i > 0; i--)
        {
            if (IsObsolete(list[i]))
            {
                list.RemoveAt(i);
            }
        }

        fields = list.ToArray();
        sb.AppendFormat("public class {0}Wrap\r\n", wrapClassName);
        sb.AppendLine("{");

        sb.AppendLine("\tpublic static void Register(LuaState L)");
        sb.AppendLine("\t{");
        sb.AppendFormat("\t\tL.BeginEnum(typeof({0}));\r\n", className);

        for (int i = 0; i < fields.Length; i++)
        {
            sb.AppendFormat("\t\tL.RegVar(\"{0}\", get_{0}, null);\r\n", fields[i].Name);
        }

        sb.AppendFormat("\t\tL.RegFunction(\"IntToEnum\", IntToEnum);\r\n");
        sb.AppendFormat("\t\tL.EndEnum();\r\n");
        sb.AppendLine("\t}");

        for (int i = 0; i < fields.Length; i++)
        {
            sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
            sb.AppendFormat("\tstatic int get_{0}(IntPtr L)\r\n", fields[i].Name);
            sb.AppendLine("\t{");
            sb.AppendFormat("\t\tToLua.Push(L, {0}.{1});\r\n", className, fields[i].Name);
            sb.AppendLine("\t\treturn 1;");
            sb.AppendLine("\t}");
        }

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendLine("\tstatic int IntToEnum(IntPtr L)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tint arg0 = (int)LuaDLL.lua_tonumber(L, 1);");
        sb.AppendFormat("\t\t{0} o = ({0})arg0;\r\n", className);
        sb.AppendLine("\t\tToLua.Push(L, o);");
        sb.AppendLine("\t\treturn 1;");
        sb.AppendLine("\t}");
    }

    static string CreateDelegate = @"
    [NoToLuaAttribute]
    public static Delegate CreateDelegate(Type t, LuaFunction func = null)
    {
        DelegateValue create = null;

        if (!dict.TryGetValue(t, out create))
        {
            throw new LuaException(string.Format(""Delegate {0} not register"", LuaMisc.GetTypeName(t)));            
        }
        
        return create(func);        
    }
";

    static string RemoveDelegate = @"
    [NoToLuaAttribute]
    public static Delegate RemoveDelegate(Delegate obj, LuaFunction func)
    {
        LuaState state = func.GetLuaState();
        Delegate[] ds = obj.GetInvocationList();

        for (int i = 0; i < ds.Length; i++)
        {
            LuaDelegate ld = ds[i].Target as LuaDelegate;

            if (ld != null && ld.func == func)
            {
                obj = Delegate.Remove(obj, ds[i]);
                state.DelayDispose(ld.func);
                break;
            }
        }

        return obj;
    }
";

    static string GetDelegateParams(MethodInfo mi)
    {
        ParameterInfo[] infos = mi.GetParameters();
        List<string> list = new List<string>();

        for (int i = 0; i < infos.Length; i++)
        {
            string str = IsParams(infos[i]) ? "params " : "";
            string s2 = GetTypeStr(infos[i].ParameterType) + " param" + i;
            str += s2;
            list.Add(str);
        }

        return string.Join(",", list.ToArray());
    }

    public static void GenDelegates(DelegateType[] list)
    {
        usingList.Add("System");
        usingList.Add("System.Collections.Generic");

        for (int i = 0; i < list.Length; i++)
        {
            Type t = list[i].type;

            if (!typeof(System.Delegate).IsAssignableFrom(t))
            {
                Debug.LogError(t.FullName + " not a delegate type");
                return;
            }
        }

        sb.Append("public static class DelegateFactory\r\n");
        sb.Append("{\r\n");
        sb.Append("\tdelegate Delegate DelegateValue(LuaFunction func);\r\n");
        sb.Append("\tstatic Dictionary<Type, DelegateValue> dict = new Dictionary<Type, DelegateValue>();\r\n");
        sb.AppendLine();
        sb.Append("\tstatic DelegateFactory()\r\n");
        sb.Append("\t{\r\n");
        sb.Append("\t\tRegister();\r\n");
        sb.AppendLine("\t}\r\n");

        sb.Append("\t[NoToLuaAttribute]\r\n");
        sb.Append("\tpublic static void Register()\r\n");
        sb.Append("\t{\r\n");
        sb.Append("\t\tdict.Clear();\r\n");

        for (int i = 0; i < list.Length; i++)
        {
            string type = list[i].strType;
            string name = list[i].name;
            sb.AppendFormat("\t\tdict.Add(typeof({0}), {1});\r\n", type, name);
        }

        sb.Append("\t}\r\n");
        sb.Append(CreateDelegate);
        sb.AppendLine(RemoveDelegate);

        for (int i = 0; i < list.Length; i++)
        {
            Type t = list[i].type;
            string strType = list[i].strType;
            string name = list[i].name;
            MethodInfo mi = t.GetMethod("Invoke");
            string args = GetDelegateParams(mi);

            sb.AppendFormat("\tclass {0}_Event : LuaDelegate\r\n", name);
            sb.AppendLine("\t{");
            sb.AppendFormat("\t\tpublic {0}_Event(LuaFunction func) : base(func) {{ }}\r\n", name);
            sb.AppendLine();
            sb.AppendFormat("\t\tpublic {0} Call({1})\r\n", GetTypeStr(mi.ReturnType), args);
            GenDelegateBody(sb, t, "\t\t");
            sb.AppendLine("\t}\r\n");

            sb.AppendFormat("\tpublic static Delegate {0}(LuaFunction func)\r\n", name);
            sb.AppendLine("\t{");
            sb.AppendLine("\t\tif (func == null)");
            sb.AppendLine("\t\t{");


            if (mi.ReturnType == typeof(void))
            {
                sb.AppendLine("\t\t\t" + strType + " fn = delegate { };");
            }
            else
            {
                GenDefaultDelegate(mi.ReturnType, "\t\t\t", strType);
            }

            sb.AppendLine("\t\t\treturn fn;");
            sb.AppendLine("\t\t}\r\n");

            sb.AppendFormat("\t\t{0} d = (new {1}_Event(func)).Call;\r\n", strType, name);
            sb.AppendLine("\t\treturn d;");

            sb.AppendLine("\t}\r\n");
        }

        sb.AppendLine("}\r\n");
        SaveFile(CustomSettings.saveDir, "DelegateFactory.cs");

        Clear();
    }

    static void ProcessExtends(List<MethodInfo> list)
    {
        extendName = "ToLua_" + className.Replace(".", "_");
        extendType = Type.GetType(extendName + ", Assembly-CSharp-Editor");

        if (extendType != null)
        {
            List<MethodInfo> list2 = new List<MethodInfo>();
            list2.AddRange(extendType.GetMethods(BindingFlags.Instance | binding | BindingFlags.DeclaredOnly));

            for (int i = list2.Count - 1; i >= 0; i--)
            {
                if (list2[i].Name.Contains("op_") || list2[i].Name.Contains("add_") || list2[i].Name.Contains("remove_"))
                {
                    if (!IsNeedOp(list2[i].Name))
                    {
                        //list2.RemoveAt(i);
                        continue;
                    }
                }

                list.RemoveAll((md) => { return md.Name == list2[i].Name; });

                if (!IsObsolete(list2[i]))
                {
                    list.Add(list2[i]);
                }
            }

            FieldInfo field = extendType.GetField("AdditionNameSpace");

            if (field != null)
            {
                string str = field.GetValue(null) as string;
                string[] spaces = str.Split(new char[] { ';' });

                for (int i = 0; i < spaces.Length; i++)
                {
                    usingList.Add(spaces[i]);
                }
            }
        }
    }

    static void GetDelegateTypeFromMethodParams(MethodInfo m)
    {
        if (m.IsGenericMethod)
        {
            return;
        }

        ParameterInfo[] pifs = m.GetParameters();

        for (int k = 0; k < pifs.Length; k++)
        {
            Type t = pifs[k].ParameterType;

            if (typeof(System.MulticastDelegate).IsAssignableFrom(t))
            {
                eventSet.Add(t);
            }
        }
    }

    public static void GenEventFunction(Type t, StringBuilder sb)
    {
        string funcName;
        string space = GetNameSpace(t, out funcName);
        funcName = CombineTypeStr(space, funcName);
        funcName = ConvertToLibSign(funcName);

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", funcName);
        sb.AppendLine("\t{");
        sb.AppendLine("\t\ttry");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tLuaFunction func = ToLua.CheckLuaFunction(L, 1);");
        sb.AppendFormat("\t\t\tDelegate arg1 = DelegateFactory.CreateDelegate(typeof({0}), func);\r\n", GetTypeStr(t));
        sb.AppendLine("\t\t\tToLua.Push(L, arg1);");
        sb.AppendLine("\t\t\treturn 1;");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t\tcatch(Exception e)");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\treturn LuaDLL.toluaL_exception(L, e);");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t}");
    }

    static void GenEventFunctions()
    {
        foreach (Type t in eventSet)
        {
            GenEventFunction(t, sb);
        }
    }

    static string RemoveChar(string str, char c)
    {
        int index = str.IndexOf(c);

        while (index > 0)
        {
            str = str.Remove(index, 1);
            index = str.IndexOf(c);
        }

        return str;
    }

    public static string ConvertToLibSign(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }

        str = str.Replace('<', '_');
        str = RemoveChar(str, '>');
        str = str.Replace('[', 's');
        str = RemoveChar(str, ']');
        str = str.Replace('.', '_');
        return str.Replace(',', '_');
    }

    public static string GetNameSpace(Type t, out string libName)
    {
        if (t.IsGenericType)
        {
            return GetGenericNameSpace(t, out libName);
        }
        else
        {
            string space = t.FullName;

            if (space.Contains("+"))
            {
                space = space.Replace('+', '.');
                int index = space.LastIndexOf('.');
                libName = space.Substring(index + 1);
                return space.Substring(0, index);
            }
            else
            {
                libName = t.Namespace == null ? space : space.Substring(t.Namespace.Length + 1);
                return t.Namespace;
            }
        }
    }

    static string GetGenericNameSpace(Type t, out string libName)
    {
        Type[] gArgs = t.GetGenericArguments();
        string typeName = t.FullName;
        int count = gArgs.Length;
        int pos = typeName.IndexOf("[");
        typeName = typeName.Substring(0, pos);

        string str = null;
        string name = null;
        int offset = 0;
        pos = typeName.IndexOf("+");

        while (pos > 0)
        {
            str = typeName.Substring(0, pos);
            typeName = typeName.Substring(pos + 1);
            pos = str.IndexOf('`');

            if (pos > 0)
            {
                count = (int)(str[pos + 1] - '0');
                str = str.Substring(0, pos);
                str += "<" + string.Join(",", LuaMisc.GetGenericName(gArgs, offset, count)) + ">";
                offset += count;
            }

            name = CombineTypeStr(name, str);
            pos = typeName.IndexOf("+");
        }

        string space = name;
        str = typeName;

        if (offset < gArgs.Length)
        {
            pos = str.IndexOf('`');
            count = (int)(str[pos + 1] - '0');
            str = str.Substring(0, pos);
            str += "<" + string.Join(",", LuaMisc.GetGenericName(gArgs, offset, count)) + ">";
        }

        libName = str;

        if (string.IsNullOrEmpty(space))
        {
            space = t.Namespace;

            if (space != null)
            {
                libName = str.Substring(space.Length + 1);
            }
        }

        return space;
    }
}
#endif
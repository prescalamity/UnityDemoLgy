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
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.IO;
using System.Diagnostics;

using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using System.Threading;

[InitializeOnLoad]
public static class ToLuaMenu
{
#if DEV_BRANCH
#else
    //不需要导出或者无法导出的类型
    public static List<Type> dropType = new List<Type>
    {
        typeof(ValueType),                                  //不需要
        typeof(Motion),                                     //很多平台只是空类
        typeof(UnityEngine.YieldInstruction),               //无需导出的类      
        typeof(UnityEngine.WaitForEndOfFrame),              //内部支持
        typeof(UnityEngine.WaitForFixedUpdate),
        typeof(UnityEngine.WaitForSeconds),        
        typeof(UnityEngine.Mathf),                          //lua层支持        
        typeof(Plane),                                      
        typeof(LayerMask),                                  
        typeof(Vector3),
        typeof(Vector4),
        typeof(Vector2),
        typeof(Quaternion),
        typeof(Ray),
        typeof(Bounds),
        typeof(Color),                                    
        typeof(Touch),
        typeof(RaycastHit),                                 
        typeof(TouchPhase),     
        typeof(LuaInterface.LuaOutMetatable),               //手写支持
        typeof(LuaInterface.NullObject),     
        typeof(LuaInterface.LuaOutMetatable),    
        typeof(System.Array),                        
        typeof(System.Reflection.MemberInfo),    
        typeof(LuaInterface.LuaFunction),
        typeof(LuaInterface.LuaTable),
        typeof(LuaInterface.LuaThread),
        typeof(LuaInterface.LuaByteBuffer),                 //只是类型标识符
        typeof(DelegateFactory),                            //无需导出，导出类支持lua函数转换为委托。如UIEventListener.OnClick(luafunc)
    };

    //可以导出的内部支持类型
    public static List<Type> baseType = new List<Type>
    {
        typeof(System.Object),
        typeof(System.Delegate),
        typeof(System.String),
        typeof(System.Enum),
        typeof(System.Type),
        typeof(System.Collections.IEnumerator),
        typeof(UnityEngine.Object),
        typeof(LuaInterface.EventObject),
    };

    private static bool beAutoGen = false;
    private static bool beCheck = true;        
    static List<BindType> allTypes = new List<BindType>();

    static ToLuaMenu()
    {
        //string dir = CustomSettings.saveDir;
        //string[] files = Directory.GetFiles(dir, "*.cs", SearchOption.TopDirectoryOnly);

        //if (files.Length < 3 && beCheck)
        //{
        //    if (EditorUtility.DisplayDialog("自动生成", "点击确定自动生成常用类型注册文件， 也可通过菜单逐步完成此功能", "确定", "取消"))
        //    {
        //        beAutoGen = true;
        //        GenLuaDelegates();
        //        AssetDatabase.Refresh();
        //        GenerateClassWraps();
        //        GenLuaBinder();
        //        beAutoGen = false;                
        //    }

        //    beCheck = false;
        //}
    }

    static string RemoveNameSpace(string name, string space)
    {
        if (space != null)
        {
            name = name.Remove(0, space.Length + 1);
        }

        return name;
    }

    public class BindType
    {
        public string name;                 //类名称
        public Type type;
        public bool IsStatic;        
        public string wrapName = "";        //产生的wrap文件名字
        public string libName = "";         //注册到lua的名字
        public Type baseType = null;
        public string nameSpace = null;     //注册到lua的table层级

        public BindType(Type t)
        {
            type = t;                        
            nameSpace = ToLuaExport.GetNameSpace(t, out libName);
            name = ToLuaExport.CombineTypeStr(nameSpace, libName);            
            libName = ToLuaExport.ConvertToLibSign(libName);

            if (name == "object")
            {
                wrapName = "System_Object";
                name = "System.Object";
            }
            else if (name == "string")
            {
                wrapName = "System_String";
                name = "System.String";
            }
            else
            {
                wrapName = name.Replace('.', '_');
                wrapName = ToLuaExport.ConvertToLibSign(wrapName);
            }

            if (t.BaseType != null && t.BaseType != typeof(ValueType))
            {                
                baseType = t.BaseType;
            }
            
            int index = CustomSettings.staticClassTypes.IndexOf(t);

            if (index >= 0 || (t.GetConstructor(Type.EmptyTypes) == null && t.IsAbstract && t.IsSealed))
            {                         
                IsStatic = true;
                baseType = baseType == typeof(object) ?  null : baseType;
            }
        }

        public BindType SetBaseType(Type t)
        {
            baseType = t;
            return this;
        }

        public BindType SetWrapName(string str)
        {
            wrapName = str;
            return this;
        }

        public BindType SetLibName(string str)
        {
            libName = str;
            return this;
        }

        public BindType SetNameSpace(string space)
        {
            nameSpace = space;            
            return this;
        }
    }

    static bool CheckToLua(MemberInfo m)
    {
        object[] attributes = m.GetCustomAttributes(true);

        foreach (Attribute attr in attributes)
        {
            DoNotToLua tmp = attr as DoNotToLua;
            if (tmp != null)
                return true;
        }
        return false;
    }

    static BindType[] GenBindTypes(BindType[] list, bool beDropBaseType = true)
    {                
        allTypes = new List<BindType>(list);

        for (int i = 0; i < list.LongLength; i++)
        { 
            Type[] info = list[i].type.GetNestedTypes();
            for (int j = 0; j < info.Length; ++j)
            {
                if (!info[j].BaseType.Name.Equals("Enum") && !info[j].BaseType.Name.Equals("Object"))
                    continue;
                if (CheckToLua(info[j])) continue;
                BindType bt = new BindType(info[j]);
                if( allTypes.Contains(bt) ) continue;
                allTypes.Add(bt);
            }
        }

        for (int i = 0; i < list.Length; i++)
        {            
            if (dropType.IndexOf(list[i].type) >= 0)
            {
                Debug.LogWarning(list[i].type.FullName + " in dropType table, not need to export");
                allTypes.Remove(list[i]);
                continue;
            }
            else if (beDropBaseType && baseType.IndexOf(list[i].type) >= 0)
            {
                Debug.LogWarning(list[i].type.FullName + " is Base Type, not need to export");
                allTypes.Remove(list[i]);
                continue;
            }
            else if (list[i].type.IsEnum) 
            {
                continue;
            }

            Type t = list[i].baseType;

            while (t != null)
            {
                if (t.IsInterface)
                {
                    Debugger.LogWarning("{0} has a base type {1} is Interface", list[i].name, t.FullName);
                    list[i].baseType = t.BaseType;       
                }
                else if (dropType.IndexOf(t) >= 0)
                {
                    Debugger.LogWarning("{0} has a base type {1} is a drop type", list[i].name, t.FullName);
                    list[i].baseType = t.BaseType;                    
                }
                else if (!beDropBaseType || baseType.IndexOf(t) < 0)
                {
                    int index = allTypes.FindIndex((bt) => { return bt.type == t; });

                    if (index < 0)
                    {
                        if (!t.IsAbstract)
                        {
                            Debugger.LogWarning("not defined bindtype for {0}, autogen it, child class is {1}", t.FullName, list[i].name);
                            BindType bt = new BindType(t);
                            allTypes.Add(bt);
                        }
                        else
                        {
                            Debugger.LogWarning("not defined bindtype for {0}, it is abstract class, jump it, child class is {1}", t.FullName, list[i].name);
                            list[i].baseType = t.BaseType;
                        }
                    }                  
                }

                t = t.BaseType;
            }
        }

        return allTypes.ToArray();
    }

    [MenuItem("CustomEditor/Lua/Generate Lua Wraps", false, 1)]
    public static void GenerateClassWraps()
    {
        Debug.Log("Begin Gen Lua Wrap Files");
        if (!beAutoGen && EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译在执行此功能", "确定");
            return;
        }

        if (!File.Exists(CustomSettings.saveDir))
        {
            Directory.CreateDirectory(CustomSettings.saveDir);
        }

        allTypes.Clear();
        BindType[] list = GenBindTypes(CustomSettings.customTypeList);

        float count = 0f;
        float totalCnt = list.Length;
        for (int i = 0; i < list.Length; i++)
        {
            ++count;
            EditorUtility.DisplayProgressBar("Gen Lua Wrap Files...", "", count / totalCnt);
            if (CustomSettings.notReGenerateList.Contains(list[i].type))
                continue;
            ToLuaExport.Clear();
            ToLuaExport.className = list[i].name;
            ToLuaExport.type = list[i].type;
            ToLuaExport.isStaticClass = list[i].IsStatic;            
            ToLuaExport.baseType = list[i].baseType;
            ToLuaExport.wrapClassName = list[i].wrapName;
            ToLuaExport.libClassName = list[i].libName;
            ToLuaExport.Generate(CustomSettings.saveDir);
        }
        EditorUtility.ClearProgressBar();

        EditorApplication.isPlaying = false;
        Debug.Log("Generate lua binding files over");
        allTypes.Clear();
        AssetDatabase.Refresh();
        GenLuaBinder();
        //File.WriteAllText(CustomSettings.mLuaPath + "common/ClassType.lua", ToLuaExport.WrapTypeAll.ToString() + "\nTypeEnum = {\n" + ToLuaExport.TWrapTypeAll.ToString() + "}\n");
        Debug.Log("End Gen Lua Wrap Files");
    }

    static HashSet<Type> GetCustomTypeDelegates()
    {
        BindType[] list = CustomSettings.customTypeList;
        HashSet<Type> set = new HashSet<Type>();
        BindingFlags binding = BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.Instance;

        for (int i = 0; i < list.Length; i++)
        {
            Type type = list[i].type;
            FieldInfo[] fields = type.GetFields(BindingFlags.GetField | BindingFlags.SetField | binding);
            PropertyInfo[] props = type.GetProperties(BindingFlags.GetProperty | BindingFlags.SetProperty | binding);
            MethodInfo[] methods = null;

            if (type.IsInterface)
            {
                methods = type.GetMethods();
            }
            else
            {
                methods = type.GetMethods(BindingFlags.Instance | binding);
            }

            for (int j = 0; j < fields.Length; j++)
            {
                Type t = fields[j].FieldType;

                if (typeof(System.Delegate).IsAssignableFrom(t))
                {
                    set.Add(t);
                }
            }

            for (int j = 0; j < props.Length; j++)
            {
                Type t = props[j].PropertyType;

                if (typeof(System.Delegate).IsAssignableFrom(t))
                {
                    set.Add(t);
                }
            }

            for (int j = 0; j < methods.Length; j++)
            {
                MethodInfo m = methods[j];

                if (m.IsGenericMethod)
                {
                    continue;
                }

                ParameterInfo[] pifs = m.GetParameters();

                for (int k = 0; k < pifs.Length; k++)
                {
                    Type t = pifs[k].ParameterType;

                    if (typeof(System.MulticastDelegate).IsAssignableFrom(t))
                    {
                        set.Add(t);
                    }
                }
            }

        }

        return set;
    }

    //[MenuItem("GameEditor/Lua/Gen Lua Delegates", false, 2)]
    static void GenLuaDelegates()
    {
        if (!beAutoGen && EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译在执行此功能", "确定");
            return;
        }

        ToLuaExport.Clear();
        List<DelegateType> list = new List<DelegateType>();
        list.AddRange(CustomSettings.customDelegateList);
        HashSet<Type> set = GetCustomTypeDelegates();        

        foreach (Type t in set)
        {
            if (null == list.Find((p) => { return p.type == t; }))
            {
                list.Add(new DelegateType(t));
            }
        }

        ToLuaExport.GenDelegates(list.ToArray());
        set.Clear();
        ToLuaExport.Clear();
        AssetDatabase.Refresh();
        Debug.Log("Create lua delegate over");
    }    

    static ToLuaTree<string> InitTree()
    {                        
        ToLuaTree<string> tree = new ToLuaTree<string>();
        ToLuaNode<string> root = tree.GetRoot();        
        BindType[] list = GenBindTypes(CustomSettings.customTypeList);

        for (int i = 0; i < list.Length; i++)
        {
            string space = list[i].nameSpace;
            AddSpaceNameToTree(tree, root, space);
        }

        DelegateType[] dts = CustomSettings.customDelegateList;        

        for (int i = 0; i < dts.Length; i++)
        {            
            string space = dts[i].type.Namespace;                        
            AddSpaceNameToTree(tree, root, space);            
        }

        return tree;
    }

    static void AddSpaceNameToTree(ToLuaTree<string> tree, ToLuaNode<string> root, string space)
    {
        if (space == null || space == string.Empty)
        {
            return;
        }

        string[] ns = space.Split(new char[] { '.' });
        ToLuaNode<string> parent = root;

        for (int j = 0; j < ns.Length; j++)
        {
            //pos变量
            ToLuaNode<string> node = tree.Find((_t) => { return _t == ns[j]; }, j);

            if (node == null)
            {
                node = new ToLuaNode<string>();
                node.value = ns[j];
                parent.childs.Add(node);
                node.parent = parent;
                //加入pos跟root里的pos比较，只有位置相同才是统一命名空间节点
                node.pos = j;
                parent = node;
            }
            else
            {
                parent = node;
            }
        }
    }

    static string GetSpaceNameFromTree(ToLuaNode<string> node)
    {
        string name = node.value;

        while (node.parent != null && node.parent.value != null)
        {
            node = node.parent;
            name = node.value + "." + name;
        }

        return name;
    }

    static string RemoveTemplateSign(string str)
    {
        str = str.Replace('<', '_');

        int index = str.IndexOf('>');

        while (index > 0)
        {
            str = str.Remove(index, 1);
            index = str.IndexOf('>');
        }

        return str;
    }
     
    //[MenuItem("GameEditor/Lua/Gen LuaBinder File", false, 4)]
    static void GenLuaBinder()
    {
        //if (!beAutoGen && EditorApplication.isCompiling)
        //{
        //    EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译在执行此功能", "确定");
        //    return;
        //}

        allTypes.Clear();
        ToLuaTree<string> tree = InitTree();        
        StringBuilder sb = new StringBuilder();
        //List<DelegateType> dtList = new List<DelegateType>();

        List<DelegateType> list = new List<DelegateType>();
        list.AddRange(CustomSettings.customDelegateList);
        HashSet<Type> set = GetCustomTypeDelegates();

        List<BindType> backupList = new List<BindType>();
        backupList.AddRange(allTypes);

        foreach (Type t in set)
        {
            if (null == list.Find((p) => { return p.type == t; }))
            {
                list.Add(new DelegateType(t));
            }
        }

        sb.AppendLine("//this source code was auto-generated by tolua#, do not modify it");
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using UnityEngine;");
        sb.AppendLine("using LuaInterface;");
        sb.AppendLine();

        sb.AppendLine("public static class LuaBinder");
        sb.AppendLine("{");
        sb.AppendLine("");

        List<string> bList = new List<string>();

        sb.AppendLine("\tpublic static void Bind(LuaState L)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tvar time = Time.realtimeSinceStartup;");
        sb.AppendLine("\t\tL.BeginModule(null);");
        //sb.AppendLine("\t\tfloat t = Time.realtimeSinceStartup;");
        //sb.AppendLine("\t\tL.BeginModule(null);");
        
        //sb.AppendFormat("\t\tProtocalWrap.Register(L);\r\n");
    
        for (int i = 0; i < allTypes.Count; i++)
        {
            Type dt = CustomSettings.dynamicList.Find((p) => { return allTypes[i].type == p; });

            if (dt == null && allTypes[i].nameSpace == null)
            {
                if (allTypes[i].type.BaseType != null && allTypes[i].type.BaseType.Name.Equals("Enum"))
                {
                    allTypes.RemoveAt(i--);
                    continue;
                }
                //string str = "\t\t" + allTypes[i].wrapName + "Wrap.Register(L);\r\n";
                if (bList.Contains(allTypes[i].wrapName))
                {
                    allTypes.RemoveAt(i--);
                    continue;
                }
                bList.Add(allTypes[i].wrapName);
                sb.AppendLine("\t\t" + allTypes[i].wrapName + "Wrap.Register(L);");
                allTypes.RemoveAt(i--);                
            }
        }
        string lastKey = "";
        Action<ToLuaNode<string>> begin = (node) =>
        {
            if (node.value == null)
            {
                return;
            }

            //sb.AppendFormat("\t\tL.BeginModule(\"{0}\");\r\n", node.value);
            string space = GetSpaceNameFromTree(node);

            for (int i =0; i < allTypes.Count; i++)
            {
                Type dt = CustomSettings.dynamicList.Find((p) => { return allTypes[i].type == p; });

                if (dt == null && allTypes[i].nameSpace == space)
                {
                    if (allTypes[i].type.BaseType != null && allTypes[i].type.BaseType.Name.Equals("Enum"))
                    {
                        allTypes.RemoveAt(i--);
                        continue;
                    }
                    //string str = "\t\t" + allTypes[i].wrapName + "Wrap.Register(L);\r\n";
                    if (bList.Contains(allTypes[i].wrapName))
                    {
                        allTypes.RemoveAt(i--);
                        continue;
                    }
                    bList.Add(allTypes[i].wrapName);
                    if (lastKey != node.value)
                    {
                        if (lastKey != "")
                        {
                            sb.AppendLine("\t\tL.EndModule();");
                        }
                        sb.AppendLine("\t\tL.BeginModule(\"" + node.value + "\");");
                        lastKey = node.value;
                    }
                    sb.AppendLine("\t\t" + allTypes[i].wrapName + "Wrap.Register(L);");
                    allTypes.RemoveAt(i--);
                }
            }

            string funcName = null;

            //for (int i = 0; i < list.Count; i++)
            //{
            //    DelegateType dt = list[i];
            //    Type type = dt.type;
            //    string typeSpace = ToLuaExport.GetNameSpace(type, out funcName);

            //    if (typeSpace == space)
            //    {                    
            //        funcName = ToLuaExport.ConvertToLibSign(funcName);
            //        string abr = dt.abr;
            //        abr = abr == null ? funcName : abr;
            //        sb.AppendFormat("\t\tL.RegFunction(\"{0}\", {1});\r\n", abr, dt.name);
            //        dtList.Add(dt);
            //    }
            //}
        };

        Action<ToLuaNode<string>> end = (node) =>
        {
            if (node.value != null)
            {
                //sb.AppendLine("\t\tL.EndModule();");
            }
        };

        tree.DepthFirstTraversal(begin, end, tree.GetRoot());
        if (lastKey != "")
        {
            sb.AppendLine("\t\tL.EndModule();");
        }
        sb.AppendLine("\t\tL.EndModule();");
        //sb.AppendLine("\t\tL.EndModule();"); 

        if (CustomSettings.dynamicList.Count > 0)
        {
            sb.AppendLine("\t\tL.BeginPreLoad();");            

            for (int i = 0; i < CustomSettings.dynamicList.Count; i++)
            {
                Type t1 = CustomSettings.dynamicList[i];
                BindType bt = backupList.Find((p) => { return p.type == t1; });
                sb.AppendFormat("\t\tL.AddPreLoad(\"{0}\", LuaOpen_{1}, typeof({0}));\r\n", bt.name, bt.wrapName);
            }

            sb.AppendLine("\t\tL.EndPreLoad();");
        }
        sb.AppendLine("\t\tDLog.Log(\"注册LUA耗时：\" + (Time.realtimeSinceStartup - time));");

        //sb.AppendLine("\t\tDebugger.Log(\"Register lua type cost time: {0}\", Time.realtimeSinceStartup - t);");
        sb.AppendLine("\t}");

        //for (int i = 0; i < dtList.Count; i++)
        //{
        //    ToLuaExport.GenEventFunction(dtList[i].type, sb);
        //}

        if (CustomSettings.dynamicList.Count > 0)
        {
            
            for (int i = 0; i < CustomSettings.dynamicList.Count; i++)
            {
                Type t = CustomSettings.dynamicList[i];
                BindType bt = backupList.Find((p) => { return p.type == t; });
                GenPreLoadFunction(bt, sb);
            }            
        }

        sb.AppendLine("");
        sb.AppendLine("}");
        allTypes.Clear();
        string file = Application.dataPath + "/Scripts/lua_wrap_gen/base/LuaBinder.cs";

        using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
        {
            textWriter.Write(sb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }

        AssetDatabase.Refresh();
        Debugger.Log("Generate LuaBinder over !");
    }

    static void GenPreLoadFunction(BindType bt, StringBuilder sb)
    {
        string funcName = "LuaOpen_" + bt.wrapName;

        sb.AppendLine("\r\n\t[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]");
        sb.AppendFormat("\tstatic int {0}(IntPtr L)\r\n", funcName);
        sb.AppendLine("\t{");
        sb.AppendLine("\t\ttry");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\tint top = LuaDLL.lua_gettop(L);");
        sb.AppendLine("\t\t\tLuaState state = LuaState.Get(L);");
        sb.AppendFormat("\t\t\tint preTop = state.BeginPreModule(\"{0}\");\r\n", bt.nameSpace);
        sb.AppendFormat("\t\t\t{0}Wrap.Register(state);\r\n", bt.wrapName);
        sb.AppendLine("\t\t\tstate.EndPreModule(preTop);");
        sb.AppendLine("\t\t\tLuaDLL.lua_settop(L, top);");
        sb.AppendLine("\t\t\treturn 0;");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t\tcatch(Exception e)");
        sb.AppendLine("\t\t{");
        sb.AppendLine("\t\t\treturn LuaDLL.toluaL_exception(L, e);");
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t}");
    }

    static string GetOS()
    {
#if UNITY_STANDALONE
        return "Win";
#elif UNITY_ANDROID
        return "Android";
#elif UNITY_IOS
        return "iOS";
#else
        return "";
#endif
    }

    static void CreateStreamDir(string dir)
    {
        dir = Application.streamingAssetsPath + "/" + dir;

        if (!File.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void BuildLuaBundle(string dir)
    {
        BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DeterministicAssetBundle;

        string[] files = Directory.GetFiles("Assets/" +  "/Lua/" + dir, "*.lua.bytes");
        List<Object> list = new List<Object>();
        string bundleName = dir == null ? "Lua.unity3d" : "Lua_" + dir + ".unity3d";

        for (int i = 0; i < files.Length; i++)
        {
            Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
            list.Add(obj);
        }

        if (files.Length > 0)
        {            
            string output = string.Format("{0}/{1}/" + bundleName, Application.streamingAssetsPath, GetOS());
            File.Delete(output);
            BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
            string output1 = string.Format("{0}/{1}/" + bundleName, Application.persistentDataPath, GetOS());
            File.Copy(output, output1, true);
            AssetDatabase.Refresh();
        }
    }

    static void CopyLuaFiles()
    {
        string sourceDir = Application.streamingAssetsPath + "/Lua";
        string destDir = Application.streamingAssetsPath + "/" + GetOS() + "/Lua";
        string[] files = Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories);
        
        for (int i = 0; i < files.Length; i++)
        {
            string str = files[i].Remove(0, sourceDir.Length);
            string dest = destDir + str;
            string dir = Path.GetDirectoryName(dest);
            Directory.CreateDirectory(dir);
            File.Copy(files[i], dest, true);            
        }

        Directory.Delete(sourceDir, true);
    }

    static void ClearAllLuaFiles()
    {
        string osPath = Application.streamingAssetsPath + "/" + GetOS();

        if (Directory.Exists(osPath))
        {
            string[] files = Directory.GetFiles(osPath, "Lua*.unity3d");

            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }

        string path = osPath + "/Lua";

        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }

        path = Application.dataPath + "/Resources/Lua";

        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }

        path = Application.persistentDataPath + "/" + GetOS() + "/Lua";

        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
    }

    //[MenuItem("GameEditor/Lua/Gen LuaWrap + Binder", false, 4)]
    static void GenLuaWrapBinder()
    {
        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译在执行此功能", "确定");
            return;
        }

        beAutoGen = true;        
        AssetDatabase.Refresh();
        GenerateClassWraps();
        GenLuaBinder();
        beAutoGen = false;   
    }

    //[MenuItem("GameEditor/Lua/Generate All", false, 5)]
    static void GenLuaAll()
    {
        if (EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译在执行此功能", "确定");
            return;
        }

        beAutoGen = true;
        GenLuaDelegates();
        AssetDatabase.Refresh();
        GenerateClassWraps();
        GenLuaBinder();
        beAutoGen = false;
    }

    static void ClearFiles(string path)
    {
        string[] names = Directory.GetFiles(path);
        foreach (var filename in names)
        {
            File.Delete(filename); //删除缓存
        }
    }


    [MenuItem("CustomEditor/Lua/Clear LuaW raps", false, 6)]
    static void ClearLuaWraps()
    {
        Debug.Log("Begin Clear wrap files");    
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using LuaInterface;");
        sb.AppendLine();
        sb.AppendLine("public static class LuaBinder");
        sb.AppendLine("{");
        sb.AppendLine("\tpublic static List<string> wrapList = new List<string>();");
        sb.AppendLine("\tpublic static bool register_over = false;\n");
        sb.AppendLine("\tpublic static void Bind(LuaState L, string type = null)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t}");

        sb.AppendLine("\tpublic static void  RegisterAll()");
        sb.AppendLine("\t{");
        sb.AppendLine("\t}");
        sb.AppendLine("\tpublic static void FrameRegister()");
        sb.AppendLine("\t{");
        sb.AppendLine("\t}");

        sb.AppendLine("\tpublic static void BindFirst(LuaState L)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t}");

        sb.AppendLine("}");

        string file = Application.dataPath + "/Scripts/lua_wrap_gen/base/LuaBinder.cs";

        using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
        {
            textWriter.Write(sb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }
        //if (ULuaConfig.AutoWrapMode)
        //{
        //    if (!string.IsNullOrEmpty(mLuaPath))
        //    {
        //        string wrapfile = mLuaPath + "common/ulualib/Wrap.lua";
        //        File.WriteAllText(wrapfile, string.Empty);
        //    }
        //    else
        //    {
        //        Debugger.logError("  Lua path is not existed! pls check ");
        //    }
        //}
        ClearFiles(Application.dataPath + "/Scripts/lua_wrap_gen");

        if(Directory.Exists(Application.dataPath + "/Scripts/lua_wrap_gen/UnityEngine_wrap"))
            ClearFiles(Application.dataPath + "/Scripts/lua_wrap_gen/UnityEngine_wrap");

        System.Diagnostics.Process proc = System.Diagnostics.Process.Start(Application.dataPath + "/Editor/ClearWrap.bat");

        proc.WaitForExit();

        AssetDatabase.Refresh();
        Debug.Log("End Clear wrap files");
    }


    //[MenuItem("GameEditor/Lua/Copy Lua  files to Resources", false, 51)]
    public static void CopyLuaFilesToRes()
    {
        ClearAllLuaFiles();
        string destDir = Application.dataPath + "/Resources" + "/Lua";
        CopyLuaBytesFiles(CustomSettings.luaDir, destDir);
        CopyLuaBytesFiles(CustomSettings.toluaLuaDir, destDir);
        AssetDatabase.Refresh();
        Debug.Log("Copy lua files over");
    }

    //[MenuItem("GameEditor/Lua/Copy Lua  files to Persistent", false, 52)]
    public static void CopyLuaFilesToPersistent()
    {
        ClearAllLuaFiles();
        string destDir = Application.persistentDataPath + "/" + GetOS() + "/Lua";
        CopyLuaBytesFiles(CustomSettings.luaDir, destDir, false);
        CopyLuaBytesFiles(CustomSettings.toluaLuaDir, destDir, false);
        AssetDatabase.Refresh();
        Debug.Log("Copy lua files over");
    }


    //[MenuItem("GameEditor/Lua/Build bundle files not jit", false, 53)]
    public static void BuildNotJitBundles()
    {
        ClearAllLuaFiles();
        CreateStreamDir(GetOS());
        CreateStreamDir("Lua/");
        string dir = Application.persistentDataPath + "/" + GetOS();

        if (!File.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string streamDir = Application.streamingAssetsPath + "/Lua";
        CopyLuaBytesFiles(CustomSettings.luaDir, streamDir);
        CopyLuaBytesFiles(Application.dataPath + "/ToLua/Lua", streamDir);

        AssetDatabase.Refresh();
        string[] dirs = Directory.GetDirectories(streamDir);

        for (int i = 0; i < dirs.Length; i++)
        {
            string str = dirs[i].Remove(0, streamDir.Length + 1);
            BuildLuaBundle(str);
        }

        BuildLuaBundle(null);
        Directory.Delete(streamDir, true);
        AssetDatabase.Refresh();
    }

    //[MenuItem("GameEditor/Lua/Build Lua files  (PC运行)", false, 54)]
    public static void BuildLua()
    {
        ClearAllLuaFiles();
        CreateStreamDir(GetOS());
        CreateStreamDir("Lua/Out/");

        Process proc = Process.Start(Application.dataPath + "/ToLua/Lua/Build.bat");
        proc.WaitForExit();
        UnityEngine.Debug.Log("build tolua fils over");

        if (File.Exists(CustomSettings.luaDir + "/Build.bat"))
        {
            proc = Process.Start(CustomSettings.luaDir + "/Build.bat");
            UnityEngine.Debug.Log("build lua files over");
            proc.WaitForExit();
        }

        CreateStreamDir(GetOS() + "/Lua");
        CopyLuaFiles();
        AssetDatabase.Refresh();
    }

    //[MenuItem("GameEditor/Lua/Build Luajit bundle files   (PC运行)", false, 55)]
    public static void BuildLuaBundles()
    {
        ClearAllLuaFiles();
        CreateStreamDir(GetOS());
        CreateStreamDir("Lua/Out/");
        string dir = Application.persistentDataPath + "/" + GetOS();

        if (!File.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        Process proc = Process.Start(Application.dataPath + "/ToLua/Lua/Build.bat");
        proc.WaitForExit();
        UnityEngine.Debug.Log("build tolua fils over");

        if (File.Exists(CustomSettings.luaDir + "/Build.bat"))
        {
            proc = Process.Start(CustomSettings.luaDir + "/Build.bat");
            UnityEngine.Debug.Log("build lua files over");
            proc.WaitForExit();
        }

        AssetDatabase.Refresh();
        string sourceDir = Application.streamingAssetsPath + "/Lua";
        string[] dirs = Directory.GetDirectories(sourceDir);

        for (int i = 0; i < dirs.Length; i++)
        {
            string str = dirs[i].Remove(0, sourceDir.Length + 1);
            BuildLuaBundle(str);
        }

        BuildLuaBundle(null);
        Directory.Delete(sourceDir, true);
        AssetDatabase.Refresh();
    }

    //[MenuItem("GameEditor/Lua/Clear all Lua files", false, 55)]
    public static void ClearLuaFiles()
    {
        ClearAllLuaFiles();
    }


    static void CopyLuaBytesFiles(string sourceDir, string destDir, bool appendext = true)
    {
        if (!Directory.Exists(sourceDir))
        {
            return;
        }

        string[] files = Directory.GetFiles(sourceDir, "*.lua", SearchOption.AllDirectories);
        int len = sourceDir.Length;

        if (sourceDir[len - 1] == '/' || sourceDir[len - 1] == '\\')
        {
            --len;
        }        

        for (int i = 0; i < files.Length; i++)
        {            
            string str = files[i].Remove(0, len);
            string dest = destDir + str;
            if (appendext) dest += ".bytes";
            string dir = Path.GetDirectoryName(dest);
            Directory.CreateDirectory(dir);
            File.Copy(files[i], dest, true);
        }        
    }


    //[MenuItem("GameEditor/Lua/Gen BaseType Wrap", false, 101)]
    static void GenBaseTypeLuaWrap()
    {
        if (!beAutoGen && EditorApplication.isCompiling)
        {
            EditorUtility.DisplayDialog("警告", "请等待编辑器完成编译在执行此功能", "确定");
            return;
        }

        string dir = CustomSettings.toluaBaseType;

        if (!File.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        allTypes.Clear();
        List<BindType> btList = new List<BindType>();
        
        for (int i = 0; i < baseType.Count; i++)
        {
            btList.Add(new BindType(baseType[i]));
        }

        GenBindTypes(btList.ToArray(), false);
        BindType[] list = allTypes.ToArray();

        for (int i = 0; i < list.Length; i++)
        {
            ToLuaExport.Clear();
            ToLuaExport.className = list[i].name;
            ToLuaExport.type = list[i].type;
            ToLuaExport.isStaticClass = list[i].IsStatic;
            ToLuaExport.baseType = list[i].baseType;
            ToLuaExport.wrapClassName = list[i].wrapName;
            ToLuaExport.libClassName = list[i].libName;
            ToLuaExport.Generate(dir);
        }
        
        Debug.Log("Generate base type files over");
        allTypes.Clear();
        AssetDatabase.Refresh();
    }

    static void CreateDefaultWrapFile(string path, string name)
    {
        StringBuilder sb = new StringBuilder();
        path = path + name + ".cs";
        sb.AppendLine("using System;");
        sb.AppendLine("using LuaInterface;");
        sb.AppendLine();
        sb.AppendLine("public static class " + name);
        sb.AppendLine("{");
        sb.AppendLine("\tpublic static void Register(LuaState L)");
        sb.AppendLine("\t{");        
        sb.AppendLine("\t\tthrow new LuaException(\"Please click menu Lua/Gen BaseType Wrap first!\");");
        sb.AppendLine("\t}");
        sb.AppendLine("}");

        using (StreamWriter textWriter = new StreamWriter(path, false, Encoding.UTF8))
        {
            textWriter.Write(sb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }
    }
    
    //[MenuItem("GameEditor/Lua/Clear BaseType Wrap", false, 102)]
    static void ClearBaseTypeLuaWrap()
    {
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "System_ObjectWrap");
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "System_DelegateWrap");
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "System_StringWrap");
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "System_EnumWrap");
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "System_TypeWrap");
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "System_Collections_IEnumeratorWrap");
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "UnityEngine_ObjectWrap");
        CreateDefaultWrapFile(CustomSettings.toluaBaseType, "LuaInterface_EventObjectWrap");

        Debug.Log("Clear base type wrap files over");
        AssetDatabase.Refresh();
    }
#endif
}

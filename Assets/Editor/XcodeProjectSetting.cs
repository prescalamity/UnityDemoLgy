#if UNITY_IOS

using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;
//using Strings;

class XClass
{
    private string filePath;

    public XClass(string fPath)
    {
        filePath = fPath;
        if (!File.Exists(filePath))
        {
            Debug.LogError(filePath + "路径下文件不存在");
        }
    }

    public void WriteBelow(string below, string text)
    {
        StreamReader streamReader = new StreamReader(filePath);
        string text_all = streamReader.ReadToEnd();
        streamReader.Close();

        int beginIndex = text_all.IndexOf(below);
        if (beginIndex == -1)
        {
            Debug.LogError(filePath + "中没有找到标志" + below);
            return;
        }

        int endIndex = text_all.LastIndexOf("\n", beginIndex + below.Length);

        text_all = text_all.Substring(0, endIndex) + "\n" + text + "\n" + text_all.Substring(endIndex);

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(text_all);
        streamWriter.Close();
    }

    public void Replace(string below, string newText)
    {
        StreamReader streamReader = new StreamReader(filePath);
        string text_all = streamReader.ReadToEnd();
        streamReader.Close();

        int beginIndex = text_all.IndexOf(below);
        if (beginIndex == -1)
        {
            Debug.LogError(filePath + "中没有找到标志" + below);
            return;
        }

        text_all = text_all.Replace(below, newText);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(text_all);
        streamWriter.Close();
    }

    public void ReplaceALL(string srcPath)
    {
        StreamReader srcStreamReader = new StreamReader(srcPath);
        string srcText = srcStreamReader.ReadToEnd();
        srcStreamReader.Close();

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(srcText);
        streamWriter.Close();
    }

    public string FindLineStringContain(string pattern)
    {
        try
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Contains(pattern))
                    {
                        return line;
                    }
                }
            }
        }
        catch(System.Exception e)
        {

            Debug.LogError("无法打开文件：" + filePath);
        }
        return null;
    }
}

public class XcodeProjectSetting
{
    static Dictionary<string, string> buildSettings = new Dictionary<string, string>
    {
        //{ "GCC_ENABLE_CPP_EXCEPTIONS", "YES" },
        //{ "GCC_ENABLE_CPP_RTTI", "YES" },
        //{ "GCC_ENABLE_OBJC_EXCEPTIONS", "YES" },
        { "ENABLE_BITCODE", "NO" },
        //{ "CLANG_ENABLE_OBJC_ARC", "NO" },
        //{ "CLANG_CXX_LIBRARY", "libc++" },
        //{ "GCC_SYMBOLS_PRIVATE_EXTERN", "NO"},
        //{ "VALIDATE_WORKSPACE" , "YES" },
    };

    static Dictionary<string, string> addingFileCompileFlag = new Dictionary<string, string>
    {
        //{ "Classes/Unity/DisplayManager.mm", "-fobjc-arc" },
        //{ "Classes/Unity/MetalHelper.mm", "-fobjc-arc" },
    };

    static List<string> headers = new List<string>
    {
        "UnityFramework/UnityFramework.h",
        "Libraries/Plugins/iOS/SDK/PTSdkInterface.h",
        "Libraries/Plugins/iOS/SDK/PTInterfaceManager.h",
        "Classes/PluginBase/AppDelegateListener.h",
        "Classes/PluginBase/LifeCycleListener.h",
        "Classes/PluginBase/RenderPluginDelegate.h",
        "Classes/PluginBase/UnityViewControllerListener.h"
    };

    static List<string> frameworks = new List<string>
    {
        //"Security.framework",
        //"SystemConfiguration.framework",
        //"CFNetwork.framework",
        //"CoreTelephony.framework",
        "AdSupport.framework",
        "AssetsLibrary.framework",
        //"AddressBook.framework",
        //"JavaScriptCore.framework",
        //"Foundation.framework",
        //"Contacts.framework",
        //"CoreLocation.framework",
        //"UserNotifications.framework",
        //"WebKit.framework",
        
        // TRTC
        //"TXLiteAVSDK_TRTC.framework",
        //"Accelerate.framework"
    };

    static List<string> dynamicLibrarys = new List<string>
    {
        //"libsqlite3.tbd",
        "libz.tbd",
        "libc++.tbd",

        // TRTC
        "libresolv.tbd"
    };

    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string pathToBuiltProject)
    {
        if (buildTarget != BuildTarget.iOS)
        {
            return;
        }
        // 设置主工程的相关内容
        string projPath = PBXProject.GetPBXProjectPath(pathToBuiltProject);

        PBXProject pbxProject = new PBXProject();
        pbxProject.ReadFromFile(projPath);
        string mainGuid = pbxProject.GetUnityMainTargetGuid();

        pbxProject.SetBuildProperty(mainGuid, "ENABLE_BITCODE", "NO");
        pbxProject.SetBuildProperty(mainGuid, "HEADER_SEARCH_PATHS", "../");
        pbxProject.AddFrameworkToProject(mainGuid, "UnityFramework.framework", false);
        pbxProject.WriteToFile(projPath);

        // 设置UnityFramework的相关内容
        string targetGuid = pbxProject.GetUnityFrameworkTargetGuid();

        // 设置编译属性（Xcode工程的BuildSettings）
        foreach (KeyValuePair<string, string> kvp in buildSettings)
        {
            pbxProject.SetBuildProperty(targetGuid, kvp.Key, kvp.Value);
        }

        // 添加文件编译参数（Xcode工程中的BuildPhases==>CompileSources）
        foreach (KeyValuePair<string, string> kvp in addingFileCompileFlag)
        {
            string fileGuid = pbxProject.FindFileGuidByProjectPath(kvp.Key);
            List<string> flags = pbxProject.GetCompileFlagsForFile(targetGuid, fileGuid); // fix me
            if (flags == null)
            {
                flags = new List<string>();
            }
            flags.Add(kvp.Value);
            pbxProject.SetCompileFlagsForFile(targetGuid, fileGuid, flags);
        }

        // 添加 头文件
        foreach (string header in headers)
        {
            string fileGuid = pbxProject.FindFileGuidByProjectPath(header);
            if (!string.IsNullOrEmpty(fileGuid))
                pbxProject.AddPublicHeaderToBuild(targetGuid, fileGuid);
        }

        // 添加framework
        foreach (string framework in frameworks)
        {
            pbxProject.AddFrameworkToProject(targetGuid, framework, false);
        }

        // 添加动态库
        foreach (string dylib in dynamicLibrarys)
        {
            string path = "usr/lib/" + dylib;
            string projectPath = "Frameworks/" + dylib;
            string fileGuid = pbxProject.AddFile(path, projectPath, PBXSourceTree.Sdk);
            pbxProject.AddFileToBuild(targetGuid, fileGuid);
        }

        // 添加链接参数（用于保留所有二进制符号供反射调用）
        pbxProject.AddBuildProperty(targetGuid, "OTHER_LDFLAGS_FRAMEWORK", "-ObjC");

        // 应用修改
        pbxProject.WriteToFile(projPath);
        
        //设置多语言
        //NativeLocale.AddLocalizedStringsIOS(pathToBuiltProject, Path.Combine(Application.dataPath, "Editor/gamebuildtool/NativeLocale/iOS")); 

        // 修改一部分源码
        EditCodes(Path.GetFullPath(pathToBuiltProject));

        //***使用'Assets\Plugins\iOS\Info.plist修改build出的xcode工程的'.plist'文件***
        string sourcePlistPath = Application.streamingAssetsPath + "/../Plugins/iOS/Info.plist";
        string targetPlistPath = pathToBuiltProject + "/Info.plist";

        if(!File.Exists(sourcePlistPath) || !File.Exists(targetPlistPath))
        {
            Debug.Log(string.Format("'{0}' or '{1}' is not exists!", sourcePlistPath, targetPlistPath));
            return;
        }
        PlistDocument sourcePlist = new PlistDocument();
        byte[] sourcePlistBytes = File.ReadAllBytes(sourcePlistPath);
        //byte[] sourcePlistBytes1 = new byte[sourcePlistBytes.Length - 3];
        //System.Array.Copy(sourcePlistBytes, 3, sourcePlistBytes1, 0, sourcePlistBytes1.Length); //去掉DOM头
        string sourcePlistString = System.Text.Encoding.UTF8.GetString(sourcePlistBytes);
        Debug.Log(string.Format("'sourcePlistString is '{0}'.", sourcePlistString));
        sourcePlist.ReadFromString(sourcePlistString);
        PlistElementDict sourcePlistDic = sourcePlist.root;

        PlistDocument targetPlist = new PlistDocument();
        byte[] targetPlistBytes = File.ReadAllBytes(targetPlistPath);
        //byte[] targetPlistBytes1 = new byte[targetPlistBytes.Length - 3];
        //System.Array.Copy(targetPlistBytes, 3, targetPlistBytes1, 0, targetPlistBytes1.Length);
        string targetPlistString = System.Text.Encoding.UTF8.GetString(targetPlistBytes);
        Debug.Log(string.Format("'targetPlistString is '{0}'.", targetPlistString));
        targetPlist.ReadFromString(targetPlistString);
        PlistElementDict targetPlistDic = targetPlist.root;

        foreach (string key in sourcePlistDic.values.Keys)
        {
            if(targetPlistDic.values.ContainsKey(key))
            {
                targetPlistDic.values[key] = sourcePlistDic.values[key];
            }
            else
            {
                targetPlistDic.values.Add(key, sourcePlistDic.values[key]);
            }
        }
        File.WriteAllText(targetPlistPath, targetPlist.WriteToString());
        //***end***
    }

    private static void EditCodes(string filePath)
    {
        // main.mm
        XClass Mainmm = new XClass(filePath + "/MainApp/main.mm");
        Mainmm.Replace("#include <UnityFramework/UnityFramework.h>", @"#include ""../UnityFramework/UnityFramework.h""");


        // UnityAppController.mm
        XClass UnityAppController = new XClass(filePath + "/Classes/UnityAppController.mm");

        UnityAppController.WriteBelow("::printf(\"WARNING -> applicationDidReceiveMemoryWarning()\\n\");", "\tUnitySendMessage(\"GameMain\",\"GetMemWarning\",\"\" );");
        UnityAppController.WriteBelow("#include \"PluginBase/AppDelegateListener.h\"", "#include \"Libraries/Plugins/iOS/SDK/PTInterfaceManager.h\"");
        UnityAppController.WriteBelow("UnityInitApplicationNoGraphics(UnityDataBundleDir());", "[[PTInterfaceManager Instance] InitLJBDYHS];");

        // CrashReporter.h
        //if (UnityBuildTool.open_unity_crash_report)
        //{
        //    XClass CrashReporter = new XClass(filePath + "/Classes/CrashReporter.h");
        //    CrashReporter.Replace("#define ENABLE_CUSTOM_CRASH_REPORTER 0", "#define ENABLE_CUSTOM_CRASH_REPORTER 1");
        //}

        // SplashScreen.mm
        // XClass SplashScreen = new XClass(filePath + "/Classes/UI/SplashScreen.mm");
        // SplashScreen.ReplaceALL(Application.dataPath + "/Editor/gamebuildtool/SplashScreen.mm");

        // string UnityVersionMark = "UnityVersion_";
        // string version = SplashScreen.FindLineStringContain(UnityVersionMark);
        // version = version.Trim();
        // if(!string.IsNullOrEmpty(version))
        // {
        //     int versionIdx = version.LastIndexOf(UnityVersionMark);
        //     version = version.Substring(versionIdx + UnityVersionMark.Length);

        //     string unityVersion = Application.unityVersion;

        //     int shortLen = Mathf.Min(version.Length, unityVersion.Length);
        //     shortLen = shortLen < 6 ? shortLen : 6;

        //     if (version.Substring(0, shortLen) != unityVersion.Substring(0, shortLen))
        //         Debug.LogError(string.Format(filePath + " 文件版本标记不匹配,标记版本是：{0}，打包机的Unity版本是：{1}", version, unityVersion));
        // }
        // else
        //     Debug.LogError(filePath + " 文件没有UnityVersion标记, 如果你是从2017.3版本迁移过来的,就需要在此文件中,将标记以注释的形式写成: //UnityVersion_2017.3");

    }
}

#endif

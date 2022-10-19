using System.IO;
using UnityEditor;
using UnityEngine;
public class CreateAssetBundle
{
    [MenuItem("CustomEditor/Build AssetBundles", priority = (int)EditerMenuPriorty.BuildAssetBundles)]//编辑器菜单路径 打包
    static void BulidAllAssetBundle()
    {
        Debug.Log("开始平台资源打包。。。");

        // 打包AB输出路径
        string strABOutPAthDir = Application.streamingAssetsPath + "/../../StreamingAssets/assetbundles";
        // 判断文件夹是否存在，不存在则新建

#if UNITY_ANDROID//安卓端
        strABOutPAthDir = strABOutPAthDir + "/android";
        if (Directory.Exists(strABOutPAthDir) == false) Directory.CreateDirectory(strABOutPAthDir);

        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.Android);
        Debug.Log("安卓平台打包成功，输出的路径："+ strABOutPAthDir);

#elif UNITY_IPHONE //IOS
        strABOutPAthDir = strABOutPAthDir + "/ios";
        if (Directory.Exists(strABOutPAthDir) == false) Directory.CreateDirectory(strABOutPAthDir);

        BulidPipeline.BulidAssetBundles(strABOutPAthDir,
                                        BulidAssetBundleOptions.None,
                                        BulidTarget.iOS);
        Debug.Log("IOS平台打包成功，输出的路径："+ strABOutPAthDir);

#elif UNITY_STANDALONE_WIN //PC或则编辑器
        strABOutPAthDir = strABOutPAthDir + "/windows";
        if (Directory.Exists(strABOutPAthDir) == false) Directory.CreateDirectory(strABOutPAthDir);

        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.StandaloneWindows);
        Debug.Log("PC平台打包成功，输出的路径："+ strABOutPAthDir);

#elif UNITY_WEBGL         //WEBGL
        strABOutPAthDir = strABOutPAthDir + "/webgl";
        if (Directory.Exists(strABOutPAthDir) == false) Directory.CreateDirectory(strABOutPAthDir);

        //BuildPipeline.BuildAssetBundles(strABOutPAthDir, BuildAssetBundleOptions.AppendHashToAssetBundleName, BuildTarget.WebGL);

        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.WebGL);
        Debug.Log("WebGL 平台打包成功，输出的路径："+ strABOutPAthDir);

#endif

    }
}
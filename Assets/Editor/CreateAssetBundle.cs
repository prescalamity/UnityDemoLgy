using System.IO;
using UnityEditor;
using UnityEngine;
public class CreateAssetBundle
{
    [MenuItem("CustomEditor/Build AssetBundles")]//编辑器菜单路径 打包
    static void BulidAllAssetBundle()
    {
        // 打包AB输出路径
        string strABOutPAthDir = Application.streamingAssetsPath + "/../../StreamingAssets";
        // 判断文件夹是否存在，不存在则新建
        if (Directory.Exists(strABOutPAthDir) == false) Directory.CreateDirectory(strABOutPAthDir);
#if UNITY_ANDROID//安卓端
        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.Android);
        Debug.Log("安卓平台打包成功");
#elif UNITY_IPHONE //IOS
        BulidPipeline.BulidAssetBundles(strABOutPAthDir,
                                        BulidAssetBundleOptions.AppendHashToAssetBundleName,
                                        BulidTarget.iOS);
        Debug.Log("IOS平台打包成功");
#elif UNITY_STANDALONE_WIN //PC或则编辑器
        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.AppendHashToAssetBundleName,
                                        BuildTarget.StandaloneWindows);
        Debug.Log("PC平台打包成功");
#elif UNITY_WEBGL         //WEBGL
        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.WebGL);
        Debug.Log("WebGL 平台打包成功");
#endif
    }
}
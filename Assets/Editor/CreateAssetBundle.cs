using System.IO;
using UnityEditor;
using UnityEngine;
public class CreateAssetBundle
{
    [MenuItem("CustomEditor/BUild AssetBundles")]//�༭���˵�·�� ���
    static void BulidAllAssetBundle()
    {
        // ���AB���·��
        string strABOutPAthDir = Application.streamingAssetsPath + "/../../StreamingAssets";
        // �ж��ļ����Ƿ���ڣ����������½�
        if (Directory.Exists(strABOutPAthDir) == false) Directory.CreateDirectory(strABOutPAthDir);
#if UNITY_ANDROID//��׿��
        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.Android);
        Debug.Log("��׿ƽ̨����ɹ�");
#elif UNITY_IPHONE //IOS
        BulidPipeline.BulidAssetBundles(strABOutPAthDir,
                                        BulidAssetBundleOptions.AppendHashToAssetBundleName,
                                        BulidTarget.iOS);
        Debug.Log("IOSƽ̨����ɹ�");
#elif UNITY_STANDALONE_WIN //PC����༭��
        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.AppendHashToAssetBundleName,
                                        BuildTarget.StandaloneWindows);
        Debug.Log("PCƽ̨����ɹ�");
#elif UNITY_WEBGL         //WEBGL
        BuildPipeline.BuildAssetBundles(strABOutPAthDir,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.WebGL);
        Debug.Log("WebGL ƽ̨����ɹ�");
#endif
    }
}
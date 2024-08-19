using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using UnityEngine.UI;

/// <summary>
/// 测试加载ab包，中文
/// </summary>
public class AssetBundleScene : MonoBehaviour
{
    private string StreamingAssetsPath;//AB包路径

    //public GameObject myPrefab;


    void Start()
    {
        Debug.Log("AssetBundleScene.Start");


        //GameObject dasd = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

    }


    void Update()
    {

    }


    /// <summary>
    /// 加载ab包
    /// </summary>
    /// <param name="assetBundle">ab资源名（不包含路径）</param>
    /// <param name="resName">ab资源名中具体的模型名</param>
    /// <returns></returns>
    public IEnumerator LoadAssetBundle(string assetBundle, string resName, UnityAction<Object> GOLoadedCallback, System.Type type = null)
    {
        string mUrl = StreamingAssetsPath + assetBundle;
        Debug.Log("LoadAssetBundle.mUrl: " + mUrl);
        UnityWebRequest UWR_AB = UnityWebRequestAssetBundle.GetAssetBundle(mUrl);
        yield return UWR_AB.SendWebRequest();
        Debug.Log(string.Format("LoadAssetBundle.mUrl over: {0},  UWR_AB.downloadedBytes: {1}", mUrl, UWR_AB.downloadedBytes));
        if (!string.IsNullOrEmpty(UWR_AB.error))
            Debug.LogError(UWR_AB.error);
        else
        {
            AssetBundle _ab = DownloadHandlerAssetBundle.GetContent(UWR_AB);
            Object obj;
            if (type == null)
                obj = _ab.LoadAsset(resName);
            else
                //obj = _ab.
                obj = _ab.LoadAsset(resName, type);
            GOLoadedCallback?.Invoke(obj);
            yield return null;
            _ab.Unload(false);
        }
        UWR_AB.Dispose();
    }


    public IEnumerator LoadAssetBundleAudioClip(string assetBundle, string resName, UnityAction<AudioClip> GOLoadedCallback)
    {
        string mUrl = StreamingAssetsPath + assetBundle;
        Debug.Log("LoadAssetBundleBytes.mUrl: " + mUrl);
        UnityWebRequest UWR_AB = UnityWebRequestAssetBundle.GetAssetBundle(mUrl);
        yield return UWR_AB.SendWebRequest();
        Debug.Log(string.Format("LoadAssetBundleBytes.mUrl over: {0},  UWR_AB.downloadedBytes: {1}", mUrl, UWR_AB.downloadedBytes));
        AssetBundle _ab = DownloadHandlerAssetBundle.GetContent(UWR_AB);
        AudioClip _ac = _ab.LoadAsset<AudioClip>(resName);
        GOLoadedCallback.Invoke(_ac);
        yield return null;
        UWR_AB.Dispose();
    }

}



public class GO_AB_Info
{
    public string AB_PathName;
    public string GO_name;
}
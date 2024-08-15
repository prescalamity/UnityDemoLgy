using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using UnityEngine.UI;

/// <summary>
/// 测试加载ab包
/// </summary>
public class AssetBundleScene : MonoBehaviour
{
    private string StreamingAssetsPath;//AB包路径
    /// <summary>
    /// AB包的名字，不包含路径
    /// </summary>
    public string abName;
    /// <summary>
    /// 想要从AB包中加载物体的名字
    /// </summary>
    public string prefabsName;
    //public TMP_Text tmp;
    public Text tmp;
    StringBuilder textSB = new StringBuilder();
    string _str;
    string textureFormat = "Astc";// "Astc";  "dxt"
    public GameObject canvas = null;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world!");
        //Application.runInBackground = true;
        InitPath();
        textSB.Length = 0;
        textSB.Append("Hello, world! by Testpro." + System.Environment.NewLine);
        textSB.Append("-------------" + textureFormat + "------------------------------------");
        LoadUiButton();
    }
    /// <summary>
    /// 场景有 button UI 时小游戏插件 瘦身功能报错，改用ab形式动态加载
    /// </summary>
    public void LoadUiButton()
    {
        Debug.Log("helloworld.LoadUiButton");
        canvas = GameObject.Find("Canvas");
        GO_AB_Info gO_AB_Info1 = new GO_AB_Info();
        gO_AB_Info1.AB_PathName = "ab_button.unity3d";
        gO_AB_Info1.GO_name = "AB_Button";
        StartCoroutine(
            LoadAssetBundle(
                gO_AB_Info1.AB_PathName,
                gO_AB_Info1.GO_name,
                cbdata => {
                    GameObject goUI = (GameObject)Instantiate(cbdata);
                    goUI.transform.SetParent(canvas.transform, false);
                    goUI.GetComponent<Button>().onClick.AddListener(LoadSomeOneAB);
                }
            )
        );
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        GO_AB_Info gO_AB_Info2 = new GO_AB_Info();
        gO_AB_Info2.AB_PathName = "music_zhandou01.unity3d";
        gO_AB_Info2.GO_name = "music_zhandou01";
        StartCoroutine(
            LoadAssetBundleAudioClip(gO_AB_Info2.AB_PathName, gO_AB_Info2.GO_name, cbdata => { audioSource.clip = cbdata; audioSource.Play(); })
        );
    }
    long _tempMen = 0;
    long textureMem = 0;
    long textureMemdibiao02_1024 = 0;
    long textureMemxiaowujian = 0;
    int dibiaoCounter = 0;
    bool firstdibiao02_1024 = true;
    bool firstxiaowujian = true;
    StringBuilder dbSB = new StringBuilder("dibiao02_1024 Texture using Bytes: ");
    StringBuilder xwSB = new StringBuilder("xiaowujian02 Texture using Bytes: ");
    void Update()
    {
        //Debug.Log("-------------" + textureFormat +  "------------------------------------");
        textureMem = 0;
        Object[] textures = Resources.FindObjectsOfTypeAll(typeof(Texture));
        foreach (Texture t in textures)
        {
            _tempMen = Profiler.GetRuntimeMemorySizeLong((Texture)t);
            //_tempMen = 1;
            textureMem += _tempMen;
            if (t.name.Equals("dibiao02_1024") && textureMemdibiao02_1024 != _tempMen)
            {
                if (firstdibiao02_1024)
                {
                    firstdibiao02_1024 = false;
                    dbSB.Append("[textureFormat: " + t.graphicsFormat + "] ");
                }
                textureMemdibiao02_1024 = _tempMen;
                dbSB.Append(System.Environment.NewLine + "-->" + textureMemdibiao02_1024);
            }
            //if (t.name.Equals("dibiao02_1024")) {
            //    dbSB.Clear();
            //    dbSB.Append("dibiao02_1024 [textureFormat: " + t.graphicsFormat +  "] ");
            //}
            if (t.name.Equals("xiaowujian02") && textureMemxiaowujian != _tempMen)
            {
                if (firstxiaowujian)
                {
                    firstxiaowujian = false;
                    xwSB.Append("[textureFormat: " + t.graphicsFormat + "] ");
                }
                textureMemxiaowujian = _tempMen;
                xwSB.Append(System.Environment.NewLine + "-->" + textureMemxiaowujian);
            }
            //if (t.name.Equals("xiaowujian02")){
            //    xwSB.Clear();
            //    xwSB.Append("xiaowujian02 [textureFormat: " + t.graphicsFormat +  "] ");
            //}
        }
        //Debug.Log("All Texture objects using: " + textureMem + "_Bytes");
        //Debug.Log("dibiao02_1024 Texture using: " + textureMemdibiao02_1024 +  "_Bytes");
        //Debug.Log("xiaowujian02 Texture using: " + textureMemxiaowujian +  "_Bytes");
        _str = textSB.ToString() + System.Environment.NewLine + dbSB.ToString() + System.Environment.NewLine + xwSB.ToString();
        tmp.text = _str;
    }
    void InitPath()
    {
        StreamingAssetsPath =
#if UNITY_EDITOR
             "http://192.168.11.54/U202131_WEBGL/StreamingAssetsEditor/";
#elif UNITY_ANDROID
                "jar:file://"+Application.dataPath+"!/assets/";
#elif UNITY_IPHONE
                Application.dataPath+"/Raw/";
#elif UNITY_STANDALONE_WIN
               "file://" + Application.dataPath + "/../StreamingAssets/";
#elif UNITY_WEBGL
        "http://192.168.11.54/U202131_WEBGL/StreamingAssets/";
        //m_streaming_assets_path =  Application.streamingAssetsPath.Replace("Release/StreamingAssets",  "Resource/StreamingAssets");
        //m_streaming_assets_path = m_streaming_assets_path.Replace("http://", "");
        //m_streaming_assets_path = m_streaming_assets_path.Replace("https://",  "");
#endif
        Debug.Log("当前域名下的资源根路径: " + StreamingAssetsPath);
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
    public void LoadSomeOneAB()
    {
        GO_AB_Info gO_AB_Info1 = new GO_AB_Info();
        gO_AB_Info1.AB_PathName = "cylinderastc.unity3d";
        gO_AB_Info1.GO_name = "CylinderAstc";
        StartCoroutine(LoadAssetBundle(gO_AB_Info1.AB_PathName, gO_AB_Info1.GO_name, cbdata => Instantiate(cbdata)));
        GO_AB_Info gO_AB_Info = new GO_AB_Info();
        gO_AB_Info.AB_PathName = "cubeastc.unity3d";
        gO_AB_Info.GO_name = "CubeAstc";
        StartCoroutine(LoadAssetBundle(gO_AB_Info.AB_PathName, gO_AB_Info.GO_name, cbdata => Instantiate(cbdata)));
    }
}



public class GO_AB_Info
{
    public string AB_PathName;
    public string GO_name;
}
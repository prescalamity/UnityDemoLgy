using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 加载并在场景中创建模板实例，以及管理
/// </summary>
public class LoadResources
{

    private static GameObject TemplateGO = null;

    private static bool luaLoaded = false;
    public static bool LuaLoaded{
        get => luaLoaded;
        //private set { }
    }

    /// <summary>
    /// 加载lua源代码资源
    /// </summary>
    public static void loadLuaSources()
    {

        string[] luaStr = new string[] { "/lua_source/main.lua", "/lua_source/platforminterface.lua" };

        int copltCount = 0;

        foreach (string str in luaStr)
        {
            Main.Instance.StartCoroutine(
                DownloadResources.LoadBytesResourceCallBack(Util.m_streaming_assets_path + str,
                    data =>
                    {
                        LuaScriptMgr.GetInstance().lua.DoBytes(data);

                        copltCount++;

                        if (copltCount == luaStr.Length)
                        {
                            DLog.Log(" All lua_source have been loaded to LuaState.");
                            luaLoaded = true;
                        }

                    }
                )
            );
        }



    }

    /// <summary>
    /// 加载ab资源
    /// </summary>
    public static void loadAssetBundle()
    {

        string[] abStr = new string[] { "/capsule.unity3d", "/floor_cube.unity3d", "/sphere.unity3d" };

        string[] uiAbStr = new string[] { "/dropdown.unity3d" };   // "/input_field.unity3d", "/video_raw_image.unity3d", "power.unity",

        int absCount = abStr.Length + uiAbStr.Length;
        int absCounter = 0;

        string _urlprex = Util.m_streaming_assets_path + "/assetbundles";

        if (PlatformAdapter.mPlatform == PlatformType.AndroidRuntime)
        {
            _urlprex += "/android";
        }
        else if (PlatformAdapter.mPlatform == PlatformType.WebglRuntime)
        {
            _urlprex += "/webgl";
        }
        else if (PlatformAdapter.mPlatform == PlatformType.IosRuntime)
        {
            _urlprex += "/ios";
        }
        else
        {
            _urlprex += "/windows";
        }

        foreach (string str in abStr)
        {
            LoadResources.LoadGOAsyncUrl(_urlprex + str,
                data => {
                    absCounter++;
                    if (absCounter >= absCount) Main.canStartAfterInit = true;
                    if (data.name.Contains("sphere")) data.gameObject.AddComponent<TestMove>();
                    UiManager.updateUiSort();
                    DLog.Log("ok，name: {0}，absCounter：{1}", data.name, absCounter.ToString());
                },
                Main.Instance.GoRoot.transform);
        }

        foreach (string str in uiAbStr)
        {
            LoadResources.LoadGOAsyncUrl(_urlprex + str,
                data => {
                    data.name = str.TrimStart('/').Replace(".unity3d", "");   //这里 str 在foreach循环中被认为是闭包匿名类中私有的
                    absCounter++;
                    if (absCounter >= absCount) Main.canStartAfterInit = true;
                    UiManager.updateUiSort();
                    DLog.Log("ok，name: {0}，absCounter：{1}", data.name, absCounter.ToString());  //absCounter 被认为是闭包匿名类中引用的（即公有的）
                },
                Main.Instance.UiRootCanvas.transform);
        }
    }


    /// <summary>
    /// 从网络加载资源
    /// </summary>
    /// <param name="abUrl"></param>
    /// <param name="compltLoad"></param>
    /// <param name="parentTransform"></param>
    public static void LoadGOAsyncUrl(string abUrl, UnityAction<GameObject> compltLoad, Transform parentTransform)
    {
        string goName = abUrl.Split('/', System.StringSplitOptions.RemoveEmptyEntries)[^1].Replace(".unity3d", "");

        if (TemplateGO == null){
            Main.Instance.StartCoroutine(
                DownloadResources.DownloadAssetBundleCallBack(abUrl,
                    absData =>
                    {
                        GameObject _go = absData.LoadAsset<GameObject>(goName);

                        //TemplateGO = Object.Instantiate(_go, parentTransform);  //将实例 存放于模板，方便以后复制
                        GameObject gameObject = Object.Instantiate(_go, parentTransform);

                        absData.UnloadAsync(false);  //仅 卸载 运行内存中 镜像于硬盘ab资源 的空间
                        compltLoad?.Invoke(gameObject);
                    }
                )
            );
        }
    }

    //同步加载接口，本地加载
    public static GameObject LoadGoSync(string abFilePath, Transform parentTransform)
    {
        string goName = abFilePath.Split('/', System.StringSplitOptions.RemoveEmptyEntries)[^1].Replace(".unity3d", "");

        if (TemplateGO == null)
        {
            AssetBundle absData = AssetBundle.LoadFromFile(abFilePath);

            GameObject _go = absData.LoadAsset<GameObject>(goName);

            //TemplateGO = Object.Instantiate(_go, parentTransform);  //将实例 存放于模板，方便以后复制
            GameObject gameObject = Object.Instantiate(_go, parentTransform);

            absData.UnloadAsync(false);  //仅 卸载 运行内存中 镜像于硬盘ab资源 的空间
            return gameObject;
        }
        return null;
    }


    //异步加载，可以用于预加载资源
    public static void LoadGoSAsync(string abFilePath, UnityAction<GameObject> compltLoad, Transform parentTransform)
    {
        if (TemplateGO == null)

            Main.Instance.StartCoroutine(_LoadGoSAsync( abFilePath, compltLoad, parentTransform)); 

    }
    private static IEnumerator _LoadGoSAsync(string abFilePath, UnityAction<GameObject> compltLoad, Transform parentTransform)
    {
        string goName = abFilePath.Split('/', System.StringSplitOptions.RemoveEmptyEntries)[^1].Replace(".unity3d", "");

        AssetBundleCreateRequest absData = AssetBundle.LoadFromFileAsync(abFilePath);
        //absData.completed += (data) => { Debug.Log(data.progress); };
        yield return absData;

        if (absData.assetBundle == null)
        {
            DLog.Log("LoadResources._LoadGoSAsync fail");
            yield break;
        }

        AssetBundleRequest assetBundleRequest = absData.assetBundle.LoadAssetAsync<GameObject>(goName);  //异步加载单个数据，防止单个数据过大卡住

        yield return assetBundleRequest;

        GameObject _go = assetBundleRequest.asset as GameObject;

        //TemplateGO = Object.Instantiate(_go, parentTransform);  //将实例 存放于模板，方便以后复制
        GameObject gameObject = Object.Instantiate(_go, parentTransform);

        absData.assetBundle.UnloadAsync(false);  //仅 卸载 运行内存中 镜像于硬盘ab资源 的空间

        compltLoad?.Invoke(gameObject);

    }


}

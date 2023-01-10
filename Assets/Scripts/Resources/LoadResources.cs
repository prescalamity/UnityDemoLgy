using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    /// 缓存放lua脚本的文件名和内容的二进制数据，其中，文件名为相对 lua_source 路径，例如："/lua_source/config/main_config.lua"，暂时没有进行内存管理
    /// </summary>
    private static Dictionary<string, byte[]> luaFileByteDataDic = new Dictionary<string, byte[]>();
    public static byte[] getLuaFileByteData(string str)
    {
        byte[] byteData;

        bool isExcit = luaFileByteDataDic.TryGetValue(str, out byteData);

        if (!isExcit) DLog.Log(LogType.Warning,"Lua file not exist, {0}", str);

        return isExcit ? byteData : null;
    }

    public static void init()
    {
        DelegateToPlugins.Instance.getLuaFileByteData = getLuaFileByteData;
    }


    /// <summary>
    /// 加载lua源代码资源，先加载 main.lua，再根据其中的配置表加载其他lua脚本
    /// </summary>
    public static void loadLuaSources()
    {
        string luaStr =  "config/main_config.lua" ;

        Main.Instance.StartCoroutine(
            DownloadResources.LoadBytesResourceCallBack(Util.m_streaming_assets_path + "/lua_source/" + luaStr,
                data =>
                {
                    try
                    {
                        luaFileByteDataDic.Add(luaStr, data);

                        // 主表配置数据立即写入 lua 虚拟机中
                        LuaScriptMgr.GetInstance().lua.DoBytes(data);

                        DLog.LogToUI("The main_config.lua have been loaded to LuaState.");

                        loadOtherLuaSources();
                    }
                    catch (System.Exception ex)
                    {
                        DLog.Log("请检查 {0} 是否正确，下载的 {1} 内容为：{2}",luaStr, luaStr, Encoding.UTF8.GetString(data));
                        DLog.Log(ex.ToString());
                    }
                }
            )
        );
        
    }

    /// <summary>
    /// 除 main.lua 外的 其他lua脚本
    /// </summary>
    private static void loadOtherLuaSources()
    {
        LuaTable luaTable = LuaScriptMgr.GetInstance().GetLuaTable("mainconfig.otherLuaSoure");

        if(luaTable!=null && luaTable.Length > 0)
        {
           DLog.Log("LoadResources.loadOtherLuaSources.luaTable.Length:{0}", luaTable.Length);

            int copltCount = 0;

            foreach (var str in luaTable.ToArray())
            {
                Main.Instance.StartCoroutine(
                    DownloadResources.LoadBytesResourceCallBack(Util.m_streaming_assets_path + "/lua_source/" + str.ToString(),
                        data =>
                        {
                            try
                            {
                                luaFileByteDataDic.Add(str.ToString(), data);

                                //LuaScriptMgr.GetInstance().lua.DoBytes(data);

                                copltCount++;

                                if (copltCount == luaTable.Length)
                                {
                                    DLog.LogToUI(" All lua_source have been loaded to LuaState.");
                                    luaLoaded = true;
                                }
                            }
                            catch (System.Exception ex)
                            {
                                DLog.Log("请检查 {0} 是否正确，下载的 {1} 内容为：{2}", str.ToString(), str.ToString(), Encoding.UTF8.GetString(data));
                                DLog.Log(ex.ToString());
                            }

                        }
                    )
                );
            }
        }
        else
        {
            DLog.Log(LogType.Warning, "The other lua load error, or no other lua needs loaded to LuaState.");
            luaLoaded = true;
        }

    }

    /// <summary>
    /// 加载ab资源
    /// </summary>
    public static void loadAssetBundle()
    {
        LuaTable modelLuaTable = LuaScriptMgr.GetInstance().GetLuaTable("mainconfig.assetsbundles.model");
        LuaTable uiLuaTable = LuaScriptMgr.GetInstance().GetLuaTable("mainconfig.assetsbundles.ui");

        int absCount = modelLuaTable.Length + uiLuaTable.Length;

        int absCounter = 0;

        string _urlprex = Util.m_streaming_assets_path + "/assetbundles/" + PlatformAdapter.PlatformNameOnly() + "/";

        foreach (var str in modelLuaTable.ToArray())
        {
            LoadGOAsyncUrl(_urlprex + str.ToString(),
                data => {
                    //临时测试
                    if (data.name.Contains("sphere")) data.gameObject.AddComponent<TestMove>();

                    absCounter++;
                    if (absCounter >= absCount) {
                        DLog.LogToUI(" All assetbundle have been loaded to momery.");
                        Main.canStartAfterInit = true; 
                    }

                    UiManager.updateUiSort();
                    DLog.Log("ok，name: {0}，absCounter：{1}", data.name, absCounter.ToString());
                },
                Main.Instance.GoRoot.transform);
        }

        foreach (var str in uiLuaTable.ToArray())
        {
            LoadGOAsyncUrl(_urlprex + str.ToString(),
                data => {
                    data.name = str.ToString().TrimStart('/').Replace(".unity3d", "");   //这里 str 在foreach循环中被认为是闭包匿名类中私有的

                    absCounter++;
                    if (absCounter >= absCount) {
                        DLog.LogToUI(" All assetbundle have been loaded to momery.");
                        Main.canStartAfterInit = true; 
                    }

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

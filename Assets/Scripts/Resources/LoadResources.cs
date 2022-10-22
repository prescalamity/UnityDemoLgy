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
            Main.Instance.MainStartCoroutine(
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

            Main.Instance.MainStartCoroutine(_LoadGoSAsync( abFilePath, compltLoad, parentTransform)); 

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

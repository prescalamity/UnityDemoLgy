using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadResources
{

    private static GameObject TemplateGO = null;

    public static void LoadGO(string abUrl, UnityAction<GameObject> compltLoad, Transform parentTransform)
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



}

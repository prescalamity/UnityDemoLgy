using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ���ز��ڳ����д���ģ��ʵ�����Լ�����
/// </summary>
public class LoadResources
{

    private static GameObject TemplateGO = null;

    /// <summary>
    /// �����������Դ
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

                        //TemplateGO = Object.Instantiate(_go, parentTransform);  //��ʵ�� �����ģ�壬�����Ժ���
                        GameObject gameObject = Object.Instantiate(_go, parentTransform);

                        absData.UnloadAsync(false);  //�� ж�� �����ڴ��� ������Ӳ��ab��Դ �Ŀռ�
                        compltLoad?.Invoke(gameObject);
                    }
                )
            );
        }
    }

    //ͬ�����ؽӿڣ����ؼ���
    public static GameObject LoadGoSync(string abFilePath, Transform parentTransform)
    {
        string goName = abFilePath.Split('/', System.StringSplitOptions.RemoveEmptyEntries)[^1].Replace(".unity3d", "");

        if (TemplateGO == null)
        {
            AssetBundle absData = AssetBundle.LoadFromFile(abFilePath);

            GameObject _go = absData.LoadAsset<GameObject>(goName);

            //TemplateGO = Object.Instantiate(_go, parentTransform);  //��ʵ�� �����ģ�壬�����Ժ���
            GameObject gameObject = Object.Instantiate(_go, parentTransform);

            absData.UnloadAsync(false);  //�� ж�� �����ڴ��� ������Ӳ��ab��Դ �Ŀռ�
            return gameObject;
        }
        return null;
    }


    //�첽���أ���������Ԥ������Դ
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

        AssetBundleRequest assetBundleRequest = absData.assetBundle.LoadAssetAsync<GameObject>(goName);  //�첽���ص������ݣ���ֹ�������ݹ���ס

        yield return assetBundleRequest;

        GameObject _go = assetBundleRequest.asset as GameObject;

        //TemplateGO = Object.Instantiate(_go, parentTransform);  //��ʵ�� �����ģ�壬�����Ժ���
        GameObject gameObject = Object.Instantiate(_go, parentTransform);

        absData.assetBundle.UnloadAsync(false);  //�� ж�� �����ڴ��� ������Ӳ��ab��Դ �Ŀռ�

        compltLoad?.Invoke(gameObject);

    }


}

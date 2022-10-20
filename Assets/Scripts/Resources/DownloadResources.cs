using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadResources
{

    public static IEnumerator LoadBytesResourceCallBack(string url, Action<byte[]> callback = null)
    {
        var req = UnityWebRequest.Get(url);

        DLog.LogToUI("��ʼ�����ļ���" + url);

        yield return req.SendWebRequest();

        byte[] datas = req.downloadHandler.data;

        if (datas == null)
        {
            DLog.LogToUI("����ʧ�ܣ�" + url);
        }
        else
        {
            DLog.LogToUI("���سɹ���" + url + "-->Length:" + datas.Length);
        }

        callback?.Invoke(datas);

        req.Dispose();
    }



    public static IEnumerator DownloadAssetBundleCallBack(string url, Action<AssetBundle> callback = null)
    {
        DLog.Log("��ʼ����ab�ļ���" + url);

        var req = UnityWebRequestAssetBundle.GetAssetBundle(url);

        yield return req.SendWebRequest();

        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(req);

        if (ab == null) DLog.Log("AssetBundle����ʧ�ܣ�" + url);

        callback?.Invoke(ab);

        req.Dispose();
    }



}

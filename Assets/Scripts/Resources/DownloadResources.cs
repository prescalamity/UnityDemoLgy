using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadResources
{

    public static IEnumerator LoadBytesResourceCallBack(string url, Action<byte[]> callback = null)
    {
        var req = UnityWebRequest.Get(url);

        DLog.LogToUI("开始下载文件：" + url);

        yield return req.SendWebRequest();

        byte[] datas = req.downloadHandler.data;

        if (datas == null)
        {
            DLog.LogToUI("下载失败：" + url);
        }
        else
        {
            DLog.LogToUI("下载成功：" + url + "-->Length:" + datas.Length);
        }

        callback?.Invoke(datas);

        req.Dispose();
    }



    public static IEnumerator DownloadAssetBundleCallBack(string url, Action<AssetBundle> callback = null)
    {
        DLog.Log("开始下载ab文件：" + url);

        var req = UnityWebRequestAssetBundle.GetAssetBundle(url);

        yield return req.SendWebRequest();

        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(req);

        if (ab == null) DLog.Log("AssetBundle下载失败：" + url);

        callback?.Invoke(ab);

        req.Dispose();
    }



}

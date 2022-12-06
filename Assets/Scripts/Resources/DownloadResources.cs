using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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
            DLog.LogToUI(LogType.error, "error:下载失败，请检查网络资源是否可以访问-->" + url);
        }
        else
        {
            DLog.LogToUI("下载成功：" + url + "-->资源大小:" + datas.Length);
            callback?.Invoke(datas);
        }

        req.Dispose();
    }



    public static IEnumerator DownloadAssetBundleCallBack(string url, Action<AssetBundle> callback = null)
    {
        DLog.Log("开始下载ab文件：" + url);

        var req = UnityWebRequestAssetBundle.GetAssetBundle(url);

        yield return req.SendWebRequest();

        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(req);

        if (ab == null) DLog.Log(LogType.error, "error: AssetBundle下载失败：" + url);

        callback?.Invoke(ab);

        req.Dispose();
    }

    public static IEnumerator LoadTexture(string filePath, Image image)
    {

        if (PlatformAdapter.mPlatform == PlatformType.AndroidRuntime)
        {
            filePath = "file:///" + filePath;
        }
        else
        {
            filePath = "file://" + filePath;
        }

        DLog.LogToUI("DownloadResources.LoadTexture.filePath：" + filePath);

        WWW www = new WWW(filePath);

        yield return www;

        if (www.error != null)
        {
            DLog.Log("ReadFileByWWW {0} error, use ReadFileByPath", filePath);
            if (www.url.StartsWith("file://"))
            {
                var tex = ReadFileByPath(filePath);
                if (tex)
                {
                    image.sprite = Sprite.Create( (Texture2D)tex, new Rect(0,0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                }
                else
                {
                    DLog.Log("DownLoadFile error : {0} url : {1}", www.error, www.url);
                }
            }
            else
            {
                DLog.Log("DownLoadFile error : {0} url : {1}", www.error, www.url);
            }
        }
        else
        { 
            //AssetBundle ab = www.assetBundle;
            //tx.TexturePath = "";
            //tx.TextureName = "";
            if (image != null && image.gameObject != null)
            {
                if (image.mainTexture != null)
                {
                    GameObject.Destroy(image.mainTexture);
                }
                DLog.Log("www.texture.width: "+ www.texture.width+ ", height: " + www.texture.height);
                image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            }
        }
        www.Dispose();
    }


    public static Texture ReadFileByPath(string fileName)
    {
        Texture2D tex = null;
        byte[] fileData;
        if (System.IO.File.Exists(fileName))
        {
            fileData = System.IO.File.ReadAllBytes(fileName);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }

        return tex;

    }

}

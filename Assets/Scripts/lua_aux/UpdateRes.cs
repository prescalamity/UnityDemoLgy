//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Security.Cryptography;
//using System.Text;
//using LuaInterface;
//using UnityEngine;
//using System.Runtime.InteropServices;
//using System.Reflection;

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

//public class UpdateRes
//{
//    static AssetBundle updateBundle = null;
//    static AudioSource audioSource = null;

//    public static Action<bool> confirmCallback = null;
//    public static void LoadRes()
//    {

//        Shader transparentShader = Resources.Load<Shader>("Shader/Transparent Colored");
//        Shader textShader = Resources.Load<Shader>("Shader/Text");
//        Shader sdfShader = Resources.Load<Shader>("Shader/SdfText");

//        ShaderManager.GetInstance().AddShader(transparentShader);
//        ShaderManager.GetInstance().AddShader(textShader);
//        ShaderManager.GetInstance().AddShader(sdfShader);
//    }

//    public static GameObject root
//    {
//        get
//        {
//            return UIRoot.list[0].gameObject;
//        }
//    }

//    public static void SetColor(UIWidget w, float r, float g, float b)
//    {
//        w.color = new Color(r, g, b);
//    }


//    public static void popUpdateAlertView(string title, string message, string confirm, string cancel)
//    {
//#if UNITY_IPHONE || UNITY_ANDROID
//        Unity3DHelper.popUpdateAlertView(title, message, confirm, cancel, ClientInfo.forceUpdateUrl);
//#endif
//    }

//    public static void Confirm(bool confirm)
//    {
//        if (confirmCallback != null)
//        {
//            confirmCallback(confirm);
//        }
//    }

//    public static void ForceUpdate()
//    {
//        Application.OpenURL(ClientInfo.forceUpdateUrl);
//    }

//    public static void UnloadRes()
//    {
//        if (updateBundle != null)
//            Util.DelayToUnload(updateBundle);
//        //updateBundle.Unload(false);

//        updateBundle = null;
//    }

//    public static GameObject LoadGameObject(string objName)
//    {

//        if (updateBundle == null)
//        {
//            QLog.LogError("Bundle released !");
//            return null;
//        }


//        GameObject obj = updateBundle.LoadAsset<GameObject>(objName);
//        if (obj == null)
//        {
//            QLog.LogError("Can't Find GameObject<" + objName + "> in PlatformBundle.unity3d");
//        }

//        return GameObject.Instantiate(obj) as GameObject;
//    }

//    public static Texture2D ReadBundleTexture(string bundleName)
//    {
//        if (WebGL_Confing.IsWebglRuntime)
//        {
//            QLog.Log("webgl环境兼容提示：ReadBundleTexture");
//            return null;
//        }

//        return null;
//    }

//    public static void PlayBGMusic(string bg, bool loop, float vol)
//    {
//        if (updateBundle == null)
//        {
//            QLog.LogError("Bundle released !");
//            return;
//        }


//        AudioClip ac = updateBundle.LoadAsset<AudioClip>(bg);
//        if (ac == null)
//        {
//            QLog.LogError("Can't Find Sound<" + bg + "> in PlatformBundle.unity3d");
//        }

//        soundManager.GetInstance().PlayBGMusic(ac, loop, vol);
//    }
//    public static Texture2D LoadTexture(string texName)
//    {
//        if (updateBundle == null)
//        {
//            QLog.LogError("Bundle released !");
//            return null;
//        }

//        Texture2D tex = updateBundle.LoadAsset<Texture2D>(texName);
//        if (tex == null)
//        {
//            QLog.LogError("Can't Find Texture<" + texName + "> in PlatformBundle.unity3d");
//            UIHelper.PrintLuaStack();
//        }

//        return tex;
//    }

//    public static void ScreenSize(ref float x, ref float y)
//    {
//        x = Screen.width;
//        y = Screen.height;
//    }

//    public static void GetTransformLocalPos(Transform trans, out float x, out float y, out float z)
//    {
//        Vector3 pos = trans.localPosition;
//        x = pos.x;
//        y = pos.y;
//        z = pos.z;
//    }

//    public static void SetTransformLocalPos(Transform trans, float x, float y, float z)
//    {
//        Vector3 pos = Vector3.zero;
//        pos.x = x;
//        pos.y = y;
//        pos.z = z;

//        trans.localPosition = pos;
//    }

//    public static void GetTransformLocalRotation(Transform trans, out float x, out float y, out float z, out float w)
//    {
//        Quaternion qua = trans.localRotation;
//        x = qua.x;
//        y = qua.y;
//        z = qua.z;
//        w = qua.w;
//    }

//    static Quaternion sq = Quaternion.identity;

//    public static void SetTransformLocalRotation(Transform trans, float x, float y, float z, float w)
//    {
//        sq.x = x;
//        sq.y = y;
//        sq.z = z;
//        sq.w = w;

//        trans.localRotation = sq;
//    }

//    public static void SetTransformLocalScale(Transform trans, float x, float y, float z)
//    {
//        Vector3 scale = Vector3.zero;
//        scale.x = x;
//        scale.y = y;
//        scale.z = z;

//        trans.localScale = scale;
//    }

//    public static void GetTransformLocalScale(Transform trans, out float x, out float y, out float z)
//    {
//        Vector3 scale = trans.localScale;
//        x = scale.x;
//        y = scale.y;
//        z = scale.z;
//    }

//    public static void SetTextureBorder(UITexture texture, float x, float y, float z, float w)
//    {
//        texture.border = new Vector4(x, y, z, w);
//    }

//    public static void TestLoadingPanel()
//    {
//        if (!Application.isPlaying)
//            return;
//        xClientProxy.StartCoroutineFunc(TestLoadingView());
//    }

//    public static void AddWidgetCollider(GameObject go)
//    {
//        NGUITools.AddWidgetCollider(go);
//    }

//    static IEnumerator TestLoadingView()
//    {
//        UIPanel panel = UIPanel.Create(GameUIManager.instance.uiRoot);
//        panel.depth = 81000;
//        UILabel lb = UILabel.Create(panel.gameObject);
//        lb.text = "开始测试加载面板";
//        lb.fontSize = 32;
//        lb.transform.localPosition = new Vector3(0, 400, 0);
//        yield return null;
//        UILoadPanel.Instance.OpenView();
//        UILoadPanel.Instance.ShowLoadCircle(true);
//        yield return new WaitForSeconds(2);
//        lb.text = "开始测试强更";
//        UILoadPanel.Instance.ShowLoadCircle(false);
//        UILoadPanel.Instance.popUpdateAlertView(true);
//        yield return new WaitForSeconds(2);
//        UILoadPanel.Instance.Destroy();
//        lb.text = "开始更新提示";
//        yield return new WaitForSeconds(1);
//        UILoadPanel.Instance.OpenView();
//        bool done = false;
//        UILoadPanel.Instance.ShowConfirmUpdateButton(true, 1024 * 1023 * 99, (confirm) =>
//        {
//            if (!confirm)
//            {
//                lb.text = "取消被点击";
//            }
//            else
//            {
//                lb.text = "确定被点击";
//            }

//            done = true;
//        });

//        while (!done)
//        {

//            yield return null;
//        }

//        yield return new WaitForSeconds(2);

//        lb.text = "开始测试下载";

//        LuaTable luaTable = LuaScriptMgr.GetInstance().GetLuaTable("platform_update_setting");

//        string download_string = "正在下载最新文件";
//        ClientInfo.ReadLoadingModuleString("downing_files", ref download_string);
//        UILoadPanel.Instance.ShowTopTips(download_string);

//        string downloading_tips1 = "已下载";
//        ClientInfo.ReadLoadingModuleString("downloading_tips1", ref downloading_tips1);
//        string downloading_tips2 = "M/";
//        ClientInfo.ReadLoadingModuleString("downloading_tips2", ref downloading_tips2);
//        string downloading_tips3 = "M, 下载速度:";
//        ClientInfo.ReadLoadingModuleString("downloading_tips3", ref downloading_tips3);
//        string downloading_tips4 = "KB/s";
//        ClientInfo.ReadLoadingModuleString("downloading_tips4", ref downloading_tips4);
//        string mTipsConfig = "正在下载最新文件";
//        ClientInfo.ReadLoadingModuleString("downing_files", ref mTipsConfig);

//        string downloadStr = "0.6";
//        UILoadPanel.Instance.ReadLoadingModuleString("download_finnish_percent", ref downloadStr);
//        float downloadRate = float.Parse(downloadStr);


//        for (int i = 0; i < 200; ++i)
//        {
//            CommonConst.StringBuffer.Length = 0;
//            CommonConst.StringBuffer.AppendFormat("{0}{1:N2}{2}{3:N2}{4}{5:N2}{6}",
//                downloading_tips1, 99 * (i * 0.01f), downloading_tips2,
//                99, downloading_tips3, UnityEngine.Random.Range(1, 99),
//                downloading_tips4);
//            UILoadPanel.Instance.ShowUpdateTips(CommonConst.StringBuffer.ToString());
//            UILoadPanel.Instance.SetProcess((99 * (i * 0.005f) / 99) + 0.1f);
//            yield return null;
//        }

//        lb.text = "开始测试错误提示";
//        yield return new WaitForSeconds(2);
//        UILoadPanel.Instance.ShowErrTips("请求配置文件失败，请检查网络");
//        yield return new WaitForSeconds(2);
//        lb.text = "测试完毕";

//        yield return new WaitForSeconds(2);
//        UILoadPanel.Instance.Destroy();

//        GameObject.Destroy(panel.gameObject);
//    }

//    public static Texture2D LoadTextureFromPng(string resName)
//    {
//        return SyncResLoader.LoadTextureFromPng(resName);
//    }
//    public static void LoadTextureFromPngCallbcak(string resName, LuaFunction luaFunction)
//    {
//        AsyncResLoader.LoadTextureFromPng(resName, luaFunction);
//    }
//}
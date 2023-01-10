using UnityEngine;
using System.Collections;
using LuaInterface;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using LitJson;

public class PlatformSDK : Singleton<PlatformSDK>
{
#if UNITY_IOS
    [DllImport("__Internal")]
    public static extern string QdHSSSFromLJB(string key,string arg,string callback);
#endif

    LuaFunction mCallback = null;
    private LuaFunction PauseCallback = null;
    private LuaFunction RebackCallback = null;
    static string login_result = "";

    [DoNotToLua]
    public void Init()
    {
        DelegateToPlugins.Instance.callPlatformFunc = CallPlatformFunc;
    }

    public void SetPauseCallback(LuaFunction callback)
    {
        this.PauseCallback = callback;
    }

    public void SetRebackCallback(LuaFunction callback)
    {
        this.RebackCallback = callback;
    }

    [DoNotToLua]
    public void CallPauseEvent()
    {
        if (this.PauseCallback != null)
        {
            this.PauseCallback.Call();
        }
    }

    [DoNotToLua]
    public void CallReBackEvent()
    {
        if (this.RebackCallback != null)
        {
            this.RebackCallback.Call();
        }
    }
    public new static PlatformSDK GetInstance()
    {
        return Singleton<PlatformSDK>.GetInstance();
    }

    public static void Free()
    {
    }


/*SDK start*/
    public void OpenLogin(LuaFunction call_back)
    {
        mCallback = call_back;

        if (login_result != null && !login_result.Equals(""))
        {
	        DLog.Log(" OpenLogin  login_result!= null");
            nativeLoginCallback(login_result);
            login_result = "";
            return;
        }

#if UNITY_ANDROID || UNITY_IOS
        PlatformSDK.GetInstance().CallPlatformFunc("OpenLogin", "", "");
#endif
    }


    //废弃接口
    public void OpenYYBLogin(int type, LuaFunction call_back)
    {
    }

    public void OpenPay(int chargeId, int amount, int price, int pid,
            int sid, int rid, string platformUserId, string platformUserName,
            string serverName, string moneyName, float exchange,
            string roleName, string extra, string ext1, string ext2, string ext3)
    {
        JsonData jsonData = new JsonData();
        jsonData["chargeId"] = chargeId.ToString();
        jsonData["amount"] = amount.ToString();
        jsonData["price"] = price.ToString();
        jsonData["pid"] = pid.ToString();
        jsonData["sid"] = sid.ToString();
        jsonData["rid"] = rid.ToString();
        jsonData["platformUserId"] = platformUserId;
        jsonData["platformUserName"] = platformUserName;
        jsonData["serverName"] = serverName;
        jsonData["moneyName"] = moneyName;
        jsonData["mName"] = moneyName;
        jsonData["exchange"] = exchange;
        jsonData["roleName"] = roleName;
        jsonData["extra"] = extra;
        jsonData["ext1"] = ext1;
        jsonData["ext2"] = ext2;
        jsonData["ext3"] = ext3;

#if UNITY_ANDROID || UNITY_IOS
         PlatformSDK.GetInstance().CallPlatformFunc("OpenPay", jsonData.ToJson(), "");
#endif
    }

    public void setUserInfo(int pid, int sid, int rid,
			string platformUserId, string platformUserName, string serverName,
			string roleName, int roleLevel, string extraInfo)
    {
        JsonData jsonData = new JsonData();
        jsonData["pid"] = pid.ToString();
        jsonData["sid"] = sid.ToString();
        jsonData["rid"] = rid.ToString();
        jsonData["platformUserId"] = platformUserId;
        jsonData["platformUserName"] = platformUserName;
        jsonData["serverName"] = serverName;
        jsonData["roleName"] = roleName;
        jsonData["roleLevel"] = roleLevel.ToString() ;
        jsonData["extraInfo"] = extraInfo;
#if UNITY_ANDROID || UNITY_IOS
         PlatformSDK.GetInstance().CallPlatformFunc("SetUserInfo", jsonData.ToJson(), "");
#endif
    }

    // int type -> string type
    public void SendStatistic(string type, string msg)
    {
        JsonData jsonData = new JsonData();
        jsonData["msgtype"] = type;
        jsonData["msg"] = msg;
#if UNITY_ANDROID || UNITY_IOS
         PlatformSDK.GetInstance().CallPlatformFunc("SendStatistic", jsonData.ToJson(), "");
#endif
    }

    public void OpenUserPanel()
    {
#if UNITY_ANDROID || UNITY_IOS
         PlatformSDK.GetInstance().CallPlatformFunc("OpenUserPanel", "", "");
#endif
    }

    public void Logout(string username)
    {
#if UNITY_ANDROID
        JsonData jsonData = new JsonData();
        jsonData["username"] = username;
        PlatformSDK.GetInstance().CallPlatformFunc("Logout", jsonData.ToJson(), "");
#elif UNITY_IOS
         PlatformSDK.GetInstance().CallPlatformFunc("Logout", username, "");
#endif
    }
    /*SDK end*/


    public bool GetPlatForm()
    {
        bool is_sdk = false;
#if UNITY_IOS || UNITY_ANDROID
        is_sdk = true;
#endif
        return is_sdk;
    }

    public void ShowLoadCircle(bool isShow)
    {
        if (isShow)
        {
            PlatformSDK.GetInstance().CallPlatformFunc("ShowProgress", "Loading...", string.Empty);
        }
        else
        {
            PlatformSDK.GetInstance().CallPlatformFunc("CloseProgress", "", string.Empty);
        }
    }

    public void nativeLoginCallback(string message)
    {
        if (mCallback != null)
        {
            mCallback.Call(message);
        }else if (message != null)
        {
		     DLog.Log("nativeLoginCallback={0}", message);            
             login_result = message;
         }

        //if (ClientInfo.login_in_loading)
        //{
        //      PlatformMsgHandler.WebLog("sdk_success");
        //}

    }

    public void WebLog(string message)
    {
        PlatformMsgHandler.WebLog(message);
    }

    public bool CheckClientUpdate()
    {
        //登陆完成后检查是否有强更
        //if (ClientInfo.IsUpdateAfterLogin)
        //{
        //    if (ClientInfo.UpdateOption == ForceUpdateOption.FORCE_UPDATE || ClientInfo.UpdateOption == ForceUpdateOption.NEED_CONFIRM_UPDATE)
        //    {
        //        UILoadPanel.Instance.UnshowViewBg();
        //    }
        //    if (ClientInfo.CheckClientNeedUpdate())
        //    {
        //        return true;
        //    }
        //}
        return false;
    }

    public string GetUserIPAddress()
    {
        string userIp = "";
        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces(); ;
        foreach (NetworkInterface adapter in adapters)
        {
            if (adapter.Supports(NetworkInterfaceComponent.IPv4))
            {
                UnicastIPAddressInformationCollection uniCast = adapter.GetIPProperties().UnicastAddresses;
                if (uniCast.Count > 0)
                {
                    foreach (UnicastIPAddressInformation uni in uniCast)
                    {
                        //得到IPv4的地址。 AddressFamily.InterNetwork指的是IPv4
                        if (uni.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            userIp = uni.Address.ToString();
                        }
                    }
                }
            }
        }
        return userIp;
    }

    public string CallPlatformFunc(string key, string data, string lua_callback)
    {
        if (!string.IsNullOrEmpty(data))
        {
            DLog.Log("KeyPath: CallPlatformFunc key={0}, data={1}, lua_callback={2}", key, data, lua_callback);
        }
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass androidclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = androidclass.GetStatic<AndroidJavaObject>("currentActivity");
            string ret = jo.Call<string>("CallPlatformFunc", key, data, lua_callback);
            androidclass.Dispose();
            jo.Dispose();
            return ret;
            
#elif UNITY_IOS && !UNITY_EDITOR
            return QdHSSSFromLJB(key, data, lua_callback);
#endif

        return "";
    }


    [DoNotToLua]
    public void DYJBHS(string message)
    {
        if (string.IsNullOrEmpty(message)) return;
        if (message.Contains("logout"))
        {
            login_result = "";
            //if ( ClientInfo.login_in_loading && !xClientProxy.mLoadMainLua)
            //{
            //    //在更新界面调用切换账户lua没启动，直接打开登陆
            //    DLog.Log("DYJBHS openlogin");
            //    PlatformSDK.GetInstance().OpenLogin(null);
            //    return;
            //}
        }

        Singleton<LuaScriptMgr>.GetInstance().CallLuaFunction("PlatformInterface.CallScriptFunc", message);  
    }

    public void ReStartResourceUpdate()
    {
        //xClientProxy.IsReConnect = true;
        //xClientProxy.mLoadMainLua = false;
        //Singleton<LuaScriptMgr>.GetInstance().SetLuaUpdateFun("");
        //UILoadPanel.Instance.OpenView();
        //UILoadPanel.Instance.Init();
        //UpdateControllerEx.Instance.ToShowPanel();
    }
}

using UnityEditor;
using UnityEngine;


public class MenuEditerSample
{

    static bool douyinValidate = false;
    static bool weixinValidate = true;
    static bool windowsValidate = true;


    static MenuEditerSample()
    {
    }

    /// <summary>
    /// 需要删除微信插件，然后增加抖音插件
    /// </summary>
    [MenuItem("切换出包平台/抖音")]
    public static void Douyin()
    {
        Debug.Log("BuildDouyin.MyBuidlDouyin");

    }
    [MenuItem("切换出包平台/抖音", validate = true)]
    private static bool DouYinValidate()
    {
        return douyinValidate;
    }


    /// <summary>
    /// 需要删除抖音插件，然后增加微信插件
    /// </summary>
    [MenuItem("切换出包平台/微信")]
    public static void WeiXin()
    {
        Debug.Log("BuildDouyin.WeiXin");

    }
    [MenuItem("切换出包平台/微信", validate = true)]
    private static bool WeiXinValidate()
    {
        return weixinValidate;
    }

    /// <summary>
    /// 需要删除抖音插件&微信插件
    /// </summary>
    [MenuItem("切换出包平台/Windows WebGL")]
    public static void Windows()
    {
        Debug.Log("BuildDouyin.Windows WebGL");

    }
    [MenuItem("切换出包平台/Windows WebGL", validate = true)]
    private static bool WindowsValidate()
    {
        return windowsValidate;
    }


}

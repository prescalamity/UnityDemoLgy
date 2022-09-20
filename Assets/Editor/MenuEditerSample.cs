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
    /// ��Ҫɾ��΢�Ų����Ȼ�����Ӷ������
    /// </summary>
    [MenuItem("�л�����ƽ̨/����")]
    public static void Douyin()
    {
        Debug.Log("BuildDouyin.MyBuidlDouyin");

    }
    [MenuItem("�л�����ƽ̨/����", validate = true)]
    private static bool DouYinValidate()
    {
        return douyinValidate;
    }


    /// <summary>
    /// ��Ҫɾ�����������Ȼ������΢�Ų��
    /// </summary>
    [MenuItem("�л�����ƽ̨/΢��")]
    public static void WeiXin()
    {
        Debug.Log("BuildDouyin.WeiXin");

    }
    [MenuItem("�л�����ƽ̨/΢��", validate = true)]
    private static bool WeiXinValidate()
    {
        return weixinValidate;
    }

    /// <summary>
    /// ��Ҫɾ���������&΢�Ų��
    /// </summary>
    [MenuItem("�л�����ƽ̨/Windows WebGL")]
    public static void Windows()
    {
        Debug.Log("BuildDouyin.Windows WebGL");

    }
    [MenuItem("�л�����ƽ̨/Windows WebGL", validate = true)]
    private static bool WindowsValidate()
    {
        return windowsValidate;
    }


}

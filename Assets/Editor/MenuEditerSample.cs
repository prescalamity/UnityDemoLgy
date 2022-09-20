using System.IO;
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
    /// ���԰�ť
    /// </summary>
    [MenuItem("CustomEditor/���԰�ť")]
    public static void TestButton()
    {
        Debug.Log("MenuEditerSample.TestButton");

        string testPath1 = "D:/Test1";
        string testPath2 = "D:/Test2";

        //FileHelper.MoveDirectoryAndOverwrite(testPath1, testPath2);
        //FileHelper.MoveFileAndOverwrite(testPath1, testPath2);
        Directory.Delete(testPath1, true);
        
    }




    /// <summary>
    /// ��Ҫɾ��΢�Ų����Ȼ�����Ӷ������
    /// </summary>
    [MenuItem("CustomEditor/�л�����ƽ̨/����")]
    public static void Douyin()
    {
        Debug.Log("BuildDouyin.MyBuidlDouyin");

    }
    [MenuItem("CustomEditor/�л�����ƽ̨/����", validate = true)]
    private static bool DouYinValidate()
    {
        return douyinValidate;
    }


    /// <summary>
    /// ��Ҫɾ�����������Ȼ������΢�Ų��
    /// </summary>
    [MenuItem("CustomEditor/�л�����ƽ̨/΢��")]
    public static void WeiXin()
    {
        Debug.Log("BuildDouyin.WeiXin");

    }
    [MenuItem("CustomEditor/�л�����ƽ̨/΢��", validate = true)]
    private static bool WeiXinValidate()
    {
        return weixinValidate;
    }

    /// <summary>
    /// ��Ҫɾ���������&΢�Ų��
    /// </summary>
    [MenuItem("CustomEditor/�л�����ƽ̨/Windows WebGL")]
    public static void Windows()
    {
        Debug.Log("BuildDouyin.Windows WebGL");

    }
    [MenuItem("CustomEditor/�л�����ƽ̨/Windows WebGL", validate = true)]
    private static bool WindowsValidate()
    {
        return windowsValidate;
    }


}

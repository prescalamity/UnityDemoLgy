using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogScene : MonoBehaviour
{

    int MaxCount = 30000;
	private TMP_Text mOutputTextTMP;
	private Button mButton;

	long long1 = 4294967244;
	long long2 = 4294967295;

	float float1 = 0.0f;
	double double1 = 0;

	public void Awake()
	{

        //PlatformAdapter.init();

        mOutputTextTMP = GameObject.Find("Canvas/output").GetComponent<TMP_Text>();

		mButton = GameObject.Find("Canvas/test_button").GetComponent<Button>();
		mButton.onClick.AddListener(TestMainButtonEvent);
	}

	private void TestMainButtonEvent()
	{
		int couter = 0;
		string testStr = "";

		long flag1 = DateTime.UtcNow.Ticks;
		for (int i = 0; i < MaxCount; i++)
		{
			//couter++;
			testStr = $"Test.RunThis, i=-1";
		}

		long flag2 = DateTime.UtcNow.Ticks;

		for (int i = 0; i < MaxCount; i++)
		{
			Sub1.ThisStaticFunc("");
		}
		long flag2_1 = DateTime.UtcNow.Ticks;


		LogModule.Instance.Init(LogController.Close);


		long flag2_5 = DateTime.UtcNow.Ticks;
		for (int i = 0; i < MaxCount; i++)
		{
			//LogModule.Info($"Test.RunThis, i={i}");
			LogModule.Info("Test.RunThis, i=-1");
		}
		long flag2_6 = DateTime.UtcNow.Ticks;


		LogModule.Instance.Init(LogController.OutputToConsole + LogController.Info);


		long flag3 = DateTime.UtcNow.Ticks;
		for (int i = 0; i < MaxCount; i++)
		{
			LogModule.Info($"Test.RunThis, i=-1");
		}
		long flag4 = DateTime.UtcNow.Ticks;


		//long end = Timer.DateTimeToLongTimeStamp();

		//Console.WriteLine($"Start here, time totle: -- ms, \n flag1={flag1}, \n flag2={flag2}, ns");

		string strRes = $"Test.RunThis, testStr={testStr}, MaxCount: {MaxCount}, flag1={flag1}, + = {flag2 - flag1}00 ns, CallFunction = {flag2_1 - flag2}00 ns, CallFunctionInit = {flag2_5 - flag2_1}00 ns, " +
			$"CallFunctionBool = {flag2_6 - flag2_5}00 ns, CallFunctionInit = {flag3 - flag2_6}00 ns, CallFunctionPrint = {flag4 - flag3}00 ns.";

		Debug.Log(strRes);

		mOutputTextTMP.text = strRes;

	}

	void Start()
    {

		float1 = long1;

		double1 = long1;


		long resLog1 = (long)float1;

		long resLong2 = (long)double1;

		Debug.Log($"LogScene.Start, start,, long1={long1}, float1={float1}, resLog={resLog1}, " +
			$"double1={double1}, resLong2={resLong2}");

		//TestMainButtonEvent();


	}


    /// <summary>
    /// DateTimeת��Ϊ13λʱ�������λ�����룩
    /// </summary>
    /// <param name="dateTime"> DateTime</param>
    /// <returns>13λʱ�������λ�����룩</returns>
    public static long DateTimeToLongTimeStamp()
    {
        return (long) ( DateTime.UtcNow.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) ).TotalMilliseconds;
    }


}

public class Sub1
{

    public static void ThisStaticFunc(string value)
    {

    }

}

public class LogModule
{

    #region ģ�����ӿ�

    /// <summary>
    /// �������ڲ���ĳ�� bug ��ʱ��ʹ��
    /// </summary>
    public static void PersonDebug(string content)
    {
        Instance.ControllerPrintLog(content, LogController.PersonDebug);
    }

    /// <summary>
    /// �� �ض���־��� ������Ϣ��־
    /// </summary>
    public static void Info(string content)
    {
        Instance.ControllerPrintLog(content, LogController.Info);
    }

    public static void NetworkOrDataTransmit(string content)
    {
        Instance.ControllerPrintLog(content, LogController.NetworkOrDataTransmit);

    }

    public static void Warning(string content)
    {
        Instance.ControllerPrintLog(content, LogController.Warning);

    }

    public static void ProgramImportantNode(string content)
    {
        Instance.ControllerPrintLog(content, LogController.ProgramImportantNode);

    }

    public static void Error(string content)
    {
        Instance.ControllerPrintLog(content, LogController.Error);

    }

    #endregion


    private string _LogPath = string.Empty;
    /// <summary>
    /// ָ����־������ĸ��ļ�
    /// </summary>
    public string LogPath
    {
        get { return _LogPath; }
        private set { _LogPath = value; }
    }


    private int _NeedOutputLogs = LogController.OutputToConsole + LogController.Error + LogController.ProgramImportantNode;
    /// <summary>
    /// ָ�� LogController�� ��Щ�ȼ�����־���������
    /// Ĭ���Ǵ���ͳ������̽ڵ���־
    /// </summary>
    public int NeedOutputLogs
    {
        get { return _NeedOutputLogs; }
        private set { _NeedOutputLogs = value; }
    }

    private int _LogMaxCount = int.MaxValue;
    /// <summary>
    /// ������־����
    /// </summary>
    public int LogMaxCount
    {
        get { return _LogMaxCount; }
        private set { _LogMaxCount = value; }
    }


    private int logCount = 0;

    /// <summary>
    /// �ⲿ���� new ����
    /// </summary>
    private LogModule()
    {
        //RunThis();
    }


    private static LogModule instance = null;

    public static LogModule Instance
    {

        get
        {
            if (instance == null)
            {
                instance = new LogModule();
            }

            return instance;
        }

        set { instance = value; }
    }


    public void Init(int needOutputLogs, string logPath = "")
    {
        //Console.WriteLine($"LogModule.Init, logPath={logPath}, needOutputLogs={needOutputLogs}");

        //_NeedOutputLogs += LogController.PersonDebug;

        //if ( (_NeedOutputLogs & LogController.PersonDebug) == 0)
        //{
        //    Console.WriteLine($"LogModule.RunThis, {_NeedOutputLogs} not contain {LogController.PersonDebug}");
        //}
        //else
        //{
        //    Console.WriteLine($"LogModule.RunThis, {_NeedOutputLogs} contain {LogController.PersonDebug}");
        //}

        LogPath = logPath;
        NeedOutputLogs = needOutputLogs;
    }


    private void ControllerPrintLog(string content, int logLevel)
    {
        if (_NeedOutputLogs == 0) return;

        if ((_NeedOutputLogs & logLevel) == 0) return;

        if (logCount >= (_LogMaxCount - 1))
        {
            if (logCount == (_LogMaxCount - 1))
            {
                // ����ѳ���������־����
                PrintLog($"Warning: logs over {_LogMaxCount}, and no longer print after logs.");
            }

            return;
        }

        PrintLog(content);

    }

    private void PrintLog(string content)
    {

        // ��Ҫ���������̨���Ұ���ָ����־
        if ((_NeedOutputLogs & LogController.OutputToConsole) != 0)
        {
            //Console.WriteLine(content);
            Debug.Log(content);
        }

        // ��Ҫ������ļ����Ұ���ָ����־
        if ((_NeedOutputLogs & LogController.OutputToFile) != 0)
        {
            // ������ⲿ�ļ���

        }

        if (((_NeedOutputLogs & LogController.OutputToConsole) != 0) || ((_NeedOutputLogs & LogController.OutputToFile) != 0))
        {
            logCount++;
        }

    }


}



///// <summary>
///// ��־�ȼ���һ��8������ 255�� ���
///// 1111 1111 = 255
///// 1000 0000 = 128  = 2^7
///// 0000 0001 = 1    = 2^0
///// </summary>
//public enum LogController
//{

//    First = 1,

//    Second = 2,

//    Third = 4,

//    PersonDebug = 8,

//    NetOrDataTransmit = 16,

//    Warning = 32,

//    ProgramImportantNode = 64,

//    Error = 128,

//}


/// <summary>
/// ��־�ȼ���һ��8������ 255�� ���
/// 1111 1111 = 255
/// 1000 0000 = 128  = 2^7
/// 0000 0001 = 1    = 2^0
/// </summary>
public class LogController
{
    /// <summary>
    /// �ر���־��ӡ
    /// </summary>
    public const int Close = 0;

    /// <summary>
    /// �Ƿ����������̨
    /// </summary>
    public const int OutputToConsole = 1;

    /// <summary>
    /// �Ƿ�������ļ�
    /// </summary>
    public const int OutputToFile = 2;

    /// <summary>
    /// �������ڲ���ĳ�� bug ��ʱ��ʹ��
    /// </summary>
    public const int PersonDebug = 4;

    /// <summary>
    /// �� �ض���־��� ������Ϣ��־
    /// </summary>
    public const int Info = 8;

    public const int NetworkOrDataTransmit = 16;

    public const int Warning = 32;

    public const int ProgramImportantNode = 64;

    public const int Error = 128;


}

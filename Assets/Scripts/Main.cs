//using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class Main : MonoBehaviour
{
    private static Main mainInstance = null;
    public static Main Instance
    {
        get {
            if (mainInstance == null) {
                mainInstance = GameObject.Find("GameMain").GetComponent<Main>();
            }
            return mainInstance; 
        }
        private set { }
    }

    private static GameObject goRoot = null;
    private static GameObject uiRootCanvas = null;

    private static TMP_Text m_outputTextTMP;
    public static string OutputTextTMP_text {
        private get { return m_outputTextTMP.text; }
        set{
            m_outputTextTMP.text = value;
        }
    }

    public TMP_InputField m_inputFieldTMP;
    private TMP_Dropdown m_Dropdown;
    private Button mButton;
    private Button m_ClearButtonTMP;

    private VideoPlayer mVideoPlayer;
    //private VideoPlayer mLocalVideoPlayer;
    private bool mCanPlayVideo = false;


    private string m_Text = "This is input text." + System.Environment.NewLine;

    private int m_Index = 0;

    private bool luaLoaded = false;

    private bool hasStartAfterInit = false;
    private bool canStartAfterInit = false;

    private void Awake()
    {
        PlatformAdapter.init();
    }

    /// <summary>
    /// 初始化 必须的同步资源，以及 异步加载 一些初始化必须的资源
    /// </summary>
    void Start()
    {
        DLog.Log("1. Hello, world. in UnityDemoL.Main.Start by LGY. 2022-10-11 23:25.");

        test.onlyTestFunc();

        goRoot = GameObject.Find("GOsRoot");
        uiRootCanvas = GameObject.Find("Canvas");

        //加载异步的初始化资源
        loadAssetBundle();


    }

    /// <summary>
    /// 异步初始化必须资源 之后的一些初始化
    /// </summary>
    private void StartAfterInit()
    {
        m_outputTextTMP = GameObject.Find("Canvas/output").GetComponent<TMP_Text>();
        m_inputFieldTMP = GameObject.Find("Canvas/input_field").GetComponent<TMP_InputField>();
        m_inputFieldTMP.onEndEdit.AddListener( data => DLog.LogToUI("your input: " + data) );
        //m_inputFieldTMP.interactable = true;

        m_Dropdown = GameObject.Find("Canvas/dropdown").GetComponent<TMP_Dropdown>();
        m_Dropdown.options.Clear();
        TestDropdown.initDpd(m_Dropdown);
        m_Dropdown.onValueChanged.AddListener(
            (data) => {

                DLog.LogToUI("m_Dropdown selected: " + m_Dropdown.options[data].text);

                if (luaLoaded)
                {
                    LuaScriptMgr.GetInstance().CallLuaFunction("testFlatformFuncCallback", m_Dropdown.options[data].text);
                }

            }
        );


        mVideoPlayer = GameObject.Find("Canvas/video_raw_image").GetComponent<VideoPlayer>();
        mVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        mVideoPlayer.renderMode = VideoRenderMode.RenderTexture;
        mVideoPlayer.source = VideoSource.Url;
        mVideoPlayer.playOnAwake = false;
        mVideoPlayer.isLooping = false;

        //mLocalVideoPlayer = GameObject.Find("Canvas/local_video_raw_image").GetComponent<VideoPlayer>();
        //mLocalVideoPlayer.isLooping = false;
        //mLocalVideoPlayer.loopPointReached += (VideoPlayer source) =>
        //{
        //    source.Play();
        //    stringBuilder.Append("the source.Play again by loopPointReached."); 
        //    DLog.Log("the source.Play again by loopPointReached.");
        //};

        mButton = GameObject.Find("Canvas/test_button").GetComponent<Button>();
        mButton.onClick.AddListener(TestButtonEvent);

        m_ClearButtonTMP = GameObject.Find("Canvas/clear_output_area").GetComponent<Button>();
        m_ClearButtonTMP.onClick.AddListener(
            () => {
                DLog.gameUISB.Clear();
                m_outputTextTMP.text = DLog.gameUISB.ToString();
            }
        );

        GameObject.Find("Canvas/quit").GetComponent<Button>().onClick.AddListener(() =>
        {
            DLog.Log("Game quits.");
            mVideoPlayer.Stop();
            Application.Quit();
        });


        //http://192.168.11.46/t14/Resource/StreamingAssets/assetbundle/webgl/videos/_res_md5_156B62FA002DA941D0318335B1287B5C_chapter_video.mp4
        //"http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"
        //"https://sample-videos.com/video123/mp4/480/big_buck_bunny_480p_2mb.mp4"

        StartCoroutine(ExportVideo(
            Util.m_streaming_assets_path + "/video/big_buck_bunny.mp4"
            ));




        //------------------------------Lua Start---------------------------------------------------------------------------------

        LuaBinder.Bind(LuaScriptMgr.GetInstance().lua);   //初始化lua虚拟机，然后注册C#函数给lua用

        loadLuaSources();

        //LuaLoader.GetInstance().Init();

        //------------------------------Lua End---------------------------------------------------------------------------------

    }

    void Update()
    {
        if (!hasStartAfterInit)
        {
            if (canStartAfterInit) {
                StartAfterInit();
                hasStartAfterInit = true;
            }
            else
            {
                return;
            }
        }

        //if (!mLocalVideoPlayer.isPlaying)
        //{
        //    mLocalVideoPlayer.Play();
        //    DLog.Log("the mLocalVideoPlayer.isPlaying play again by Update.");
        //}
    }


    private void TestButtonEvent()
    {
        m_Index++;

        DLog.LogToUI(m_Index + ". Main.TestButtonEvent. ");
        //DLog.LogToUI(m_Index + ". Main.TestButtonEvent, input:" + m_inputFieldTMP.text);
        //DLog.LogToUI(m_Index + ". m_Dropdown.text :" + m_Dropdown.options[m_Dropdown.value].text);

        if (luaLoaded)
        {

            string res = LuaScriptMgr.GetInstance().InvokeLuaFunction<string>("start");

            DLog.LogToUI(m_Index + ". " + res);

            //luaLoaded = false;
        }

        if (mCanPlayVideo && !mVideoPlayer.isPlaying)
        {
            mVideoPlayer.Play();
            DLog.Log("it start to play the video.");
        }

        DLog.LogToUI("the mobile phone electricity 'Power.electricity' is " + Power.electricity);

    }


    private void loadLuaSources()
    {

        string[] luaStr = new string[] { "/lua_source/main.lua", "/lua_source/platforminterface.lua" };

        int copltCount = 0;

        foreach (string str in luaStr)
        {
            this.StartCoroutine(
                DownloadResources.LoadBytesResourceCallBack(Util.m_streaming_assets_path + str,
                    data =>
                    {
                        LuaScriptMgr.GetInstance().lua.DoBytes(data);

                        copltCount++;

                        if (copltCount == luaStr.Length) {
                            DLog.Log(" All lua_source have been loaded to LuaState.");
                            luaLoaded = true; 
                        }

                    }
                )
            );
        }



    }

    private void loadAssetBundle()
    {

        string[] abStr = new string[] { "/capsule.unity3d", "/floor_cube.unity3d", "/sphere.unity3d"  };

        string[] uiAbStr = new string[] { "/video_raw_image.unity3d", "/input_field.unity3d", "/dropdown.unity3d" };

        int absCount = abStr.Length + uiAbStr.Length;
        int absCounter = 0;

        string _urlprex = Util.m_streaming_assets_path + "/assetbundles";

        if (PlatformAdapter.mPlatform == PlatformType.AndroidRuntime) 
        { 
            _urlprex += "/android"; 
        }
        else if(PlatformAdapter.mPlatform == PlatformType.WebglRuntime)
        { 
            _urlprex += "/webgl";
        }
        else if (PlatformAdapter.mPlatform == PlatformType.IosRuntime)
        {
            _urlprex += "/ios";
        }
        else
        {
            _urlprex += "/windows";
        }

        foreach (string str in abStr)
        {
            LoadResources.LoadGOAsyncUrl(_urlprex + str, 
                data => { 
                    absCounter++;
                    if (absCounter >= absCount) canStartAfterInit = true;
                    DLog.Log("ok，name: {0}，absCounter：{1}", data.name, absCounter.ToString()); 
                }, 
                goRoot.transform);
        }

        foreach (string str in uiAbStr)
        {
            LoadResources.LoadGOAsyncUrl(_urlprex + str, 
                data => {
                    data.name = str.TrimStart('/').Replace(".unity3d", "");   //这里 str 在foreach循环中被认为是闭包匿名类中私有的
                    absCounter++;
                    if (absCounter >= absCount) canStartAfterInit = true;
                    DLog.Log("ok，name: {0}，absCounter：{1}", data.name, absCounter.ToString());  //absCounter 被认为是闭包匿名类中引用的（即公有的）
                },
                uiRootCanvas.transform);
        }
    }


    public IEnumerator ExportVideo(string videoPath)
    {
        DLog.Log("调用视频加载接口");


        //mVideoPlayer.SetTargetAudioSource(0, tex.gameObject.AddComponent<AudioSource>());

        mVideoPlayer.url = videoPath;

        mVideoPlayer.errorReceived += (v, s) => DLog.Log(string.Format("播放视频[{0}]出错:{1}", videoPath, s));

        mVideoPlayer.prepareCompleted += (v) =>
        {
            DLog.Log("视频准备完毕[" + videoPath + "]");

            DLog.LogToUI("视频准备完毕：" + mVideoPlayer.url);

            mCanPlayVideo = true;
        };

        DLog.LogToUI("正在下载视频：" + mVideoPlayer.url);

        mVideoPlayer.Prepare();  //下载资源准备播放

        yield return null;
    }


    private void CallScriptFunc(string cbData)
    {
        DLog.Log("Main.CallScriptFunc.cbData:"+ cbData);
        LuaScriptMgr.GetInstance().CallLuaFunction("PlatformInterface.CallScriptFunc", cbData);
    }

    public void MainStartCoroutine(IEnumerator func)
    {
        this.StartCoroutine(func);
    }
}

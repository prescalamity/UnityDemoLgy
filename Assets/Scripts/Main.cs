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

/// <summary>
/// 该类主要做些必须常驻必须资源的初始化
/// </summary>
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

    private GameObject goRoot = null;
    public GameObject GoRoot {
        get { 
            if(goRoot==null) goRoot = GameObject.Find("GOsRoot");
            return goRoot;
        }
    }

    private GameObject uiRootCanvas = null;
    public GameObject UiRootCanvas
    {
        get
        {
            if (uiRootCanvas == null) uiRootCanvas = GameObject.Find("Canvas");
            return uiRootCanvas;
        }
    }


    private static TMP_Text mOutputTextTMP;
    public static string OutputTextTMP_text {
        private get { return mOutputTextTMP.text; }
        set{
            if (mOutputTextTMP != null) { mOutputTextTMP.text = value; }
        }
    }


    public TMP_InputField mInputFieldTMP;
    private TMP_Dropdown mDropdown;
    private Button mButton;
    private Button mClearButtonTMP;

    private TestDevice androidDevicePower;



    private VideoPlayer mVideoPlayer;
    //private VideoPlayer mLocalVideoPlayer;
    private bool mCanPlayVideo = false;




    private string m_Text = "This is input text." + System.Environment.NewLine;

    private int m_SetpId = 0;


    private bool hasStartAfterInit = false;
    public static bool canStartAfterInit = false;

    private bool hasDownloadAbs = false;

    // 临时变量，用于判空
    GameObject _tempGo;


    private void Awake()
    {
        PlatformAdapter.init();
    }


    /// <summary>
    /// 初始化 常驻内存中资源，以及 异步加载 一些初始化必须的资源
    /// </summary>
    void Start()
    {
        DLog.Log("1. Hello, world. in UnityDemoL.Main.Start by LGY. 2022-10-11 23:25.");

        test.onlyTestFunc();

        //goRoot = GameObject.Find("GOsRoot");
        //uiRootCanvas = GameObject.Find("Canvas");


        mOutputTextTMP = GameObject.Find("Canvas/output").GetComponent<TMP_Text>();

        mButton = GameObject.Find("Canvas/test_button").GetComponent<Button>();
        mButton.onClick.AddListener(TestMainButtonEvent);

        mClearButtonTMP = GameObject.Find("Canvas/clear_output_area").GetComponent<Button>();
        mClearButtonTMP.onClick.AddListener(
            () => {
                DLog.gameUISB.Clear();
                mOutputTextTMP.text = DLog.gameUISB.ToString();
            }
        );

        GameObject.Find("Canvas/quit").GetComponent<Button>().onClick.AddListener(() =>
        {
            DLog.Log("Game quits.");
            mVideoPlayer?.Stop();
            Application.Quit();
        });




        DLog.LogToUI("cacahPath-->" + Util.m_temporary_cache_path);


        #region------------------------------Lua---------------------------------------------------------------------------------

        LuaBinder.Bind(LuaScriptMgr.GetInstance().lua);   //初始化lua虚拟机，然后注册C#函数给lua用

        LoadResources.loadLuaSources();

        //LuaLoader.GetInstance().Init();

        #endregion------------------------------Lua---------------------------------------------------------------------------------

        //加载异步的初始化资源
        //LoadResources.loadAssetBundle();

    }

    /// <summary>
    /// 异步初始化必须资源 之后的一些 常驻资源 初始化
    /// </summary>
    private void StartAfterInit()
    {
        //测试输入框
        _tempGo = null;
        _tempGo = GameObject.Find("Canvas/input_field");
        if(_tempGo != null)
        {
            mInputFieldTMP = _tempGo.GetComponent<TMP_InputField>();
            mInputFieldTMP.onEndEdit.AddListener(data => DLog.LogToUI("your input: " + data));
            mInputFieldTMP.interactable = true;
        }


        //下拉框，测试一般性平台接口，如简单属性获取，电池电量，
        mDropdown = GameObject.Find("Canvas/dropdown").GetComponent<TMP_Dropdown>();
        mDropdown.options.Clear();
        TestDropdown.initDpd(mDropdown);
        mDropdown.onValueChanged.AddListener(
            (data) => {

                //DLog.LogToUI("m_Dropdown selected: " + m_Dropdown.options[data].text);

                if (LoadResources.LuaLoaded)
                {
                    //LuaScriptMgr.GetInstance().CallLuaFunction("testFlatformFuncCallback", m_Dropdown.options[data].text);
                }
                
            }
        );


        #region------------------------------测试视频播放---------------------------------------------------------------------------------
        _tempGo = null;
        _tempGo = GameObject.Find("Canvas/video_raw_image");

        if (_tempGo != null)
        {
            mVideoPlayer = _tempGo.GetComponent<VideoPlayer>();
            mVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            mVideoPlayer.renderMode = VideoRenderMode.RenderTexture;
            mVideoPlayer.source = VideoSource.Url;
            mVideoPlayer.playOnAwake = false;
            mVideoPlayer.isLooping = false;


            //http://192.168.11.46/t14/Resource/StreamingAssets/assetbundle/webgl/videos/_res_md5_156B62FA002DA941D0318335B1287B5C_chapter_video.mp4
            //"http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"
            //"https://sample-videos.com/video123/mp4/480/big_buck_bunny_480p_2mb.mp4"

            StartCoroutine( ExportVideo( Util.m_streaming_assets_path + "/video/big_buck_bunny.mp4" ) );
        }


        //mLocalVideoPlayer = GameObject.Find("Canvas/local_video_raw_image").GetComponent<VideoPlayer>();
        //mLocalVideoPlayer.isLooping = false;
        //mLocalVideoPlayer.loopPointReached += (VideoPlayer source) =>
        //{
        //    source.Play();
        //    stringBuilder.Append("the source.Play again by loopPointReached."); 
        //    DLog.Log("the source.Play again by loopPointReached.");
        //};

        #endregion------------------------------测试视频播放---------------------------------------------------------------------------------


        //测试平台接口模块
        androidDevicePower = GoRoot.AddComponent<TestDevice>();

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


    private void TestMainButtonEvent()
    {
        m_SetpId++;

        DLog.LogToUI(m_SetpId + ". Main.TestButtonEvent. ");
        //DLog.LogToUI(m_SetpId + ". Main.TestButtonEvent, input:" + m_inputFieldTMP.text);


        if (LoadResources.LuaLoaded && hasDownloadAbs)
        {
            //string res = LuaScriptMgr.GetInstance().InvokeLuaFunction<string>("start");
            //DLog.LogToUI(m_SetpId + ". " + res);
            //luaLoaded = false;

            DLog.LogToUI(m_SetpId + ". m_Dropdown.text :" + mDropdown.options[mDropdown.value].text);
            LuaScriptMgr.GetInstance().CallLuaFunction("testFlatformFuncCallback", mDropdown.options[mDropdown.value].text);


            //LuaScriptMgr.GetInstance().InvokeLuaFunction<string>("TestMainButtonEvent");
        }

        if (mCanPlayVideo && !mVideoPlayer.isPlaying)
        {
            mVideoPlayer.Play();
            DLog.Log("it start to play the video.");
        }

        if (!hasDownloadAbs)
        {
            hasDownloadAbs = true;
            LoadResources.loadAssetBundle();

        }
    
        if(hasDownloadAbs) androidDevicePower?.MainButtonTestFunction(m_SetpId, mDropdown.options[mDropdown.value].text);

    }


    // 视频加载 暂时先放main这
    public IEnumerator ExportVideo(string videoPath)
    {
        DLog.Log("调用视频加载接口");


        //mVideoPlayer.SetTargetAudioSource(0, tex.gameObject.AddComponent<AudioSource>());

        mVideoPlayer.url = videoPath;

        mVideoPlayer.errorReceived += (v, s) => DLog.Log(string.Format("播放视频[{0}]出错:{1}", videoPath, s));

        mVideoPlayer.prepareCompleted += (v) =>
        {

            DLog.LogToUI("视频准备完毕：" + mVideoPlayer.url);

            mCanPlayVideo = true;
        };

        DLog.LogToUI("正在下载视频：" + mVideoPlayer.url);

        mVideoPlayer.Prepare();  //下载资源准备播放

        yield return null;
    }

    private void CallScriptFunc(string cbData)
    {
        //if (cbData.Contains("file_name")) DLog.LogToUI(cbData);

        if (cbData.Contains("OpenHeadPhotoCB")) TestHeadPhoto.OpenHeadPhotoCB(cbData);

        DLog.Log("Main.CallScriptFunc.cbData:"+ cbData);

        //LuaScriptMgr.GetInstance().CallLuaFunction("PlatformInterface.CallScriptFunc", cbData);
    }

    /// <summary>
    ///   上传头像回调，V1 版本的 平台回调 游戏的方式
    /// </summary>
    void ImagePicker_OnPickFinish(string file_name)
    {
        DLog.Log(">>>>><<<<< ImagePicker_OnPickFinish -> {0}", file_name);
        //ImagePicker.GetInstance().OnPickFinish(file_name);
    }
    
    void IosOcLog(string cbData)
    {
        DLog.Log(cbData);
    }

    void AndroidJavaLog(string cbData)
    {
        DLog.Log(cbData);
    }

    //public void MainStartCoroutine(IEnumerator func)
    //{
    //    this.StartCoroutine(func);
    //}

}

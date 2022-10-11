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

    private void Awake()
    {
        PlatformAdapter.init();
    }


    void Start()
    {
        DLog.Log("1. Hello, world. in UnityDemoL.Main.Start by LGY. 2022-10-10 19:57.");

        test.onlyTestFunc();


        m_outputTextTMP = GameObject.Find("Canvas/output").GetComponent<TMP_Text>();
        m_inputFieldTMP = GameObject.Find("Canvas/input_field").GetComponent<TMP_InputField>();

        m_Dropdown = GameObject.Find("Canvas/dropdown").GetComponent<TMP_Dropdown>();
        m_Dropdown.options.Clear();
        TestDropdown.initDpd(m_Dropdown);
        m_Dropdown.onValueChanged.AddListener(
            (data) => {

                DLog.showInGameUI("m_Dropdown selected: " + m_Dropdown.options[data].text);

                if(luaLoaded) LuaScriptMgr.GetInstance().CallLuaFunction("testFlatformFuncCallback", m_Dropdown.options[data].text);

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

        downloadLuaSources();

        //LuaLoader.GetInstance().Init();

        //------------------------------Lua End---------------------------------------------------------------------------------

    }


    void Update()
    {
        //if (!mLocalVideoPlayer.isPlaying)
        //{
        //    mLocalVideoPlayer.Play();
        //    DLog.Log("the mLocalVideoPlayer.isPlaying play again by Update.");
        //}
    }


    private void TestButtonEvent()
    {
        m_Index++;

        DLog.showInGameUI(m_Index + ". Main.TestButtonEvent. ");
        //DLog.showInGameUI(m_Index + ". Main.TestButtonEvent, input:" + m_inputFieldTMP.text);
        //DLog.showInGameUI(m_Index + ". m_Dropdown.text :" + m_Dropdown.options[m_Dropdown.value].text);

        if (luaLoaded) { 

            string res = LuaScriptMgr.GetInstance().InvokeLuaFunction<string>("start");
            
            DLog.showInGameUI(m_Index + ". " + res);

            luaLoaded = false;
        }

        if (mCanPlayVideo && !mVideoPlayer.isPlaying)
        {
            mVideoPlayer.Play();
            DLog.Log("it start to play the video.");
        }


        DLog.Log("Main.TestButtonEvent");
    }


    private void downloadLuaSources()
    {

        string[] luaStr = new string[] { "/lua_source/main.lua", "/lua_source/platforminterface.lua" };

        int copltCount = 0;

        foreach (string str in luaStr)
        {
            this.StartCoroutine(
                LoadBytesResourceCallBack(Util.m_streaming_assets_path + str,
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


    public static IEnumerator LoadBytesResourceCallBack(string url, Action<byte[]> callback = null)
    {
        var req = UnityWebRequest.Get(url);

        DLog.showInGameUI("开始下载文件：" + url);

        yield return req.SendWebRequest();

        byte[] datas = req.downloadHandler.data;

        if (datas == null)
        {
            DLog.Log("下载失败：" + url);
            DLog.showInGameUI("下载失败：" + url);
        }
        else
        {
            DLog.Log(url + "-->Length:" + datas.Length);
            DLog.showInGameUI(url + "-->Length:" + datas.Length);
        }

        callback?.Invoke(datas);

        req.Dispose();
    }


    public static IEnumerator LoadAssetBundleCallBack(string url, Action<AssetBundle> callback = null)
    {
        var req = UnityWebRequestAssetBundle.GetAssetBundle(url);

        yield return req.SendWebRequest();

        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(req);

        if (ab == null) DLog.Log("AssetBundle下载失败：" + url);

        callback?.Invoke(ab);

        req.Dispose();
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

            DLog.showInGameUI("视频准备完毕：" + mVideoPlayer.url);

            mCanPlayVideo = true;
        };

        DLog.showInGameUI("正在下载视频：" + mVideoPlayer.url);

        mVideoPlayer.Prepare();  //下载资源准备播放

        yield return null;
    }

}

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

    public TMP_Text m_TextMeshPro;

    private Button mButton;

    private VideoPlayer mVideoPlayer;
    private VideoPlayer mLocalVideoPlayer;
    private bool mCanPlayVideo = false;

    private StringBuilder stringBuilder = new StringBuilder();

    private string m_Text = "This is input text." + System.Environment.NewLine;

    private int m_Index = 0;

    private bool luaLoaded = false;

    private void Awake()
    {
        AndroidHelper.ShowAndroidStatusBar();
        AndroidHelper.SetAndroidStatusBarColor();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Start is called before the first frame update
    void Start()
    {
        DLog.Log("1. Hello, world. in StarkMini.Main.Start by LGY.");

        DLog.Log("2. Hello, world. in {0} by {1}.", "StarkMini.Main.Start", "LGY");


        m_TextMeshPro = GameObject.Find("Canvas/output").GetComponent<TMP_Text>();

        mVideoPlayer = GameObject.Find("Canvas/video_raw_image").GetComponent<VideoPlayer>();
        mVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        mVideoPlayer.renderMode = VideoRenderMode.RenderTexture;
        mVideoPlayer.playOnAwake = false;
        mVideoPlayer.isLooping = true;
        mVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        mLocalVideoPlayer = GameObject.Find("Canvas/local_video_raw_image").GetComponent<VideoPlayer>();
        //mLocalVideoPlayer.isLooping = true;
        //mLocalVideoPlayer.loopPointReached += (VideoPlayer source) =>
        //{
        //    source.Play();
        //    stringBuilder.Append("the source.Play again by loopPointReached.");
        //    DLog.Log("the source.Play again by loopPointReached.");
        //};

        mButton = GameObject.Find("Canvas/test_button").GetComponent<Button>();
        mButton.onClick.AddListener(TestButtonEvent);

        GameObject.Find("Canvas/quit").GetComponent<Button>().onClick.AddListener( () => { 
            DLog.Log("Game quits."); 
            mVideoPlayer.Stop();
            Application.Quit();
        });

        stringBuilder.Clear();


        //------------------------------Lua Start---------------------------------------------------------------------------------

        //LuaBinder.Bind(LuaScriptMgr.GetInstance().lua);

        downloadLuaSourceAB();

        //http://192.168.11.46/t14/Resource/StreamingAssets/assetbundle/webgl/videos/_res_md5_156B62FA002DA941D0318335B1287B5C_chapter_video.mp4
        //"http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"
        //"https://sample-videos.com/video123/mp4/480/big_buck_bunny_480p_2mb.mp4"

        StartCoroutine(ExportVideo(
            "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"
            ));

        //LuaLoader.GetInstance().Init();

        //------------------------------Lua End---------------------------------------------------------------------------------

    }

    // Update is called once per frame
    void Update()
    {
        if (!mLocalVideoPlayer.isPlaying)
        {
            mLocalVideoPlayer.Play();
            DLog.Log("the mLocalVideoPlayer.isPlaying play again by Update.");
        }
    }


    private void TestButtonEvent()
    {
        m_Index++;
        stringBuilder.Append(m_Index + ". Main.TestButtonEvent" + Environment.NewLine);
        m_TextMeshPro.text = stringBuilder.ToString();

        if (luaLoaded) { 

            //string res = LuaScriptMgr.GetInstance().InvokeLuaFunction<string>("start");
            
            stringBuilder.Append(m_Index + ". ");
            //stringBuilder.Append(m_Text);
            //stringBuilder.Append(res + System.Environment.NewLine);

            m_TextMeshPro.text = stringBuilder.ToString();
        }

        if (mCanPlayVideo && !mVideoPlayer.isPlaying)
        {
            mVideoPlayer.Play();
            DLog.Log("it start to play the video.");
        }

        DLog.Log("Main.TestButtonEvent");
    }


    private void downloadLuaSourceAB()
    {

        this.StartCoroutine(LoadBytesResourceCallBack(Util.m_streaming_assets_path + "/lua_source/main.lua",
            data => {
                //LuaScriptMgr.GetInstance().lua.DoBytes(data);
                //luaLoaded = true;
                DLog.Log("The lua_source have been loaded to LuaState.");
            }
        ));

    }


    public static IEnumerator LoadBytesResourceCallBack(string url, Action<byte[]> callback = null)
    {
        var req = UnityWebRequest.Get(url);

        yield return req.SendWebRequest();

        byte[] datas = req.downloadHandler.data;

        DLog.Log(url + "-->Length:" + datas.Length);

        if (datas == null) DLog.Log("下载失败：" + url);

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

        mVideoPlayer.errorReceived += (v, s) =>
        {
            DLog.Log(string.Format("播放视频[{0}]出错:{1}", videoPath, s));
        };

        mVideoPlayer.prepareCompleted += (v) =>
        {
            DLog.Log("视频准备完毕[" + videoPath + "]");

            stringBuilder.Append("视频准备完毕：" + mVideoPlayer.url + Environment.NewLine);
            m_TextMeshPro.text = stringBuilder.ToString();

            mCanPlayVideo = true;
        };

        stringBuilder.Append("正在下载视频：" + mVideoPlayer.url + Environment.NewLine);
        m_TextMeshPro.text = stringBuilder.ToString();

        mVideoPlayer.Prepare();  //下载资源准备播放

        yield return null;
    }


}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using UnityEngine.AI;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using static UnityEngine.UI.Button;
//using Cinemachine;

#if DEV_BRANCH
#else
using System.Text;
//using CookieManagerSpace;
using LuaInterface;
//using StatManager;
using BindType = ToLuaMenu.BindType;
#endif

public static class CustomSettings
{
    public static string mLuaPath
    {
        get
        {
            //string LuaPath = string.Empty;
#if !DEV_BRANCH
            //if (Directory.Exists(Application.dataPath + "/../3dscripts/lua_source"))
            //{
            //    LuaPath = Application.dataPath + "/../3dscripts/lua_source/";
            //    return LuaPath;
            //}
            //string configPath = "scriptspak/engineconfig.lua";
            //Util.Initpath();
            //if (UnityEngine.Debug.isDebugBuild || Application.isEditor)
            //{
            //    configPath = "scriptspak/engineconfig_debug.lua";
            //}
            //try
            //{
            //    byte[] text = Encoding.UTF8.GetBytes(FileHelperEx.Instance.ReadAllText(configPath));
            //    Singleton<LuaScriptMgr>.GetInstance().DoFile(ref text, ref configPath);
            //}
            //catch (Exception ex)
            //{
            //    try
            //    {
            //        byte[] text = FileHelperEx.Instance.ReadAllBytesInStreamingAsset(configPath);
            //        Singleton<LuaScriptMgr>.GetInstance().DoFile(ref text, ref configPath);
            //    }
            //    catch (Exception exx)
            //    {
            //        QLog.LogError("Load engineconfig error, stop the game : " + exx.Message);
            //    }
            //}
            //LuaPath = Convert.ToString(Singleton<LuaScriptMgr>.Instance.GetLuaTable("ConfigTable")["lua_script_path"]);
            //if (!LuaPath.EndsWith("/"))
            //{
            //    LuaPath += "/";
            //}
#endif
            //return LuaPath;

            return Application.dataPath + "/../StreamingAssets/lua_source/";

        }
        private set
        {
            mLuaPath = value;
        }
    }
#if DEV_BRANCH
#else




    public static string saveDir = Application.dataPath + "/Scripts/lua_wrap_gen/";
    public static string luaDir = Application.dataPath + "/Lua/";
    public static string toluaBaseType = Application.dataPath + "/ToLua/BaseType/";
    public static string toluaLuaDir = Application.dataPath + "/ToLua/Lua";

    //导出时强制做为静态类的类型(注意customTypeList 还要添加这个类型才能导出)
    //unity 有些类作为sealed class, 其实完全等价于静态类
    public static List<Type> staticClassTypes = new List<Type>
    {
        typeof(UnityEngine.Application),
        typeof(UnityEngine.Time),
        typeof(UnityEngine.Screen),
        typeof(UnityEngine.SleepTimeout),
        typeof(UnityEngine.Input),
        typeof(UnityEngine.Resources),
        typeof(UnityEngine.Physics),
        typeof(UnityEngine.RenderSettings),
        typeof(UnityEngine.QualitySettings),
    };

    //附加导出委托类型(在导出委托时, customTypeList 中牵扯的委托类型都会导出， 无需写在这里)
    public static DelegateType[] customDelegateList =
    {
    };

    public static List<Type> notReGenerateList = new List<Type>()
    {

    };

    //在这里添加你要导出注册到lua的类型列表
    public static BindType[] customTypeList =
    {                
      //_GT(typeof(Protocal)),
        //_GT(typeof(DownloadResources)),
  //      // 游戏启动时，优先注册的luawrap类
  //      _GT(typeof(UIRect)),
  //      _GT(typeof(UIWidget)),
  //      _GT(typeof(UILabel)),
  //      _GT(typeof(Behaviour)),
  //      _GT(typeof(UISprite)),
  //      _GT(typeof(UIAnchor)),
  //      _GT(typeof(UITexture)),
  //      _GT(typeof(UISlider)),
  //      _GT(typeof(QLog)),
  //      _GT(typeof(UIBasicSprite)),
  //      _GT(typeof(UpdateRes)),
  //      _GT(typeof(MonoBehaviour)),
  //      _GT(typeof(UIPanel)),
  //      _GT(typeof(Component)),
  //      _GT(typeof(Texture2D)),
  //      _GT(typeof(UIProgressBar)),
  //      _GT(typeof(UIEventListener)),
  //      _GT(typeof(UIDepthHelper)),

  //      _GT(typeof(GameObject)),
  //      _GT(typeof(Transform)),
  //      _GT(typeof(MeshFilter)),
  //      _GT(typeof(Time)),
  //      _GT(typeof(Input)),
  //      _GT(typeof(SystemInfo)),
  //      _GT(typeof(Resources)),
  //      _GT(typeof(TextAsset)),
  //      _GT(typeof(Graphics)),
  //      _GT(typeof(Mesh)),
  //      _GT(typeof(RenderTexture)),
  //      _GT(typeof(Application)),
  //      _GT(typeof(Keyframe)),
  //      _GT(typeof(AnimationCurve)),
  //      _GT(typeof(RenderSettings)),
  //      _GT(typeof(QualitySettings)),
  //      _GT(typeof(SystemInfo)),
  //      _GT(typeof(LightType)),
  //      _GT(typeof(Light)),
  //      _GT(typeof(LightBakingOutput)),
  //      _GT(typeof(Physics)),
  //      _GT(typeof(RaycastHit)),
  //      _GT(typeof(Rigidbody)),
  //      _GT(typeof(Space)),
  //      _GT(typeof(Animation)),
  //      _GT(typeof(LineRenderer)),
  //      _GT(typeof(AudioSource)),
  //      _GT(typeof(AudioClip)),
  //      _GT(typeof(UnityEngine.Profiling.Profiler)),
  //      _GT(typeof(PlayerPrefs)),
  //      _GT(typeof(Gradient)),
  //      _GT(typeof(GradientColorKey)),
  //      _GT(typeof(GradientAlphaKey)),
  //      _GT(typeof(Volume)),
  //      _GT(typeof(VolumeManager)),
  //      _GT(typeof(VolumeProfile)),
  //      _GT(typeof(Tonemapping)),
  //      _GT(typeof(Bloom)),
  //      _GT(typeof(ColorAdjustments)),
  //      _GT(typeof(RadialBlur)),
  //      _GT(typeof(DepthOfField)),
  //      _GT(typeof(ColorLookup)),
  //      _GT(typeof(Vignette)),
  //      _GT(typeof(ChromaticAberration)),
  //      _GT(typeof(ScreenWaterWave)),

  //      _GT(typeof(ClampedFloatParameter)),
  //      _GT(typeof(ColorParameter)),
  //      _GT(typeof(BoolParameter)),
  //      _GT(typeof(ClampedIntParameter)),
  //      _GT(typeof(MinFloatParameter)),

  //      // 用于PS4和xbox手柄摇杆和按键输入
  //      _GT(typeof(JoystickInput)),



  //      _GT(typeof(NavMeshAgent)),
  //      _GT(typeof(NavMeshHit)),
  //      _GT(typeof(MeshCollider)),
  //      _GT(typeof(SphereCollider)),
  //      _GT(typeof(CapsuleCollider)),

  //      _GT( typeof(UIFont) ),		
  //      //_GT(typeof(ObjectCommon)),	
  //      _GT(typeof(TweenType)),
  //      _GT(typeof(WrapMode)),
  //      _GT(typeof(TweenType)),

  //      _GT(typeof(UploadFile)),
  //      //_GT(typeof(ScreenEffectBase)),

  //      //UI相关接口
  //      _GT(typeof(UnityEvent)),
  //      _GT(typeof(Image)),  
  //      _GT(typeof(TMP_Text)),   
  //      _GT(typeof(TMP_Dropdown)),
  //      _GT(typeof(RectTransform)),
  //      _GT(typeof(ButtonClickedEvent)),
        _GT(typeof(TextMeshProUGUI)),
  
  //      _GT(typeof(UILabelSDFExt)),
  //      _GT(typeof(Button)),
  //      _GT(typeof(LayerMask)),
  //      _GT(typeof(NGUITools)),
  //      _GT(typeof(NGUIText.Alignment)),
  //      _GT(typeof(Camera)),
  //      _GT(typeof(Mathf)),
  //      _GT(typeof(CameraClearFlags)),
  //      _GT(typeof(CameraExtensions)),
  //      _GT(typeof(CameraOverrideOption)),
  //      _GT(typeof(AntialiasingMode)),
  //      _GT(typeof(CameraRenderType)),
  //      _GT(typeof(AntialiasingQuality)),
  //      _GT(typeof(UniversalAdditionalCameraData)),
  //      _GT(typeof(Font)),
  //     // _GT(typeof(Color)),
  //      _GT(typeof(UIRoot)),
  //     // _GT(typeof(Color)),
  //      _GT(typeof(UIInput)),
  //      _GT(typeof(UIOrthoCamera)),
  //      _GT(typeof(UISpriteAnimation)),
  //      _GT(typeof(UISpriteData)),
  //      //_GT(typeof(UIStretch)),
  //      _GT(typeof(UITextList)),
  //      //_GT(typeof(UITooltip)),
  //      _GT(typeof(UIViewport)),
  //      _GT(typeof(UIPolygon)),
  //      _GT(typeof(UIPolygon2)),
  //      _GT(typeof(UIDrawCall)),
  //      _GT(typeof(UILine)),
  //      _GT(typeof(UICamera)),
  //      _GT(typeof(TweenAlpha)),
  //      _GT(typeof(TweenColor)),
  //      _GT(typeof(UITweener)),
  //      _GT(typeof(TweenFOV)),
  //      _GT(typeof(TweenHeight)),
  //      _GT(typeof(TweenOrthoSize)),
  //      _GT(typeof(TweenPosition)),
  //      _GT(typeof(TweenRotation)),
  //      _GT(typeof(TweenScale)),
  //      _GT(typeof(TweenTransform)),
  //      _GT(typeof(TweenVolume)),
  //      _GT(typeof(TweenWidth)),
  //      _GT(typeof(TweenLetters)),
  //      //_GT(typeof(Stopwatch)),
  //      _GT(typeof(RealMarker)),
  //      _GT(typeof(RealMarkerData)),
  //      _GT(typeof(RealSingleData)),
  //      _GT(typeof(SingleDataPair)),
  //      _GT(typeof(KeyData)),
  //      _GT(typeof(UIWidgetContainer)),
  //      _GT(typeof(UIDragScrollView)),
  //      _GT(typeof(UIEventTrigger)),
  //      _GT(typeof(UIPlayTween)),

  //      _GT(typeof(UIScrollView)),
  //      _GT(typeof(UIRichlabel)),
  //      _GT(typeof(UIScrollViewSystem)),
  //      _GT(typeof(UIVAlign)),
  //      _GT(typeof(UIHAlign)),
  //      _GT(typeof(ExUIButton)),
  //      //_GT(typeof(EventDelegate)),
  //      _GT(typeof(UIExFrameASprite)),
  //      _GT(typeof(UIDrawCall.Clipping)),
  //      _GT(typeof(NGUIMath)),
  //      //_GT(typeof(UIHelper)),
  //      //_GT(typeof(UIFadeInOutPanel)),
  //      //_GT(typeof(UIFocusToCirclePanel)),
  //      _GT(typeof(UIHelper)),
  //      _GT(typeof(UIEraser)),

  //      _GT(typeof(UIProfiler)),
  //      _GT(typeof(WindowMarker)),
  //      _GT(typeof(GameUIPanelBase)),
  //      _GT(typeof(HUDText)),
  //      _GT(typeof(BlurScreen)),
  //      _GT(typeof(Util)),
  //      //_GT(typeof(LuaHelper)),
  //      _GT(typeof(NetManager)),
  //      _GT(typeof(GameUIManager)),
  //      _GT(typeof(UIResourceManager)),
  //      _GT(typeof(XDevice)),
  //      _GT(typeof(ModelData)),
  //      _GT(typeof(ModelDataManager)),
  //      _GT(typeof(FxStickMode)),
  //      _GT(typeof(HardWareQuality)),
  //      _GT(typeof(ModelRotateHelp)),
  //      _GT(typeof(MonoHelper)),    
  //     //Http
  //      _GT(typeof(HttpManager)),
  //      _GT(typeof(GameSceneManager)),

  //     //Scene
  //      _GT(typeof(SkinQuality)),
  //      _GT(typeof(AttachFxBuildInfo)),
  //      _GT(typeof(AttachedFX)),
  //      _GT(typeof(CSceneFxManager)),
  //      _GT(typeof(FxManager)),
  //      _GT(typeof(FxWeight)),
  //      _GT(typeof(FxHideStrategy)),
  //      _GT(typeof(SceneFxBuildInfo)),
  //      _GT(typeof(SceneFx)),
  //      _GT(typeof(VisualPropertyInfo)),
  //      _GT(typeof(TerrainHelper)),
  //      _GT(typeof(PoolManager)),
  //      _GT(typeof(EAnimCrossFadeType)),
  //      _GT(typeof(EntityType)),
  //      _GT(typeof(ShaderManager)),
  //      _GT(typeof(CharacterShadow)),
  //      _GT(typeof(SyncResLoader)),
  //      _GT(typeof(InputEventManager)),
  //      _GT(typeof(AvatarManager)),
  //      _GT(typeof(MyAvatar)),
  //      _GT(typeof(ImageEffectManager)),
  //      _GT(typeof(MapInstance)),
  //      _GT(typeof(Aoi)),
  //      _GT(typeof(AoiType)),
  //      _GT(typeof(CommonConst)),
  //      _GT(typeof(CommonFlag)),
  //      _GT(typeof(BlinkObjectCustomFrame)),
  //      _GT(typeof(TransitionKit)),
  //      _GT(typeof(Scene2DEffectManager)),
  //      _GT(typeof(SceneEnvironmentCtrl)),
  //      _GT(typeof(SceneRenderSettings)),
  //      _GT(typeof(ProjectionSelfShadowMap)),
  //      _GT(typeof(AnimationClip)),
  //      _GT(typeof(Animator)),
  //      _GT(typeof(RuntimeAnimatorController)),
  //      _GT(typeof(AnimatorOverrideController)),
  //      _GT(typeof(AnimatorStateInfo)),
  //      _GT(typeof(UnityEngine.SceneManagement.SceneManager)),
  //      _GT(typeof(UnityEngine.SceneManagement.Scene)),
  //      _GT(typeof(ScreenCapture)),
  //      _GT(typeof(AssetBundle)),
  //      _GT(typeof(GrassRendererFeature)),
  //      _GT(typeof(TraceGenerateRendererFeature)),
  //      _GT(typeof(PlanarReflections)),
  //      _GT(typeof(FurRendererFeature)),
  //      _GT(typeof(OffScreenParticleFeature)),
        
		////push
  //     _GT(typeof(NoticePush)),
  //     _GT(typeof(ImagePicker)),
  //     _GT(typeof(LocationService)),
  //     _GT(typeof(WXVoiceHelper)),
  //     _GT(typeof(Screen)),
  //     _GT(typeof(SoundRecorder)),
  //     _GT(typeof(IflytekVoiceHelper)),
  //     _GT(typeof(HeartbeatThread)),
  //     //_GT(typeof(TRTCHelper)),

  //      //cookie相关;
  //      _GT(typeof(CookieManager)),
  //      //状态机;
  //      //_GT(typeof(StateMachineState)),
  //     // _GT(typeof(GameStateMachine)),
  //      _GT(typeof(UIFollowTarget)),

  //      //性能测试相关
  //      _GT(typeof(PerformanceModule)),

  //      //统计模块
  //      _GT(typeof(StatHelper)),

  //      //SDK
  //      _GT(typeof(PlatformSDK)),

  //      //等级资源管理
  //      _GT(typeof(LevelZipManager)),

  //      //更新面板
  //      _GT(typeof(UILoadPanel)),

  //      //声音
  //      _GT(typeof(soundManager)),
  //      _GT(typeof(SoundPlayer)),

  //      //w
  //      //_GT(typeof(DelegateFactory)),
  //      _GT( typeof(Shader) ),
  //      _GT( typeof(Material) ),
  //      _GT( typeof(CameraFacingBillboard) ),
  //      _GT( typeof(UIAtlas) ),
  //      _GT( typeof(Collider) ),
  //      _GT( typeof(BoxCollider) ),
  //      _GT( typeof(TerrainCollider) ),
  //      _GT( typeof(Texture)),
  //      _GT( typeof(TextureParameter) ),
  //      _GT( typeof(Cubemap)),
  //      _GT( typeof(Matrix4x4) ),
  //      _GT( typeof(Renderer) ),
  //      _GT( typeof(SkinnedMeshRenderer) ),
  //      _GT( typeof(MeshRenderer) ),
  //      _GT( typeof(ParticleSystemRenderer) ),
  //      _GT( typeof(ParticleSystem) ),
  //      _GT( typeof(CommandBuffer) ),
  //      _GT( typeof(CameraEvent) ),
  //      _GT(typeof(NavMesh)),
  //      _GT(typeof(NavMeshPath)),
  //      _GT(typeof(NavMeshTriangulation)),
  //      _GT(typeof(FlareLayer)),

  //      _GT(typeof(AsyncResLoader)),
  //      //_GT(typeof(AStarPoint)),
  //      //_GT(typeof(Protocal)),
  //      _GT(typeof(KeyCode)),
  //      _GT(typeof(DynamicBone)),
  //      _GT(typeof(DynamicBoneInfo)),
  //      _GT(typeof(DynamicBoneControllerInfo)),
  //      _GT(typeof(DynamicBoneManager)),
  //      _GT(typeof(HeadLookController)),

  //      // 剧情
  //      _GT( typeof(CinemaDirectorMgr)),
  //      _GT( typeof(CinemaDirector.SetParent)),
  //      _GT(typeof(CinemachineDollyCart)),
  //      _GT(typeof(CinemachineSmoothPath)),

  //      //降帧
  //       _GT( typeof(CSSleepManager)),

  //       _GT( typeof(ScrollUVHelper) ),
  //       _GT( typeof(Rect) ),

  //       // 剧情操作       
  //       _GT(typeof(UnityEngine.Playables.PlayableAsset)),
  //       _GT(typeof(UnityEngine.Playables.PlayableDirector)),
  //       _GT(typeof(UnityEngine.Playables.PlayableBinding)),
  //       _GT(typeof(UnityEngine.Timeline.TimelineAsset)),
  //       _GT(typeof(UnityEngine.Timeline.AnimationTrack)),
  //       _GT(typeof(UnityEngine.Timeline.TimelineClip)),
  //       _GT(typeof(UnityEngine.Timeline.AnimationPlayableAsset)),
  //       _GT(typeof(UnityEngine.Timeline.ActivationTrack)),
  //       _GT(typeof(TimelineHelper)),
  //       _GT(typeof(TLEventProxy)),
  //       _GT(typeof(MaterialPropertyBlock)),
  //       _GT(typeof(SceneRealtimeShadow)),
  //       _GT(typeof(GrabPassHelper)),
  //       _GT(typeof(SceneBloomOptimized)),

  //       _GT(typeof(UniWebViewUtil)),

  //       //spine
  //       _GT(typeof(Spine.Unity.SkeletonAnimation)),
  //       _GT(typeof(Spine.Skeleton)),
  //       _GT(typeof(SpineLoader)),

  //       _GT(typeof(PostProcessManager)),

  //       _GT(typeof(UnityEngine.Rendering.Universal.ShadowQuality)),
  //       _GT(typeof(UnityEngine.Rendering.Universal.ShadowResolution)),
  //       _GT(typeof(MsaaQuality)),
  //       _GT(typeof(Downsampling)),
  //       _GT(typeof(LightRenderingMode)),
  //       _GT(typeof(ShaderVariantLogLevel)),
  //       _GT(typeof(ColorGradingMode)),
  //       _GT(typeof(UniversalRenderPipelineAsset)),
  //       _GT(typeof(CustomRendererFeature)),
  //       _GT(typeof(RenderPipelineAssetSetting)),
  //       _GT(typeof(ScriptableRendererFeature)),
        
  //      // 插件
  //      _GT(typeof(TRTCHelper)),
  //      _GT(typeof(WeatherHelper))
    };

    public static List<Type> dynamicList = new List<Type>()
    {

    };
    //重载函数，相同参数个数，相同位置out参数匹配出问题时, 需要强制匹配解决
    //使用方法参见例子14
    public static List<Type> outList = new List<Type>()
    {

    };

    static BindType _GT(Type t)
    {
        return new BindType(t);
    }

    static DelegateType _DT(Type t)
    {
        return new DelegateType(t);
    }
#endif
}

﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public static class LuaBinder
{

    public static void Bind(LuaState L)
    {
        //var time = Time.realtimeSinceStartup;
        L.BeginModule(null);

        CustomWrap.MyRegister(L);

        DownloadResourcesWrap.Register(L);
        //ProtocalWrap.Register(L);
        //UIRectWrap.Register(L);
        //UIWidgetWrap.Register(L);
        //UILabelWrap.Register(L);
        //UISpriteWrap.Register(L);
        //UIAnchorWrap.Register(L);
        //UITextureWrap.Register(L);
        //UISliderWrap.Register(L);
        //QLogWrap.Register(L);
        //UIBasicSpriteWrap.Register(L);
        //UpdateResWrap.Register(L);
        //UIPanelWrap.Register(L);
        //UIProgressBarWrap.Register(L);
        //UIEventListenerWrap.Register(L);
        //UIDepthHelperWrap.Register(L);
        //JoystickInputWrap.Register(L);
        //UIFontWrap.Register(L);
        //UploadFileWrap.Register(L);
        //UILabelSDFExtWrap.Register(L);
        //UIButtonWrap.Register(L);
        //NGUIToolsWrap.Register(L);
        //UIRootWrap.Register(L);
        //UIInputWrap.Register(L);
        //UIOrthoCameraWrap.Register(L);
        //UISpriteAnimationWrap.Register(L);
        //UISpriteDataWrap.Register(L);
        //UITextListWrap.Register(L);
        //UIViewportWrap.Register(L);
        //UIPolygonWrap.Register(L);
        //UIPolygon2Wrap.Register(L);
        //UIDrawCallWrap.Register(L);
        //UILineWrap.Register(L);
        //UICameraWrap.Register(L);
        //TweenAlphaWrap.Register(L);
        //TweenColorWrap.Register(L);
        //UITweenerWrap.Register(L);
        //TweenFOVWrap.Register(L);
        //TweenHeightWrap.Register(L);
        //TweenOrthoSizeWrap.Register(L);
        //TweenPositionWrap.Register(L);
        //TweenRotationWrap.Register(L);
        //TweenScaleWrap.Register(L);
        //TweenTransformWrap.Register(L);
        //TweenVolumeWrap.Register(L);
        //TweenWidthWrap.Register(L);
        //TweenLettersWrap.Register(L);
        //RealMarkerWrap.Register(L);
        //RealMarkerDataWrap.Register(L);
        //RealSingleDataWrap.Register(L);
        //SingleDataPairWrap.Register(L);
        //KeyDataWrap.Register(L);
        //UIWidgetContainerWrap.Register(L);
        //UIDragScrollViewWrap.Register(L);
        //UIEventTriggerWrap.Register(L);
        //UIPlayTweenWrap.Register(L);
        //UIScrollViewWrap.Register(L);
        //UIRichlabelWrap.Register(L);
        //UIScrollViewSystemWrap.Register(L);
        //ExUIButtonWrap.Register(L);
        //UIExFrameASpriteWrap.Register(L);
        //NGUIMathWrap.Register(L);
        //UIHelperWrap.Register(L);
        //UIEraserWrap.Register(L);
        //UIProfilerWrap.Register(L);
        //WindowMarkerWrap.Register(L);
        //GameUIPanelBaseWrap.Register(L);
        //HUDTextWrap.Register(L);
        //BlurScreenWrap.Register(L);
        UtilWrap.Register(L);
        //NetManagerWrap.Register(L);
        //GameUIManagerWrap.Register(L);
        //UIResourceManagerWrap.Register(L);
        //XDeviceWrap.Register(L);
        //ModelDataWrap.Register(L);
        //ModelDataManagerWrap.Register(L);
        //FxStickModeWrap.Register(L);
        //HardWareQualityWrap.Register(L);
        //ModelRotateHelpWrap.Register(L);
        //MonoHelperWrap.Register(L);
        //HttpManagerWrap.Register(L);
        //GameSceneManagerWrap.Register(L);
        //AttachFxBuildInfoWrap.Register(L);
        //AttachedFXWrap.Register(L);
        //CSceneFxManagerWrap.Register(L);
        //FxManagerWrap.Register(L);
        //SceneFxBuildInfoWrap.Register(L);
        //SceneFxWrap.Register(L);
        //VisualPropertyInfoWrap.Register(L);
        //TerrainHelperWrap.Register(L);
        //PoolManagerWrap.Register(L);
        //ShaderManagerWrap.Register(L);
        //CharacterShadowWrap.Register(L);
        //SyncResLoaderWrap.Register(L);
        //InputEventManagerWrap.Register(L);
        //AvatarManagerWrap.Register(L);
        //MyAvatarWrap.Register(L);
        //ImageEffectManagerWrap.Register(L);
        //MapInstanceWrap.Register(L);
        //AoiWrap.Register(L);
        //CommonConstWrap.Register(L);
        //CommonFlagWrap.Register(L);
        //BlinkObjectCustomFrameWrap.Register(L);
        //TransitionKitWrap.Register(L);
        //Scene2DEffectManagerWrap.Register(L);
        //SceneEnvironmentCtrlWrap.Register(L);
        //SceneRenderSettingsWrap.Register(L);
        //ProjectionSelfShadowMapWrap.Register(L);
        //GrassRendererFeatureWrap.Register(L);
        //TraceGenerateRendererFeatureWrap.Register(L);
        //FurRendererFeatureWrap.Register(L);
        //OffScreenParticleFeatureWrap.Register(L);
        //NoticePushWrap.Register(L);
        //ImagePickerWrap.Register(L);
        //WXVoiceHelperWrap.Register(L);
        //SoundRecorderWrap.Register(L);
        IflytekVoiceHelperWrap.Register(L);
        //HeartbeatThreadWrap.Register(L);
        //UIFollowTargetWrap.Register(L);
        //StatHelperWrap.Register(L);
        PlatformSDKWrap.Register(L);
        //LevelZipManagerWrap.Register(L);
        //UILoadPanelWrap.Register(L);
        //soundManagerWrap.Register(L);
        //SoundPlayerWrap.Register(L);
        //CameraFacingBillboardWrap.Register(L);
        //UIAtlasWrap.Register(L);
        //AsyncResLoaderWrap.Register(L);
        //DynamicBoneWrap.Register(L);
        //DynamicBoneInfoWrap.Register(L);
        //DynamicBoneControllerInfoWrap.Register(L);
        //DynamicBoneManagerWrap.Register(L);
        //HeadLookControllerWrap.Register(L);
        //CinemaDirectorMgrWrap.Register(L);
        //CSSleepManagerWrap.Register(L);
        //ScrollUVHelperWrap.Register(L);
        //TimelineHelperWrap.Register(L);
        //TLEventProxyWrap.Register(L);
        //SceneRealtimeShadowWrap.Register(L);
        //GrabPassHelperWrap.Register(L);
        //SceneBloomOptimizedWrap.Register(L);
        //UniWebViewUtilWrap.Register(L);
        //SpineLoaderWrap.Register(L);
        //PostProcessManagerWrap.Register(L);
        //CustomRendererFeatureWrap.Register(L);
        //RenderPipelineAssetSettingWrap.Register(L);
        //TRTCHelperWrap.Register(L);
        //WeatherHelperWrap.Register(L);
        //Singleton_NetManagerWrap.Register(L);
        //Singleton_XDeviceWrap.Register(L);
        //Singleton_ModelDataManagerWrap.Register(L);
        //Singleton_GameSceneManagerWrap.Register(L);
        //Singleton_CSceneFxManagerWrap.Register(L);
        //Singleton_FxManagerWrap.Register(L);
        //Singleton_PoolManagerWrap.Register(L);
        //Singleton_ShaderManagerWrap.Register(L);
        //Singleton_InputEventManagerWrap.Register(L);
        //Singleton_AvatarManagerWrap.Register(L);
        //Singleton_MapInstanceWrap.Register(L);
        //Singleton_AoiWrap.Register(L);
        //Singleton_Scene2DEffectManagerWrap.Register(L);
        //Singleton_ImagePickerWrap.Register(L);
        //Singleton_WXVoiceHelperWrap.Register(L);
        //Singleton_SoundRecorderWrap.Register(L);
        Singleton_IflytekVoiceHelperWrap.Register(L);
        //Singleton_HeartbeatThreadWrap.Register(L);
        //Singleton_CookieManagerSpace_CookieManagerWrap.Register(L);
        Singleton_PlatformSDKWrap.Register(L);
        //Singleton_LevelZipManagerWrap.Register(L);
        //Singleton_soundManagerWrap.Register(L);
        //Singleton_SoundPlayerWrap.Register(L);
        //Singleton_WeatherHelperWrap.Register(L);

        L.BeginModule("TMPro");
        TMPro_TMP_TextWrap.Register(L);
        TMPro_TMP_DropdownWrap.Register(L);
        TMPro_TMP_Dropdown_OptionDataWrap.Register(L);
        TMPro_TMP_Dropdown_OptionDataListWrap.Register(L);
        TMPro_TextMeshProUGUIWrap.Register(L);
        L.EndModule();



        L.BeginModule("UnityEngine");

        L.BeginModule("Events");
        UnityEngine_Events_UnityEventWrap.Register(L);
        L.EndModule();
        L.BeginModule("EventSystems");
        UnityEngine_EventSystems_BaseEventDataWrap.Register(L);
        UnityEngine_EventSystems_EventTriggerWrap.Register(L);
        L.BeginModule("EventTrigger");
        UnityEngine_EventSystems_EventTrigger_EntryWrap.Register(L);
        L.EndModule();
        L.EndModule();


        L.BeginModule("UI");
        UnityEngine_UI_ImageWrap.Register(L);
        UnityEngine_UI_ButtonWrap.Register(L);
        L.BeginModule("Button");
        UnityEngine_UI_Button_ButtonClickedEventWrap.Register(L);
        L.EndModule();
        UnityEngine_UI_SelectableWrap.Register(L);
        L.EndModule();

        UnityEngine_BehaviourWrap.Register(L);
        UnityEngine_MonoBehaviourWrap.Register(L);
        UnityEngine_ComponentWrap.Register(L);
        UnityEngine_Texture2DWrap.Register(L);
        UnityEngine_GameObjectWrap.Register(L);
        UnityEngine_TransformWrap.Register(L);
        UnityEngine_RectTransformWrap.Register(L);
        UnityEngine_MeshFilterWrap.Register(L);
        UnityEngine_TimeWrap.Register(L);
        UnityEngine_InputWrap.Register(L);
        UnityEngine_SystemInfoWrap.Register(L);
        UnityEngine_ResourcesWrap.Register(L);
        UnityEngine_TextAssetWrap.Register(L);
        UnityEngine_GraphicsWrap.Register(L);
        UnityEngine_MeshWrap.Register(L);
        UnityEngine_RenderTextureWrap.Register(L);
        UnityEngine_ApplicationWrap.Register(L);
        UnityEngine_KeyframeWrap.Register(L);
        UnityEngine_AnimationCurveWrap.Register(L);
        UnityEngine_RenderSettingsWrap.Register(L);
        UnityEngine_QualitySettingsWrap.Register(L);
        UnityEngine_LightWrap.Register(L);
        UnityEngine_LightBakingOutputWrap.Register(L);
        UnityEngine_PhysicsWrap.Register(L);
        UnityEngine_RigidbodyWrap.Register(L);
        UnityEngine_AnimationWrap.Register(L);
        UnityEngine_LineRendererWrap.Register(L);
        UnityEngine_AudioSourceWrap.Register(L);
        UnityEngine_AudioClipWrap.Register(L);
        UnityEngine_PlayerPrefsWrap.Register(L);
        UnityEngine_GradientWrap.Register(L);
        UnityEngine_GradientColorKeyWrap.Register(L);
        UnityEngine_GradientAlphaKeyWrap.Register(L);
        UnityEngine_MeshColliderWrap.Register(L);
        UnityEngine_SphereColliderWrap.Register(L);
        UnityEngine_CapsuleColliderWrap.Register(L);
        UnityEngine_CameraWrap.Register(L);
        UnityEngine_FontWrap.Register(L);
        UnityEngine_AnimationClipWrap.Register(L);
        UnityEngine_AnimatorWrap.Register(L);
        UnityEngine_RuntimeAnimatorControllerWrap.Register(L);
        UnityEngine_AnimatorOverrideControllerWrap.Register(L);
        UnityEngine_AnimatorStateInfoWrap.Register(L);
        UnityEngine_ScreenCaptureWrap.Register(L);
        UnityEngine_AssetBundleWrap.Register(L);
        UnityEngine_LocationServiceWrap.Register(L);
        UnityEngine_ScreenWrap.Register(L);
        UnityEngine_ShaderWrap.Register(L);
        UnityEngine_MaterialWrap.Register(L);
        UnityEngine_ColliderWrap.Register(L);
        UnityEngine_BoxColliderWrap.Register(L);
        UnityEngine_TerrainColliderWrap.Register(L);
        UnityEngine_TextureWrap.Register(L);
        UnityEngine_CubemapWrap.Register(L);
        UnityEngine_Matrix4x4Wrap.Register(L);
        //UnityEngine_RendererWrap.Register(L);
        UnityEngine_SkinnedMeshRendererWrap.Register(L);
        UnityEngine_MeshRendererWrap.Register(L);
        UnityEngine_ParticleSystemRendererWrap.Register(L);
        UnityEngine_ParticleSystemWrap.Register(L);
        UnityEngine_FlareLayerWrap.Register(L);
        UnityEngine_RectWrap.Register(L);
        UnityEngine_MaterialPropertyBlockWrap.Register(L);
        UnityEngine_AudioBehaviourWrap.Register(L);
        UnityEngine_ScriptableObjectWrap.Register(L);
        L.EndModule();
        //L.BeginModule("Profiling");
        //UnityEngine_Profiling_ProfilerWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("Rendering");
        //UnityEngine_Rendering_VolumeWrap.Register(L);
        //UnityEngine_Rendering_VolumeManagerWrap.Register(L);
        //UnityEngine_Rendering_VolumeProfileWrap.Register(L);
        //UnityEngine_Rendering_ClampedFloatParameterWrap.Register(L);
        //UnityEngine_Rendering_ColorParameterWrap.Register(L);
        //UnityEngine_Rendering_BoolParameterWrap.Register(L);
        //UnityEngine_Rendering_ClampedIntParameterWrap.Register(L);
        //UnityEngine_Rendering_MinFloatParameterWrap.Register(L);
        //UnityEngine_Rendering_TextureParameterWrap.Register(L);
        //UnityEngine_Rendering_CommandBufferWrap.Register(L);
        //UnityEngine_Rendering_VolumeComponentWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("Universal");
        //UnityEngine_Rendering_Universal_TonemappingWrap.Register(L);
        //UnityEngine_Rendering_Universal_BloomWrap.Register(L);
        //UnityEngine_Rendering_Universal_ColorAdjustmentsWrap.Register(L);
        //UnityEngine_Rendering_Universal_RadialBlurWrap.Register(L);
        //UnityEngine_Rendering_Universal_DepthOfFieldWrap.Register(L);
        //UnityEngine_Rendering_Universal_ColorLookupWrap.Register(L);
        //UnityEngine_Rendering_Universal_VignetteWrap.Register(L);
        //UnityEngine_Rendering_Universal_ChromaticAberrationWrap.Register(L);
        //UnityEngine_Rendering_Universal_ScreenWaterWaveWrap.Register(L);
        //UnityEngine_Rendering_Universal_CameraExtensionsWrap.Register(L);
        //UnityEngine_Rendering_Universal_UniversalAdditionalCameraDataWrap.Register(L);
        //UnityEngine_Rendering_Universal_PlanarReflectionsWrap.Register(L);
        //UnityEngine_Rendering_Universal_UniversalRenderPipelineAssetWrap.Register(L);
        //UnityEngine_Rendering_Universal_ScriptableRendererFeatureWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("PlanarReflections");
        //UnityEngine_Rendering_Universal_PlanarReflections_PlanarReflectionSettingsWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("AI");
        //UnityEngine_AI_NavMeshAgentWrap.Register(L);
        //UnityEngine_AI_NavMeshHitWrap.Register(L);
        //UnityEngine_AI_NavMeshWrap.Register(L);
        //UnityEngine_AI_NavMeshPathWrap.Register(L);
        //UnityEngine_AI_NavMeshTriangulationWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("SceneManagement");
        //UnityEngine_SceneManagement_SceneManagerWrap.Register(L);
        //UnityEngine_SceneManagement_SceneWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("Playables");
        //UnityEngine_Playables_PlayableAssetWrap.Register(L);
        //UnityEngine_Playables_PlayableDirectorWrap.Register(L);
        //UnityEngine_Playables_PlayableBindingWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("Timeline");
        //UnityEngine_Timeline_TimelineAssetWrap.Register(L);
        //UnityEngine_Timeline_AnimationTrackWrap.Register(L);
        //UnityEngine_Timeline_TimelineClipWrap.Register(L);
        //UnityEngine_Timeline_AnimationPlayableAssetWrap.Register(L);
        //UnityEngine_Timeline_ActivationTrackWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("TimelineAsset");
        //UnityEngine_Timeline_TimelineAsset_EditorSettingsWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("CookieManagerSpace");
        //CookieManagerSpace_CookieManagerWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("StatManager");
        //StatManager_PerformanceModuleWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("CinemaDirector");
        //CinemaDirector_SetParentWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("Cinemachine");
        //Cinemachine_CinemachineDollyCartWrap.Register(L);
        //Cinemachine_CinemachineSmoothPathWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("Spine");
        //Spine_SkeletonWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("Unity");
        //Spine_Unity_SkeletonAnimationWrap.Register(L);
        //Spine_Unity_SkeletonRendererWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("UIRect");
        //UIRect_AnchorPointWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("UICamera");
        //UICamera_MouseOrTouchWrap.Register(L);
        //UICamera_TouchWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("TweenLetters");
        //TweenLetters_AnimationPropertiesWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("UIProfiler");
        //UIProfiler_ProfilerInfoWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("WindowMarker");
        //WindowMarker_WindowRankInfoWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("UIResourceManager");
        //UIResourceManager_LoadingDynamicTemplateWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("HardWareQuality");
        //HardWareQuality_QualityInfoWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("SceneRenderSettings");
        //SceneRenderSettings_SkyboxSettingWrap.Register(L);
        //SceneRenderSettings_TimeRenderInfoWrap.Register(L);
        //SceneRenderSettings_LightInfoWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("FurRendererFeature");
        //FurRendererFeature_PassSettingsWrap.Register(L);
        //L.EndModule();
        //L.BeginModule("soundManager");
        //soundManager_ClipDataWrap.Register(L);
        //L.EndModule();
        L.EndModule();
        //QLog.Log("注册LUA耗时：" + (Time.realtimeSinceStartup - time));
    }

}

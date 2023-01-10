using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using System.IO;
using UnityEngine.Video;
#if DEV_BRANCH
#else
using System.Text;
//using BindType = ToLuaMenu.BindType;
#endif

public static class CustomSettings
{
    public static string mLuaPath
    {
        get
        {
            string LuaPath = string.Empty;
#if !DEV_BRANCH

            if (Directory.Exists(Application.dataPath + "/../3dscripts/lua_source"))
            {
                LuaPath = Application.dataPath + "/../3dscripts/lua_source/";
                return LuaPath;
            }
#endif
            return LuaPath;
        }
        set
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
    public static string injectionFilesPath = Application.dataPath + "/ToLua/Injection/";

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
        //_DT(typeof(Action)),
        //_DT(typeof(Action<GameObject>)).SetAbrName("ActionGo"),
        //_DT(typeof(UnityEngine.Events.UnityAction)),       
        
    };

    public static List<Type> notReGenerateList = new List<Type>()
    {

    };

    //在这里添加你要导出注册到lua的类型列表
    //public static BindType[] customTypeList =
    //{                
    //    // 游戏启动时，优先注册的luawrap类
    //    _GT(typeof(GameObject)),
    //    _GT(typeof(Transform)),

    //    _GT(typeof(Behaviour)),

    //    _GT(typeof(MonoBehaviour)),

    //    _GT(typeof(Component)),
    //    _GT(typeof(Texture2D)),
    //    _GT( typeof(Texture)),


    //    _GT(typeof(Time)),
    //    _GT(typeof(SystemInfo)),
    //    _GT(typeof(Component)),

    //    _GT(typeof(RenderTexture)),
    //    _GT(typeof(Application)),
    //    _GT(typeof(Keyframe)),
    //    _GT(typeof(AnimationCurve)),
    //    _GT(typeof(RenderSettings)),
    //    _GT(typeof(QualitySettings)),
    //    _GT(typeof(LightType)),
    //    _GT(typeof(Light)),
    //    _GT(typeof(RaycastHit)),
    //    _GT(typeof(Rigidbody)),
    //    _GT(typeof(Space)),
    //    _GT(typeof(Animation)),
    //    _GT(typeof(AnimationClip)),
    //    _GT(typeof(Animator)),
    //    _GT(typeof(RuntimeAnimatorController)),
    //    _GT(typeof(MeshFilter)),


    //    _GT(typeof(WrapMode)),



    //   //Scene
    //    _GT(typeof(SkinQuality)),

    //   _GT(typeof(Screen)),

    //   _GT(typeof(AudioSource)),
    //   _GT(typeof(AudioClip)),



    //    _GT( typeof(Shader) ),
    //    _GT( typeof(Material) ),
    //    _GT( typeof(Collider) ),
    //    _GT( typeof(BoxCollider) ),


    //    _GT( typeof(Matrix4x4) ),
    //    _GT( typeof(Renderer) ),
    //    _GT( typeof(MeshRenderer) ),



    //     _GT(typeof(Rect)),


    //     _GT(typeof(KeyCode)),

    //     _GT(typeof(VideoPlayer)),
    //     _GT(typeof(MeshCollider)),
    //     _GT(typeof(ParticleSystem)),
    //};

    public static List<Type> dynamicList = new List<Type>()
    {        
        
    };
    //重载函数，相同参数个数，相同位置out参数匹配出问题时, 需要强制匹配解决
    //使用方法参见例子14
    public static List<Type> outList = new List<Type>()
    {
        
    };

    //static BindType _GT(Type t)
    //{
    //    return new BindType(t);
    //}  
#endif
}

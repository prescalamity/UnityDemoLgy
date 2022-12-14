//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_UI_ImageWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Image), typeof(UnityEngine.MonoBehaviour), "Image");
		L.RegFunction("DisableSpriteOptimizations", DisableSpriteOptimizations);
		L.RegFunction("OnBeforeSerialize", OnBeforeSerialize);
		L.RegFunction("OnAfterDeserialize", OnAfterDeserialize);
		L.RegFunction("SetNativeSize", SetNativeSize);
		L.RegFunction("CalculateLayoutInputHorizontal", CalculateLayoutInputHorizontal);
		L.RegFunction("CalculateLayoutInputVertical", CalculateLayoutInputVertical);
		L.RegFunction("IsRaycastLocationValid", IsRaycastLocationValid);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("sprite", get_sprite, set_sprite);
		L.RegVar("overrideSprite", get_overrideSprite, set_overrideSprite);
		L.RegVar("type", get_type, set_type);
		L.RegVar("preserveAspect", get_preserveAspect, set_preserveAspect);
		L.RegVar("fillCenter", get_fillCenter, set_fillCenter);
		L.RegVar("fillMethod", get_fillMethod, set_fillMethod);
		L.RegVar("fillAmount", get_fillAmount, set_fillAmount);
		L.RegVar("fillClockwise", get_fillClockwise, set_fillClockwise);
		L.RegVar("fillOrigin", get_fillOrigin, set_fillOrigin);
		L.RegVar("alphaHitTestMinimumThreshold", get_alphaHitTestMinimumThreshold, set_alphaHitTestMinimumThreshold);
		L.RegVar("useSpriteMesh", get_useSpriteMesh, set_useSpriteMesh);
		L.RegVar("defaultETC1GraphicMaterial", get_defaultETC1GraphicMaterial, null);
		L.RegVar("mainTexture", get_mainTexture, null);
		L.RegVar("hasBorder", get_hasBorder, null);
		L.RegVar("pixelsPerUnitMultiplier", get_pixelsPerUnitMultiplier, set_pixelsPerUnitMultiplier);
		L.RegVar("pixelsPerUnit", get_pixelsPerUnit, null);
		L.RegVar("material", get_material, set_material);
		L.RegVar("minWidth", get_minWidth, null);
		L.RegVar("preferredWidth", get_preferredWidth, null);
		L.RegVar("flexibleWidth", get_flexibleWidth, null);
		L.RegVar("minHeight", get_minHeight, null);
		L.RegVar("preferredHeight", get_preferredHeight, null);
		L.RegVar("flexibleHeight", get_flexibleHeight, null);
		L.RegVar("layoutPriority", get_layoutPriority, null);
		L.RegFunction("GetClassType", GetClassType);
		L.EndClass();
	}

	static Type classType = typeof(UnityEngine.UI.Image);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DisableSpriteOptimizations(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
			obj.DisableSpriteOptimizations();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBeforeSerialize(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
			obj.OnBeforeSerialize();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnAfterDeserialize(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
			obj.OnAfterDeserialize();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetNativeSize(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
			obj.SetNativeSize();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateLayoutInputHorizontal(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
			obj.CalculateLayoutInputHorizontal();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateLayoutInputVertical(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
			obj.CalculateLayoutInputVertical();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsRaycastLocationValid(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)ToLua.CheckObject(L, 1, typeof(UnityEngine.UI.Image));
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			UnityEngine.Camera arg1 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.Camera));
			bool o = obj.IsRaycastLocationValid(arg0, arg1);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);

		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sprite(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.sprite");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.Sprite ret = obj.sprite;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sprite on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_overrideSprite(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.overrideSprite");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.Sprite ret = obj.overrideSprite;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index overrideSprite on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_type(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.type");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.UI.Image.Type ret = obj.type;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index type on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preserveAspect(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.preserveAspect");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool ret = obj.preserveAspect;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index preserveAspect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillCenter(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillCenter");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool ret = obj.fillCenter;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillCenter on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillMethod(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillMethod");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.UI.Image.FillMethod ret = obj.fillMethod;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillMethod on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillAmount(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillAmount");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.fillAmount;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillAmount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillClockwise(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillClockwise");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool ret = obj.fillClockwise;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillClockwise on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fillOrigin(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillOrigin");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			int ret = obj.fillOrigin;
			LuaDLL.lua_pushinteger(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillOrigin on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_alphaHitTestMinimumThreshold(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.alphaHitTestMinimumThreshold");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.alphaHitTestMinimumThreshold;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index alphaHitTestMinimumThreshold on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useSpriteMesh(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.useSpriteMesh");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool ret = obj.useSpriteMesh;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useSpriteMesh on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defaultETC1GraphicMaterial(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.UI.Image.defaultETC1GraphicMaterial);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.mainTexture");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.Texture ret = obj.mainTexture;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index mainTexture on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasBorder(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.hasBorder");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool ret = obj.hasBorder;
			LuaDLL.lua_pushboolean(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index hasBorder on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelsPerUnitMultiplier(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.pixelsPerUnitMultiplier");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.pixelsPerUnitMultiplier;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelsPerUnitMultiplier on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelsPerUnit(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.pixelsPerUnit");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.pixelsPerUnit;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelsPerUnit on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.material");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.Material ret = obj.material;
			ToLua.Push(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index material on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minWidth(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.minWidth");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.minWidth;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index minWidth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preferredWidth(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.preferredWidth");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.preferredWidth;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index preferredWidth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flexibleWidth(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.flexibleWidth");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.flexibleWidth;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index flexibleWidth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minHeight(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.minHeight");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.minHeight;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index minHeight on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preferredHeight(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.preferredHeight");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.preferredHeight;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index preferredHeight on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flexibleHeight(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.flexibleHeight");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float ret = obj.flexibleHeight;
			LuaDLL.lua_pushnumber(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index flexibleHeight on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layoutPriority(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.layoutPriority");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			int ret = obj.layoutPriority;
			LuaDLL.lua_pushinteger(L, ret);
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index layoutPriority on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sprite(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.sprite");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.Sprite arg0 = (UnityEngine.Sprite)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Sprite));
			obj.sprite = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sprite on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_overrideSprite(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.overrideSprite");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.Sprite arg0 = (UnityEngine.Sprite)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Sprite));
			obj.overrideSprite = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index overrideSprite on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_type(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.type");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.UI.Image.Type arg0 = (UnityEngine.UI.Image.Type)LuaDLL.luaL_checknumber(L, 2);
			obj.type = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index type on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_preserveAspect(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.preserveAspect");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.preserveAspect = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index preserveAspect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillCenter(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillCenter");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.fillCenter = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillCenter on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillMethod(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillMethod");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.UI.Image.FillMethod arg0 = (UnityEngine.UI.Image.FillMethod)LuaDLL.luaL_checknumber(L, 2);
			obj.fillMethod = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillMethod on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillAmount(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillAmount");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.fillAmount = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillAmount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillClockwise(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillClockwise");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.fillClockwise = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillClockwise on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fillOrigin(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.fillOrigin");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.fillOrigin = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fillOrigin on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_alphaHitTestMinimumThreshold(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.alphaHitTestMinimumThreshold");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.alphaHitTestMinimumThreshold = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index alphaHitTestMinimumThreshold on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useSpriteMesh(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.useSpriteMesh");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.useSpriteMesh = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index useSpriteMesh on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelsPerUnitMultiplier(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.pixelsPerUnitMultiplier");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.pixelsPerUnitMultiplier = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index pixelsPerUnitMultiplier on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		object o = null;

		try
		{
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.Begin("UnityEngine.UI.Image.material");
#endif
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Image obj = (UnityEngine.UI.Image)o;
			UnityEngine.Material arg0 = (UnityEngine.Material)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Material));
			obj.material = arg0;
#if ENABLE_PROFILER || UNITY_EDITOR || UNITY_STANDALONE_WIN
			//UIProfiler.End();
#endif
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index material on a nil value" : e.Message);
		}
	}
}


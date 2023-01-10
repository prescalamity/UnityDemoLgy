﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;
using UnityEngine.EventSystems;

public class UnityEngine_EventSystems_EventTriggerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.EventSystems.EventTrigger), typeof(UnityEngine.MonoBehaviour), "EventTrigger");
		L.RegFunction("OnPointerEnter", OnPointerEnter);
		L.RegFunction("OnPointerExit", OnPointerExit);
		L.RegFunction("OnDrag", OnDrag);
		L.RegFunction("OnDrop", OnDrop);
		L.RegFunction("OnPointerDown", OnPointerDown);
		L.RegFunction("OnPointerUp", OnPointerUp);
		L.RegFunction("OnPointerClick", OnPointerClick);
		L.RegFunction("OnSelect", OnSelect);
		L.RegFunction("OnDeselect", OnDeselect);
		L.RegFunction("OnScroll", OnScroll);
		L.RegFunction("OnMove", OnMove);
		L.RegFunction("OnUpdateSelected", OnUpdateSelected);
		L.RegFunction("OnInitializePotentialDrag", OnInitializePotentialDrag);
		L.RegFunction("OnBeginDrag", OnBeginDrag);
		L.RegFunction("OnEndDrag", OnEndDrag);
		L.RegFunction("OnSubmit", OnSubmit);
		L.RegFunction("OnCancel", OnCancel);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("triggers", get_triggers, set_triggers);
		L.RegFunction("GetClassType", GetClassType);

		L.RegFunction("AddListener", AddListener);

		L.EndClass();
	}

	
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);

			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));

			EventTrigger.Entry entryBtn = new EventTrigger.Entry();

			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			entryBtn.eventID = (EventTriggerType)arg0;

			UnityEngine.Events.UnityAction<BaseEventData> arg1 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 3);
			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				arg1 = (UnityEngine.Events.UnityAction<BaseEventData>)ToLua.CheckObject(L, 3, typeof(UnityEngine.Events.UnityAction<BaseEventData>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				arg1 = DelegateFactory.CreateDelegate(typeof(UnityEngine.Events.UnityAction<BaseEventData>), func) as UnityEngine.Events.UnityAction<BaseEventData>;
			}

			entryBtn.callback.AddListener(arg1);

			obj.triggers.Add(entryBtn);

			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}


	static Type classType = typeof(UnityEngine.EventSystems.EventTrigger);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		ToLua.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerEnter(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnPointerEnter(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerExit(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnPointerExit(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDrag(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnDrag(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDrop(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnDrop(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnPointerDown(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnPointerUp(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerClick(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnPointerClick(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSelect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));
			obj.OnSelect(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDeselect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));
			obj.OnDeselect(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnScroll(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnScroll(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnMove(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.AxisEventData arg0 = (UnityEngine.EventSystems.AxisEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.AxisEventData));
			obj.OnMove(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnUpdateSelected(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));
			obj.OnUpdateSelected(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnInitializePotentialDrag(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnInitializePotentialDrag(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBeginDrag(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnBeginDrag(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnEndDrag(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
			obj.OnEndDrag(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSubmit(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));
			obj.OnSubmit(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnCancel(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)ToLua.CheckObject(L, 1, typeof(UnityEngine.EventSystems.EventTrigger));
			UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)ToLua.CheckObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));
			obj.OnCancel(arg0);
			return 0;
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
	static int get_triggers(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)o;
			System.Collections.Generic.List<UnityEngine.EventSystems.EventTrigger.Entry> ret = obj.triggers;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index triggers on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_triggers(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.EventSystems.EventTrigger obj = (UnityEngine.EventSystems.EventTrigger)o;
			System.Collections.Generic.List<UnityEngine.EventSystems.EventTrigger.Entry> arg0 = (System.Collections.Generic.List<UnityEngine.EventSystems.EventTrigger.Entry>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.EventSystems.EventTrigger.Entry>));
			obj.triggers = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index triggers on a nil value" : e.Message);
		}
	}
}

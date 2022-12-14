using System;
using LuaInterface;

public class LuaInterface_EventObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaInterface.EventObject), typeof(System.Object), "EventObject");
		L.RegFunction("New", _CreateLuaInterface_EventObject);
		L.RegFunction("__add", op_Addition);
		L.RegFunction("__sub", op_Subtraction);
		L.RegFunction("__tostring", Lua_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaInterface_EventObject(IntPtr L)
	{
		return LuaDLL.tolua_error(L, "LuaInterface.EventObject class does not have a constructor function");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Subtraction(IntPtr L)
	{
        try
        {
            LuaInterface.EventObject arg0 = (LuaInterface.EventObject)ToLua.CheckObject(L, 1, typeof(LuaInterface.EventObject));
            arg0.func = ToLua.CheckLuaFunction(L, 2);
            arg0.op = EventOp.Sub;
            ToLua.Push(L, arg0);
            return 1;
        }
        catch (Exception e)
        {
            return LuaDLL.toluaL_exception(L, e);
        }
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Addition(IntPtr L)
	{
        try
        {
            LuaInterface.EventObject arg0 = (LuaInterface.EventObject)ToLua.CheckObject(L, 1, typeof(LuaInterface.EventObject));
            arg0.func = ToLua.CheckLuaFunction(L, 2);
            arg0.op = EventOp.Add;
            ToLua.Push(L, arg0);
            return 1;
        }
        catch (Exception e)
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
}


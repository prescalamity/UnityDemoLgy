/*
Copyright (c) 2015-2016 topameng(topameng@qq.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using UnityEngine;

namespace LuaInterface
{
    public static class TypeChecker
    {
        public static bool IsValueType(Type t)
        {
            return !t.IsEnum && t.IsValueType;
        }


        public static bool CheckTypes(IntPtr L, int begin, Type type0)
        {
            return CheckType(L, type0, begin);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9) && CheckType(L, type10, begin + 10);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9) && CheckType(L, type10, begin + 10) && CheckType(L, type11, begin + 11);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11, Type type12)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9) && CheckType(L, type10, begin + 10) && CheckType(L, type11, begin + 11) && CheckType(L, type12, begin + 12);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11, Type type12, Type type13)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9) && CheckType(L, type10, begin + 10) && CheckType(L, type11, begin + 11) && CheckType(L, type12, begin + 12) && CheckType(L, type13, begin + 13);
        }

        public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9, Type type10, Type type11, Type type12, Type type13, Type type14)
        {
            return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
                   CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9) && CheckType(L, type10, begin + 10) && CheckType(L, type11, begin + 11) && CheckType(L, type12, begin + 12) && CheckType(L, type13, begin + 13) && CheckType(L, type14, begin + 14);
        }


        public static bool CheckTypes(IntPtr L, params Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (!CheckType(L, types[i], i + 1))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckParamsType(IntPtr L, Type t, int begin, int count)
        {
            if (t == typeof(object))
            {
                return true;
            }

            for (int i = 0; i < count; i++)
            {
                if (!CheckType(L, t, i + begin))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckType(IntPtr L, Type t, int pos)
        {
         
            if (t.IsEnum)
            {
                t = typeof (int);
            }
            //默认都可以转 object
            if (t == typeof(object))
            {
                return true;
            }

            LuaTypes luaType = LuaDLL.lua_type(L, pos);

            if (t == typeof (string) && luaType == LuaTypes.LUA_TNUMBER)
            {
                return true;
            }

            switch (luaType)
            {
                case LuaTypes.LUA_TNUMBER:
                    return t.IsPrimitive;
                case LuaTypes.LUA_TSTRING:
                    return t == typeof(string) || t == typeof(byte[]) || t == typeof(char[]);
                case LuaTypes.LUA_TUSERDATA:
                    return IsMatchUserData(L, t, pos);
                case LuaTypes.LUA_TBOOLEAN:
                    return t == typeof(bool);
                case LuaTypes.LUA_TFUNCTION:
                    return t == typeof(LuaFunction);                            
                case LuaTypes.LUA_TTABLE:
                    return lua_isusertable(L, t, pos);
                case LuaTypes.LUA_TLIGHTUSERDATA:
                    return t == typeof(IntPtr);
                case LuaTypes.LUA_TNIL:
                    return t == null || t.IsEnum || !t.IsValueType;
                default:
                    break;
            }

          Debugger.LuaLog(1, "undefined type to check" + LuaDLL.luaL_typename(L, pos));
            return false;
        }

        static bool IsMatchUserData(IntPtr L, Type t, int pos)
        {
            if (t == typeof(LuaInteger64))
            {
                return LuaDLL.tolua_isint64(L, pos);
            }

            object obj = null;
            int udata = LuaDLL.tolua_rawnetobj(L, pos);

            if (udata != -1)
            {
                ObjectTranslator translator = ObjectTranslator.Get(L);
                obj = translator.GetObject(udata);
                if (obj != null)
                {
                    Type objType = obj.GetType();

                    if (t == objType || t.IsAssignableFrom(objType))
                    {
                        return true;
                    }
                }
                else
                {
                    return !t.IsValueType;
                }
            }

            return false;
        }

        static bool lua_isusertable(IntPtr L, Type t, int pos)
        {
            if (t.IsArray)
            {
                return true;
            }
            else if (t == typeof(LuaTable))
            {
                return true;
            }
            else if (t.IsValueType)
            {
                LuaValueType vt = LuaDLL.tolua_getvaluetype(L, pos);

                switch (vt)
                {
                    case LuaValueType.Vector3:
                        return typeof(Vector3) == t;
                    case LuaValueType.Quaternion:
                        return typeof(Quaternion) == t;
                    case LuaValueType.Color:
                        return typeof(Color) == t;
                    case LuaValueType.Ray:
                        return typeof(Ray) == t;
                    case LuaValueType.Bounds:
                        return typeof(Bounds) == t;
                    case LuaValueType.Vector2:
                        return typeof(Vector2) == t;
                    case LuaValueType.Vector4:
                        return typeof(Vector4) == t;
                    case LuaValueType.Touch:
                        return typeof(Touch) == t;
                    case LuaValueType.LayerMask:
                        return typeof(LayerMask) == t;
                    case LuaValueType.RaycastHit:
                        return typeof(RaycastHit) == t;
                    default:
                        break;
                }
            }
            else if (LuaDLL.tolua_isvptrtable(L, pos))
            {
                return IsMatchUserData(L, t, pos);
            }

            return false;
        }
    }
}
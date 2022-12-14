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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace LuaInterface
{
    public static class LuaStatic
    {
        public static int GetMetaReference(IntPtr L, Type t)
        {
            LuaState state = LuaState.Get(L);
            return state.GetMetaReference(t);
        }

        public static int GetMissMetaReference(IntPtr L, Type t)
        {
            LuaState state = LuaState.Get(L);
            return state.GetMissMetaReference(t);
        }

        public static Type GetClassType(IntPtr L, int reference)
        {
            LuaState state = LuaState.Get(L);
            return state.GetClassType(reference);
        }

        public static LuaFunction GetFunction(IntPtr L, int reference)
        {
            LuaState state = LuaState.Get(L);
            return state.GetFunction(reference);
        }

        public static LuaTable GetTable(IntPtr L, int reference)
        {
            LuaState state = LuaState.Get(L);
            return state.GetTable(reference);
        }

        public static LuaThread GetLuaThread(IntPtr L, int reference)
        {
            LuaState state = LuaState.Get(L);
            return state.GetLuaThread(reference);
        }

        public static void GetUnpackRayRef(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            LuaDLL.lua_getref(L, state.UnpackRay);
        }

        public static void GetUnpackBounds(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            LuaDLL.lua_getref(L, state.UnpackBounds);
        }

        public static void GetPackRay(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            LuaDLL.lua_getref(L, state.PackRay);
        }

        public static void GetPackRaycastHit(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            LuaDLL.lua_getref(L, state.PackRaycastHit);
        }

        public static void GetPackTouch(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            LuaDLL.lua_getref(L, state.PackTouch);
        }

        public static void GetPackBounds(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            LuaDLL.lua_getref(L, state.PackBounds);
        }

        public static int GetOutMetatable(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            return state.OutMetatable;
        }

        public static int GetArrayMetatable(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            return state.ArrayMetatable;
        }

        public static int GetTypeMetatable(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            return state.TypeMetatable;
        }

        public static int GetDelegateMetatable(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            return state.DelegateMetatable;
        }

        public static int GetEventMetatable(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            return state.EventMetatable;
        }

        public static int GetIterMetatable(IntPtr L)
        {
            LuaState state = LuaState.Get(L);
            return state.IterMetatable;
        }

        public static int GetEnumObject(IntPtr L, System.Enum e, out object obj)
        {
            LuaState state = LuaState.Get(L);
            obj = state.GetEnumObj(e);
            return state.EnumMetatable;
        }

        public static LuaCSFunction GetPreModule(IntPtr L, Type t)
        {
            LuaState state = LuaState.Get(L);
            return state.GetPreModule(t);
        }

        static public void OpenLibs(IntPtr L)
        {
            LuaDLL.tolua_atpanic(L, Panic);
            //LuaDLL.tolua_pushcfunction(L, Print);
            //LuaDLL.lua_setglobal(L, "print");
            LuaDLL.tolua_pushcfunction(L, DoFile);
            LuaDLL.lua_setglobal(L, "dofile");

            AddLuaLoader(L);
        }

        static void AddLuaLoader(IntPtr L)
        {
            LuaDLL.lua_getglobal(L, "package");
            LuaDLL.lua_getfield(L, -1, "loaders");
            LuaDLL.tolua_pushcfunction(L, Loader);

            for (int i = LuaDLL.lua_objlen(L, -2) + 1; i > 2; i--)
            {
                LuaDLL.lua_rawgeti(L, -2, i - 1);
                LuaDLL.lua_rawseti(L, -3, i);
            }

            LuaDLL.lua_rawseti(L, -2, 2);
            LuaDLL.lua_settop(L, 0);
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int Panic(IntPtr L)
        {
            string reason = String.Format("PANIC: unprotected error in call to Lua API ({0})", LuaDLL.lua_tostring(L, -1));
            Debugger.LuaLog(1, reason);
            //throw new Exception(reason);
            return 0;
        }

        static string LuaWhere(IntPtr L)
        {
#if UNITY_EDITOR || DEVELOPER
            int top = LuaDLL.lua_gettop(L);
            LuaDLL.luaL_where(L, 1);
            string str = LuaDLL.lua_tostring(L, -1);
            LuaDLL.lua_settop(L, top);
            return str;
#else
            return string.Empty;
#endif
        }

        
        // 重写 lua 的 require
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int Loader(IntPtr L)
        {
            try
            {
                string fileName = LuaDLL.lua_tostring(L, 1);
                //ProfilerHelper.BeginSample("lua static load file :" + fileName);
                if (fileName.EndsWith(".lua"))
                {
                    fileName = fileName.Remove(fileName.Length - 4);
                }
                fileName = fileName.Replace(".", "/");
                if (!Path.HasExtension(fileName))
                {
                    fileName += ".lua";
                }

                //Debugger.Log("require {0}", fileName);

				IntPtr ptrFileBuff = IntPtr.Zero;
				int fileLen = 0;

                //byte[] buffer = LuaScriptMgr.GetInstance().Loader(fileName, out ptrFileBuff, out fileLen );

                Debug.Log("LuaStatic.Loader, You want to require file name is " + fileName);
                byte[] buffer = DelegateToPlugins.Instance.getLuaFileByteData(fileName);


                if ( ptrFileBuff != IntPtr.Zero )
				{
					int ret =  LuaDLL.luaL_loadBufferPtr(L, ptrFileBuff, fileLen, fileName);
					PackageAnalyser.FreeHGlobal(ptrFileBuff);
					ptrFileBuff = IntPtr.Zero;

					if ( ret != 0 )
					{
						Debugger.LogError("file {0} failed", fileName);
                        //ProfilerHelper.EndSample();
						return 0;
					}
                    //ProfilerHelper.EndSample();
					return 1;
				}

				if (buffer == null)
				{
                    Debug.Log("LuaStatic.Loader, buffer is null.");
                    //ProfilerHelper.EndSample();
                    return 0;
				}
				
				LuaDLL.luaL_loadbuffer(L, buffer, buffer.Length, fileName);

                //ProfilerHelper.EndSample();
				return 1;
            }
            catch (Exception e)
            {
                return LuaDLL.toluaL_exception(L, e);
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int DoFile(IntPtr L)
        {
            try
            {
                string fileName = LuaDLL.lua_tostring(L, 1);

                if (!Path.HasExtension(fileName))
                {
                    fileName += ".lua";
                }

                int n = LuaDLL.lua_gettop(L);
                byte[] text = LuaFileUtils.Instance.ReadFile(fileName);

                if (text == null)
                {
                    return 0;
                }

                if (LuaDLL.luaL_loadbuffer(L, text, text.Length, fileName) == 0)
                {
                    if (LuaDLL.lua_pcall(L, 0, LuaDLL.LUA_MULTRET, 0) != 0)
                    {
                        string error = LuaDLL.lua_tostring(L, -1);
                        throw new LuaException(error);
                    }
                }

                return LuaDLL.lua_gettop(L) - n;
            }
            catch (Exception e)
            {
                return LuaDLL.toluaL_exception(L, e);
            }
        }
    }
}
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
using System.Runtime.CompilerServices;
using UnityEngine;

namespace LuaInterface
{
    public class ObjectTranslator
    {
        private class DelayGC
        {
            public DelayGC(int id, float time)
            {
                this.id = id;
                this.time = time;
            }

            public int id;
            public float time;
        }

        private class CompareObject : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {
                return object.ReferenceEquals(x, y);                
            }

            public int GetHashCode(object obj)
            {
                if (obj != null)
                {
                   return RuntimeHelpers.GetHashCode(obj);  
                }

                return 0;
            }
        }

        public bool LogGC { get; set; }
        public readonly Dictionary<object, int> objectsBackMap = new Dictionary<object, int>(55000, new CompareObject());
       // public readonly static Hashtable objectsMap = new Hashtable(55000);
        public readonly LuaObjectPool objects = new LuaObjectPool();
        private List<DelayGC> gcList = new List<DelayGC>();
        private static ObjectTranslator _translator = null;

        public ObjectTranslator()
        {
            LogGC = false;

#if !MULTI_STATE
            _translator = this;
#endif
        }

        public int AddObject(object obj)
        {
            int index = objects.Add(obj);
          //  objectsMap[obj] = true;  

            if (openLuaNilDebug)
            {
                m_objectNameMap.Add(index, obj.ToString());
                string lua_stack_trace = LuaScriptMgr.GetInstance().InvokeLuaFunction<string, string>("traceback", "");
                traceList.Add(index, lua_stack_trace);   
            }

            if (!TypeChecker.IsValueType(obj.GetType()))
            {
                objectsBackMap[obj] = index;
            }

            return index;
        }

        public static ObjectTranslator Get(IntPtr L)
        {
#if !MULTI_STATE
                return _translator;
#else
                return LuaState.GetTranslator(L);
#endif
        }

        //完全移除一个对象，适合lua gc
        public void RemoveObject(int udata)
        {
            RemoveFromGCList(udata);
            object o = objects.Remove(udata);

			if (openLuaNilDebug)
			{
				if (m_objectNameMap.ContainsKey(udata))
				{
					m_objectNameMap.Remove(udata);
				}
				if (traceList.ContainsKey(udata))
				{
					traceList.Remove(udata);
				}
			}

            if (o != null)
            {
                //objectsMap.Remove(o);
                if (!TypeChecker.IsValueType(o.GetType()))
                {
                    objectsBackMap.Remove(o);
                }

                if (LogGC)
                {
                    Debugger.Log("remove object {0}, id {1}", o, udata);
                }
            }
        }

        public object GetObject(int udata)
        {
            return objects.TryGetValue(udata);         
        }

        //删除，但不移除一个lua对象
        public void Destroy(int udata)
        {
            RemoveFromGCList(udata);
            object o = objects.Destroy(udata);

			if (openLuaNilDebug)
			{
				if (m_objectNameMap.ContainsKey(udata))
				{
					m_objectNameMap.Remove(udata);
				}
				if (traceList.ContainsKey(udata))
				{
					traceList.Remove(udata);
				}
			}

            if (o != null)
            {
               // objectsMap.Remove(o);
                if (!TypeChecker.IsValueType(o.GetType()))
                {
                    objectsBackMap.Remove(o);
                }

                if (LogGC)
                {
                    Debugger.Log("destroy object {0}, id {1}", o, udata);
                }
            }
        }

        public void DelayDestroy(int id, float time)
        {
            gcList.Add(new DelayGC(id, time));
        }

        public bool Getudata(object o, out int index)
        {
            index = -1;
            return objectsBackMap.TryGetValue(o, out index);
        }

        public void SetBack(int index, object o)
        {
            object obj = objects.Replace(index, o);
            objectsBackMap.Remove(obj);
            if (!TypeChecker.IsValueType(o.GetType())) 
            {
                objectsBackMap[o] = index;
            }
        }

        void RemoveFromGCList(int id)
        {
            for (int i = gcList.Count - 1; i >= 0; --i )
            {
                if ( gcList[i].id == id  )
                {
                    gcList.RemoveAt(i);
                    return;
                }
               
            }
        }
        
        void DestroyUnityObject(int udata)
        {
            object o = objects.Destroy(udata);

            if (o != null)
            {                
                if (!TypeChecker.IsValueType(o.GetType()))
                {
                    objectsBackMap.Remove(o);
                }

                UnityEngine.Object obj = o as UnityEngine.Object;

                if (obj != null)
                {
                    UnityEngine.Object.Destroy(obj);
                }

                if (LogGC)
                {
                    Debugger.LogWarning("destroy object {0}, id {1}", o, udata);
                }
            }
        }

        public void Collect()
        {
            if (gcList.Count == 0)
            {
                return;
            }

            float delta = Time.deltaTime;

            for (int i = gcList.Count - 1; i >= 0; i--)
            {
                float time = gcList[i].time - delta;

                if (time <= 0)
                {
                    DestroyUnityObject(gcList[i].id);                    
                    gcList.RemoveAt(i);
                }
                else
                {
                    gcList[i].time = time;
                }
            }
        }

        public void Dispose()
        {
            objectsBackMap.Clear();
            objects.Clear();
           // objectsMap.Clear();
#if !MULTI_STATE
            _translator = null;
#endif
        }

        //public static bool objectIsExist(object o)
        //{
        //    //if (o == null || o.Equals(null) ) return false;
        //    //return  objectsMap.ContainsKey(o);
        //}


        /*
         * Gets the CLR object in the index positon of the Lua stack. Returns
         * delegates as is.
         */
        internal object getRawNetObject(IntPtr luaState, int index)
        {
            int udata = LuaDLL.tolua_rawnetobj(luaState, index);
            object obj = null;
            obj = objects.TryGetValue(udata);
            if (obj == null || obj.Equals(null)  ) obj = null;
            return obj;
        }

        public int GetObjCnt()
        {
            int cnt = objects.Count;
            cnt -= objects.GetIdleSpace();
            return cnt;
        }

        public int GetIdleSpace()
        {
           return  objects.GetIdleSpace();
        }

        public int GetNullObjCnt()
        {
            int cnt = 0;
            int objsCnt = objects.Count;
            for (int i = 0; i <= objsCnt; ++i)
            {
                object obj = objects[i];

                if (obj != null && !obj.Equals(null)) cnt++;
            }
            objsCnt -= cnt;
            objsCnt -= objects.GetIdleSpace();
            return objsCnt;
        }

//------------------------快照功能begin
		private static Dictionary<int, string> m_objectNameMap = null;
		private static Dictionary<int, string> traceList = null;
		private static bool openLuaNilDebug = false;

		public static void OpenLuaObjectStatistic()
		{
			m_objectNameMap = new Dictionary<int, string>();
			traceList = new Dictionary<int, string>();
			openLuaNilDebug = true;
		}

		public static string NormalizePath(string path)
		{
			if (!path.StartsWith("/"))
			{
				path = "/" + path;
			}
			return path.Replace("//", "/");
		}

		public static string GetWritablePath(string url)
		{
			System.Text.StringBuilder sbWritablePath = new System.Text.StringBuilder();

			//在windows和editor环境下使用自创建目录PersistentData
			sbWritablePath.Length = 0;
#if UNITY_EDITOR
			sbWritablePath.Append(LuaScriptMgr.m_streaming_assets_path);
			sbWritablePath.Append("/../../PersistentData/");
			sbWritablePath.Append(NormalizePath(url));
#elif UNITY_STANDALONE
	        sbWritablePath.Append(LuaScriptMgr.m_streaming_assets_path);
		    sbWritablePath.Append("/../PersistentData/");
			sbWritablePath.Append(NormalizePath(url));
#elif UNITY_IPHONE
	        sbWritablePath.Append(LuaScriptMgr.m_persistent_data_path);
		    sbWritablePath.Append("/../Library");
			sbWritablePath.Append(NormalizePath(url));
#else
	        sbWritablePath.Append(LuaScriptMgr.m_persistent_data_path);
		    sbWritablePath.Append("/");
			sbWritablePath.Append(NormalizePath(url));
#endif
			return sbWritablePath.ToString();
		}

		int counter = 0;
		public void PrintLuaObject()
		{
			if (!openLuaNilDebug)
			{
				return;
			}

			Debugger.Log("ObjectTranslator.PrintLuaObject objects.count[{0}]	objectsBackMap.Count[{1}]", objects.Count, objectsBackMap.Count);

			LuaScriptMgr.GetInstance().DoString("collectgarbage(\"collect\")");

			string path = GetWritablePath("snap" + counter++ + ".txt");

			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
			}

			int objsCnt = objects.Count;
			for (int i = 0; i <= objsCnt; ++i)
			{
				object obj = objects[i];
				if (null != obj)
				{
					string objName_current = obj.ToString();
					string objName_add = m_objectNameMap[i];
					string objTrace = traceList[i];
					objTrace = objTrace.Replace('\n', '|');

					//Debugger.Log("PrintLuaObject	id[{0}]	current_name[{1}]	add_name[{2}]	trace[{3}]", i, objName_current, objName_add, objTrace);
					System.IO.File.AppendAllText(path, string.Format("id[{0}]	current_name[{1}]	add_name[{2}]	trace[{3}]\n", i, objName_current, objName_add, objTrace));
				}
			}
		}

        public void PrintNullObjectName()
        {
            if (!openLuaNilDebug)
            {
                return;
            }

            Debugger.Log("PrintNullObjectName");
            LuaScriptMgr.GetInstance().DoString("collectgarbage(\"collect\")");
          
            //先做一次完整的gc，效果会更好
            int objsCnt = objects.Count;

            List<int> idleSpaceIndexList = objects.GetIdleSpaceIndexList();

            for (int i = 0; i <= objsCnt; ++i)
            {
                object obj = objects[i];
                int index = objects.GetIndex(i);
                if (obj != null && obj.Equals(null) && !idleSpaceIndexList.Contains(index) )
                {
                    Debugger.Log("lua_null_object   key[" + index + "]   name[ " + m_objectNameMap[index] + " ]  trace : " + traceList[index]);

                }
            }

            idleSpaceIndexList.Clear();
            idleSpaceIndexList = null;
        }
//------------------------快照功能end

        
    }
}
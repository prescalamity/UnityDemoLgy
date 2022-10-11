﻿/*
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
using System.Collections.Generic;

namespace LuaInterface
{
    public class LuaObjectPool
    {        
        class PoolNode
        {
            public int index;
            public object obj;

            public PoolNode(int index, object obj)
            {
                this.index = index;
                this.obj = obj;
            }
        }

        private List<PoolNode> list;
        //同lua_ref策略，0作为一个回收链表头，不使用这个位置
        private PoolNode head = null;   
        private int count = 0;

        public LuaObjectPool()
        {
            list = new List<PoolNode>(55000);
            head = new PoolNode(0, null);
            list.Add(head);
            list.Add(new PoolNode(1, null));
            count = list.Count;
        }

        public int GetIdleSpace()
        {
            int cnt = 2;
            int index = head.index;
            while( index != 0 )
            {
                ++cnt;
                index = list[index].index;
            }
            return cnt;
        }

        public List<int> GetIdleSpaceIndexList()
        {
            List<int> indexList = new List<int>();
            int index = head.index;
            while (index != 0)
            {
                indexList.Add(index);
                index = list[index].index;
            }
            return indexList;
        }

        public int GetIndex(int i)
        {
            if (i > 0 && i < count)
            {
                return list[i].index;
            }
            return 0;
        }

        public object this[int i]
        {
            get 
            {
                if (i > 0 && i < count)
                {
                    return list[i].obj;
                }

                return null;
            }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public void Clear()
        {
            list.Clear();
            head = null;
            count = 0;
        }

        public int Add(object obj)
        {
            int pos = -1;

            if (head.index != 0)
            {
                pos = head.index;
                list[pos].obj = obj;
                head.index = list[pos].index;
            }
            else
            {
                pos = list.Count;
                list.Add(new PoolNode(pos, obj));
                count = pos + 1;
            }

            return pos;
        }

        public object TryGetValue(int index)
        {
            if (index > 0 && index < count)
            {
                return list[index].obj;                
            }
            
            return false;
        }

        public object Remove(int pos)
        {
            if (pos > 0 && pos < count)
            {
                object o = list[pos].obj;
                list[pos].obj = null;                
                list[pos].index = head.index;
                head.index = pos;

                return o;
            }

            return null;
        }

        public object Destroy(int pos)
        {
            if (pos > 0 && pos < count)
            {
                object o = list[pos].obj;
                list[pos].obj = null;
                return o;
            }

            return null;
        }

        public object Replace(int pos, object o)
        {
            if (pos > 0 && pos < count)
            {
                object obj = list[pos].obj;
                list[pos].obj = o;
                return obj;
            }

            return null;
        }
    }
}
using System;
using LuaInterface;
using System.Runtime.InteropServices;


public struct LuaMethod
{
    public string name;
    public LuaCSFunction func;

    public LuaMethod(string str, LuaCSFunction f)
    {
        name = str;
        func = f;
    }
};

public struct LuaField
{
    public string name;
    public LuaCSFunction getter;
    public LuaCSFunction setter;

    public LuaField(string str, LuaCSFunction g, LuaCSFunction s)
    {
        name = str;
        getter = g;
        setter = s;        
    }
};

/*public struct LuaEnum
{
    public string name;
    public System.Enum val;

    public LuaEnum(string str, System.Enum v)
    {
        name = str;
        val = v;
    }
}*/


public interface ILuaWrap 
{
    void Register();
}



public class LuaByteBuffer
{
    public LuaByteBuffer(IntPtr source, int len)
    {
        buffer = new byte[len];
        Marshal.Copy(source, buffer, 0, len);
    }

    public LuaByteBuffer(byte[] buf)
    {
        this.buffer = buf;
    }

    public override bool Equals(object o)
    {
        if ((object)o == null) return false;
        LuaByteBuffer bb = o as LuaByteBuffer;
        return bb != null && bb.buffer == buffer;
    }

    public static bool operator ==(LuaByteBuffer a, LuaByteBuffer b)
    {
        if (System.Object.ReferenceEquals(a, b))
        {
            return true;
        }

        object l = (object)a;
        object r = b;

        if (l == null && r != null)
        {
            return b.buffer == null;
        }

        if (l != null && r == null)
        {
            return a.buffer == null;
        }

        return a.buffer == b.buffer;
    }

    public static bool operator !=(LuaByteBuffer a, LuaByteBuffer b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return buffer.GetHashCode();
    }

    public byte[] buffer = null;
}

public class LuaStringBuffer : LuaByteBuffer
{
    public LuaStringBuffer(IntPtr source, int len):base(source, len)
    {
        
    }
}
//{
//    //从lua端读取协议数据
//    public LuaStringBuffer(IntPtr source, int len)
//    {
//        buffer = new byte[len];
//        Marshal.Copy(source, buffer, 0, len);
//    }

//    //c#端创建协议数据
//    public LuaStringBuffer(byte[] buf)
//    {
//        this.buffer = buf;
//    }

//    public byte[] buffer = null;
//}

public class LuaRef
{
    public IntPtr L;
    public int reference;

    public LuaRef(IntPtr L, int reference)
    {
        this.L = L;
        this.reference = reference;
    }
}

/*一个发送协议的例子结构*/
public class MsgPacket
{
    public ushort id;
    public int      seq;
    public ushort   errno;        
    public LuaStringBuffer data;   
}

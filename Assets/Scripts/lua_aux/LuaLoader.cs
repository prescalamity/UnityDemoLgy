using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using System.Runtime.InteropServices;
using LuaInterface;


//fix_me mac 跑不起来了
//去掉宏  和 编译多平台
public class LuaLoader
{
    private static LuaLoader mInstance;
    /// <summary>
    /// 获取LuaLoader 单例
    /// </summary>
    public static LuaLoader GetInstance()
    {
        if (mInstance == null)
        {
            mInstance = Activator.CreateInstance<LuaLoader>();
        }
        return mInstance;
    }

    private const int WINCLIENT_SCRIPT_FILE = (int)(((int)('S') << 24) | ((int)('F') << 16) | ((int)('D') << 8) | ((int)('A')));
    private const int SCRIPT_FILE_VERSION = 1;
    private const UInt32 ENCRYPT_SEED = 0x6E104A93;

    private List<byte[]> m_file_buff_vec = new List<byte[]>();

    private DirNode m_root_path = new DirNode();

    private bool bInitFlag = false;

    private IntPtr mPackageAnalyserInstance = IntPtr.Zero;

    private List<string> pak_files = new List<string>();
    private class FileMap : Dictionary<string, FileNode>
    {

    }

    private class DirMap : Dictionary<string, DirNode>
    {

    }

    private struct FileNode
    {
        public string file_name;
        public Int32 file_data_num;
        public UInt32 file_offset;
        public UInt32 file_length;
        public UInt32 file_orient_length;
    }
    private struct DirNode
    {
        public string dir_name;
        public DirMap subdir_map;
        public FileMap curfile_map;
    }

    private struct DataFileHeader
    {
        public UInt32 fourcc;
        public UInt32 version;
        public UInt32 file_count;
        public UInt32 header_length;
        public UInt32 header_length_orient;
    }

    private struct ScriptFileHeader
    {
        public string filename;
        public UInt32 file_offset;
        public UInt32 file_length;
        public UInt32 file_orient_length;
    }

    public void Init()
    {
        //QLog.Log("LuaLoader Init");
        LuaScriptMgr.GetInstance();


#if (UNITY_IPHONE || UNITY_STANDALONE || UNITY_ANDROID)
        //mPackageAnalyserInstance = PackageAnalyser.PackageAnalyserNew();
#endif

        //LuaScriptMgr.GetInstance().LuaPath = new LuaScriptMgr.LuaPathDelegate(Util.LuaPath);
        LuaScriptMgr.GetInstance().LuaGetBuf = new LuaScriptMgr.LuaGetBuffDelegate(LuaLoader.GetInstance().GetFileBuff);

    }

    public bool ReloadPak()
    {
        //QLog.Log("LuaLoader Reload Pak");

        //if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
        //{
        //    return LoadPak();
        //}

        return true;
    }

    public void Start()
    {

        LuaState L = LuaScriptMgr.GetInstance().lua;
        LuaScriptMgr.GetInstance().Start();
    }

    public void ExportLuaPak(string pak_path = "")
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        //if (!string.IsNullOrEmpty(pak_path))
        //{
        //    if (File.Exists(pak_path))
        //        FileHelperEx.Instance.ExportFile(pak_path, Util.GetWritablePath(pak_path));
        //    return;
        //}
        //pak_path = string.Empty;
        //string des_path = string.Empty;
        ////QLog.Log("ExportLuaPak count {0}", pak_files.Count);
        //for (int i = 0; i < pak_files.Count; i++)
        //{
        //    //QLog.Log("ExportLuaPak file {0}", pak_files[i]);
        //    CommonConst.StringBuffer.Length = 0;
        //    CommonConst.StringBuffer.AppendFormat("scriptspak/{0}/{1}", ClientInfo.GetOsType(), pak_files[i]);
        //    pak_path = CommonConst.StringBuffer.ToString();
        //    des_path = pak_path.Replace("scriptspak", "scriptspak_source");
        //    //des_path = Util.GetWritablePath(des_path);
        //    //FileHelperEx.Instance.ExportFile(pak_path, des_path);
        //    Unity3DHelper.ExportResourceFile2OtherPath(pak_path, des_path, true);
        //}
#endif

    }


    public bool LoadPak()
    {
        bInitFlag = true;
        m_root_path.dir_name = "";
        //DataEncrypt.InitCryptTable();
        return RecursivePackageFile();
    }

    private bool RecursivePackageFile()
    {
        //ProfilerHelper.BeginSample("LuaLoader.RecursiveParsePackageLuaFile");

        //if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
        //{
        //    ////QLog.Log("LuaLoader.RecursivePackageFileAsync-->WebResLoader.RemoteResList.Keys.Count: {0}", WebResLoader.RemoteResList.Keys.Count);
        //    foreach (string key in WebResLoader.RemoteResInfo.Keys)
        //    {
        //        if (key.EndsWith(".pak"))
        //        {
        //            if (!ParsePackageFile(WebResLoader.GetResData(key)))
        //            {
        //                //QLog.LogError("/scriptspak/{0}/{1} Reaad Failed !!\n{2}", ClientInfo.GetOsType(), key, LuaScriptMgr.GetErrorFunc(1));
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        return false;
    }

    private bool ParsePackageFile(byte[] stream)
    {
        //if (stream == null)
        //{
        //    return false;
        //}
        //UInt32 header_size = 0;
        //MemoryStream src_stream = new MemoryStream(stream);
        //src_stream.Position = 0;

        //if (src_stream.Length == 0)
        //{
        //    //QLog.Log("Can't find lua data");
        //    return false;
        //}

        //long src_stream_len = src_stream.Length;
        //byte[] info_array = new byte[src_stream_len];
        //src_stream.Read(info_array, 0, (int)src_stream_len);

        //DataFileHeader file_header = new DataFileHeader();
        //file_header = (DataFileHeader)StructOperateHelper.ByteToStruct(info_array, typeof(DataFileHeader));

        //header_size += (UInt32)Marshal.SizeOf(file_header);
        //header_size += file_header.header_length;

        //if (file_header.fourcc != WINCLIENT_SCRIPT_FILE)
        //{
        //    //QLog.Log("Lua Pak File Format Error!");
        //    return false;
        //}

        //if (file_header.version != SCRIPT_FILE_VERSION)
        //{
        //    //QLog.Log("Lua Pak File Update!");
        //    return false;
        //}

        //byte[] comp_header_data = new byte[file_header.header_length];
        //byte[] uncomp_header_data = new byte[file_header.header_length_orient];
        //src_stream.Seek(Marshal.SizeOf(file_header), SeekOrigin.Begin);
        //src_stream.Read(comp_header_data, 0, comp_header_data.Length);
        //m_data_encrypt.DecryptHashTableData(ref comp_header_data, ENCRYPT_SEED);

        //if (-1 == DataDeflate.Inflate(comp_header_data, comp_header_data.Length, uncomp_header_data, uncomp_header_data.Length))
        //{
        //    return false;
        //}

        //MemoryStream uncomp_header = new MemoryStream();
        //uncomp_header.Write(uncomp_header_data, 0, uncomp_header_data.Length);
        //XReadStream mem_file = new XReadStream(uncomp_header, (UInt32)uncomp_header_data.Length);

        //for (int i = 0; i < file_header.file_count; i++)
        //{
        //    FileNode filenode;
        //    mem_file.Read(out filenode.file_name);
        //    mem_file.Read(out filenode.file_offset);
        //    mem_file.Read(out filenode.file_length);
        //    mem_file.Read(out filenode.file_orient_length);
        //    filenode.file_data_num = m_file_buff_vec.Count;
        //    if (!InsertFileNode(ref m_root_path, filenode))
        //    {
        //        return false;
        //    }
        //}

        //// save the rest data
        //long file_buff_size = src_stream_len - header_size;
        //byte[] file_buff = new byte[file_buff_size];
        //Array.Copy(info_array, header_size, file_buff, 0, file_buff_size);
        //m_file_buff_vec.Add(file_buff);

        //src_stream.Dispose();
        //src_stream = null;
        //info_array = null;
        //comp_header_data = null;
        //uncomp_header_data = null;
        //uncomp_header.Dispose();
        //uncomp_header = null;
        //mem_file = null;
        //file_buff = null;
        //xClientProxy.DoGCCollect();

        return true;
    }

    private bool InsertFileNode(ref DirNode parent_path, FileNode filenode)
    {
        if (filenode.file_name.StartsWith("/"))
        {
            filenode.file_name = filenode.file_name.Substring(1);
        }
        if (filenode.file_name.Contains("/"))
        {
            // directory
            int position = filenode.file_name.IndexOf("/");
            string dir_name = filenode.file_name.Substring(0, position);
            filenode.file_name = filenode.file_name.Substring(position);
            if (parent_path.subdir_map == null)
            {
                parent_path.subdir_map = new DirMap();
            }
            if (!parent_path.subdir_map.ContainsKey(dir_name))
            {
                DirNode subdir = new DirNode();
                subdir.dir_name = dir_name;
                subdir.subdir_map = new DirMap();
                subdir.curfile_map = new FileMap();
                parent_path.subdir_map.Add(subdir.dir_name, subdir);
                return InsertFileNode(ref subdir, filenode);
            }
            else
            {
                DirNode subdir = new DirNode();
                parent_path.subdir_map.TryGetValue(dir_name, out subdir);
                return InsertFileNode(ref subdir, filenode);
            }
        }
        else
        {
            // file
            if (parent_path.curfile_map == null)
            {
                parent_path.curfile_map = new FileMap();
            }
            if (!parent_path.curfile_map.ContainsKey(filenode.file_name))
            {
                parent_path.curfile_map.Add(filenode.file_name, filenode);
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }


    public byte[] GetFileBuff(string file_path, out IntPtr ptrFileBuff, out int fileLen)
    {
        ptrFileBuff = IntPtr.Zero;
        fileLen = 0;

        //if (WebGL_Confing.IsWebglRuntime && WebGL_Confing.ResEnableWebMode)
        //{
        //    return GetFileBuff(file_path);
        //}

        return GetFileBuff(file_path);
    }



    public byte[] GetFileBuff(string file_path)
    {
        FileNode filenode = new FileNode();
        if (!GetFileNode(file_path, ref filenode))
        {
            return null;
        }
        return GetFileBuffByNode(filenode);
    }




    public bool IsFileExist(string file_path)
    {
        if (bInitFlag == true)
        {
#if UNITY_IPHONE || UNITY_STANDALONE || UNITY_ANDROID
            return PackageAnalyser.IsFileExist(mPackageAnalyserInstance, file_path);
#else
            FileNode filenode = new FileNode();
            return GetFileNode(file_path, ref filenode);
#endif
        }
        else
        {
            return false;
        }
    }

    private bool GetFileNode(string file_path, ref FileNode filenode)
    {
        if (!FindFileNode(file_path, ref m_root_path, ref filenode))
        {
            return false;
        }
        return true;
    }

    private bool FindFileNode(string file_path, ref DirNode parent_dir_node, ref FileNode filenode)
    {
        if (file_path.StartsWith("/"))
        {
            file_path = file_path.Substring(1);
        }
        if (file_path.Contains("/"))
        {
            //directory
            int position = file_path.IndexOf("/");
            string subdir_name = file_path.Substring(0, position);
            file_path = file_path.Substring(position);
            if (parent_dir_node.subdir_map.ContainsKey(subdir_name))
            {
                DirNode dirnode = new DirNode();
                parent_dir_node.subdir_map.TryGetValue(subdir_name, out dirnode);
                return FindFileNode(file_path, ref dirnode, ref filenode);
            }
            return false;

        }
        else
        {
            if (parent_dir_node.curfile_map.ContainsKey(file_path))
            {
                return parent_dir_node.curfile_map.TryGetValue(file_path, out filenode);
            }
            return false;
        }
    }

    byte[] GetFileBuffByNode(FileNode filenode)
    {
        byte[] uncompr_file_buff = new byte[filenode.file_orient_length];
        byte[] compr_file_buff = new byte[filenode.file_length];
        byte[] file_data = m_file_buff_vec[filenode.file_data_num];
        Array.Copy(file_data, filenode.file_offset, compr_file_buff, 0, filenode.file_length);
        //m_data_encrypt.DecryptHashTableData(ref compr_file_buff, ENCRYPT_SEED);
        //if (-1 == DataDeflate.Inflate(compr_file_buff, compr_file_buff.Length, uncompr_file_buff, uncompr_file_buff.Length))
        //{
        //    return null;
        //}
        return uncompr_file_buff;
    }

    public void ClearLuaPak()
    {
#if UNITY_IPHONE || UNITY_STANDALONE || UNITY_ANDROID
        PackageAnalyser.ClearLuaPak(mPackageAnalyserInstance);
#else
        m_file_buff_vec.Clear();
        m_file_buff_vec = null;
        m_file_buff_vec = new List<byte[]>();
#endif
    }

    public int GetLuaPakCount()
    {
        return m_file_buff_vec.Count;
    }
}

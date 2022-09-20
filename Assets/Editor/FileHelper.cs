using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

/*

文件 和 文件夹 的 复制 移动 删除

另外：
移动文件夹，可以使用DirectoryInfo.MoveTo()
复制文件，可以使用FileInfo.CopyTo()

 */

public class FileHelper{
    static Dictionary<string, string> mSuffixDic;
    static FileHelper()
    {
        mSuffixDic = new Dictionary<string, string>();
        mSuffixDic.Add(".PNG", ".AAA");
        mSuffixDic.Add(".png", ".aaa");
        mSuffixDic.Add(".JPG", ".BBB");
        mSuffixDic.Add(".jpg", ".bbb");
        mSuffixDic.Add(".TGA", ".CCC");
        mSuffixDic.Add(".tga", ".ccc");
        
    }

    /// <summary>
    /// 把direcSource文件夹下的 所有内容 复制到 direcTarget（不存在时会创建）文件夹下，
    /// </summary>
    /// <param name="direcSource"></param>
    /// <param name="direcTarget"></param>
	public static void CopyDirectory(string direcSource, string direcTarget)
	{
		if (!Directory.Exists(direcTarget))
			Directory.CreateDirectory(direcTarget);
		
		DirectoryInfo direcInfo = new DirectoryInfo(direcSource);
		FileInfo[] files = direcInfo.GetFiles();
		foreach (FileInfo file in files)
			file.CopyTo(Path.Combine(direcTarget, file.Name), true);
		
		DirectoryInfo[] direcInfoArr = direcInfo.GetDirectories();
		foreach (DirectoryInfo dir in direcInfoArr)
			CopyDirectory(Path.Combine(direcSource, dir.Name), Path.Combine(direcTarget, dir.Name));
	}

 //   /// <summary>
 //   /// 删除指定文件夹path，以及是否删除文件夹本事
 //   /// </summary>
 //   /// <param name="path"></param>
 //   /// <param name="delete_myself">是否删除文件夹本身</param>
	//public static void DeleteDirectory(string path, bool delete_myself = false)
	//{
	//	DirectoryInfo dir = new DirectoryInfo(path);
	//	if (dir.Exists)
	//	{
	//		foreach (DirectoryInfo child in dir.GetDirectories())
	//		{
	//		    try
	//		    {
	//		        DeleteDirectory(child.FullName, true);
	//		    }
	//		    catch (Exception e)
	//		    {
	//		        Debug.LogWarning(string.Format("Delete Directory Failed: path->{0}, error->{1}", child.FullName,e.Message));
	//		    }
	//		} 
 //           FileInfo[] infos = dir.GetFiles();
	//		foreach (FileInfo child in infos)
	//		{
	//		    try
	//		    {
	//		        child.Delete();
	//		    }
	//		    catch (Exception e)
	//		    {
	//		        Debug.LogWarning(string.Format("Delete File Failed: path->{0}, error->{1}", child.FullName,e.Message));
	//		    }
	//		}
 //           if(delete_myself)
 //           {
 //               dir.Delete(true);
 //           }
	//	}
	//}


    /// <summary>
    /// 将 direcSource 移动（剪切）到 direcTarget 文件夹下，且当 direcTarget文件夹中已存在 和direcSource文件夹同名的文件夹时，原文件夹会被覆盖
    /// </summary>
    public static void MoveDirectoryAndOverwrite(string direcSource, string direcTarget)
    {
        //DLog.Log("FileHelper.MoveDirectory");

        if (!Directory.Exists(direcSource) || !Directory.Exists(direcSource))
        {
            DLog.Log("pls, check that the both directories are existed. {0} , {1}", direcSource, direcTarget);
            return;
        }

        string _dirName = direcSource.Split(new char[]{'/', '\\'}, StringSplitOptions.RemoveEmptyEntries)[^1];

        direcTarget = direcTarget + "/" + _dirName;

        if(Directory.Exists(direcTarget))Directory.Delete(direcTarget, true);

        Directory.Move(direcSource, direcTarget);

    }

    /// <summary>
    /// fileSource 目标文件，direcTarget 需要 移动(剪切) 到的文件夹, isCreateDirecTarget 文件夹不存在时是否创建
    /// </summary>
    /// <param name="fileSource"></param>
    /// <param name="direcTarget"></param>
    public static void MoveFileAndOverwrite(string fileSource, string direcTarget, bool isCreateDirecTarget = false)
    {

        if (!File.Exists(fileSource))
        {
            DLog.Log("the file does not exists: " + fileSource);
            return;
        }

        if (!Directory.Exists(direcTarget))
        {
            if (isCreateDirecTarget)
            {
                Directory.CreateDirectory(direcTarget);
            }
            else
            {
                DLog.Log("pls, check that the directorys is existed. {0}", direcTarget);
                return;
            }
        }

        string _filename = fileSource.Split(new char[] {'/','\\'}, StringSplitOptions.RemoveEmptyEntries)[^1];

        direcTarget = direcTarget + "/" + _filename;
        //DLog.Log("the file name is " + _filename);
        
        if (File.Exists(direcTarget)) File.Delete(direcTarget);

        File.Move(fileSource, direcTarget);

    }


    public static string[] FindFileBySuffix(string search_path, string suffix)
	{
		List<string> result = new List<string>();
        if (Directory.Exists(search_path))
        {
            foreach (string dir in Directory.GetDirectories(search_path))
            {
                FindFileBySuffix(dir, suffix, ref result);
            }
            foreach (string file in Directory.GetFiles(search_path))
            {
                if (file.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    string str = file.Replace("\\", "/");
                    result.Add(str);
                }
            }
        }
        else
        {
            Debug.LogWarning("FindFileBySuffix, directory not exist, dir = " + search_path);
        }
		return result.ToArray();
	}

	public static void FindFileBySuffix(string search_path, string suffix, ref List<string> result)
	{
        if (Directory.Exists(search_path))
        {
            foreach (string dir in Directory.GetDirectories(search_path))
            {
                FindFileBySuffix(dir, suffix, ref result);
            }
            foreach (string file in Directory.GetFiles(search_path))
            {
                if (file.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    string str = file.Replace("\\", "/");
                    result.Add(str);
                }
            }
        }
        else
        {
            Debug.LogWarning("FindFileBySuffix, directory not exist, dir = " + search_path);
        }
	}

    public static void DeleteEmptyDirectory(string path)
    {
        DirectoryInfo dir_info = new DirectoryInfo(path);
        foreach(var dir in dir_info.GetDirectories())
        {
            if(dir.GetFileSystemInfos().Length == 0)
            {
                dir.Delete();
            }
            else
            {
                DeleteEmptyDirectory(dir.FullName);
            }
        }
    }

    public static void RenameFile(string filepath)
    {
        string new_name = string.Empty;
        foreach (KeyValuePair<string, string> current in FileHelper.mSuffixDic)
        {
            if (filepath.EndsWith(current.Key))
            {
                new_name = filepath.Replace(current.Key, current.Value);
                if (File.Exists(new_name))
                {
                    File.Delete(new_name);
                }
                File.Move(filepath, new_name);
                break;
            }
        }
    }

    public static void RenameTexFile(string path)
    {
        string new_name = string.Empty;
        foreach (string filename in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
        {
            foreach (KeyValuePair<string, string> current in FileHelper.mSuffixDic)
            {
                if (filename.EndsWith(current.Key))
                {
                    new_name = filename.Replace(current.Key, current.Value);
                    if (File.Exists(new_name))
                    {
                        File.Delete(new_name);
                    }
                    File.Move(filename, new_name);
                    break;
                }   
            }
        }
        Debug.Log("RenameTexFile Complete !!!!");
    }

    public static void RevertTexFile(string path)
    {
        string new_name = string.Empty;
        foreach (string filename in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
        {
            foreach (KeyValuePair<string, string> current in FileHelper.mSuffixDic)
            {
                if (filename.EndsWith(current.Value))
                {
                    new_name = filename.Replace(current.Value, current.Key);
                    if (File.Exists(new_name))
                    {
                        File.Delete(new_name);
                    }
                    File.Move(filename, new_name);
                    break;
                }
            }
        }
        Debug.Log("RevertTexFile Complete !!!!");
    }
}

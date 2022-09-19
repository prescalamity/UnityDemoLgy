using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

/*

 File.Copy("","");

 移动文件，使用DirectoryInfo.MoveTo()

 FileInfo.CopyTo()


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

	public static void DeleteDirectory(string path, bool delete_myself = false)
	{
		DirectoryInfo dir = new DirectoryInfo(path);
		if (dir.Exists)
		{
			foreach (DirectoryInfo child in dir.GetDirectories())
			{
			    try
			    {
			        DeleteDirectory(child.FullName, true);
			    }
			    catch (Exception e)
			    {
			        Debug.LogWarning(string.Format("Delete Directory Failed: path->{0}, error->{1}", child.FullName,e.Message));
			    }
			} 
            FileInfo[] infos = dir.GetFiles();
			foreach (FileInfo child in infos)
			{
			    try
			    {
			        child.Delete();
			    }
			    catch (Exception e)
			    {
			        Debug.LogWarning(string.Format("Delete File Failed: path->{0}, error->{1}", child.FullName,e.Message));
			    }
			}
            if(delete_myself)
            {
                dir.Delete(true);
            }
		}
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

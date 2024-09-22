using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 查找指定 组件被谁引用
/// https://blog.csdn.net/aaa27987/article/details/118032288
/// </summary>
public class FindReference : MonoBehaviour
{
    [MenuItem("Tools/Find Prefab Script Reference")]
    public static void FindReferences0()
    {
        //Debug.Log("TestEditor.FindReferences, " + 1);
        //int counter=0;
        //string scriptName = "HyperText"; // 替换为你要查找的脚本名称
        //try {
        //    GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefab"); // 加载 Resources 文件夹下的所有预设体

        //    Debug.Log("TestEditor.FindReferences, " + scriptName);

        //    foreach (GameObject prefab in prefabs)
        //    {
        //        if (prefab.GetComponent(scriptName))
        //        {
        //            Debug.Log("lgy, Prefab found with script: " + prefab.name);
        //        }
        //        counter++;
        //    }
        //}
        //catch(Exception ex)
        //{
        //    Debug.LogException(ex);
        //}

        //Debug.Log("TestEditor.FindReferences, over, "+ counter);
    }


    static string sourceFile = "E:/LogDiffFileLgy.log";

    [MenuItem("Tools/Find Prefab Script Reference")]
    public static void FindReferences()
    {

        if (File.Exists(sourceFile))
        {
            // 删除文件
            File.Delete(sourceFile);
        }

        Debug.Log("start, " + sourceFile);

        string[] guids = AssetDatabase.FindAssets(null);
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);    // 获取所有资源的相对Assets路径

            if (CheckEffectPathValidity(path))
            {
                //if(!path.Contains("Friend_Widget"))continue;

                GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(path);    // 在Editor中，根据路径加载资源 到内存
                if (go == null)
                {
                    continue;
                }

                //Debug.Log("FindReferences3, path=" + path);


                FindComponentInChildren<Collider>(go.transform, go.transform, path);


                //EffectNode effectNode = go.GetComponent<EffectNode>();
                //if (effectNode == null)
                //{
                //    EffectNode[] effectNodes = go.GetComponentsInChildren<EffectNode>(true);
                //    for (int j = 0; j < effectNodes.Length; j++)
                //    {
                //        RemoveEffectNote(effectNodes[j].gameObject);
                //    }
                //}
                //else
                //{
                //    RemoveEffectNote(go);
                //}
            }
        }

        File.AppendAllText(sourceFile, string.Format("{0}counter--->{1}{2}", Environment.NewLine, counter, Environment.NewLine), new UTF8Encoding(false));

        Debug.Log("over");

        AssetDatabase.SaveAssets();

    }


    private static bool CheckEffectPathValidity(string path)
    {
        //if (path.StartsWithEx("Assets/Artist/GResources/Prefab"))
        //{
        //    return true;
        //}
        if (path.StartsWith("Assets/CRes/Prefabs"))
        {
            return true;
        }
        if (path.StartsWith("Assets/GResources/Prefab"))
        {
            return true;
        }

        return false;
    }

    static string last = "";
    static int counter = 0;
    /// <summary>
    /// 查找挂有 T 组件的对象路径，和其具体的子对象名
    /// </summary>
    /// <param name="curNodeTrans"></param>
    /// <param name="pathPrefab"></param>
    private static void FindComponentInChildren<T>(Transform rootTran, Transform curNodeTrans, string pathPrefab)
    {

        T effectNode = curNodeTrans.GetComponent<T>();
        if (effectNode != null)
        {
            // 找到了拥有HyperText组件的子物体

            if (last == pathPrefab)
            {
                File.AppendAllText(sourceFile, string.Format("{0}---haveHT--->{1}{2}", pathPrefab, GetTransPath(curNodeTrans), Environment.NewLine), new UTF8Encoding(false));

            }
            else
            {
                counter++;
                last = pathPrefab;
                File.AppendAllText(sourceFile, string.Format("{0}{1}---haveHT--->{2}{3}", Environment.NewLine, pathPrefab, GetTransPath(curNodeTrans), Environment.NewLine), new UTF8Encoding(false));
                //File.AppendAllText(sourceFile, string.Format("{0}lgy{1}{2}", Environment.NewLine, pathPrefab, Environment.NewLine), new UTF8Encoding(false));
            }

            // 判断这个子物体被谁引用了
            FindOneReferenced<T>(rootTran, curNodeTrans.gameObject);

        }

        for (int i = 0; i < curNodeTrans.childCount; i++)
        {
            Transform child = curNodeTrans.GetChild(i);
            FindComponentInChildren<T>(rootTran, child, pathPrefab);
        }
    }


    /// <summary>
    /// 返回指定对象是否被某个根节点引用
    /// </summary>
    /// <param name="rootTran"></param>
    /// <param name="targetGo"></param>
    /// <returns></returns>
    private static bool FindOneReferenced<T>(Transform rootTran, GameObject targetGo)
    {
        //获取这个节点和其子节点的所有组件
        Component[] coms = rootTran.GetComponentsInChildren<Component>(true);

        bool isFind = false;
        for (int i = 0; i < coms.Length; i++)
        {
            if (coms[i] == null)
            {
                continue;
            }

            //遍历一个组件的所有字段
            var fileList = coms[i].GetType().GetFields().ToList<FieldInfo>();
            for (int j = 0; j < fileList.Count; j++)
            {
                var fileInfo = fileList[j];
                var fileValue = fileInfo.GetValue(coms[i]); //关键代码，获得一个字段的引用对象
                GameObject fileGo = null;

                if (fileValue == null)
                {
                    continue;
                }

                //是否是GameObject
                if (typeof(GameObject) == fileValue.GetType())
                {
                    var tempGo = (fileValue as GameObject);
                    if (tempGo != null)
                    {
                        fileGo = tempGo.gameObject;
                    }
                }

                //或者是否继承Component组件
                else if (typeof(Component).IsAssignableFrom(fileValue.GetType()))
                {
                    var tempComp = (fileValue as Component);
                    if (tempComp != null)
                        fileGo = tempComp.gameObject;
                    // fileGo = (fileValue as Component)?.gameObject; 如果改用此简写，可能会报 UnassignedReferenceException 异常...
                }

                else if (typeof(T[]) == fileValue.GetType())
                {
                    File.AppendAllText(sourceFile, string.Format("lgy--->找到数组引用, 引用物体名:{0}, 组件名:{1}, 字段名:{2}{3}",
                    GetTransPath(coms[i].gameObject.transform), coms[i], fileInfo.Name, Environment.NewLine), new UTF8Encoding(false));
                }

                if (fileGo != null && fileGo == targetGo)
                {
                    isFind = true;
                    //在Hierarchy窗口显示查到的物体
                    EditorGUIUtility.PingObject(coms[i]);

                    File.AppendAllText(sourceFile, string.Format("lgy--->找到引用, 引用物体名:{0}, 组件名:{1}, 字段名:{2}{3}",
                        GetTransPath(coms[i].gameObject.transform), coms[i], fileInfo.Name, Environment.NewLine), new UTF8Encoding(false));


                    //UnityEngine.Debug.Log(string.Format("找到引用, 引用物体名：{0}, 引用组件名：{1}, 字段名：{2}", coms[i].gameObject.name, coms[i], fileInfo.Name));
                }
            }
        }

        return isFind;
    }

    /// <summary>
    /// 递归实现，获得GameObject在Hierarchy中的完整路径
    /// </summary>
    public static string GetTransPath(Transform trans)
    {
        if (!trans.parent)
        {
            return trans.name;
        }
        return GetTransPath(trans.parent) + "/" + trans.name;
    }


    public static Transform[] GetAllChildrenIncludingInactive(Transform parent)
    {
        // 创建一个列表来存储所有子物体
        var childrenList = new System.Collections.Generic.List<Transform>();

        // 遍历 parent 的所有直接子物体
        foreach (Transform child in parent)
        {
            childrenList.Add(child);

            // 递归调用以获取所有的子物体，包括未激活的
            childrenList.AddRange(GetAllChildrenIncludingInactive(child));
        }

        return childrenList.ToArray();
    }
}

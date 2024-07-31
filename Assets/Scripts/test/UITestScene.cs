using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 具体场景的主函数脚本
/// </summary>
public class UITestScene : MonoBehaviour
{

    public GameObject uiGameObject;
    //public GameObject uiGameObject { get; set; }


    void Start()
    {

        // 移出屏幕外
        uiGameObject.gameObject.transform.localPosition = new Vector3(-Screen.width,
            uiGameObject.gameObject.transform.localPosition.y,
             uiGameObject.gameObject.transform.localPosition.z);
    }


    void Update()
    {
        float deltaX = Screen.width * (Time.deltaTime / 20f);
        float wantX = uiGameObject.gameObject.transform.localPosition.x + deltaX;
        if (wantX < 0f)
        {
            uiGameObject.gameObject.transform.localPosition = new Vector3(wantX,
                uiGameObject.gameObject.transform.localPosition.y,
                uiGameObject.gameObject.transform.localPosition.z);
        }

        //Debug.Log($"uiGameObject 向左移动, 20秒走完 wantX={wantX}, deltaX={deltaX}");
    }
}

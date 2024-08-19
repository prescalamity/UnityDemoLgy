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
	private RectTransform rectTransform = null;


	void Start()
    {

        // 移出屏幕外
        uiGameObject.gameObject.transform.localPosition = new Vector3(-Screen.width,
            uiGameObject.gameObject.transform.localPosition.y,
             uiGameObject.gameObject.transform.localPosition.z);

        rectTransform = uiGameObject.GetComponent<RectTransform>();

        // 修改 UI 的宽度，屏幕的1.5倍
        //rectTransform.rect.width = Screen.width * 1.5f;
        if (rectTransform != null)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 1.5f);

			Debug.Log($"UITestScene.Start, rectTransform.anchoredPosition, x={rectTransform.anchoredPosition.x}, y={rectTransform.anchoredPosition.y}");
        }


    }


    void Update()
    {
		float deltaX = Screen.width * (Time.deltaTime / 20f);
		//float wantX = uiGameObject.gameObject.transform.localPosition.x + deltaX;

		//if (wantX < 0f)
		//{
		//	uiGameObject.gameObject.transform.localPosition = new Vector3(wantX,
		//		uiGameObject.gameObject.transform.localPosition.y,
		//		uiGameObject.gameObject.transform.localPosition.z);
		//}

		//Debug.Log($"uiGameObject 向左移动, 20秒走完 wantX={wantX}, deltaX={deltaX}");


		float anchoredPositionX = rectTransform.anchoredPosition.x;
		anchoredPositionX += deltaX;
		if (rectTransform.anchoredPosition.x < 0)
		{
			rectTransform.anchoredPosition = new Vector2(anchoredPositionX, rectTransform.anchoredPosition.y);

		}


	}
}

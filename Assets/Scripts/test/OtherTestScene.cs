using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherTestScene : MonoBehaviour
{


    /// <summary>
    /// ¼Ì³ÐMono
    /// </summary>
    public void Create()
    {
        Debug.LogWarning($"OtherTestScene.Create, ½ø¶ÈÌõ, frameCount={Time.frameCount}, " +
            $"time={DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff")}");

    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"OtherTestScene.Start, frameCount={Time.frameCount}, time={DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff")}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

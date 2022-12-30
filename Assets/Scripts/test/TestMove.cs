using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    float timer = 0;
    float speed = 2;
    Vector3 vector3 = new Vector3();

    void Start()
    {
        DLog.Log("TestMove.Start");
        vector3.x = gameObject.transform.localPosition.x;
        vector3.y = gameObject.transform.localPosition.y;
        vector3.z = gameObject.transform.localPosition.z;
        
    }


    void Update()
    {
        timer += Time.deltaTime;

        // 每4秒改变一次移动方向
        if (timer > 4)
        {
            timer = 0;
            speed = -speed;
        }

        vector3.z = vector3.z + speed * Time.deltaTime;
        gameObject.transform.localPosition = vector3;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ��ⰲ׿�豸����
/// </summary>
public class AndroidDevicePower : MonoBehaviour
{

    static GameObject mGameObject = null;
    static TMP_Text battery_capacity_value = null;
    static TMP_Text battery_electricity_value = null;
    static TMP_Text battery_voltage_value = null;
    static TMP_Text battery_retain_value = null;
    static TMP_Text battery_retain_time_value = null;
    static TMP_Text battery_get_api_time_value = null;

    public static void setPanelSort()
    {
        if(mGameObject!=null)mGameObject.transform.SetAsLastSibling();
    }


    public void Start()
    {
        DLog.Log("AndroidDevicePower.Start");

        mGameObject = GameObject.Find("Canvas/power");

        battery_capacity_value = GameObject.Find("Canvas/power/battery_capacity_value").GetComponent<TMP_Text>();
        battery_electricity_value = GameObject.Find("Canvas/power/battery_electricity_value").GetComponent<TMP_Text>();
        battery_voltage_value = GameObject.Find("Canvas/power/battery_voltage_value").GetComponent<TMP_Text>();
        battery_retain_value = GameObject.Find("Canvas/power/battery_retain_value").GetComponent<TMP_Text>();
        battery_retain_time_value = GameObject.Find("Canvas/power/battery_retain_time_value").GetComponent<TMP_Text>();
        battery_get_api_time_value = GameObject.Find("Canvas/power/battery_get_api_time_value").GetComponent<TMP_Text>();


        battery_capacity_value.text = Power.capacity.ToString();
        battery_voltage_value.text= Power.voltage.ToString();
        battery_retain_value.text = Power.batteryRetain.ToString();

    }


    //private void OnGUI()
    //{
    //    GUILayout.Label(string.Format($"<size=80>���������{Power.capacity}����,��ѹ{Power.voltage}��</size>"));
    //    GUILayout.Label(string.Format($"<size=80>ʵʱ����{e}����,ʵʱ����{(int)(e * Power.voltage)},����������{((Power.capacity / e).ToString("f2"))}Сʱ</size>"));
    //}

    float e = 0f;
    float t = 0f;
    private void Update()
    {
        if (Time.time - t > 0.1f)
        {
            t = Time.time;
            e = Power.electricity;
            battery_electricity_value.text = e.ToString();
            battery_get_api_time_value.text = Power.deltaTime.ToString();
            battery_retain_time_value.text = (Power.capacity * Power.batteryRetain / 100 / e).ToString("f2");
        }
    }


}



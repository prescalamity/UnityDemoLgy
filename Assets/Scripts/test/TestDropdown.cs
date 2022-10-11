using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestDropdown : MonoBehaviour
{

    public TMP_Dropdown m_Dropdown;


    void Start()
    {
        m_Dropdown = GameObject.Find("Canvas/dropdown").GetComponent<TMP_Dropdown>();
        m_Dropdown.options.Clear();
        m_Dropdown.options.Add(new TMP_Dropdown.OptionData("dhasjkd"));
        m_Dropdown.options.Add(new TMP_Dropdown.OptionData("testLuaFunction"));

        DLog.Log("m_Dropdown.options.count: "+ m_Dropdown.options.Count);


    }


    void Update()
    {
        


    }



    public static void initDpd(TMP_Dropdown dropdown ,string content = "")
    {

        if (content == "") content = txt.DropdownStr;

        string[] strDpd = content.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (string str in strDpd)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(str));
        }

        // TMP_Dropdown ֵ�����һ�Σ��Ż���ʾĬ���ַ�
        dropdown.value = 1;
        dropdown.value = 0;

    }


}

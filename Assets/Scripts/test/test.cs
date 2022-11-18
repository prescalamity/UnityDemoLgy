using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class test
{

    public static void onlyTestFunc()
    {

        //PlatformAdapter.CallFuncByName("funcName", "asdasda");


        PlatformAdapter.CallPlatformFuncByName("Hello", ".from onlyTestFunc");


        PlatformAdapter.CallPlatformFuncByName("PlayVideo", ".from onlyTestFunc for video");




        List<persion> listPersons1 = new List<persion>() {new persion("aaa",10,"guangzhou"), new persion("bbb",20, "shanghai"), new persion("ccc", 30,"beijing") };
        List<persion> listPersons2 = new List<persion>() {new persion("ddd",40,"shengzhen"), new persion("eee",50, "beijing"), new persion("fff", 60,"hangzhou") };


        foreach (persion per in (from res in listPersons1   from res2 in listPersons2   where res.address == res2.address   select res) )
        {
            Debug.Log("lgy --> per.name: " + per.name);
        }

    }
}

public class persion {

    public persion(string na, int ag, string ad) { 
        name = na;
        age = ag;
        address = ad;
    }


    public string name;
    public int age;
    public string address;

}




public interface IFunctionbridage
{
    public void targetfunction();
}


public class functionbridageCla : IFunctionbridage
{
    void IFunctionbridage.targetfunction()
    {

        throw new System.NotImplementedException();
    }
}









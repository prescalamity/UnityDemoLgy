using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class test
{

    //public enum ASTART_DIR
    //{
    //    DIR_S = 0,
    //    Dir_LU,
    //    Dir_U,
    //    Dir_RU,
    //    Dir_L,
    //    Dir_RESERVED,
    //    Dir_R,
    //    Dir_LD,
    //    Dir_D,
    //    Dir_RD,
    //    Dir_Count
    //};


    //public static byte[,] POINT_DIR = new byte[3, 3]{
    //                    {(byte)ASTART_DIR.Dir_LU, (byte)ASTART_DIR.Dir_U, (byte)ASTART_DIR.Dir_RU},
    //                    {(byte)ASTART_DIR.Dir_L, (byte)ASTART_DIR.DIR_S, (byte)ASTART_DIR.Dir_R},
    //                    {(byte)ASTART_DIR.Dir_LD, (byte)ASTART_DIR.Dir_D, (byte)ASTART_DIR.Dir_RD}
    //                    };


    public static void onlyTestFunc()
    {

        //PlatformAdapter.CallFuncByName("funcName", "asdasda");


        PlatformAdapter.CallPlatformFuncByName("Hello", ".from onlyTestFunc");


        PlatformAdapter.CallPlatformFuncByName("PlayVideo", ".from onlyTestFunc for video");




        List<person> listPersons1 = new List<person>() {new person("aaa",10,"guangzhou"), new person("bbb",20, "shanghai"), new person("ccc", 30,"beijing") };
        List<person> listPersons2 = new List<person>() {new person("ddd",40,"shengzhen"), new person("eee",50, "beijing"), new person("fff", 60,"hangzhou") };


        foreach (person per in (from res in listPersons1   from res2 in listPersons2   where res.address == res2.address   select res) )
        {
            Debug.Log("lgy --> per.name: " + per.name);
        }

        //int xx = -1;
        //int yy = -1;
        //byte resm = POINT_DIR[xx + 1, yy + 1];
        //Debug.Log("lgy --> 0.0 : " + resm);

    }
}

public class person {

    public person(string na, int ag, string ad) { 
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









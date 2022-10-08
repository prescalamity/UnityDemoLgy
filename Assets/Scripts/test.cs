using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public static void onlyTestFunc()
    {

        //PlatformAdapter.CallFuncByName("funcName", "asdasda");


        PlatformAdapter.CallPlatformFuncByName("Hello", ".from onlyTestFunc");


        PlatformAdapter.CallPlatformFuncByName("PlayVideo", ".from onlyTestFunc for video");

        DLog.Log("StarkSDK.API.SDKVersion.1: {0}.", StarkSDKSpace.StarkSDK.API.SDKVersion);



    }
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









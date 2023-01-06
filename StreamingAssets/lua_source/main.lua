
--临时配置表
maintable = {
    -- 系统平台有的一些函数，用于测试
    platformFuncNameList = {
        "Select Click TestBtn",
        "SoundPanel",
        "PowerPanel",
        "GetPkgName",
        "OpenPhotoLibraryPanel",
        "OpenCameraPanel",
        --"openCameraPanel",        -- 开头小写 的为V1库接口，Demo工程也是适配的
        --"openPhotoLibraryPanel", 
        "GetNumberOfCPUCores",
        "GetCPUMaxFreqKHz",
        "GetSdcardRootPath",
        "GetSDCardAvailaleSize",
        "CheckSDCardUsable",
        "GetVailMemory",
        "GetScreenWidth",
        "GetScreenHeight",
        "GetScreenMetricsWidth",
        "GetScreenMetricsHeight",
        "GettInches",
        "JumpToLink",
        "GetAndroidVersion",
        "IsInternetConnected",
        "GetPackageVersion",
        "CloseProgress",
        "GetManufacturer",
        "PopUpdateAlertView",
        "ReadBytesFromAssets",
        "ReadObbBytesFromAssets4K",
        "ExportResourceFile2OtherPath",
        "ExportResourceFile",
        "ExportResourceDirectory",
        "GetPakFiles",
        "IsOpenObb",
        "GetSettingFlag",
        "GetVideoState",
        "TestMulteCallback",
    },

    otherLuaSoure = {
        "/lua_source/platforminterface.lua",
    },

    assetsbundles = {
        model = {
            "/capsule.unity3d", 
            "/floor_cube.unity3d", 
            "/sphere.unity3d",
        },

        ui = {
            "/dropdown.unity3d",
            "/power.unity3d",
            "/head_photo.unity3d",
            "/sound_record.unity3d",
        },
    },

}

function start() 

    Debug.Log("this is main.start calling CSharp.")

    return "This is from 192.168.11.46 start.lua, --over."

end

function testFlatformFuncCallback(funcName)

    local result = PlatformInterface.CallPlatformFunc(funcName, "", function() Debug.LogToUI("This is testPlatformFuncCallback.") end )

    Debug.LogToUI(funcName.."----->:"..result)

end

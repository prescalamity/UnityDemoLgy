--主配置表，主要用来配置游戏启动时 需要下载的资源，包括 lua 源代码和 assetbundle 资源
mainconfig = {
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
        "main.lua",

        "core/ClassType.lua",
        "systool/baseclass.lua",

        "platform/platforminterface.lua",
        "platform/iflytekVoice_helper.lua",
        "platform/image_picker.lua",

        "utils/json_util.lua",
        "utils/dkjson.lua",

        "config/csenum.lua",
        
        "test/TestDevice.lua",
        --"test.lua",

    },

    assetsbundles = {
        model = {
            "capsule.unity3d", 
            "floor_cube.unity3d", 
            "sphere.unity3d",
        },

        ui = {
            "dropdown.unity3d",
            "power.unity3d",
            "head_photo.unity3d",
            "sound_record.unity3d",
        },
    },

}
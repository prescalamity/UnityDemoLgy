

require("core.ClassType")
require("systool.baseclass")

require("config.csenum")

require("utils.json_util")
require("platform.image_picker")
require("platform.platforminterface")
require("platform.iflytekVoice_helper")

require("test.TestDevice")

-- 缓存一些东西
UiRootCanvas = Main.Instance_UiRootCanvas()
GoRoot       = Main.Instance_GoRoot()

function MainStart() 

    Debug.Log("this is main.start calling CSharp.")

    TestDevice.Init()

    TestDevice.Start()
    --TestDevice.setPanelSort()


    return "This is from 192.168.11.46 start.lua, --over."

end


function MainUpdate()
    --Debug.Log("this is MainUpdate")
    TestDevice.Update()
end


function testPlatformFuncCallback(stepID, funcName)
    --local result = PlatformInterface.CallPlatformFunc(funcName, "", function() Debug.LogToUI("This is testPlatformFuncCallback.") end )
    --Debug.LogToUI(funcName.."----->:"..result)
end



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
--output       = nil


TTextMeshProUGUI                       = TMPro.TextMeshProUGUI.GetClassType()
TTMP_Text                              = TMPro.TMP_Text.GetClassType()


function MainStart() 

    Debug.Log("this is main.start calling CSharp.")

    TestDevice.Init()

    TestDevice.Start()
    --TestDevice.setPanelSort()

    -- output = UiRootCanvas.transform:Find("output").gameObject

    -- Debug.Log("lua file, Text_TMP_lgy.name:"..output.name)

    -- tmpro_text = output:GetComponent(TTextMeshProUGUI)
    -- tmpro_text.text = "main.MainStart, lgybyyyyy"

    -- Debug.Log("main.MainStart, tmpro_text.text:"..tmpro_text.text)

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

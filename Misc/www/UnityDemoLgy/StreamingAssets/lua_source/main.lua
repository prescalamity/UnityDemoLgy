maintable = {

}

function start() 
    Debug.Log("this is main.start calling CSharp.")

    return "This is from 192.168.11.46 start.lua, --over."

end

function testFlatformFuncCallback(funcName)

    local result = PlatformInterface.CallPlatformFunc(funcName, "", function() Debug.LogToUI("This is testFlatformFuncCallback.") end )

    Debug.LogToUI(funcName.."----->:"..result)

end

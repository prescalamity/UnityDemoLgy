--require("utils.json_util")
PlatformInterface = PlatformInterface or {}

local lua_callback_list = {}
local lua_callback_count = 0

--该接口主要用于 Lua 调用 java/objc 的接口（如：调用平台特性后返回的情况），其中callback是一次性非常驻的，且不会被覆盖
--key		用于约定调用的是哪个接口名
--data		string 传给java/objc的参数，如参数位置不够，请用jason包装
--callback	回调函数，带一个string参数，java/objc可以回调回来
--returnValue	string，该函数会返回一个string作为调用结果，当然也可以用json包装
function PlatformInterface.CallPlatformFunc(key, data, callback)

	if lua_callback_list["LuaCallback"] == nil then 

		Debug.Log("PlatformInterface.CallPlatformFunc.LuaCallback.UnRegisterMobileCallbackFunc1")

		lua_callback_list["LuaCallback"] = PlatformInterface.UnRegisterMobileCallbackFunc
	end

	if nil == key then
		return ""
	end

	if nil == data then
		data = ""
	end

	local callback_handle = ""


	Debug.Log("PlatformInterface.CallPlatformFunc.key:"..key)

	if callback and "function" == type(callback) then

		lua_callback_count = lua_callback_count + 1
		callback_handle = tostring(lua_callback_count)
		lua_callback_list[callback_handle] = callback

		Debug.Log("PlatformInterface.CallPlatformFunc.callback: not nil. and callback_handle:"..callback_handle)

	else
		Debug.Log("PlatformInterface.CallPlatformFunc.callback: nil")
	end

	return PlatformAdapter.CallPlatformFunc(key, data, callback_handle)
end


--该接口主要用于注册 java/objc 调用 Lua 的接口（如：监听和登出回调），其调用是常驻的，且可以被覆盖，若确需清理时手动调用清理
function PlatformInterface.RegisterMobileCallbackFunc(key, callback)

	if not key then
		Debug.Log("error : the key can't be nil")
		return
	end

	if callback and "function" == type(callback) then
		lua_callback_list[key] = callback
	else
		Debug.Log("error in RegisterMobileCallbackFunc : the key had already been register")
	end
end

-- 清理指定的注册接口
function PlatformInterface.UnRegisterMobileCallbackFunc(key)
	Debug.Log("PlatformInterface.UnRegisterMobileCallbackFunc.key:"..tostring(key))
	if key then
		lua_callback_list[key] = nil
	end

end


-- 用于接收平台调用Lua
function PlatformInterface.CallScriptFunc(message)

	Debug.LogToUI("PlatformInterface.CallScriptFunc.message:"..message)

	-- local json_obj = JsonUtil.ReadJsonStr(message)
	-- local callback_handle = json_obj["callback"]
	-- local data = json_obj["data"]


	-- if callback_handle == nil then
	-- 	Debug.Log("error in CallScriptFunc : callback_handle can't be nil")
	-- 	return
	-- end

	-- local callback = lua_callback_list[callback_handle]

	-- if callback and "function" == type(callback) then
	-- 	callback(data)
	-- end

end



function PlatformInterface.SDKLogout(param)

	PlatformAdapter.Logout(param)
end


-- 注册登出回调，其调用是常驻的，可以被覆盖
function PlatformInterface.RegisterLogoutCallback()

	local callback = function() 
		Debug.Log("SDK logouted.") 
	end

	PlatformInterface.RegisterMobileCallbackFunc("logout", callback)
end
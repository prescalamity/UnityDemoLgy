JsonUtil = JsonUtil or {}

function JsonUtil.Init()
end

function JsonUtil.ReadJsonStr(str)
	if str == nil then
		logwarn("json str is nil ", debug.traceback() )
		return 
	end
	local json = require("utils.dkjson")
	return json.decode( str, 1, nil )
end


function JsonUtil.WriteJsonStr(str)
	if str == nil then
		logwarn("json str is nil ", debug.traceback() )
		return 
	end
	local json = require("utils.dkjson")
	return json.encode( str , {indent = true} )
end



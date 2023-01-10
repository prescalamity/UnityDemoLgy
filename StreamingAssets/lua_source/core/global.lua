if not REAL_LUA_REQUIRE then -- 防止reload的时候重新执行
  REAL_LUA_REQUIRE = require
  require = function (require_file)
    local origin_require_file = require_file
    if string.sub(require_file, -4, -1) == ".lua" then
      if logerror then
        logerror('require path '..origin_require_file..' contain .lua')
      end
      require_file = string.sub(require_file, 1, -5)
    end
    if string.find(require_file, '/') then
      if logerror then
        logerror('require path '..origin_require_file..' contain /')
      end
      require_file = string.gsub(require_file, '/', '.')
    end
    if string.find(require_file, '\\') then
      if logerror then
        logerror('require path '..origin_require_file..' contain \\')
      end
      require_file = string.gsub(require_file, '\\', '.')
    end
    return REAL_LUA_REQUIRE(require_file)
  end
end

-- require "common.ulualib.Wrap"
if jit then	
	jit.off()	
	if jit.opt then
		jit.opt.start(3)	
	end
end
 
--默认就开启debug module
OPEN_DEBUG_MODULE = true
-- local function appendFile(fileName,content)
--     local f = assert(io.open(fileName,'a'))
--     f:write(content)
--     f:close()
-- end 

-- local fileName = "C:\\gamelog.txt"
-- os.remove(fileName)
-- setmetatable(_G, {__newindex = function(t,k,v)
--  local info = debug.getinfo(2, "lS")
--  appendFile(fileName, "k:" .. tostring(k) .. " == type:" .. type(v) .. " == short_src:" .. info.short_src .. " == currentline:" .. info.currentline .. "\n\r" )
--  rawset(t, k, v)
-- end}
-- )
g_traceback = g_traceback or debug.traceback
if  OPEN_DEBUG_MODULE == false then --不开启debug模块 则覆该模块
	debug.traceback = function( ) end
	debug.getinfo = function() end
  --  {"getuservalue", db_getuservalue},
  -- {"gethook", db_gethook},
  -- {"getinfo", db_getinfo},
  -- {"getlocal", db_getlocal},
  -- {"getregistry", db_getregistry},
  -- {"getmetatable", db_getmetatable},
  -- {"getupvalue", db_getupvalue},
  -- {"upvaluejoin", db_upvaluejoin},
  -- {"upvalueid", db_upvalueid},
  -- {"setuservalue", db_setuservalue},
  -- {"sethook", db_sethook},
  -- {"setlocal", db_setlocal},
  -- {"setmetatable", db_setmetatable},
  -- {"setupvalue", db_setupvalue},
  -- {"traceback", db_traceback},
end



function traceback(msg)
	msg = msg or "traceback"
	if OPEN_DEBUG_MODULE or OPEN_DEBUG_MODULE == nil then
		msg = debug.traceback(msg, 2)
	elseif g_traceback then
		msg = g_traceback(msg, 2)
	end
	return msg
end


-------------------------------------------------------------------------------
--      Copyright (c) 2015 , 蒙占志(topameng) topameng@gmail.com
--      All rights reserved.
--      Use, modification and distribution are subject to the "MIT License"
-------------------------------------------------------------------------------


require("common.ulualib.bit")
require("common.ulualib.Math") 
require("common.ulualib.Mathf") 

Vector3 = require("common.ulualib.Vector3") 
require("common.ulualib.Quaternion") 

Vector2 = require("common.ulualib.Vector2") 
require("common.ulualib.Vector4") 
require("common.ulualib.Color") 
require("common.ulualib.Ray") 
require("common.ulualib.Raycast") 
require("common.ulualib.Layer") 
require("common.ulualib.Touch") 

require("common.ulualib.Bounds") 
require("common.ulualib.RaycastHit") 

require("common.ulualib.list") 
require("common.ulualib.Time") 
require("common.ulualib.utf8") 

require("common.ulualib.slot") 
require("common.ulualib.typeof") 
require("common.ulualib.event") 
require("common.ulualib.Timer") 
require("common.ulualib.coroutine") 
require("common.ulualib.Plane") 

require("common.ulualib.ValueType")

--require "misc/strict"


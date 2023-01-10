--保存类类型的虚表
_class = _class or {}
-- 之前是保存为local变量，会导致在reload之后BaseClass构建的新类无法与旧类形成父子关系
-- 将_class变量放到全局表之后，可以修复这个问题
-- 目前还存在的问题：reload之前所形成的继承关系，在reload之后也无法更新为新的继承关系
-- 造成无法更新类继承关系的原因：每个类都是XXX = XXX or BaseClass(XX)的写法，导致reload不会重建XXX

GLOBAL_OBJ_COUNT = {}

Debug.Log("this is baseclass.lua.")

-- OPEN_PROFILER_SAMPLE = false

if OPEN_PROFILER_SAMPLE then
	ENABLE_OBJ_COUNT = 1
else
	ENABLE_OBJ_COUNT = 0
end

ENABLE_OBJ_COUNT = 0

function FindClassName(target, depth)
	for key,value in pairs(_G) do
		if value == target then
			return key
		end
	end
end

function ClasCountRetain(c)
	local key = FindClassName(c)
	if GLOBAL_OBJ_COUNT[key] == nil then
		GLOBAL_OBJ_COUNT[key] = 1
	else
		GLOBAL_OBJ_COUNT[key] = GLOBAL_OBJ_COUNT[key] + 1
	end
end

function ClasCountRelease(c)
	local key = FindClassName(c)
	if GLOBAL_OBJ_COUNT[key] == nil then
		GLOBAL_OBJ_COUNT[key] = -100000--标识异常
	else
		GLOBAL_OBJ_COUNT[key] = GLOBAL_OBJ_COUNT[key] - 1
	end
end




function PrintLuaClassCount( ... )
	loginfo("PrintLuaClassCount_begin............")
	for key,value in pairs(GLOBAL_OBJ_COUNT) do
		loginfo("LuaClassCount:"..key..":",value)
	end

	loginfo("PrintLuaClassCount_end............")
end

local UI_DIC = {
	["UIWidget"] = true,
	["UIScrollViewContent"] =  true,
	["UIButton"] = true,
	["UIRichlabel"] = true,
	["UILabel"] = true,
	["UISprite"] = true,
	["UIWidgetContainer"] = true,
	["UIInput"] = true,
	["UIPanel"] = true,
	["UITexture"] = true,
	["UISlider"] = true,
	["UIExFrameASprite"] = true,
	["UIToggle"] = true,
	["UnityEngine.GameObject"] = true,
	["UnityEngine.Transform"] = true,
	["ExUIButton"] = true,
	["TweenAlpha"] = true,
	["TweenRotation"] = true,

	--for T4
	["UIScrollViewSystem"] = true,
	["UnityEngine.BoxCollider"] = true,
	["TweenScale"] = true,
	["ScrollUVHelper"] = true,
	["TweenPosition"] = true,
}


local function CheckIsUIComponent(v)
	if not v then
		return false
	end

	local v_type = type(v)
	if "userdata" == v_type then
		if  v.GetClassType then
			local component_type = v:GetClassType()
			-- loginfo("component_type ", component_type, tostring(component_type), tbl.layout_name )
			if UI_DIC[tostring(component_type)] then
				return true
			end
		end
	elseif "table" == v_type then
		if v.DeleteMeWhenCloseView and v.DeleteMeWhenCloseView == true then
			return true
		end
	end

	return false
end

local HasCheckIsEditor = false
local CheckIsEditor = false
local function CheckNoticeDepthComponent(...)
    if not HasCheckIsEditor then
        HasCheckIsEditor = true
        CheckIsEditor = UnityEngineApplication.isEditor
    end
    if CheckIsEditor and NoticeDepthComponent then
        NoticeDepthComponent(...)
    end
end

function BaseClass(super)

	-- 生成一个类类型
	local class_type = {}
	-- 在创建对象的时候自动调用
	class_type.__init = false
	class_type.__delete = false
	class_type.super = super

	class_type.New = function(...)
		-- 生成一个类对象
		local obj = {}
		
		local index_tbl
		local newindex_function
		local obj_data = {}

		obj._class_type = class_type
		class_type._new_tag = "BaseClass"

		if super and super.BASE_UI_TAG then
			setmetatable(obj_data, { __index = _class[class_type]})
			index_tbl = obj_data
			newindex_function = function (tbl, k, v)
				if not tbl["ui_tag"] then
					rawset(tbl,"ui_tag", {})
				end 
				if v ~= nil then
					local v_type = type(v)
					if CheckIsUIComponent(v) or CheckIsUIComponent(k) then
						-- tbl.ui_tag[ #tbl.ui_tag  + 1 ] = k
						table.insert(tbl.ui_tag, k)
					elseif v_type == "table" and  not next(v)  then
						
						setmetatable(v, { 
							__newindex = function (tbl2, k2, v2)
								local v2_type = type(v2)
								if CheckIsUIComponent(v2) or CheckIsUIComponent(k2) then
									if not tbl.ui_tag[k] then tbl.ui_tag[k] = {} end
									table.insert(tbl.ui_tag[k], k2)
								elseif v2_type == "table" and  not next(v2)  then
									
									setmetatable( v2, {
										__newindex = function (tbl3, k3, v3)
											local v3_type = type(v3)
											if CheckIsUIComponent(v3) or CheckIsUIComponent(k3) then
												if not tbl.ui_tag[k] then tbl.ui_tag[k] = {} end
												if not tbl.ui_tag[k][k2] then tbl.ui_tag[k][k2] = {} end
												table.insert(tbl.ui_tag[k][k2], k3)
												-- tbl.ui_tag[ #tbl.ui_tag +1 ] = k ..Insert(k2) .. k2..Insert(k3) .. k3
											elseif v3_type == "table" and  not next(v3)  then
												setmetatable( v3, {
													__newindex = function (tbl4, k4, v4)
														CheckNoticeDepthComponent(obj.layout_name)
														rawset(tbl4, k4, v4)
													end
													} )
											end
											rawset(tbl3, k3, v3)
										end
										} )

								end
								rawset( tbl2, k2, v2 )
							end  } 
						) 
					end
				end

				obj_data[k] = v
			end
		else
			index_tbl = _class[class_type]
			newindex_function = rawset
		end

		-- 在初始化之前注册基类方法
		setmetatable(obj, { 
			__index = index_tbl ,  
			__newindex = newindex_function
		})

		-- 调用初始化方法
		do
			local create 
			create = function(c, ...)
				if c.super then
					create(c.super, ...)
				end
				if ENABLE_OBJ_COUNT ~= 0 then
					ClasCountRetain(c)
				end
				if c.__init then
					c.__init(obj, ...)
				end
			end

			create(class_type, ...)
		end

		-- 注册一个delete方法
		obj.DeleteMe = function(self)
			local now_super = self._class_type 
			while now_super ~= nil do
				if ENABLE_OBJ_COUNT ~= 0 then
					ClasCountRelease(now_super)
				end	
				if now_super.__delete then
					now_super.__delete(self)
				end
				now_super = now_super.super
			end
		end

		return obj
	end

	local vtbl = {}
	_class[class_type] = vtbl	

	setmetatable(class_type, {
		__index = vtbl, --For call parent method
		__newindex = vtbl,
	})

	if super then
		setmetatable(vtbl, { __index = _class[super] })
	end

	return class_type
end
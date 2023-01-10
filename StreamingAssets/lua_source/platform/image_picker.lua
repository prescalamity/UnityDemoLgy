Image_Picker = Image_Picker  or {}

--头像
function Image_Picker.OpenPhotoLibrary(callback)
	local isSucceed = false
	local local_callback = function (data)
		local json_obj = JsonUtil.ReadJsonStr(data)
		local result_succeed = json_obj["isSucceed"]
		local file_name = json_obj["file_name"]
		callback(result_succeed,file_name)
	end
	local result_str = PlatformInterface.CallPlatformFunc("OpenPhotoLibrary",nil,local_callback)
	isSucceed = (result_str=="true" and {true} or {false})[1]
	return isSucceed
end


function Image_Picker.OpenCamera(callback)
	local isSucceed = false
	local local_callback = function (data)
		local json_obj = JsonUtil.ReadJsonStr(data)
		local result_succeed = json_obj["isSucceed"]
		local file_name = json_obj["file_name"]
		callback(result_succeed,file_name)
	end
	local result_str = PlatformInterface.CallPlatformFunc("OpenCamera",nil,local_callback)
	isSucceed = (result_str=="true" and {true} or {false})[1]
	return isSucceed
end

-- function Image_Picker.TakePhoto(callback) --旧接口，暂时不用，使用OpenCamera
-- 		loginfo("新接口： TakePhoto")
-- 		local local_callback = function (data)
--           local json_obj = JsonUtil.ReadJsonStr(data)
--           local isFileNameExist = json_obj["isFileNameExist"]
--           local file_name = json_obj["file_name"]
--           callback(isFileNameExist,file_name)
--         end
-- 		local result_str = PlatformInterface.CallPlatformFunc("TakePhoto","takePhoto",local_callback)
-- 		isSucceed = (result_str=="true" and {true} or {false})[1]
--     return isSucceed
-- end

function Image_Picker.ResizeJpegImage(src_jpeg_file_path,dest_jpeg_file_path,width,height,quality)
	local isSucceed = false
	local params = {
		src_jpeg_file_path = ImagePicker.GetInstance():getTempPath() .. src_jpeg_file_path,
		dest_jpeg_file_path = ImagePicker.GetInstance():getTempPath() .. dest_jpeg_file_path,
		width = width,
		height = height,
		quality = quality
	}
	local jsonStr = JsonUtil.WriteJsonStr(params)
	--local result_str = PlatformInterface.CallPlatformFunc("ResizeJpegImage",jsonStr,nil)
	local result_str = PlatformInterface.CallPlatformFunc("CropJpegImage",jsonStr,nil)
	isSucceed = (result_str=="true" and {true} or {false})[1]
	
	return isSucceed
end
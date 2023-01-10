
TestDevice = TestDevice or {}

-- 检测安卓设备

testDeviceBases = {}
stepID = 0

function TestDevice.Init()

    MainTestButton = UiRootCanvas.transform:Find("test_button").gameObject:GetComponent(TButton)
    MainTestButton:AddListener(TestDevice.MainButtonTestFunction)

    MainDropdown = UiRootCanvas.transform:Find("dropdown").gameObject:GetComponent(TTMP_Dropdown)

    testDeviceBases["TestPower"] = TestPower.New()
    -- testDeviceBases:Add(new TestPermission())
    testDeviceBases["TestHeadPhoto"] = TestHeadPhoto.New()
    --testDeviceBases["TestSoundRecord"] = TestSoundRecord.New()
end


function TestDevice.setPanelSort()

end

function TestDevice.MainButtonTestFunction()

    stepID = stepID + 1

    local functionName = MainDropdown:SelectedText()

    Debug.Log("TestDevice.MainButtonTestFunction, You select test : "..functionName)

    for k, v in pairs(testDeviceBases) do
        v:MainButtonTestFunction(stepID, functionName)
    end
end

function TestDevice.Start()
    -- Debug.Log("function TestDevice.Start")

    for k, v in pairs(testDeviceBases) do
        v:Start()
    end

    -- local dasd = TestExtenal.New()
    -- dasd:Start() 
    -- Debug.Log("function TestDevice.Start, dasd.m_id: "..dasd.m_id)
    -- Debug.Log("function TestDevice.Start, dasd.m_idExt: "..dasd.m_idExt)
end


function TestDevice.Update()
    for k, v in pairs(testDeviceBases) do
        v:Update()
    end

end



--============================================================ TestBase start ============================================================================

TestBase = TestBase or BaseClass()

function TestBase:__init()
  self.mThePanelGo = nil
  self.m_name = "TestExtenal"
  self.m_id = "TestBase2023"
end

function TestBase:setPanelSort() 
    if self.mThePanelGo then
        self.mThePanelGo.transform:SetAsLastSibling()
    end
end

function TestBase:Start() 
    --Debug.Log("this is TestBase:Start in TestDevice.")

end

function TestBase:Update() 
end

function TestBase:MainButtonTestFunction( stepID, functionName , thePanelnameArray ) 

    --Debug.Log("function TestBase.MainButtonTestFunction.0, stepID:".. stepID ..", functionName:" .. functionName..", self.mThePanelGo:"..self.mThePanelGo.name)

    if functionName and thePanelnameArray  and self.mThePanelGo then
    
        Debug.Log("function TestBase.MainButtonTestFunction.1")
        local isCurThePanle = false

        for i=1 , #thePanelnameArray do
            if functionName == thePanelnameArray[i] then  
                isCurThePanle = true 
                break 
            end
        end

        self.mThePanelGo:SetActive(isCurThePanle)

        if isCurThePanle then
            self:setPanelSort()
        end
    end


end



-- 测试 lua 继承、覆盖 是否有效
-- TestExtenal = TestExtenal or BaseClass(TestBase)

-- function TestExtenal:__init()
--     self.mThePanelGo = nil
--     self.m_name = "TestExtenal"
--     self.m_idExt = "202301091117"
-- end

-- function TestExtenal:Start() 
--     TestBase:Start()
--     Debug.Log("this is TestExtenal:Start in TestDevice.ua.")
-- end

-- function TestExtenal:TestLgy() 
--     Debug.Log("this is TestExtenal:TestLgy in TestDevice.lua.")
-- end

--============================================================ TestPower start ============================================================================

-- 检测安卓设备电量
TestPower = TestPower or BaseClass(TestBase)

function TestPower:__init()
    self.battery_capacity_value = nil
    self.battery_electricity_value = nil
    self.battery_voltage_value = nil
    self.battery_retain_value = nil
    self.battery_retain_time_value = nil
    self.battery_get_api_time_value = nil
end


function TestPower:MainButtonTestFunction( stepID,  functionName ,  thePanelname) 
    TestBase.MainButtonTestFunction(self, stepID,  functionName,  { "PowerPanel" } )

    self.battery_capacity_value.text = tostring(Power.GetCapacity())
    self.battery_voltage_value.text = tostring(Power.GetVoltage())
    self.battery_retain_value.text = tostring(Power.GetBatteryRetain())
end

function TestPower:Start()
    Debug.LogToUI("AndroidDevicePower.Start")
    TestBase.Start(self)   -- 调用父类函数

    self.mThePanelGo = UiRootCanvas.transform:Find("power").gameObject

    self.battery_capacity_value = self.mThePanelGo.transform:Find("battery_capacity_value").gameObject:GetComponent(TTMP_Text)

    self.battery_electricity_value = self.mThePanelGo.transform:Find("battery_electricity_value").gameObject:GetComponent(TTMP_Text)

    self.battery_voltage_value = self.mThePanelGo.transform:Find("battery_voltage_value").gameObject:GetComponent(TTMP_Text)
    self.battery_retain_value = self.mThePanelGo.transform:Find("battery_retain_value").gameObject:GetComponent(TTMP_Text)
    self.battery_retain_time_value = self.mThePanelGo.transform:Find("battery_retain_time_value").gameObject:GetComponent(TTMP_Text)
    self.battery_get_api_time_value = self.mThePanelGo.transform:Find("battery_get_api_time_value").gameObject:GetComponent(TTMP_Text)

    Debug.LogToUI("TestPower.Start: " .. self.battery_electricity_value.text)

end

e = 0
t = 0
function TestPower:Update()
    if not self.mThePanelGo.activeInHierarchy then return end

    if UnityEngine.Time.time - t > 0.1 then
        t = UnityEngine.Time.time
        e = Power.GetElectricity()

        Debug.LogToUI("TestPower.Update"..tostring(e))

        self.battery_electricity_value.text = tostring(e)

        self.battery_get_api_time_value.text = tostring(Power.GetApiDeltaTime())
        self.battery_retain_time_value.text = string.format("%.2f", (Power.GetCapacity() * Power.GetBatteryRetain() / 100 / e))
    end
end



--============================================================ TestPermission start ============================================================================


-- -- 测试 android 权限，测试 V1平台版本 接口

-- TestPermission = TestPermission or {}


-- function TestPermission.MainButtonTestFunction(int stepID, string functionName = "", string[] thePanelName = nil)
--     --PlatformInterface.CallPlatformFunc("openCamera", "", "")

-- #if UNITY_ANDROID and !UNITY_EDITOR
--         AndroidJavaClass androidclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
--         AndroidJavaObject jo = androidclass.GetStatic<AndroidJavaObject>("currentActivity")

--         jo.Call(functionName)
--         androidclass.Dispose()
--         jo.Dispose()

-- #elif UNITY_IOS and !UNITY_EDITOR
--         --return QdHSSSFromLJB(key, data, lua_callback)
-- #endif
    

-- end


--============================================================ TestHeadPhoto start ============================================================================


-- 测试头像功能

TestHeadPhoto = TestHeadPhoto or BaseClass(TestBase)


function TestHeadPhoto:__init()

    self.image = nil

    self.btnOpenPhotoLib = nil
    self.btnOpenCamera = nil

end

--GameObject _tempGo

function TestHeadPhoto:Start()

    TestBase.Start(self)   -- 调用父类函数

    Debug.Log("function TestHeadPhoto.Start")

    self.mThePanelGo = UiRootCanvas.transform:Find("head_photo").gameObject

    self.image = self.mThePanelGo.transform:Find("image").gameObject:GetComponent(TImage)

    self.btnOpenPhotoLib = self.mThePanelGo.transform:Find("open_photo_library").gameObject:GetComponent(TButton)


    local OpenHeadPhotoCB = function(cbData)

        Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB-->" .. cbData)

        local json_obj = JsonUtil.ReadJsonStr(cbData)
        local fileName = json_obj["file_name"]

        local fileDestPath = Util.m_temporary_cache_path .. "/xxx_" .. fileName

        local params = {
            src_jpeg_file_path = Util.m_temporary_cache_path .. "/" .. fileName,
            dest_jpeg_file_path = fileDestPath,
            width = 200,
            height = 200,
            quality = 100
        }
        local jsonStr = JsonUtil.WriteJsonStr(params)


        Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB.sb-->" .. jsonStr)


        local resizeRes = PlatformInterface.CallPlatformFunc("CropJpegImage", jsonStr, "")

        if resizeRes and resizeRes == "true" then
        
            Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:ok")

            DownloadResources.AsyncLoadTexture(Util.AddLocalFilePrex(fileDestPath), self.image)
        
        else
        
            Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:no")
        end

    end
    
    self.btnOpenPhotoLib:AddListener( function() PlatformInterface.CallPlatformFunc("OpenPhotoLibrary", "", OpenHeadPhotoCB) end )

    self.btnOpenCamera = self.mThePanelGo.transform:Find("open_camera").gameObject:GetComponent(TButton)
    self.btnOpenCamera:AddListener( function() PlatformInterface.CallPlatformFunc("OpenCamera", "", OpenHeadPhotoCB) end )

end

function TestHeadPhoto:MainButtonTestFunction( stepID,  functionName ,  thePanelName ) 

    TestBase.MainButtonTestFunction(self, stepID, functionName, { "OpenCameraPanel", "OpenPhotoLibraryPanel" })

end


-- function TestHeadPhoto:OpenHeadPhotoCB( cbData)

--     Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB-->" .. cbData)

--     local json_obj = JsonUtil.ReadJsonStr(cbData)
--     local fileName = json_obj["file_name"]

--     -- local json_obj = JsonUtil.ReadJsonStr(data)
--     -- local result_succeed = json_obj["isSucceed"]
--     -- local file_name = json_obj["file_name"]

-- 	local params = {
-- 		src_jpeg_file_path = Util.m_temporary_cache_path .. "/" .. fileName,
-- 		dest_jpeg_file_path = Util.m_temporary_cache_path .. "/xxx_" .. fileName,
-- 		width = 200,
-- 		height = 200,
-- 		quality = 100
-- 	}
-- 	local jsonStr = JsonUtil.WriteJsonStr(params)


--     Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB.sb-->" .. jsonStr)


--     local resizeRes = PlatformInterface.CallPlatformFunc("CropJpegImage", jsonStr, "")

--     if resizeRes and resizeRes == "true" then
    
--         Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:ok")


--         DownloadResources.AsyncLoadTexture(Util.AddLocalFilePrex(fileDestPath), self.image)
    
--     else
    
--         Debug.LogToUI("function TestHeadPhoto.OpenPhotoLibraryCB-->ResizeJpegImage:no")
--     end

-- end




--============================================================ TestSoundRecord start ============================================================================

-- 测试录音
TestSoundRecord = TestSoundRecord or BaseClass(TestBase)

function TestSoundRecord:__init()

    self.voiceCount = 10000

    self.btnRecordSound = nil
    self.btnRecordSoundEvent = nil
    self.btnPlaySound = nil
    self.btnToWords = nil
    self.recordingTip = nil

    self.audioSource = nil
    self.audioName = "/record.wav"

    self.appId = "90d09164"
    self.apiSecret = "YTEwMjU2OTEwMTc3MzUwMjY5YjlmMTkx"
    self.apiKey = "3287d1186dbe24add8a383230eb2d0d9"
end

function TestSoundRecord:Start()

    TestBase.Start(self)

    self.mThePanelGo = UiRootCanvas.transform:Find("sound_record").gameObject

    self.btnRecordSound = self.mThePanelGo.transform:Find("record").gameObject:GetComponent(TButton)
    --self.btnRecordSound:AddListener( () => PlatformInterface.CallPlatformFunc("", "", "") )

    self.btnRecordSoundEvent = self.btnRecordSound.gameObject:AddComponent(TEventTrigger)
    self.btnRecordSoundEvent:AddListener(2, IflytekVoice_Helper.VoiceStart)
    self.btnRecordSoundEvent:AddListener(3, IflytekVoice_Helper.VoiceStop)

    self.btnPlaySound = self.mThePanelGo.transform:Find("play").gameObject:GetComponent(TButton)
    self.btnPlaySound:AddListener(self.PlaySound)

    self.btnToWords = self.mThePanelGo.transform:Find("to_words").gameObject:GetComponent(TButton)
    --self.btnToWords:AddListener(() => PlatformInterface.CallPlatformFunc("", "", ""))

    self.recordingTip = self.mThePanelGo.transform:Find("recording_tip").gameObject:GetComponent(TTMP_Text)

    self.audioSource = GoRoot:AddComponent(AudioSource)
    self.audioSource.playOnAwake = false

    --初始化录音功能范例
    IflytekVoice_Helper.Init()

end


function TestSoundRecord:MainButtonTestFunction( stepID,  functionName , thePanelName)

    TestBase.MainButtonTestFunction(self, stepID, functionName, { "SoundPanel" })

end



function TestSoundRecord:PlaySound()
    Debug.LogToUI("function TestSoundRecord:PlaySound")

    DownloadResources.AsyncLoadAudio( Util.AddLocalFilePrex(self.m_IflytekVoiceHelper.GetVoicePath() .. self.audioName), AudioType.WAV,
        function(data)
            if data then return end
            self.audioSource.clip = data
            self.audioSource:Play()
        end
    )
    
end


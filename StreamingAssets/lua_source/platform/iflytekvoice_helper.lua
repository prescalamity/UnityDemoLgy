IflytekVoice_Helper = IflytekVoice_Helper  or {}
local iflytekVoiceHelperInstance = IflytekVoiceHelper.GetInstance()

function IflytekVoice_Helper.Init()
  --初始化录音功能范例
  local appId = "90d09164"
  local apiSecret = "YTEwMjU2OTEwMTc3MzUwMjY5YjlmMTkx"
  local apiKey = "3287d1186dbe24add8a383230eb2d0d9"
  local path = Util.m_persistent_data_path
  iflytekVoiceHelperInstance:Init(appId, apiSecret, apiKey, path) --初始化语音功能，调用一次即可
  iflytekVoiceHelperInstance.Frequency = 8000
  iflytekVoiceHelperInstance.RecordTime = 8
end

function  IflytekVoice_Helper.VoiceStart(record_finish_func,translate_finish_func)
  local record_finish_callbak = function (recordCode, recordFile, recordLen)
    Debug.LogToUI("结果码：", recordCode)
    if recordCode == 0 or recordCode == 1 or recordCode == 2 then 
        Debug.LogToUI("录音成功，录音文件：", recordFile, "; 录音长度：", recordLen, "秒")
        if recordCode == 1 then 
            Debug.LogToUI("Warning: 找不到输入的麦克风，使用默认麦克风录音")
        elseif recordCode == 2 then 
            Debug.LogToUI("Warning: 麦克风不支持指定的录音频率")
        end
    elseif recordCode == 100 then
        Debug.LogToUI("录音失败，没有获取到麦克风使用权限")
    elseif recordCode == 101 then 
        Debug.LogToUI("录音失败，上一次使用录音还未正常退出")
    elseif recordCode == 102 then 
        Debug.LogToUI("录音失败，上一次使用语音翻译还未正常退出")
    elseif recordCode == 104 then 
        Debug.LogToUI("录音失败，没有找到麦克风设备进行录音")
    elseif recordCode == 105 then 
        Debug.LogToUI("录音失败，异常的失败")
    elseif recordCode == 106 then
        Debug.LogToUI("录音失败，AudioClip数据异常的失败")
    elseif recordCode == 107 then 
        Debug.LogToUI("录音失败，没有录取到声音")
    elseif recordCode == 108 then 
        Debug.LogToUI("录音失败，不支持的采样样本位")
    end
    Debug.LogToUI("IflytekVoice_Helper recordCode "..recordCode.." recordFile "..recordFile.." recodeLen "..recordLen)
    --这里会返回的错误码可能有很多，只需要对101和102作出处理
    if recordCode == 101 or recordCode == 102 then
      iflytekVoiceHelperInstance:Reset()
    end
    if recordCode == 0 or recordCode == 1 or recordCode == 2 then
      record_finish_func(true, recordFile, recordLen)
    else 
      record_finish_func(false, nil, 0)
    end
  end

  local translate_finish_callback = function (translateCode, translateText, translateTime)
    Debug.LogToUI("结果码：", translateCode)
    if translateCode == 0 or translateCode == 1 or translateCode == 2 then 
        Debug.LogToUI("翻译成功，翻译后文字：", translateText, "; 翻译时长：", translateTime, "秒")
        if translateCode == 1 then 
            Debug.LogToUI("Warning: 找不到输入的麦克风，使用默认麦克风录音")
        elseif translateCode == 2 then 
            Debug.LogToUI("Warning: 麦克风不支持指定的录音频率")
        end
    elseif translateCode == 100 then
        Debug.LogToUI("翻译失败，没有获取到麦克风使用权限")
    elseif translateCode == 101 then 
        Debug.LogToUI("翻译失败，上一次使用录音还未正常退出")
    elseif translateCode == 102 then 
        Debug.LogToUI("翻译失败，上一次使用语音翻译还未正常退出")
    elseif translateCode == 104 then 
        Debug.LogToUI("翻译失败，没有找到麦克风设备进行录音")
    elseif translateCode == 105 then 
        Debug.LogToUI("翻译失败，异常的失败")
    elseif translateCode == 106 then
        Debug.LogToUI("翻译失败，AudioClip数据异常的失败")
    elseif translateCode == 107 then 
        Debug.LogToUI("翻译失败，没有录取到声音")
    elseif translateCode == 108 then 
        Debug.LogToUI("翻译失败，不支持的采样样本位")
    elseif translateCode == 103 then 
        Debug.LogToUI("翻译失败，翻译服务的Socket连接过程中出错")
    elseif translateCode == 109 then 
        Debug.LogToUI("翻译失败，Socket连接出错")
    end
    Debug.LogToUI("IflytekVoice_Helper translateCode "..translateCode.." translateText "..translateText.." translateTime "..translateTime)
    --这里会返回的错误码可能有很多，只需要对101和102作出处理
    if translateCode == 101 or translateCode == 102 then
      iflytekVoiceHelperInstance:Reset()
    end
    if translateCode == 0 or translateCode == 1 or translateCode == 2 then
      translate_finish_func(true, translateText, translateTime)
    else 
      translate_finish_func(false, nil, 0)
    end
  end
  
  iflytekVoiceHelperInstance:VoiceStart(record_finish_callbak,translate_finish_callback)
end

function  IflytekVoice_Helper.VoiceStop()
  iflytekVoiceHelperInstance:VoiceStop()
end 


function IflytekVoice_Helper.IsRecording() 
    return iflytekVoiceHelperInstance.IsRecording
end

function IflytekVoice_Helper.EnterRecord()
    return iflytekVoiceHelperInstance.EnterRecord
end

function  IflytekVoice_Helper.Reset()
  iflytekVoiceHelperInstance:Reset()
end 
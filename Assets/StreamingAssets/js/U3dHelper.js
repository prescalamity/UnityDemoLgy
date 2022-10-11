var U3dHelper = (function ()
{

    function U3dHelper(){};   
    
    // 以下接口用于获取浏览器相关信息

    U3dHelper.Hello = function()
    {

        console.log("U3dHelper.Hello: Hello, world!");

    }

    U3dHelper.IsHttp = function()
    {
        var protocolStr = document.location.protocol;
        if(protocolStr == "http:")
        {
            return "true";
        }
        else
        {
            return "false";
        }
    }

    U3dHelper.IsHttps = function()
    {
        var protocolStr = document.location.protocol;
        if(protocolStr == "https:")
        {
            return "true";
        }
        else
        {
            return "false";
        }
    }

    U3dHelper.JumpToLink = function(value)
    {
        window.open(value);
        return "JumpToLink over";
    }

    U3dHelper.IsWX = function()
    {
      if(typeof wx == "undefined")
      {
        return "false";
      }
      else
      {
        return "true";
      }
    }

    U3dHelper.GetAppid = function()
    {
        //构造一个含有目标参数的正则表达式对象
		var reg = new RegExp("(^|&)" + "appid" + "=([^&]*)(&|$)");
		//匹配目标参数
		var r = window.location.search.substring(1).match(reg);
		//返回参数值
		if(r != null) {
			return decodeURI(r[2]);
		}
		return "";
    }

    return U3dHelper;

}());

window.U3dHelper = U3dHelper;
mergeInto(LibraryManager.library, {

  Hello: function (msg) {
    //window.alert("Hello, world!");
    console.log("unity_js: Hello, world! " + UTF8ToString(msg));

    //window.U3dHelper.Hello();
  },

  HelloString: function (str) {
    window.alert(UTF8ToString(str));
  },

  PrintFloatArray: function (array, size) {
    for(var i = 0; i < size; i++)
    console.log(HEAPF32[(array >> 2) + i]);
  },

  AddNumbers: function (x, y) {
    return x + y;
  },

  StringReturnValueFunction: function () {
    var returnStr = "bla";
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },

  
  PlayVideo: function( videoSrc ){

    console.log("lgy: unity_js playVideo start..." + UTF8ToString(videoSrc));

    //window.location = "https://www.baidu.com";
    //window.navigate("https://www.baidu.com");
    //window.location.replace("https://www.baidu.com");
  }


});




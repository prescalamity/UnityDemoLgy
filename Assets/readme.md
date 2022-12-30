相比于一般的应用软件，Unity实现复杂的模型数据 表现和交互，如：游戏。



-------------------------------------------------------------------------------------------------------
本项目打ipa包时，导出的xcode工程可能会少一些库，需手动添加：

问题1: iOS error “_OBJC_CLASS_$_ASIdentifierManager”, referenced from: objc-class-ref in
解决方案: 选中TARGETS： Build Phases/Link Binary With Libraries(24 items)
添加AdSupport.Framework类库即可

libc++.tbd
libresolve.tbd
libz.tbd

AssetsLibrary.framework
-------------------------------------------------------------------------------------------------------

ios 取消 bitcode



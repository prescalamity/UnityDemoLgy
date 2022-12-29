
#import <Foundation/Foundation.h>

#import <UIKit/UIKit.h>

#import "LuaCallback.h"


//sdk中继承该协议
@protocol PTSdkCallback<NSObject>
@required
-(void) _QdInit;
-(void) _QdPushLogin;
-(void) _QdPMWithAmount:(NSInteger)amount
                     chargeId:(NSInteger)chargeId
                        price:(NSInteger)price
                          sid:(NSInteger)sid
                          rid:(NSInteger)rid
               ptUserId:(NSString*)userId
             ptUserName:(NSString*)userName
                   serverName:(NSString*)serverName
                    mName:(NSString*)mName
                 exchangeRate:(CGFloat)exchangeRate
                     roleName:(NSString*)roleName
                        extra:(NSString*)extra
                         ext1:(NSString*)ext1
                         ext2:(NSString*)ext2
                   ext3:(NSString*)ext3;
-(void) _QdSendStatistic:(NSString*)type message:(NSString*)msg;
-(void) _QdOpenUserPanel;
-(void) _QdLogout:(NSString*)username;
-(void) _QdSetUserInfoWithPid:(NSInteger)pid sid:(NSInteger)sid rid:(NSInteger)rid
               ptUserId:(NSString*)ptUserId
             ptUserName:(NSString*)ptUserName
                   serverName:(NSString*)serverName
                     roleName:(NSString*)roleName
                    roleLevel:(NSInteger)roleLevel
                    extraInfo:(NSString*)extraInfo;
@end






@interface PTSdkAbstract : NSObject
{
    
}

-(void) _QdInit;

-(void) _QdPushLogin;

-(void) _QdLogout:(NSString*)username;

-(void) _QdPMWithAmount:(NSInteger)amount
                chargeId:(NSInteger)chargeId
                   price:(NSInteger)price
                     sid:(NSInteger)sid
                     rid:(NSInteger)rid
          ptUserId:(NSString*)userId
        ptUserName:(NSString*)userName
              serverName:(NSString*)serverName
               mName:(NSString*)mName
            exchangeRate:(CGFloat)exchangeRate
                roleName:(NSString*)roleName
                   extra:(NSString*)extra
                    ext1:(NSString*)ext1
                    ext2:(NSString*)ext2
                    ext3:(NSString*)ext3;


-(void) _QdSendStatistic:(NSString*)type message:(NSString*)msg;

-(void) _QdOpenUserPanel;


-(void) _QdSetUserInfoWithPid:(NSInteger)pid
                          sid:(NSInteger)sid
                          rid:(NSInteger)rid
               ptUserId:(NSString*)ptUserId
             ptUserName:(NSString*)ptUserName
                   serverName:(NSString*)serverName
                     roleName:(NSString*)roleName
                    roleLevel:(NSInteger)roleLevel
                    extraInfo:(NSString*)extraInfo;
    

@end






@interface PTSdk : PTSdkAbstract
{
}

//全局实例属性，游戏和sdk之间的沟通桥梁
+(PTSdk*) Instance;

//mLuaCallback主要保存了登录回调到lua的函数名
@property  LuaCallback *mLuaCallback;

@property (nonatomic, unsafe_unretained) UIViewController *rootViewController;

//属性，保存sdk实例，在SDK初始化时被赋值
@property (nonatomic, nullable) id<PTSdkCallback> callBack;

+(PTSdk*) Instance;

-(void) registerPTSdkCallBack:(id<PTSdkCallback>) obj;

//登陆回调 msg为登陆回调参数，有多个参数组成json字符串
-(void) _QdLoginCallback:(NSString *) msg;

//登出回调 msg为登出回调参数，有多个参数组成json字符串
-(void) _QdLogoutCallback:(NSString *) msg;

//oc调用lua接口，需要与项目组定义好key值
-(void) _QdOcCallLua:(NSString *)key data:(NSString *)data;

@end


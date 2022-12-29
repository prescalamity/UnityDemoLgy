#import "PTSdkInterface.h"
#import "PTInterfaceManager.h"
#import "LuaCallback.h"
//#import "QLog.h"

PTSdk *sPTSdk = nil;
@implementation PTSdk

+(PTSdk*) Instance {
    if (sPTSdk == nil)
    {
        sPTSdk = [[PTSdk alloc] init];
    }
    return sPTSdk;
}

-(void) registerPTSdkListener:(id<PTSdkCallback>)obj
{
    if ([self callBack] == nil)
    {
        [self setCallBack:obj];
    }
}

-(void) _QdInit{
    if (_callBack != nil)
    {
        [[self callBack] _QdInit];
    }
}


/** sdk start **/
-(void) _QdPushLogin {
    if (_callBack != nil)
    {
        [[self callBack] _QdPushLogin];
    }
    
}

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
                         ext3:(NSString*)ext3{
    if (_callBack != nil)
    {
        [[self callBack] _QdPMWithAmount:amount chargeId:chargeId price:price sid:sid rid:rid ptUserId:userId ptUserName:userName serverName:serverName mName:mName exchangeRate:exchangeRate roleName:roleName extra:extra ext1:ext1 ext2:ext2 ext3:ext3];
    }
 
}

-(void) _QdSendStatistic:(NSString*)type message:(NSString*)msg {
    if (_callBack != nil)
    {
        [[self callBack] _QdSendStatistic:type message:msg];
    }
}

-(void) _QdOpenUserPanel {
    if (_callBack != nil)
    {
        [[self callBack] _QdOpenUserPanel];
    }
}


-(void) _QdLogout:(NSString*)username {
    if (_callBack != nil)
    {
        [[self callBack] _QdLogout:username];
    }
}


-(void) _QdSetUserInfoWithPid:(NSInteger)pid sid:(NSInteger)sid rid:(NSInteger)rid
               ptUserId:(NSString*)ptUserId
             ptUserName:(NSString*)ptUserName
                   serverName:(NSString*)serverName
                     roleName:(NSString*)roleName
                    roleLevel:(NSInteger)roleLevel
                    extraInfo:(NSString*)extraInfo {
    if (_callBack != nil)
    {
        [[self callBack] _QdSetUserInfoWithPid:pid sid:sid rid:rid ptUserId:ptUserId ptUserName:ptUserName serverName:serverName roleName:roleName
                                     roleLevel:roleLevel extraInfo:extraInfo];
    }
}


//登陆回调 msg为登陆回调参数，有多个参数组成json字符串
-(void) _QdLoginCallback:(NSString *) msg{
    NSLog(@" _QdLoginCallback.msg: %@", self.mLuaCallback.cbid);
    //[QLog Log:@"PTSdk._QdLoginCallback.msg"];
    [[PTInterfaceManager Instance] DYJBHS:[self.mLuaCallback cbid] data:msg];
    self.mLuaCallback = nil;
}

//登出回调 msg为登出回调参数，有多个参数组成json字符串
-(void) _QdLogoutCallback:(NSString *) msg{
    [[PTInterfaceManager Instance] DYJBHS:@"Logout" data:msg];
}

//oc调用lua接口，需要与项目组定义好key值
-(void) _QdOcCallLua:(NSString *)key data:(NSString *)data{
    [[PTInterfaceManager Instance] DYJBHS:key data:data];
}

/** sdk end **/

@end

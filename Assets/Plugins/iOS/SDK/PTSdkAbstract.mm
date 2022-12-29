#include <stdio.h>
#import "PTSdkInterface.h"

static PTSdk* s_PTSDKInstance = nil;
@implementation PTSdkAbstract

+(PTSdk*) Instance
{
    if (nil == s_PTSDKInstance) {
        s_PTSDKInstance = [[PTSdk alloc] init];
    }
    return s_PTSDKInstance;
}


-(void) _QdInit{
    
    
}


/** sdk start **/
-(void) _QdPushLogin {
    NSLog(@" _QdPushLogin ");
    
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
 
}

-(void) _QdSendStatistic:(NSString*)type message:(NSString*)msg {
    
}

-(void) _QdOpenUserPanel {
    
}


-(void) _QdLogout:(NSString*)username {
    
}


-(void) _QdSetUserInfoWithPid:(NSInteger)pid
                          sid:(NSInteger)sid
                          rid:(NSInteger)rid
               ptUserId:(NSString*)ptUserId
             ptUserName:(NSString*)ptUserName
                   serverName:(NSString*)serverName
                     roleName:(NSString*)roleName
                    roleLevel:(NSInteger)roleLevel
                    extraInfo:(NSString*)extraInfo {
    
}

/** sdk end **/


@end

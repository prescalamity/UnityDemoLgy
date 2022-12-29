#import <Foundation/Foundation.h>

@class LuaCallback;

typedef NSString* (^CallBlock)(LuaCallback* callback, NSString* data);

@interface PTInterfaceManager : NSObject

+(PTInterfaceManager*) Instance;
-(void)RegisterPTHS:(NSString*)key hs:(CallBlock)hs;
-(void)UnRegisterPTHS:(NSString*)key;
-(NSString*)DYPTHS:(NSString*)key data:(NSString*)data cb:(NSString*)callback;
-(void) DYJBHS:(NSString*)callback data:(NSString*)data;
-(void) InitLJBDYHS;
@end

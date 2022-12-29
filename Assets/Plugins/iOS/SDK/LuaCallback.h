

#import <UIKit/UIKit.h>


@interface LuaCallback : NSObject

//回调到lua的函数名
@property(copy)  NSString *cbid;

-(id)initWithCbid:(NSString *)CallbackID;
    
-(void)toLua:(NSString *)jsonStrData;
    
-(void)dealloc;
    
@end

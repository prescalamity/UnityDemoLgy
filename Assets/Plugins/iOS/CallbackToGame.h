//
//  CallbackInterface.h
//  base_lib
//
//  Created by package on 2020/8/3.
//  Copyright © 2020 package. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface CallbackToGame : NSObject
+ (void)CallUnitySendMessage:(NSString*)obj method:(NSString*)method msg:(NSString*)msg;
+ (UIViewController*)CallUnityGetGLViewController;
+ (UIView*)CallUnityGetGLView;
+ (void)CallbackToLua:(NSString*)interfaceName Data:(NSString*)data;
@end

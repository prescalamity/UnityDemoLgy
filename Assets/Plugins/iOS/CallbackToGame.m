//
//  CallbackToGame.m
//  base_lib
//
//  Created by package on 2020/8/7.
//  Copyright © 2020 package. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "CallbackToGame.h"
#import "UnityInterface.h"

@implementation CallbackToGame
+ (void)CallUnitySendMessage:(NSString*)obj method:(NSString*)method msg:(NSString*)msg
{
    UnitySendMessage([obj UTF8String], [method UTF8String], [msg UTF8String]);
}
+ (UIViewController*)CallUnityGetGLViewController
{
    return UnityGetGLViewController();
}
+ (UIView*)CallUnityGetGLView
{
    return UnityGetGLView();
}

//a universal callback entry with just one parameter, and pass data to lua indirectly
+ (void)CallbackToLua:(NSString*)interfaceName Data:(NSString*)data;
{
	NSLog(@"[Base] Callback To Lua: @", interfaceName);
	NSDictionary* callbackDic = [NSDictionary dictionaryWithObjectsAndKeys:interfaceName, @"callback", 
		data, @"data", nil];
    NSError *jsonError;
    NSData *jsondata = [NSJSONSerialization dataWithJSONObject:callbackDic options:0 error:&jsonError];

    NSString* jsonString = [[NSString alloc] initWithData:jsondata encoding:NSUTF8StringEncoding];
    [CallbackToGame CallUnitySendMessage:@"GameMain" method:@"CallScriptFunc" msg:jsonString];
}
@end

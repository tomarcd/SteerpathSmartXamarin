//
//  SPSmartSDK.h
//  Steerpath
//
//  Created by Jussi Laakkonen on 15/11/2018.
//  Copyright © 2018 Steerpath. All rights reserved.
//

#pragma mark - Dependencies

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/**
    SPSmartSDK
 
    Singleton class that is used to initialize the Steerpath Smart SDK.
    It's highly recommended that you start the SDK inside your AppDelegate.
 
    If you have an offline data bundle 'sff' file. You can use it by inserting the filename
    into your Info.plist with the keyword 'SP_OFFLINE_DATA'. The data will be automatically read once the app
    starts.
 
    Offline data Info.plist example:
 
    <key>SP_OFFLINE_DATA</key>
    <string>my_offline_data.sff</string>
*/
@interface SPSmartSDK : NSObject

#pragma mark - Object Lifecycle

/**
    @return Singleton instance of SPSmartSDK
*/
+(instancetype)getInstance;

/** unavailable methods, do not use these */
-(instancetype) init __attribute__((unavailable("call getInstance instead")));

#pragma mark - Start

/**
    Starts the SDK with a specific API key
 
    Changes the API key to use for authentication to the Steerpath Platform.
 
    Need API access? Contact support@steerpath.com
 
    @param apiKey used for authentication
 */
-(void)start:(NSString*)apiKey;

#pragma mark - Configurations

/**
    Sets configurations for Steerpath Live.
 
    @param configuration for using Steerpath Live
*/
-(void)setLiveConfiguration:(NSDictionary*)configuration;

@end

NS_ASSUME_NONNULL_END

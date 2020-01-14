//
//  SPSmartSharingCodeResolver.h
//  Steerpath 
//
//  Created by Nguyen Ba Long on 08/07/2019.
//  Copyright © 2019 Steerpath. All rights reserved.
//

#pragma mark - Dependencies
#import <Foundation/Foundation.h>

#pragma mark - Enums
/**
 Sharing code error types.
 */
typedef void (^SPSharingCodeResolverCompletionBlock)(BOOL success, NSError* _Nullable error);

typedef NS_ENUM(NSUInteger, SPSmartSharingCodeErrorType) {
	/** The format of the sharing code is incorrect */
	SPSmartSharingCodeErrorTypeInvalidFormat = 1,
	/** The POI data could not be found from our Steerpath server */
	SPSmartSharingCodeErrorTypeDataFound = 2
};

NS_ASSUME_NONNULL_BEGIN
#pragma mark - SPSmartSharingCodeResolver Implementation
/**
	SPSmartSharingCodeResolver class is responsible for resolving sharing code obtained from scanning QR-Code in Steerpath Web SDK.

	This provides a mechanism to share POIs from Web to Native SDK.
	If the sharing code is understandable by the Native SDK, SmartMap will select the POI with its information view. Otherwise, it will throw an error.
	In order to support this class, your application should also be setup so that it supports Universal Links. The format of the sharing url can be configured from the configuration file.
 
	Example:
	 "services" : {
		...,
		"kiosk": {
			"default": {
				"share": {
				"hash": false,
				"qrCodeShare": {
					"enabled": true, // Indicate if sharing code is supported
					"qrCodeURL": "https://kiosk.steerpath.com/", // Your domain goes here
					"qrCodePath": "steerpath/index.html" // Your url path goes here
				},
				"copyLinkToClipboard": true
				}
			}
		}
	 }
 */
@interface SPSmartSharingCodeResolver : NSObject

/**
 @return Singleton instance of SPSmartSharingCodeResolver
 */
+(instancetype)sharedInstance;

/** unavailable method, do not use */
-(instancetype) init __attribute__((unavailable("call sharedInstance instead")));

#pragma mark - Resolving methods
/**
 	Used to resolve sharing code. If the code is resolved successfully, the map will select the object. Otherwise an error with description will be thrown.
 
 	@param sharingCode The code that is received from scanning QR-Code from Steerpath Web-SDK
 	@param completionBlock The completion block will be returned when function finished. Use this completionBlock if you want to know if it succeeded or failed with detailed error.
 */
-(void)resolveSharingCode:(NSString*)sharingCode completion:(nullable SPSharingCodeResolverCompletionBlock)completionBlock;

@end

NS_ASSUME_NONNULL_END

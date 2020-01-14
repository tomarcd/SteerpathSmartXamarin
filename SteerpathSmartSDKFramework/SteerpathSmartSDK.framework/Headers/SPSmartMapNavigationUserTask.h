//
//  SPSmartMapNavigationUserTask.h
//  Steerpath
//
//  Created by Nguyen Ba Long on 09/04/2019.
//  Copyright © 2019 Steerpath. All rights reserved.
//

#pragma mark - Dependencies
#import <Foundation/Foundation.h>

#pragma mark - Enums
/**
 User Task Response Enum
 */
typedef NS_ENUM(NSInteger, SPSmartMapUserTaskResponse) {
	/**
	 User task is started
	 */
	SPSmartMapUserTaskResponseStarted,
	/**
	 User task is cancelled
	 */
	SPSmartMapUserTaskResponseCancelled,
	/**
	 Some error happens
	 */
	SPSmartMapUserTaskResponseError,
	/**
	 Some other user tasks is still going on
	 */
	SPSmartMapUserTaskResponseBusy,
	/**
	 The type of the task is not supported
	 */
	SPSmartMapUserTaskResponseUnSupported,
	/**
	The task is completed successfully by user
	 */
	SPSmartMapUserTaskResponseCompleted
};

#pragma mark - Base class
/**
 A base class to define a User Task
 */
@interface SPSmartMapUserTask : NSObject


@end

#pragma mark - Protocols
/**
 	UserTaskDelegate to handle user task callbacks
 */
@protocol SPSmartMapUserTaskDelegate <NSObject>

@optional
/**
 	Called when smartmap start a userTask. Whenever the user task is interrupted. The response type will be "Cancelled" otherwise if it is finished "Completed" will be returned.
 	After a user task is finished. The map mode will be set to mapOnly.

 	@param userTask The user task that is triggering this callback.
 	@param response The response of the task.
 */
- (void)spSmartMapUserTask:(SPSmartMapUserTask* _Nonnull)userTask onUserTaskResponse:(SPSmartMapUserTaskResponse)response;

@end

NS_ASSUME_NONNULL_BEGIN

@class SPSmartMapObject;

#pragma mark - Navigation User Task Implementation
/**
 	A class that is responsible for defining a user navigation task.
 */
@interface SPSmartMapNavigationUserTask : SPSmartMapUserTask

/**
    Custom initialize method with localRef and buildingRef
 
    @param localRef local reference of the POI that you want to navigate to.
    @param buildingRef building reference of the POI that you want to navigate to.
 */
- (instancetype)initWithLocalRef:(NSString*)localRef building:(NSString*)buildingRef;

/**
    Custom initialize method with map object
 
    @param object The map object that you want to navigate to.
 */
- (instancetype)initWithMapObject:(SPSmartMapObject*)object;

/**
    Custom initialize method with map objects
    @param listOfObjects The list of map objects that you navigate through
 */
- (instancetype)initWithMapObjects:(NSArray<SPSmartMapObject*>*)listOfObjects;

#pragma mark - Public methods
/**
    Call this method if you want to set the origin of the navigation. If the origin is not set, the starting point of the navigation will be the bluedot/user current location
 
    @param origin The origin of the navigation.
 */
- (void)setOrigin:(SPSmartMapObject*)origin;

/**
 	Return localRef of the destination of the navigation task.
 
 	@return LocalRef of the destination of the navigation task.
 */
- (nullable NSString*)getUserTaskLocalRef;

/**
 	Return buildingRef of the destination of the navigation task.
 
 	@return BuildingRef of the destination of the navigation task.
 */
- (nullable NSString*)getUserTaskBuildingRef;

/**
 	Return origin of the navigation task
 
 	@return origin of the navigation task
 */
- (nullable SPSmartMapObject*)getOrigin;

/**
 	Return list of map objects that navigation go through
 
 	@return list of map objects that navigation go through excluding 
 */
- (nullable NSArray<SPSmartMapObject*>*)getNavigationObjects;

@end
NS_ASSUME_NONNULL_END

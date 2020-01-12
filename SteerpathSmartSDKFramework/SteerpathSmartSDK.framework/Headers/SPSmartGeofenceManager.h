//
//  SPSmartGeofenceManager.h
//  Steerpath
//
//  Created by Nguyen Ba Long on 19/03/2019.
//  Copyright © 2019 Steerpath. All rights reserved.
//

#import <Foundation/Foundation.h>

/** Smart Geofence Error Domain */
extern NSString* const kSPSmartGeofenceErrorDomain;

/**
 Smart Geofence response types.
 */
typedef NS_ENUM(NSUInteger, SPSmartGeofenceResponseType) {
    /** Geofence is not found with given localRef and buildingRef */
    SPSmartGeofenceResponseTypeGeofenceNotFound = 1,
    /** Malformed data error */
    SPSmartGeofenceResponseTypeMalformedData = 2,
    /** Success */
    SPSmartGeofenceResponseTypeSuccess = 3
};

@class SPSmartGeofenceManager;
/**
    Delegate for SPSmartGeofenceManager. Use this to listen for location related callbacks.
 */
@protocol SPSmartGeofenceManagerDelegate <NSObject>

@optional
/**
    Called when user enter the registered geofence
 
    @param manager the object that called this method
    @param localRef local reference of the triggered geofence
    @param buildingRef building reference of the triggered geofence
 */
-(void)spSmartGeofenceManager:(SPSmartGeofenceManager*)manager didEnterGeofence:(NSString*)localRef building:(NSString*)buildingRef;

/**
    Called when user exit the registered geofence

    @param manager the object that called this method
    @param localRef local reference of the triggered geofence
    @param buildingRef building reference of the triggered geofence
 */
-(void)spSmartGeofenceManager:(SPSmartGeofenceManager*)manager didExitGeofence:(NSString*)localRef building:(NSString*)buildingRef;

/**
    Called when users enter beacon fence
 
    @param manager the object that called this method
    @param beaconId the identifier of beacon as known as aseetTrackingId
 */
-(void)spSmartGeofenceManager:(SPSmartGeofenceManager*)manager didEnterBeaconfence:(NSString*)beaconId;

/**
    Called when users leave beacon fence
 
    @param manager the object that called this method
    @param beaconId the identifier of beacon as known as assetTrackingId
 */
-(void)spSmartGeofenceManager:(SPSmartGeofenceManager*)manager didExitBeaconfence:(NSString*)beaconId;

@end

NS_ASSUME_NONNULL_BEGIN

#pragma mark - SPSmartGeofenceManager Class Definition
@interface SPSmartGeofenceManager : NSObject
/**
    @return Singleton instance of SPSmartGeofenceManager
 */
+(instancetype)sharedInstance;

/** unavailable method, do not use */
-(instancetype) init __attribute__((unavailable("call sharedInstance instead")));

#pragma mark - Geofence CRUD
/**
    Add a geofence to SPSmartMapView
 
    Geofences will disappear when the application is restarted.
 
    To get geofence trigger events, set your delegate by calling 'addDelegate:' and implement delegate methods 'didEnterGeofence' or 'didExitGeofence'
 
    @param localRef localRef of the geofence
    @param buildingRef buildingRef of the geofence
    @param completionBlock called when the operation is finished
 */
-(void)addGeofence:(NSString*)localRef building:(NSString*)buildingRef completion:(nullable void (^)(SPSmartGeofenceResponseType response))completionBlock;

/**
    Remove a geofence with local reference and building reference
 
    @param localRef localRef of the triggered geofence
    @param buildingRef buildingRef of the triggered geofence
 */
-(void)removeGeofence:(NSString*)localRef building:(NSString*)buildingRef;

#pragma mark - Delegate methods

/**
    Add listener
 
 */
-(void)addDelegate:(id<SPSmartGeofenceManagerDelegate>)delegate;

/**
    Remove listener
 */
-(void)removeDelegate:(id<SPSmartGeofenceManagerDelegate>)delegate;

#pragma mark - Adding/Removing Beacon fences
/**
    Add all beacon fences
 */
-(void)addBeaconfences;

/**
    Remove all beacon fences
 */
-(void)removeBeaconfences;

/**
    Add a beacon fence to SPSmartMapView
 
    Beaconfence will disappear when the application is restarted
 
    To get beacon geofence trigger events, set your delegate by calling 'addDelegate:' and implement delegate methods 'didEnterGeofence' or 'didExitGeofence'
 
    @param beaconId local reference of the beacon
    @param radiusInMeter radius of the beacon in meter unit
    @param loiteringDelayInSecond time delay between before triggering 'dwell' type transitions in second unit
    @param completionBlock called when operation is finished
*/
-(void)addBeaconfence:(NSString*)beaconId radius:(NSInteger)radiusInMeter loiteringDelay:(NSTimeInterval)loiteringDelayInSecond completion:(nullable void (^)(SPSmartGeofenceResponseType response))completionBlock;

/**
    Remove a beacon fence from SPSmartMapView
 
    @param beaconId the id of the beacon
 */
-(void)removeBeaconfence:(NSString*)beaconId;

#pragma mark - Hit Test


@end

NS_ASSUME_NONNULL_END

//
//  SPSmartMapViewDelegate.h
//  Steerpath
//
//  Created by Jussi Laakkonen on 21/11/2018.
//  Copyright © 2018 Steerpath. All rights reserved.
//

#import "SPSmartMapObject.h"
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

#pragma mark - Enums

/** Live object status types */
typedef NS_ENUM(NSUInteger, SPLiveObjectStatus) {
    /** Unknown */
    SPLiveObjectStatusUnknown = 0,
    /** Neutral */
    SPLiveObjectStatusNeutral = 1,
    /** Allowed */
    SPLiveObjectStatusAllowed = 2,
    /** Forbidden */
    SPLiveObjectStatusForbidden = 3
};

/** Navigation error types */
typedef NS_ENUM(NSUInteger, SPNavigationError) {
    /** Target object for navigation was not found. This means that either the target object or the building is not found. */
    SPNavigationErrorObjectNotFound = 0,
    /** Route not found to target object. There's no connecting navigation path to the target. */
    SPNavigationErrorRouteNotFound = 1,
    /** User location not available. User does not have a blue dot and navigation can not be started. */
    SPNavigationErrorUserLocationNotFound = 2
};

/** SmartMap view status, indicating the view status of the smart map aka. which view is currently presenting */
typedef NS_ENUM(NSUInteger, SPMapViewStatus) {
	/** Search view is shown in expanded state */
	SPMapViewStatusSearchInExpandedMode,
	/** Search view is shown in preferredHeight state */
	SPMapViewStatusSearchInPreferredHeight,
	/** Search view is shown in minHeight state */
	SPMapViewStatusSearchInMinHeight,
	/** CardView with POI detail is shown in smartMap */
	SPMapViewStatusCardView,
	/** ErrorView is shown in smartMap */
	SPMapViewStatusErrorView,
	/** SmartMap is currently navigating and navigation views are showing */
	SPMapViewStatusNavigatingView,
	/** SmartMap is showing only map */
	SPMapViewStatusOnlyMap,
	/** SmartMap is showing settings view*/
	SPMapViewStatusSettingView
};

@class SPSmartMapViewDelegate;
@class SPSmartMapView;

#pragma mark - SPSmartMapViewDelegate Definition

/**
    SPSmartMapViewDelegate

    The 'SPSmartMapViewDelegate' protocol defines a set of optional methods that you can use to receive map-related update messages.
    Because many map operations require the 'SPSmartMapViewDelegate' class to load data asynchronously, the map view calls
    these methods to notify your application when specific operations complete.
 */
@protocol SPSmartMapViewDelegate <NSObject>

@optional

#pragma mark - Map Lifecycle Events

/**
    Called when map style has loaded and the map is ready to be used.
 
 	@param smartMap the object that called this delegate method.
 */
-(void)spSmartMapViewOnMapLoaded:(SPSmartMapView*)smartMap;

#pragma mark - Map Interaction Events

/**
    Called when the map is clicked.
 
 	@param smartMap the object that called this delegate method.
    @param objects list of map objects that were clicked or empty array if no objects were found
 	@return true if map event was consumed by the app. If so, SDK ignores click event.
*/
-(BOOL)spSmartMapView:(SPSmartMapView*)smartMap onMapClicked:(NSArray<SPSmartMapObject*>*)objects;

/**
 	Called when the views of smartMap changed
 
 	@param smartMap the object that called this delegate method.
 	@param status Current map status
 	@param objectDetail Detail of POI existing in the current view if any.
 */
-(void)spSmartMapView:(SPSmartMapView*)smartMap onViewStatusChanged:(SPMapViewStatus)status withPOIDetail:(nullable SPSmartMapObject*)objectDetail;

#pragma mark - Map Settings Interaction Events

/**
 	Called when an external link that is used to send email is clicked
 
 	@param smartMap The object that sent this event
 	@param email The email address that should be sent to
 */
-(void)spSmartMapView:(SPSmartMapView*)smartMap shouldSendEmailToAddress:(NSString*)email;

#pragma mark - Building and Floor Events

/**
    Called after the visible floor or building on the map has changed.
    The 'buildingRef' parameter is nil if there is no 'visible' building.
 
 	@param smartMap the object that called this delegate method.
    @param floorIndex the new visible floor index
    @param buildingRef visible building identifier or nil if no visible building
*/
-(void)spSmartMapView:(SPSmartMapView*)smartMap onVisibleFloorChanged:(NSInteger)floorIndex buildingRef:(nullable NSString*)buildingRef;
    
/**
    Called after the user moves onto a new floor or building.
    The 'buildingRef' parameter is nil if the user has moved outside of a building.
 
 	@param smartMap the object that called this delegate method.
    @param floorIndex the floor index for the user
    @param buildingRef the building identifier for the user or nil if the user is outside
*/
-(void)spSmartMapView:(SPSmartMapView*)smartMap onUserFloorChanged:(NSInteger)floorIndex buildingRef:(nullable NSString*)buildingRef;

#pragma mark - Navigation Events

/**
    Called when navigation route calculation is done and the route preview will be displayed.
 
 	@param smartMap the object that called this delegate method.
*/
-(void)spSmartMapViewOnNavigationPreviewAppeared:(SPSmartMapView*)smartMap;

/**
    Called when navigation starts or a navigation route was recalculated and navigation starts
    from the new position.
 
    Shows navigation instructions.
 
 	@param smartMap the object that called this delegate method.
*/
-(void)spSmartMapViewOnNavigationStarted:(SPSmartMapView*)smartMap;

/**
    Called when user has reached the destination.
 
 	@param smartMap the object that called this delegate method.
*/
-(void)spSmartMapViewOnNavigationDestinationReached:(SPSmartMapView*)smartMap;

/**
    Called when navigation is stopped. Navigation will be stopped when user cancels navigation, the calls 'stopNavigation' method
    or when user has reached the destination.
 
 	@param smartMap the object that called this delegate method.
*/
-(void)spSmartMapViewOnNavigationEnded:(SPSmartMapView*)smartMap;

/**
    Called if navigation fails.
 
    @param error describes why navigation fails. See 'SPNavigationError' documentation for more details.
*/
-(void)spSmartMapViewOnNavigationFailed:(SPSmartMapView*)smartMap withError:(SPNavigationError)error;

#pragma mark - Live Data

/**
    Called when a new live objects will appear on the map.
 
 	@param smartMap the object that called this delegate method.
    @param identifier unique identifier for the live object
*/
-(void)spSmartMapView:(SPSmartMapView*)smartMap onLiveObjectWillAppear:(NSString*)identifier;

/**
    Called when a live object will disappear from the map.
 
 	@param smartMap the object that called this delegate method.
    @param identifier unique identifier for the live object
*/
-(void)spSmartMapView:(SPSmartMapView*)smartMap onLiveObjectWillDisappear:(NSString*)identifier;

/**
    Called when a live object is updated on the map.
 
 	@param smartMap the object that called this delegate method.
    @param identifier unique identifier for the live object
    @param inGeofences array of geofences that the user is in
    @param status extra information on the state of the object
*/
-(void)spSmartMapView:(SPSmartMapView*)smartMap onLiveObjectUpdated:(NSString*)identifier inGeofences:(NSArray<NSString*>*)inGeofences status:(SPLiveObjectStatus)status;

#pragma mark Search events
-(BOOL)spSmartMapView:(SPSmartMapView*)smartMap onSearchResultSelected:(SPSmartMapObject*)mapObject;

@end

NS_ASSUME_NONNULL_END

//
//  SPSmartNavigationView.h
//  Steerpath
//
//  Created by Jussi Laakkonen on 27/08/2018.
//  Copyright © 2018 Steerpath. All rights reserved.
//

#pragma mark - Dependencies

#import <UIKit/UIKit.h>
#import "SPSmartMapObject.h"
#import "SPSmartNavigationViewDelegate.h"

#pragma mark - Enums

/** Map event response types */
typedef NS_ENUM(NSUInteger, SPMapResponse) {
    /** Successful map event. Everything went smoothly. */
    SPMapResponseSuccess = 0,
    /** Target object for event was not found. This means that either the target object or the building is not found. */
    SPMapResponseObjectNotFound = 1,
    /** Could not find target location for event due to network connectivity issue. In other words the device does not have an internet connection or local cache data. */
    SPMapResponseNetworkError = 2
};

NS_ASSUME_NONNULL_BEGIN

#pragma mark - SPSmartNavigationView Class Definition

/**
    SPSmartNavigationView
 
    This is the recommended class to use in your application when you want to display maps and user location
    with the Steerpath iOS SDK.
 
    To use this class you need to have a Steerpath API access token.
    See SPAccountManager.h for instructions on how to authenticate.
*/
@interface SPSmartNavigationView : UIView

#pragma mark - Delegate

/**
    Delegate for SPMapView and MGLMapView callbacks
*/
@property (nullable, nonatomic, weak) IBOutlet id<SPSmartNavigationViewDelegate> delegate;

#pragma mark - Camera Movement

/**
    Move the camera to a specific location.
    Does not include animation. Use 'animateCamera' methods if you want the camera transition to be animated.
 
    @param latitude gps latitude
    @param longitude gps longitude
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
*/
-(void)setCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel;

/**
    Move the camera to a specific location.
    Does not include animation. Use 'animateCamera' methods if you want the camera transition to be animated.
 
    @param latitude gps latitude
    @param longitude gps longitude
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
    @param bearing The new direction for the map, measured in degrees relative to true north.
    @param pitch the pitch (tilt) of the map.
*/
-(void)setCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch;

/**
    Move the camera to a specific location and change the visible floor of a building.
    Does not include animation. Use 'animateCamera' methods if you want the camera transition to be animated.
 
    How floor indexes work:
 
    Above ground level:         floor > 0
 
    Ground level:               floor == 0
 
    Below ground level:         floor < 0
 
    @param latitude gps latitude
    @param longitude gps longitude
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
    @param bearing The new direction for the map, measured in degrees relative to true north.
    @param pitch the pitch (tilt) of the map.
    @param floorIndex the floor index to show
    @param buildingRef unique identifier for the building
*/
-(void)setCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch floorIndex:(int)floorIndex buildingRef:(NSString*)buildingRef;

/**
    Move the camera to a specific map object in a particular building.
    The camera will also change its bearing to the 'natural orientation' of the building if one is defined in the map data.
    Does not include animation. Use 'animateCamera' methods if you want the camera transition to be animated.
 
    @param localRef identifier for the map object. Corresponds to the 'localRef' property in the map data.
    @param buildingRef unique identifier for the building
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
    @param completionBlock containing camera event status after completion
*/
-(void)setCameraToObject:(NSString*)localRef buildingRef:(NSString*)buildingRef zoomLevel:(double)zoomLevel completion:(nullable void(^)(SPMapResponse response))completionBlock;

/**
    Move the camera to a specific building. Camera is zoomed in so that the whole building is visible on the map.
    The camera will also change its bearing to the 'natural orientation' of the building if one is defined in the map data.
    Does not include animation. Use 'animateCamera' methods if you want the camera transition to be animated.
 
    @param buildingRef unique identifier for the building
    @param completionBlock containing camera event status after completion
*/
-(void)setCameraToBuildingRef:(NSString*)buildingRef completion:(nullable void(^)(SPMapResponse response))completionBlock;

/**
    Animate the camera to a specific location.
 
    @param latitude gps latitude
    @param longitude gps longitude
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
    @param completionBlock containing camera event status after completion
*/
-(void)animateCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel completion:(nullable void(^)(SPMapResponse response))completionBlock;

/**
    Animate the camera to a specific location.

    @param latitude gps latitude
    @param longitude gps longitude
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
    @param bearing The new direction for the map, measured in degrees relative to true north.
    @param pitch the pitch (tilt) of the map.
    @param completionBlock containing camera event status after completion
 */
-(void)animateCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch completion:(nullable void(^)(SPMapResponse response))completionBlock;

/**
 
    Animate the camera to a specific location and change the visible floor of a building.

    How floor indexes work:
 
    Above ground level:         floor > 0
 
    Ground level:               floor == 0
 
    Below ground level:         floor < 0
 
    @param latitude gps latitude
    @param longitude gps longitude
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
    @param bearing The new direction for the map, measured in degrees relative to true north.
    @param pitch the pitch (tilt) of the map.
    @param floorIndex the floor index to show
    @param buildingRef unique identifier for the building
    @param completionBlock containing camera event status after completion
 */
-(void)animateCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch floorIndex:(int)floorIndex buildingRef:(NSString*)buildingRef completion:(nullable void(^)(SPMapResponse response))completionBlock;

/**
    Animate the camera to a specific map object in a particular building.
    The camera will also change its bearing to the 'natural orientation' of the building if one is defined in the map data.
 
    @param localRef identifier for the point of interest. Corresponds to the 'localRef' property in the map data.
    @param buildingRef unique identifier for the building
    @param zoomLevel the new zoom level for the map. The bigger the value, the closer the map is zoomed, 0 is the whole world map.
    @param completionBlock containing camera event status after completion
 */
-(void)animateCameraToObject:(NSString*)localRef buildingRef:(NSString*)buildingRef zoomLevel:(double)zoomLevel completion:(nullable void(^)(SPMapResponse response))completionBlock;

/**
    Animate the camera to a specific building.
    The camera will also change its bearing to the 'natural orientation' of the building if one is defined in the map data.
 
    @param buildingRef unique identifier for the building
    @param completionBlock containing camera event status after completion
 */
-(void)animateCameraToBuildingRef:(NSString*)buildingRef completion:(nullable void(^)(SPMapResponse response))completionBlock;

#pragma mark - Map Objects

/**
    Fetches a map object from a specific source.
 
    @param localRef identifier for the point of interest. Corresponds to the 'localRef' property in the map data.
    @param buildingRef unique identifier for the building
    @param source where the map object is read from
    @param completionBlock containing map object if successful. Also contains a response informing of any possible errors.
*/
-(void)getMapObject:(NSString*)localRef buildingRef:(NSString*)buildingRef source:(SPObjectSource)source completion:(nullable void(^)(SPSmartMapObject* _Nullable mapObject, SPMapResponse response))completionBlock;

/**
    Set additional data for a live map object.
 
    @param identifier unique object identifier
    @param key for information
    @param value containing additional information
*/
-(void)setLiveObjectInfo:(NSString*)identifier key:(NSString*)key value:(NSString*)value;

#pragma mark - Selection

/**
    Centers the map on a specific object, adds marker and shows information about the object.
    Does nothing if a matching object can not be found in the map data.
 
    @param localRef identifier for the point of interest. Corresponds to the 'localRef' property in the map data.
    @param buildingRef unique identifier for the building
*/
-(void)selectMapObject:(NSString*)localRef buildingRef:(NSString*)buildingRef NS_SWIFT_NAME(selectMapObject(_:_:));

/**
    Centers the map on a specific object, adds marker and shows information about the object.
    Does nothing if a matching object can not be found in the map data.
 
    @param mapObject containing information about the object such as location, title, floor etc.
 */
-(void)selectMapObject:(SPSmartMapObject*)mapObject NS_SWIFT_NAME(selectMapObject(_:));


#pragma mark - Markers

/**
    Adds a custom marker onto the map.
    This method will display the marker with the default icon style provided by the SDK.
 
    @param mapObject containing information about the marker location, title, floor etc.
*/
-(void)addMarker:(SPSmartMapObject*)mapObject;

/**
    Adds a custom marker onto the map.
    This method will display the marker with the layout, icon and colors that you provide as parameters.
    Note that before using your own icon images you must use the 'addIconImage:' method to provide the image data.
 
    @param mapObject containing information about the marker location, title, floor etc.
    @param layout how the marker title text will be aligned relative to the icon
    @param iconName the name of the icon image. Make sure you've set the name and data with the 'addIconImage:' method
    @param textColor color for the title text in '#rrggbb' format.
    @param textHaloColor color for the outline of the text in '#rrggbb' format.
*/
-(void)addMarker:(SPSmartMapObject*)mapObject layout:(SPLayout)layout iconName:(NSString*)iconName textColor:(NSString*)textColor textHaloColor:(NSString*)textHaloColor;

/**
    Adds multiple custom markers onto the map.
    This method will display the markers with the default icon style provided by the SDK.
 
    @param mapObjects array of map objects containing information about the markers
*/
-(void)addMarkers:(NSArray<SPSmartMapObject*>*)mapObjects;

/**
     Adds multiple custom markers to the map.
     This method will display the markers with the layout, icon and colors that you provide as parameters.
     Note that before using your own icon images you must use the 'addIconImage:' method to provide the image data.
 
     @param mapObjects array of map objects containing information about the marker location, title, floor etc.
     @param layout how the marker title text will be aligned relative to the icon
     @param iconName the name of the icon image. Make sure you've set the name and data with the 'addIconImage:' method
     @param textColor color for the title text in '#rrggbb' format.
     @param textHaloColor color for the outline of the text in '#rrggbb' format.
 */
-(void)addMarkers:(NSArray<SPSmartMapObject*>*)mapObjects layout:(SPLayout)layout iconName:(NSString*)iconName textColor:(NSString*)textColor textHaloColor:(NSString*)textHaloColor;

/**
    Removes a custom marker from the map.
 
    @param mapObject to remove
*/
-(void)removeMarker:(SPSmartMapObject*)mapObject;

/**
    Removes multiple custom markers from the map.
 
    @param mapObjects to remove from the map
*/
-(void)removeMarkers:(NSArray<SPSmartMapObject*>*)mapObjects;

/**
    Removes all custom markers from the map.
*/
-(void)removeAllMarkers;

#pragma mark - Icons

/**
    Adds a custom image for a particular icon name.
    After you've set a custom image you can use the 'addMarker:layout:iconName:textColor:textHaloColor' methods to create markers with your own custom icons.
 
    @param iconName name to use for the icon
*/
-(void)addIconImage:(NSString*)iconName image:(UIImage*)image;

#pragma mark - Navigation

/**
    Attempts to start navigation to a specific map object in a building.
 
    Listen to SPSmartNavigationViewDelegate navigation callbacks to receive information about navigation related events.
 
    When navigating, the user location will be snapped to the nearest point on the navigation path.
 
    When using this method, user location will be snapped to the navigation path.
    You can use the 'stopNavigation' method to manually stop navigation at any point.
 
    @param localRef identifier for the point of interest. Corresponds to the 'localRef' property in the map data.
    @param buildingRef unique identifier for the building
 */
-(void)navigateTo:(NSString*)localRef buildingRef:(NSString*)buildingRef;

/**
    Attempts to start navigation to a specific map object
 
    Listen to SPSmartNavigationViewDelegate navigation callbacks to receive information about navigation related events.
 
    When using this method, user location will be snapped to the navigation path.
    You can use the 'stopNavigation' method to manually stop navigation at any point.
 
    @param mapObject containing information about the target location, title, floor etc.
*/
-(void)navigateToObject:(SPSmartMapObject*)mapObject;

/**
    Attempts to start navigation through multiple map objects.
    This means the navigation path will go through multiple locations in the order provided in the array parameter.
    You can use this to have multiple 'waypoints' on the navigation path or make the user to go through a certain
    point before heading to the destination.
 
    For example if you provide map objects A, B and C in the array [A,B,C], the combined navigation path will be a
    a route from A to B and B to C.
 
    Listen to SPSmartNavigationViewDelegate navigation callbacks to receive information about navigation related events.
 
    When using this method, user location will be snapped to the navigation path.
    You can use the 'stopNavigation' method to manually stop navigation at any point.
 
    @param mapObjects array of map objects containing information about the target locations, titles, floors etc.
*/
-(void)navigateThrough:(NSArray<SPSmartMapObject*>*)mapObjects;

/**
    Stops navigation. The delegate method 'onNavigationStopped' will also be triggered.
*/
-(void)stopNavigation;

@end

NS_ASSUME_NONNULL_END

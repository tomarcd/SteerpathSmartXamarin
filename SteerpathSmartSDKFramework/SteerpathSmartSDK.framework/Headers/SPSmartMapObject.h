//
//  SPSmartMapObject.h
//  Steerpath
//
//  Created by Jussi Laakkonen on 15/11/2018.
//  Copyright © 2018 Steerpath. All rights reserved.
//

#pragma mark - Dependencies

#import <Foundation/Foundation.h>
#if __has_feature(modules)
@import Mapbox;
#else
#import <Mapbox/Mapbox.h>
#endif
NS_ASSUME_NONNULL_BEGIN

#pragma mark - Enums

/** Smart Map Object Sources */
typedef NS_ENUM(NSUInteger, SPObjectSource) {
    /** Object origin is from the static map data */
    SPObjectSourceStatic = 0,
    /** Object origin is a marker created by the user */
    SPObjectSourceMarker = 1,
    /** Object origin is live map data */
    SPObjectSourceLive = 2
};

/** Layout types */
typedef NS_ENUM(NSUInteger, SPLayout) {
    /** Align elements to top */
    SPLayoutTop = 0,
    /** Align elements to bottom */
    SPLayoutBottom = 1,
    /** Align elements to right */
    SPLayoutRight = 2,
    /** Align elements to left */
    SPLayoutLeft = 3
};

#pragma mark - SPSmartMapObject Class Definition

/**
    SmartMapObject
 
    Data transfer object used for SPSmartMapView events.
*/
@interface SPSmartMapObject : NSObject

#pragma mark - Properties

/**
    Title that is displayed on the map for this object.
    Note that changing this property after the object has been added onto the map will not have any effect.
*/
@property (nonatomic, strong) NSString* title;

/**
    GPS latitude coordinate
    Note that changing this property after the object has been added onto the map will not have any effect.
*/
@property (nonatomic, assign) double latitude;

/**
    GPS longitude coordinate
    Note that changing this property after the object has been added onto the map will not have any effect.
*/
@property (nonatomic, assign) double longitude;

/**
    Floor index for object.
 
    How floor indexes work:
 
    Above ground level:         floor > 0
 
    Ground level:               floor == 0
 
    Below ground level:         floor < 0
 
    Note that changing this property after the object has been added onto the map will not have any effect.
 
*/
@property (nonatomic, assign) NSInteger floorIndex;

/**
    Identifier for the map object. Corresponds to the 'localRef' property in the map data.
    Note that changing this property after the object has been added onto the map will not have any effect.
*/
@property (nonatomic, strong) NSString* localRef;

/**
    Unique building identifier
    Note that changing this property after the object has been added onto the map will not have any effect.
*/
@property (nonatomic, strong) NSString* buildingRef;

/**
    Source where the map object originates.
 
    'Static' map objects are from the base map data.
    'Markers' are user created map objects.
*/
@property (nonatomic, assign) SPObjectSource source;

/**
    Metadata properties of the map object
 */
@property (nonatomic, assign) NSDictionary* properties;

#pragma mark - Initializer

/**
    Recommended constructor for SPSmartMapObject.
 
    Note that changing any properties after the object has been added onto the map will not affect the visualisation of the object.
 
    @param latitude gps latitude
    @param longitude gps longitude
    @param floorIndex the floor index to show
    @param localRef identifier for the map object. Corresponds to the 'localRef' property in the map data.
    @param buildingRef unique identifier for the building
    @return new instance of SPSmartMapObject
*/
-(instancetype)initWithLatitude:(double)latitude longitude:(double)longitude floorIndex:(NSInteger)floorIndex localRef:(NSString*)localRef buildingRef:(NSString*)buildingRef;

@end

NS_ASSUME_NONNULL_END

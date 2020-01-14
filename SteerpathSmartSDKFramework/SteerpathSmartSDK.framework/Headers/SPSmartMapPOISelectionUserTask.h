//
//  SPSmartMapPOISelectionUserTask.h
//  Steerpath
//
//  Created by Nguyen Ba Long on 05/07/2019.
//  Copyright © 2019 Steerpath. All rights reserved.
//

#pragma mark - Dependencies
#import <Foundation/Foundation.h>
#import "SPSmartMapNavigationUserTask.h"

NS_ASSUME_NONNULL_BEGIN
#pragma mark - POI Selection User Task Implementation
/**
 	SPSmartMapPOISelectionUserTask class Implementation
 */
@interface SPSmartMapPOISelectionUserTask : SPSmartMapUserTask

/**
	Custom initialize method for SPSmartMapPOISelectionUserTask
 
 	@param object The map object that is the target of POISelectionTask
 	@param shouldAddMarker Determine if the marker should be added when a POI section task is executed
 	@param actionButtonText Custom text that should appear in POI information view
 	@param icon The icon name of the button inside POI information view
 */
-(instancetype)initWith:(SPSmartMapObject*)object shouldAddMarker:(BOOL)shouldAddMarker actionButtonText:(NSString*)actionButtonText actionButtonIcon:(NSString*)icon;

#pragma mark - Public methods
/**
 	Return the current map object
 
 	@return The current map object
 */
-(SPSmartMapObject*)getMapObject;

/**
 	Return the flag if a marker should be added
 
 	@return should a marker be added
 */
-(BOOL)shouldAddMarker;

/**
 	Return the action button text
 
 	@return The action button text
 */
-(NSString*)getActionButtonText;

/**
 	Return icon name. It should be from the application bundle
 
 	@return icon name
 */
-(NSString*)iconName;

@end

NS_ASSUME_NONNULL_END

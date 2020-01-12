using System;
using Foundation;
using ObjCRuntime;
using SteerpathSmartSDK;
using UIKit;

namespace SteerpathSmartSDK
{
	// @interface SPSmartMapObject : NSObject
	[BaseType (typeof(NSObject))]
	interface SPSmartMapObject
	{
		// @property (nonatomic, strong) NSString * _Nonnull title;
		[Export ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (assign, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; set; }

		// @property (assign, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; set; }

		// @property (assign, nonatomic) NSInteger floorIndex;
		[Export ("floorIndex")]
		nint FloorIndex { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull localRef;
		[Export ("localRef", ArgumentSemantic.Strong)]
		string LocalRef { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull buildingRef;
		[Export ("buildingRef", ArgumentSemantic.Strong)]
		string BuildingRef { get; set; }

		// @property (assign, nonatomic) SPObjectSource source;
		[Export ("source", ArgumentSemantic.Assign)]
		SPObjectSource Source { get; set; }

		// -(instancetype _Nonnull)initWithLatitude:(double)latitude longitude:(double)longitude floorIndex:(NSInteger)floorIndex localRef:(NSString * _Nonnull)localRef buildingRef:(NSString * _Nonnull)buildingRef;
		[Export ("initWithLatitude:longitude:floorIndex:localRef:buildingRef:")]
		IntPtr Constructor (double latitude, double longitude, nint floorIndex, string localRef, string buildingRef);
	}

	// @protocol SPSmartMapViewDelegate <NSObject>
	
	[BaseType (typeof(NSObject))]
	[Model, Protocol]
	interface SPSmartMapViewDelegate
	{
		// @optional -(void)onMapLoaded;
		[Export ("onMapLoaded")]
		void OnMapLoaded ();

		// @optional -(void)onMapClicked:(NSArray<SPSmartMapObject *> * _Nonnull)objects;
		[Export ("onMapClicked:")]
		void OnMapClicked (SPSmartMapObject[] objects);

		// @optional -(void)onViewStatusChanged:(SPMapViewStatus)status withPOIDetail:(SPSmartMapObject * _Nullable)objectDetail;
		[Export ("onViewStatusChanged:withPOIDetail:")]
		void OnViewStatusChanged (SPMapViewStatus status, [NullAllowed] SPSmartMapObject objectDetail);

		// @optional -(void)onVisibleFloorChanged:(NSInteger)floorIndex buildingRef:(NSString * _Nullable)buildingRef;
		[Export ("onVisibleFloorChanged:buildingRef:")]
		void OnVisibleFloorChanged (nint floorIndex, [NullAllowed] string buildingRef);

		// @optional -(void)onUserFloorChanged:(NSInteger)floorIndex buildingRef:(NSString * _Nullable)buildingRef;
		[Export ("onUserFloorChanged:buildingRef:")]
		void OnUserFloorChanged (nint floorIndex, [NullAllowed] string buildingRef);

		// @optional -(void)onNavigationPreviewAppeared;
		[Export ("onNavigationPreviewAppeared")]
		void OnNavigationPreviewAppeared ();

		// @optional -(void)onNavigationStarted;
		[Export ("onNavigationStarted")]
		void OnNavigationStarted ();

		// @optional -(void)onNavigationDestinationReached;
		[Export ("onNavigationDestinationReached")]
		void OnNavigationDestinationReached ();

		// @optional -(void)onNavigationEnded;
		[Export ("onNavigationEnded")]
		void OnNavigationEnded ();

		// @optional -(void)onNavigationFailed:(SPNavigationError)error;
		[Export ("onNavigationFailed:")]
		void OnNavigationFailed (SPNavigationError error);

		// @optional -(void)onLiveObjectWillAppear:(NSString * _Nonnull)identifier;
		[Export ("onLiveObjectWillAppear:")]
		void OnLiveObjectWillAppear (string identifier);

		// @optional -(void)onLiveObjectWillDisappear:(NSString * _Nonnull)identifier;
		[Export ("onLiveObjectWillDisappear:")]
		void OnLiveObjectWillDisappear (string identifier);

		// @optional -(void)onLiveObjectUpdated:(NSString * _Nonnull)identifier inGeofences:(NSArray<NSString *> * _Nonnull)inGeofences status:(SPLiveObjectStatus)status;
		[Export ("onLiveObjectUpdated:inGeofences:status:")]
		void OnLiveObjectUpdated (string identifier, string[] inGeofences, SPLiveObjectStatus status);
	}

	// @interface SPSmartMapUserTask : NSObject
	[BaseType (typeof(NSObject))]
	interface SPSmartMapUserTask
	{
	}

	// @protocol SPSmartMapUserTaskDelegate <NSObject>
	[BaseType (typeof(NSObject))]
	[Model, Protocol]
	interface SPSmartMapUserTaskDelegate
	{
		// @optional -(void)onUserTaskResponse:(SPSmartMapUserTaskResponse)response;
		[Export ("onUserTaskResponse:")]
		void OnUserTaskResponse (SPSmartMapUserTaskResponse response);
	}

	// @interface SPSmartMapNavigationUserTask : SPSmartMapUserTask
	[BaseType (typeof(SPSmartMapUserTask))]
	interface SPSmartMapNavigationUserTask
	{
		// -(instancetype _Nonnull)initWithLocalRef:(NSString * _Nonnull)localRef building:(NSString * _Nonnull)buildingRef;
		[Export ("initWithLocalRef:building:")]
		IntPtr Constructor (string localRef, string buildingRef);

		// -(instancetype _Nonnull)initWithMapObject:(SPSmartMapObject * _Nonnull)object;
		[Export ("initWithMapObject:")]
		IntPtr Constructor (SPSmartMapObject @object);

		// -(instancetype _Nonnull)initWithMapObjects:(NSArray<SPSmartMapObject *> * _Nonnull)listOfObjects;
		[Export ("initWithMapObjects:")]
		IntPtr Constructor (SPSmartMapObject[] listOfObjects);

		// -(void)setOrigin:(SPSmartMapObject * _Nonnull)origin;
		[Export ("setOrigin:")]
		void SetOrigin (SPSmartMapObject origin);

		// -(NSString * _Nullable)getUserTaskLocalRef;
		[NullAllowed, Export ("getUserTaskLocalRef")]
		string UserTaskLocalRef { get; }

		// -(NSString * _Nullable)getUserTaskBuildingRef;
		[NullAllowed, Export ("getUserTaskBuildingRef")]
		string UserTaskBuildingRef { get; }

		// -(SPSmartMapObject * _Nullable)getOrigin;
		[NullAllowed, Export ("getOrigin")]
		SPSmartMapObject Origin { get; }

		// -(NSArray<SPSmartMapObject *> * _Nullable)getNavigationObjects;
		[NullAllowed, Export ("getNavigationObjects")]
		SPSmartMapObject[] NavigationObjects { get; }
	}

	// @interface SPSmartMapView : UIView
	[BaseType (typeof(UIView))]
	interface SPSmartMapView
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		SPSmartMapViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SPSmartMapViewDelegate> _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakUserTaskDelegate")]
		[NullAllowed]
		SPSmartMapUserTaskDelegate UserTaskDelegate { get; set; }

		// @property (nonatomic, weak) id<SPSmartMapUserTaskDelegate> _Nullable userTaskDelegate;
		[NullAllowed, Export ("userTaskDelegate", ArgumentSemantic.Weak)]
		NSObject WeakUserTaskDelegate { get; set; }

		// -(void)setCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel;
		[Export ("setCamera:longitude:zoomLevel:")]
		void SetCamera (double latitude, double longitude, double zoomLevel);

		// -(void)setCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch;
		[Export ("setCamera:longitude:zoomLevel:bearing:pitch:")]
		void SetCamera (double latitude, double longitude, double zoomLevel, double bearing, double pitch);

		// -(void)setCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch floorIndex:(int)floorIndex buildingRef:(NSString * _Nonnull)buildingRef;
		[Export ("setCamera:longitude:zoomLevel:bearing:pitch:floorIndex:buildingRef:")]
		void SetCamera (double latitude, double longitude, double zoomLevel, double bearing, double pitch, int floorIndex, string buildingRef);

		// -(void)setCameraToObject:(NSString * _Nonnull)localRef buildingRef:(NSString * _Nonnull)buildingRef zoomLevel:(double)zoomLevel completion:(void (^ _Nullable)(SPMapResponse))completionBlock;
		[Export ("setCameraToObject:buildingRef:zoomLevel:completion:")]
		void SetCameraToObject (string localRef, string buildingRef, double zoomLevel, [NullAllowed] Action<SPMapResponse> completionBlock);

		// -(void)setCameraToBuildingRef:(NSString * _Nonnull)buildingRef completion:(void (^ _Nullable)(SPMapResponse))completionBlock;
		[Export ("setCameraToBuildingRef:completion:")]
		void SetCameraToBuildingRef (string buildingRef, [NullAllowed] Action<SPMapResponse> completionBlock);

		// -(void)animateCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel completion:(void (^ _Nullable)(SPMapResponse))completionBlock;
		[Export ("animateCamera:longitude:zoomLevel:completion:")]
		void AnimateCamera (double latitude, double longitude, double zoomLevel, [NullAllowed] Action<SPMapResponse> completionBlock);

		// -(void)animateCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch completion:(void (^ _Nullable)(SPMapResponse))completionBlock;
		[Export ("animateCamera:longitude:zoomLevel:bearing:pitch:completion:")]
		void AnimateCamera (double latitude, double longitude, double zoomLevel, double bearing, double pitch, [NullAllowed] Action<SPMapResponse> completionBlock);

		// -(void)animateCamera:(double)latitude longitude:(double)longitude zoomLevel:(double)zoomLevel bearing:(double)bearing pitch:(double)pitch floorIndex:(int)floorIndex buildingRef:(NSString * _Nonnull)buildingRef completion:(void (^ _Nullable)(SPMapResponse))completionBlock;
		[Export ("animateCamera:longitude:zoomLevel:bearing:pitch:floorIndex:buildingRef:completion:")]
		void AnimateCamera (double latitude, double longitude, double zoomLevel, double bearing, double pitch, int floorIndex, string buildingRef, [NullAllowed] Action<SPMapResponse> completionBlock);

		// -(void)animateCameraToObject:(NSString * _Nonnull)localRef buildingRef:(NSString * _Nonnull)buildingRef zoomLevel:(double)zoomLevel completion:(void (^ _Nullable)(SPMapResponse))completionBlock;
		[Export ("animateCameraToObject:buildingRef:zoomLevel:completion:")]
		void AnimateCameraToObject (string localRef, string buildingRef, double zoomLevel, [NullAllowed] Action<SPMapResponse> completionBlock);

		// -(void)animateCameraToBuildingRef:(NSString * _Nonnull)buildingRef completion:(void (^ _Nullable)(SPMapResponse))completionBlock;
		[Export ("animateCameraToBuildingRef:completion:")]
		void AnimateCameraToBuildingRef (string buildingRef, [NullAllowed] Action<SPMapResponse> completionBlock);

		// -(void)getMapObject:(NSString * _Nonnull)localRef buildingRef:(NSString * _Nonnull)buildingRef source:(SPObjectSource)source completion:(void (^ _Nullable)(SPSmartMapObject * _Nullable, SPMapResponse))completionBlock;
		[Export ("getMapObject:buildingRef:source:completion:")]
		void GetMapObject (string localRef, string buildingRef, SPObjectSource source, [NullAllowed] Action<SPSmartMapObject, SPMapResponse> completionBlock);

		// -(void)setLiveObjectInfo:(NSString * _Nonnull)identifier key:(NSString * _Nonnull)key value:(NSString * _Nonnull)value;
		[Export ("setLiveObjectInfo:key:value:")]
		void SetLiveObjectInfo (string identifier, string key, string value);

		// -(void)selectMapObject:(NSString * _Nonnull)localRef buildingRef:(NSString * _Nonnull)buildingRef __attribute__((swift_name("selectMapObject(_:_:)")));
		[Export ("selectMapObject:buildingRef:")]
		void SelectMapObject (string localRef, string buildingRef);

		// -(void)selectMapObject:(SPSmartMapObject * _Nonnull)mapObject __attribute__((swift_name("selectMapObject(_:)")));
		[Export ("selectMapObject:")]
		void SelectMapObject (SPSmartMapObject mapObject);

		// -(void)addMarker:(SPSmartMapObject * _Nonnull)mapObject;
		[Export ("addMarker:")]
		void AddMarker (SPSmartMapObject mapObject);

		// -(void)addMarker:(SPSmartMapObject * _Nonnull)mapObject layout:(SPLayout)layout iconName:(NSString * _Nonnull)iconName textColor:(NSString * _Nonnull)textColor textHaloColor:(NSString * _Nonnull)textHaloColor;
		[Export ("addMarker:layout:iconName:textColor:textHaloColor:")]
		void AddMarker (SPSmartMapObject mapObject, SPLayout layout, string iconName, string textColor, string textHaloColor);

		// -(void)addMarkers:(NSArray<SPSmartMapObject *> * _Nonnull)mapObjects;
		[Export ("addMarkers:")]
		void AddMarkers (SPSmartMapObject[] mapObjects);

		// -(void)addMarkers:(NSArray<SPSmartMapObject *> * _Nonnull)mapObjects layout:(SPLayout)layout iconName:(NSString * _Nonnull)iconName textColor:(NSString * _Nonnull)textColor textHaloColor:(NSString * _Nonnull)textHaloColor;
		[Export ("addMarkers:layout:iconName:textColor:textHaloColor:")]
		void AddMarkers (SPSmartMapObject[] mapObjects, SPLayout layout, string iconName, string textColor, string textHaloColor);

		// -(void)removeMarker:(SPSmartMapObject * _Nonnull)mapObject;
		[Export ("removeMarker:")]
		void RemoveMarker (SPSmartMapObject mapObject);

		// -(void)removeMarkers:(NSArray<SPSmartMapObject *> * _Nonnull)mapObjects;
		[Export ("removeMarkers:")]
		void RemoveMarkers (SPSmartMapObject[] mapObjects);

		// -(void)removeAllMarkers;
		[Export ("removeAllMarkers")]
		void RemoveAllMarkers ();

		// -(void)addIconImage:(NSString * _Nonnull)iconName image:(UIImage * _Nonnull)image;
		[Export ("addIconImage:image:")]
		void AddIconImage (string iconName, UIImage image);

		// -(void)setMapMode:(SPMapMode)mapMode;
		[Export ("setMapMode:")]
		void SetMapMode (SPMapMode mapMode);

		// -(void)startUserTask:(SPSmartMapUserTask * _Nonnull)userTask;
		[Export ("startUserTask:")]
		void StartUserTask (SPSmartMapUserTask userTask);

		// -(SPSmartMapUserTask * _Nullable)getCurrentUserTask;
		[NullAllowed, Export ("getCurrentUserTask")]
		SPSmartMapUserTask CurrentUserTask { get; }

		// -(void)cancelCurrentUserTask;
		[Export ("cancelCurrentUserTask")]
		void CancelCurrentUserTask ();
	}

	// @interface SPSmartSDK : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface SPSmartSDK
	{
		// +(instancetype _Nonnull)getInstance;
		[Static]
		[Export ("getInstance")]
		SPSmartSDK GetInstance ();

		// -(void)start:(NSString * _Nonnull)apiKey;
		[Export ("start:")]
		void Start (string apiKey);

		// -(void)setLiveConfiguration:(NSDictionary * _Nonnull)configuration;
		[Export ("setLiveConfiguration:")]
		void SetLiveConfiguration (NSDictionary configuration);
	}

	[Static]
	partial interface Constants
	{
		// extern NSString *const kSPSmartGeofenceErrorDomain;
		[Field ("kSPSmartGeofenceErrorDomain", "__Internal")]
		NSString kSPSmartGeofenceErrorDomain { get; }
	}

	// @protocol SPSmartGeofenceManagerDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface SPSmartGeofenceManagerDelegate
	{
		// @optional -(void)spSmartGeofenceManager:(SPSmartGeofenceManager *)manager didEnterGeofence:(NSString *)localRef building:(NSString *)buildingRef;
		[Export ("spSmartGeofenceManager:didEnterGeofence:building:")]
		void DidEnterGeofence (SPSmartGeofenceManager manager, string localRef, string buildingRef);

		// @optional -(void)spSmartGeofenceManager:(SPSmartGeofenceManager *)manager didExitGeofence:(NSString *)localRef building:(NSString *)buildingRef;
		[Export ("spSmartGeofenceManager:didExitGeofence:building:")]
		void DidExitGeofence (SPSmartGeofenceManager manager, string localRef, string buildingRef);

		// @optional -(void)spSmartGeofenceManager:(SPSmartGeofenceManager *)manager didEnterBeaconfence:(NSString *)beaconId;
		[Export ("spSmartGeofenceManager:didEnterBeaconfence:")]
		void DidEnterBeaconfence (SPSmartGeofenceManager manager, string beaconId);

		// @optional -(void)spSmartGeofenceManager:(SPSmartGeofenceManager *)manager didExitBeaconfence:(NSString *)beaconId;
		[Export ("spSmartGeofenceManager:didExitBeaconfence:")]
		void DidExitBeaconfence (SPSmartGeofenceManager manager, string beaconId);
	}

	// @interface SPSmartGeofenceManager : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface SPSmartGeofenceManager
	{
		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		SPSmartGeofenceManager SharedInstance ();

		// -(void)addGeofence:(NSString * _Nonnull)localRef building:(NSString * _Nonnull)buildingRef completion:(void (^ _Nullable)(SPSmartGeofenceResponseType))completionBlock;
		[Export ("addGeofence:building:completion:")]
		void AddGeofence (string localRef, string buildingRef, [NullAllowed] Action<SPSmartGeofenceResponseType> completionBlock);

		// -(void)removeGeofence:(NSString * _Nonnull)localRef building:(NSString * _Nonnull)buildingRef;
		[Export ("removeGeofence:building:")]
		void RemoveGeofence (string localRef, string buildingRef);

		// -(void)addDelegate:(id<SPSmartGeofenceManagerDelegate> _Nonnull)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (SPSmartGeofenceManagerDelegate @delegate);

		// -(void)removeDelegate:(id<SPSmartGeofenceManagerDelegate> _Nonnull)delegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (SPSmartGeofenceManagerDelegate @delegate);

		// -(void)addBeaconfences;
		[Export ("addBeaconfences")]
		void AddBeaconfences ();

		// -(void)removeBeaconfences;
		[Export ("removeBeaconfences")]
		void RemoveBeaconfences ();

		// -(void)addBeaconfence:(NSString * _Nonnull)beaconId radius:(NSInteger)radiusInMeter loiteringDelay:(NSTimeInterval)loiteringDelayInSecond completion:(void (^ _Nullable)(SPSmartGeofenceResponseType))completionBlock;
		[Export ("addBeaconfence:radius:loiteringDelay:completion:")]
		void AddBeaconfence (string beaconId, nint radiusInMeter, double loiteringDelayInSecond, [NullAllowed] Action<SPSmartGeofenceResponseType> completionBlock);

		// -(void)removeBeaconfence:(NSString * _Nonnull)beaconId;
		[Export ("removeBeaconfence:")]
		void RemoveBeaconfence (string beaconId);
	}
}

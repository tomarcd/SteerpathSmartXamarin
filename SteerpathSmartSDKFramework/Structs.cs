using ObjCRuntime;

namespace SteerpathSmartSDK
{
	[Native]
	public enum SPObjectSource : ulong
	{
		Static = 0,
		Marker = 1,
		Live = 2
	}

	[Native]
	public enum SPLayout : ulong
	{
		Top = 0,
		Bottom = 1,
		Right = 2,
		Left = 3
	}

	[Native]
	public enum SPLiveObjectStatus : ulong
	{
		Unknown = 0,
		Neutral = 1,
		Allowed = 2,
		Forbidden = 3
	}

	[Native]
	public enum SPNavigationError : ulong
	{
		ObjectNotFound = 0,
		RouteNotFound = 1,
		UserLocationNotFound = 2
	}

	[Native]
	public enum SPMapViewStatus : ulong
	{
		SearchInExpandedMode,
		SearchInPreferredHeight,
		SearchInMinHeight,
		CardView,
		ErrorView,
		NavigatingView,
		OnlyMap,
		SettingView
	}

	[Native]
	public enum SPSmartMapUserTaskResponse : long
	{
		Started,
		Ended,
		Error,
		Busy,
		UnSupported
	}

	[Native]
	public enum SPMapResponse : ulong
	{
		Success = 0,
		ObjectNotFound = 1,
		NetworkError = 2
	}

	[Native]
	public enum SPMapMode : ulong
	{
		MapOnly,
		Static,
		Search
	}

	[Native]
	public enum SPSmartGeofenceResponseType : ulong
	{
		GeofenceNotFound = 1,
		MalformedData = 2,
		Success = 3
	}
}

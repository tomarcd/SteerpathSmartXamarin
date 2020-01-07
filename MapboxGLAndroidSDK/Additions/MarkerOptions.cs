using System;
using Android.Runtime;

namespace Com.Mapbox.Mapboxsdk.Annotations
{
    public  partial class MarkerOptions : global::Com.Mapbox.Mapboxsdk.Annotations.BaseMarkerOptions, global::Android.OS.IParcelable
    {
        protected override global::Java.Lang.Object RawThis
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.mapbox.mapboxsdk.annotations']/class[@name='BaseMarkerOptions']/method[@name='getThis' and count(parameter)=0]"
            [Register("getThis", "()Lcom/mapbox/mapboxsdk/annotations/BaseMarkerOptions;", "GetGetThisHandler")]
            get;
        }

        protected override global::Java.Lang.Object RawMarker
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.mapbox.mapboxsdk.annotations']/class[@name='BaseMarkerOptions']/method[@name='getMarker' and count(parameter)=0]"
            [Register("getMarker", "()Lcom/mapbox/mapboxsdk/annotations/Marker;", "GetGetMarkerHandler")]
            get;
        }
    }
}

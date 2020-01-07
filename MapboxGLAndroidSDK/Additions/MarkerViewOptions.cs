using System;
using Android.Runtime;

namespace Com.Mapbox.Mapboxsdk.Annotations
{
    public partial class MarkerViewOptions : global::Com.Mapbox.Mapboxsdk.Annotations.BaseMarkerViewOptions
    {

        protected override global::Java.Lang.Object RawThis
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.mapbox.mapboxsdk.annotations']/class[@name='BaseMarkerViewOptions']/method[@name='getThis' and count(parameter)=0]"
            [Register("getThis", "()Lcom/mapbox/mapboxsdk/annotations/BaseMarkerViewOptions;", "GetGetThisHandler")]
            get;
        }

        protected override global::Java.Lang.Object RawMarker
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.mapbox.mapboxsdk.annotations']/class[@name='BaseMarkerViewOptions']/method[@name='getMarker' and count(parameter)=0]"
            [Register("getMarker", "()Lcom/mapbox/mapboxsdk/annotations/MarkerView;", "GetGetMarkerHandler")]
            get;
        }

    }
}

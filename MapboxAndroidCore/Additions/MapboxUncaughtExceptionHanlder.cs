using System;
using Android.Content;

namespace Com.Mapbox.Android.Core.Crashreporter
{
    public partial class MapboxUncaughtExceptionHanlder : global::Java.Lang.Object, global::Android.Content.ISharedPreferencesOnSharedPreferenceChangeListener, global::Java.Lang.Thread.IUncaughtExceptionHandler
    {
        public void OnSharedPreferenceChanged(ISharedPreferences sharedPreferences, string key)
        {
            
        }
    }
}

using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Steerpath.Sdk.Meta;
using Com.Steerpath.Smart;
using static Com.Steerpath.Sdk.Meta.MetaQuery;

namespace SteerpathSmartXamarin.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity , Com.Steerpath.Sdk.Meta.MetaLoader.ILoadListener
    {
        readonly string SmartMapFragmentTag = "map";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            if (savedInstanceState == null)
            {
                SmartMapFragment map = SmartMapFragment.NewInstance();
                SupportFragmentManager
                    .BeginTransaction()
                    .Replace(Resource.Id.map_container, map, SmartMapFragmentTag)
                    .Commit();
            }

            MetaLoader.Load((Com.Steerpath.Sdk.Meta.MetaQuery)new MetaQuery.Builder(this, DataType.Buildings).Build(), this);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected SmartMapFragment GetMap()
        {
            return (SmartMapFragment)SupportFragmentManager.FindFragmentByTag(SmartMapFragmentTag);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnLoaded(MetaQueryResult p0)
        {
            if (p0.IsSuccess) {
                if (p0.MetaFeatures.Count > 0) {
                    SmartMapFragment map = GetMap();
                    if (map != null) {
                        map.NavigateToObject(ToSmartMapObject(p0.MetaFeatures[0]));
                    }
                }
            }
        }

        private  SmartMapObject ToSmartMapObject(MetaFeature var0)
        {
            SmartMapObject var2 = new SmartMapObject(var0.Latitude, var0.Longitude, var0.FloorIndex, /*var0.LocalRef*/"room", var0.BuildingRef);
            var2.Title = var0.Title;
            var2.Source = ObjectSource.Marker;
            return var2;
        }
    }
}


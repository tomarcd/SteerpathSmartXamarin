using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Mapbox.Mapboxsdk.Camera;
using Com.Mapbox.Mapboxsdk.Geometry;
using Com.Steerpath.Sdk.Maps;
using Com.Steerpath.Sdk.Meta;

namespace SteerpathSmartXamarin.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, MetaLoader.ILoadListener, SteerpathMapFragment.IMapViewListener
    {
        readonly string SteerpathMapFragmentTag = "steerpath-map-fragment";

        protected SteerpathMap map = null;
        protected SteerpathMapView mapView = null;
        protected MetaFeature building;
        protected IList<MetaFeature> features;

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
                SupportFragmentManager.BeginTransaction().Replace(
                        Resource.Id.map_container, SteerpathMapFragment.NewInstance(), "steerpath-map-fragment").Commit();
            }

            var query = (Com.Steerpath.Sdk.Meta.MetaQuery)new MetaQuery.Builder(this, MetaQuery.DataType.Buildings).Build();
            MetaLoader.Load(query, new BuildingLoadListener(this));
        }

        private void LoadPois(string buildingRef)
        {
            var query = (Com.Steerpath.Sdk.Meta.MetaQuery)new MetaQuery.Builder(this, MetaQuery.DataType.PointsOfInterest)
                    .Building(buildingRef)
                    .Build();
            MetaLoader.Load(query, this);
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

        protected SteerpathMapFragment GetMap()
        {
            return (SteerpathMapFragment)SupportFragmentManager.FindFragmentByTag(SteerpathMapFragmentTag);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnLoaded(MetaQueryResult metaQueryResult)
        {
            if (metaQueryResult.IsSuccess) {
                if (metaQueryResult.MetaFeatures.Count > 0) {
                    features = metaQueryResult.MetaFeatures;
                }
            }
        }

        public void OnMapViewReady(SteerpathMapView mapView)
        {
            this.mapView = mapView;
            mapView.GetMapAsync(new MapReadyCallback(this));
        }

        protected void ShowBuilding()
        {
            if (mapView != null) {
                mapView.GetMapAsync(new MapReadyCallback(this));
            }
        }

        protected  void MoveCameraTo(SteerpathMap map, MetaFeature feature)
        {
            if (feature != null)
            {
                map.SetCameraPosition(new CameraPosition.Builder()
                        .Target(new LatLng(feature.Latitude, feature.Longitude))
                        .Zoom(18)
                        .Build());
            }
        }

        protected class MapReadyCallback : Java.Lang.Object, Com.Steerpath.Sdk.Maps.IOnMapReadyCallback
        {
            MainActivity _parent;
            public MapReadyCallback(MainActivity parent)
            {
                _parent = parent;
            }

            public void OnMapReady(SteerpathMap steerpathMap)
            {
                _parent.map = steerpathMap;
                _parent.map.SetMyLocationEnabled(true);
                _parent.map.SetTiltGesturesEnabled(true);
                _parent.MoveCameraTo(_parent.map, _parent.building);
            }
        }



        protected class BuildingLoadListener : Java.Lang.Object, MetaLoader.ILoadListener
        {
            MainActivity _parent;
            public BuildingLoadListener(MainActivity parent)
            {
                _parent = parent;
            }

            public void OnLoaded(MetaQueryResult p0)
            {
                if (p0.IsSuccess)
                {
                    if (p0.MetaFeatures.Count > 0)
                    {
                        _parent.building = p0.MetaFeatures[0];
                        _parent.ShowBuilding();
                        _parent.LoadPois(_parent.building.BuildingRef);
                    }
                }
            }
        }
    }
}


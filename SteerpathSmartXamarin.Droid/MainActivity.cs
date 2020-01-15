using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Com.Steerpath.Smart;

namespace SteerpathSmartXamarin.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            if (savedInstanceState == null)
            {
                SmartMapFragment map = SmartMapFragment.NewInstance();
                SupportFragmentManager
                        .BeginTransaction()
                        .Replace(Resource.Id.map_container, map, "map")
                        .Commit();
                //map.setMapEventListener(this);
            }
        }

    }
}


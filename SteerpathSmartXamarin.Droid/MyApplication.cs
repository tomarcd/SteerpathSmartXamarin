using System;
using Android.App;
using Com.Steerpath.Sdk.Common;

namespace MatiIntegration.Droid
{
    [Application]
    public class MyApplication : Application , Com.Steerpath.Sdk.Common.SteerpathClient.IStartListener
    {
        public readonly String DEFAULT_APIKEY = "eyJhbGciOiJSUzI1NiJ9.eyJpYXQ6IjoxNTU3NzUyNzUzLCJqdGkiOiI3NDRiNDYwMS0xZDhhLTQxZTktYTFmYS1mMzEwNWVhZGU4MTYiLCJzY29wZXMiOiJ2Mi0wNDMyODYzNi05Y2Y3LTRjNzUtYjIxZS01ZDMyMjU1Mjc5NzAtcHVibGlzaGVkOnIiLCJzdWIiOiJ2Mi0wNDMyODYzNi05Y2Y3LTRjNzUtYjIxZS01ZDMyMjU1Mjc5NzAifQ.GMlXAGgF8DoxPQrImu5Wno8_EZf859kIv9YW6qCilBuIvUBGp8aU0o4YFj-0rMYy3vuYjmyHXAyhsQv4aQ_6b6D18aC4Y4FczEe8ODU2AMPPRIwoLQje9AY3uhVxdYZpms3RFW8D3lUywU6rBdiNH9PGQdFyCBSaMh9rrRlyjZPKyoJEUPYOi9Xkkw_hHEXFsjAyZ84iinyMHPIsjY93cWO4mwtjia48YrJbIoXyc1rTKP7K8wm_QfwC7z4kB0Xv_wsUq-Yqlq8eb5Dv02N60PhfjG8G6oxsO5YBO01dz8jSlbBuWx1qa94RYxioG3_htcGaEgVftQjsIfjvGn6w0Q";
        public readonly String DEFAULT_NAME = "Steerpath Office";


        public MyApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            
            SteerpathClient.StartConfig config = new SteerpathClient.StartConfig.Builder()
                .Name(DEFAULT_NAME)
                .ApiKey(DEFAULT_APIKEY)

                // OPTIONAL:
                // 1. OfflineBundle contains metadata, style, positioning, routing and vector tile data. Makes map features usable with bad
                // network conditions or without network at all.
                // For obtaining OfflineBundle, contact support@steerpath.com
                // .sff file must be located in /assets -folder
                // If your setup contains many large buildings and you have low end device, first initial start() may take awhile.
                // Subsequent calls are much faster.
                //.installOfflineBundle("sp_offline_data_20170703T055713Z.sff")

                // 2. OPTIONAL: Enables Steerpath Telemetry
                //.telemetry(new TelemetryConfig.Builder(context)
                //        .accessToken("YOUR_TELEMETRY_ACCESS_TOKEN")
                //        .baseUrl("YOUR_TELEMETRY_URL")
                //        .build())

                // 3. Enables some developer options. PLEASE DISABLE DEVELOPER OPTIONS IN PRODUCTION!
                // This will add "Monitor"-button above "LocateMe"-button as a visual reminder developer options are in use
                // Use logcat filter "Monitor", for example: adb logcat *:S Monitor:V
                .DeveloperOptions(DeveloperOptions.Disabled)

                .Build();

                SteerpathClient.Instance.Start(this, config, this);
        }

        public void OnError(int p0, int p1, string p2)
        {
           
        }

        public void OnStarted()
        {
            
        }
    }
}

using System;
using Android.App;
using Com.Steerpath.Smart;

namespace SteerpathSmartXamarin.Droid
{
    [Application]
    public class MyApplication : Application
    {
        public MyApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            SmartSDK.Instance.Start(this, "eyJhbGciOiJSUzI1NiJ9.eyJpYXQ6IjoxNTU3NzUyNzUzLCJqdGkiOiI3NDRiNDYwMS0xZDhhLTQxZTktYTFmYS1mMzEwNWVhZGU4MTYiLCJzY29wZXMiOiJ2Mi0wNDMyODYzNi05Y2Y3LTRjNzUtYjIxZS01ZDMyMjU1Mjc5NzAtcHVibGlzaGVkOnIiLCJzdWIiOiJ2Mi0wNDMyODYzNi05Y2Y3LTRjNzUtYjIxZS01ZDMyMjU1Mjc5NzAifQ.GMlXAGgF8DoxPQrImu5Wno8_EZf859kIv9YW6qCilBuIvUBGp8aU0o4YFj-0rMYy3vuYjmyHXAyhsQv4aQ_6b6D18aC4Y4FczEe8ODU2AMPPRIwoLQje9AY3uhVxdYZpms3RFW8D3lUywU6rBdiNH9PGQdFyCBSaMh9rrRlyjZPKyoJEUPYOi9Xkkw_hHEXFsjAyZ84iinyMHPIsjY93cWO4mwtjia48YrJbIoXyc1rTKP7K8wm_QfwC7z4kB0Xv_wsUq-Yqlq8eb5Dv02N60PhfjG8G6oxsO5YBO01dz8jSlbBuWx1qa94RYxioG3_htcGaEgVftQjsIfjvGn6w0Q");

        }
    }
}

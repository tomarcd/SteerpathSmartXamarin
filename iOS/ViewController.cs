using System;
using SteerpathSmartSDK;
using UIKit;

namespace SteerpathSmartXamarin.iOS
{
    public partial class ViewController : UIViewController, ISPSmartMapViewDelegate
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        public  void OnMapLoaded()
        {
        }
    }
}

using Foundation;
using SteerpathSmartSDK;
using UIKit;

namespace SteerpathSmartXamarin.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            SPSmartSDK.GetInstance().Start("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIndyYXBwZWQiOnRydWV9.eyJjbGllbnRfdG9rZW4iOiJleUpoYkdjaU9pSlNVekkxTmlKOS5leUpwWVhRNklqb3hOVFUzTnpVeU56VXpMQ0pxZEdraU9pSTNORFJpTkRZd01TMHhaRGhoTFRReFpUa3RZVEZtWVMxbU16RXdOV1ZoWkdVNE1UWWlMQ0p6WTI5d1pYTWlPaUoyTWkwd05ETXlPRFl6TmkwNVkyWTNMVFJqTnpVdFlqSXhaUzAxWkRNeU1qVTFNamM1TnpBdGNIVmliR2x6YUdWa09uSWlMQ0p6ZFdJaU9pSjJNaTB3TkRNeU9EWXpOaTA1WTJZM0xUUmpOelV0WWpJeFpTMDFaRE15TWpVMU1qYzVOekFpZlEuR01sWEFHZ0Y4RG94UFFySW11NVdubzhfRVpmODU5a0l2OVlXNnFDaWxCdUl2VUJHcDhhVTBvNFlGai0wck1ZeTN2dVlqbXlIWEF5aHNRdjRhUV82YjZEMThhQzRZNEZjekVlOE9EVTJBTVBQUkl3b0xRamU5QVkzdWhWeGRZWnBtczNSRlc4RDNsVXl3VTZyQmRpTkg5UEdRZEZ5Q0JTYU1oOXJyUmx5alpQS3lvSkVVUFlPaTlYa2t3X2hIRVhGc2pBeVo4NGlpbnlNSFBJc2pZOTNjV080bXd0amlhNDhZckpiSW9YeWMxclRLUDdLOHdtX1Fmd0M3ejRrQjBYdl93c1VxLVlxbHE4ZWI1RHYwMk42MFBoZmpHOEc2b3hzTzVZQk8wMWR6OGpTbGJCdVd4MXFhOTRSWXhpb0czX2h0Y0dhRWdWZnRRanNJZmp2R242dzBRIiwiaWF0IjoxNTc4OTA0MDI4LCJpc3MiOiJzdGVlcnBhdGhfd3JhcHBlciIsImp0aSI6ImJhY2IxODU5LWViYmUtNGVhYy04MWVmLTcwYmEzZDQwZGI2ZCJ9.U_Xq077uOu1dzg1seRf3m7A_6KOy8HHLCn3lzog4tMI_MbP1ItErbLoNSDm5324894dUssKWEkCc5bycoCt8m9UKDyTNw482250xu604Ycv1qJa0OEjtT6OG4OMebJq2OB9fHPg1XN2TXd_H0EX5CObm01vVspsuuWsHCM-INxbHaqaYZ4wDjneKuveRxZG2XsxluP7TePOAVSjq7SQbHv6M9SiM-yLSZEaydP_tmAcrp2H7W2zaRFM0YQBD1srtTcjzPf5yRAUKVdfwLpIx4AmgznqxoLETQv9nFnXs3ZcI-qENCevNijxpbthHtGrPSM-9HyoWdf1mbnhHda5PIA");

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}


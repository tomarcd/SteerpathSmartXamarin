﻿using System;
using Android.App;
using Com.Steerpath.Smart;

namespace SteerpathSmartXamarin.Droid
{
    [Application (UsesCleartextTraffic =true)]
    public class MyApplication : Application
    {
        static String newPublicKey = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIndyYXBwZWQiOnRydWV9.eyJjbGllbnRfdG9rZW4iOiJleUpoYkdjaU9pSlNVekkxTmlKOS5leUpwWVhRNklqb3hOVFUzTnpVeU56VXpMQ0pxZEdraU9pSTNORFJpTkRZd01TMHhaRGhoTFRReFpUa3RZVEZtWVMxbU16RXdOV1ZoWkdVNE1UWWlMQ0p6WTI5d1pYTWlPaUoyTWkwd05ETXlPRFl6TmkwNVkyWTNMVFJqTnpVdFlqSXhaUzAxWkRNeU1qVTFNamM1TnpBdGNIVmliR2x6YUdWa09uSWlMQ0p6ZFdJaU9pSjJNaTB3TkRNeU9EWXpOaTA1WTJZM0xUUmpOelV0WWpJeFpTMDFaRE15TWpVMU1qYzVOekFpZlEuR01sWEFHZ0Y4RG94UFFySW11NVdubzhfRVpmODU5a0l2OVlXNnFDaWxCdUl2VUJHcDhhVTBvNFlGai0wck1ZeTN2dVlqbXlIWEF5aHNRdjRhUV82YjZEMThhQzRZNEZjekVlOE9EVTJBTVBQUkl3b0xRamU5QVkzdWhWeGRZWnBtczNSRlc4RDNsVXl3VTZyQmRpTkg5UEdRZEZ5Q0JTYU1oOXJyUmx5alpQS3lvSkVVUFlPaTlYa2t3X2hIRVhGc2pBeVo4NGlpbnlNSFBJc2pZOTNjV080bXd0amlhNDhZckpiSW9YeWMxclRLUDdLOHdtX1Fmd0M3ejRrQjBYdl93c1VxLVlxbHE4ZWI1RHYwMk42MFBoZmpHOEc2b3hzTzVZQk8wMWR6OGpTbGJCdVd4MXFhOTRSWXhpb0czX2h0Y0dhRWdWZnRRanNJZmp2R242dzBRIiwiaWF0IjoxNTc4OTA0MDI4LCJpc3MiOiJzdGVlcnBhdGhfd3JhcHBlciIsImp0aSI6ImJhY2IxODU5LWViYmUtNGVhYy04MWVmLTcwYmEzZDQwZGI2ZCJ9.U_Xq077uOu1dzg1seRf3m7A_6KOy8HHLCn3lzog4tMI_MbP1ItErbLoNSDm5324894dUssKWEkCc5bycoCt8m9UKDyTNw482250xu604Ycv1qJa0OEjtT6OG4OMebJq2OB9fHPg1XN2TXd_H0EX5CObm01vVspsuuWsHCM-INxbHaqaYZ4wDjneKuveRxZG2XsxluP7TePOAVSjq7SQbHv6M9SiM-yLSZEaydP_tmAcrp2H7W2zaRFM0YQBD1srtTcjzPf5yRAUKVdfwLpIx4AmgznqxoLETQv9nFnXs3ZcI-qENCevNijxpbthHtGrPSM-9HyoWdf1mbnhHda5PIA";
        static String theKey = newPublicKey;

        public MyApplication(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            SmartSDK.Instance.Start(this, theKey);
        }
    }
}

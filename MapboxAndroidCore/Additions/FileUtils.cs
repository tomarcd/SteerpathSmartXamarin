using System;

namespace Com.Mapbox.Android.Core
{
    public sealed partial class FileUtils : global::Java.Lang.Object
    {
        public sealed partial class LastModifiedComparator : global::Java.Lang.Object, global::Java.Util.IComparator
        {
            public int Compare(Java.Lang.Object o1, Java.Lang.Object o2)
            {
                return Compare((global::Java.IO.File)o1, (global::Java.IO.File)o2);
            }
        }
    }
}

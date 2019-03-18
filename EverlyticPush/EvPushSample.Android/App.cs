using System;
using Android.App;
using Android.Runtime;
using Com.EverlyticPush;

namespace EvPushSample.Android
{
    [Application]
    public class App : Application
    {
        public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Everlytic.Instance
                .SetTestMode(true)
                .Initialize();
        }
    }
}
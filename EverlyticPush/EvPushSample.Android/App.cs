using System;
using Android.App;
using Android.Runtime;

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
            
            EverlyticPush.EverlyticPush.Current.Initialize();
        }
    }
}
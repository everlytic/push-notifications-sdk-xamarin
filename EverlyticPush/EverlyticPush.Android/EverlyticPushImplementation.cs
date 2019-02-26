using System;
using Android.App;
using EverlyticPush.Abstract;

namespace EverlyticPush
{
    public class EverlyticPushImplementation : IEverlyticPush
    {
        public void Initialize()
        {
            Com.Everlytic.Android.EverlyticPush.Init(Application.Context);
        }

        public void Subscribe(string email)
        {
            Com.Everlytic.Android.EverlyticPush.Subscribe(email);
            Com.Everlytic.Android.EverlyticPush.Unsubscribe();
        }

        public void Subscribe(string email, OnResultReceived resultReceivedDelegate)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe()
        {
            Com.Everlytic.Android.EverlyticPush.Unsubscribe();
        }

        public void Unsubscribe(OnResultReceived onResultReceivedDelegate)
        {
            throw new NotImplementedException();
        }

        public bool IsContactSubscribed()
        {
            return Com.Everlytic.Android.EverlyticPush.IsContactSubscribed;
        }

        public bool IsInitialized()
        {
            return Com.Everlytic.Android.EverlyticPush.IsInitialised;
        }
    }
}
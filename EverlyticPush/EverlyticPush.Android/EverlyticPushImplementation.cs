using System;
using Android.App;
using Com.Everlytic.Android;
using EverlyticPush.Abstract;
using AndroidEvResult = Com.Everlytic.Android.EvResult;
using EvResult = EverlyticPush.Abstract.EvResult;

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
        }

        public void Subscribe(string email, OnResultReceived onResultReceivedDelegate)
        {
            var resultReceiver = new ResultReceiver(onResultReceivedDelegate);

            Com.Everlytic.Android.EverlyticPush.Subscribe(email, resultReceiver);
        }

        public void Unsubscribe()
        {
            Com.Everlytic.Android.EverlyticPush.Unsubscribe(null);
        }

        public void Unsubscribe(OnResultReceived onResultReceivedDelegate)
        {
            var resultReceiver = new ResultReceiver(onResultReceivedDelegate);
            Com.Everlytic.Android.EverlyticPush.Unsubscribe(resultReceiver);
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

    internal class ResultReceiver : Java.Lang.Object, IOnResultReceiver
    {
        private readonly OnResultReceived _delegate;

        // ReSharper disable once UnusedMember.Global
        public ResultReceiver()
        {
        }

        public ResultReceiver(OnResultReceived _delegate)
        {
            this._delegate = _delegate;
        }

        public void OnResult(AndroidEvResult evResult)
        {
            var abstractEvResult = new EvResult();

            abstractEvResult.isSuccessful = evResult.IsSuccessful;
            abstractEvResult.exception = evResult.Exception;

            _delegate.Invoke(abstractEvResult);
        }
    }
}
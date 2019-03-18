using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Com.Everlytic.Android;
using Com.EverlyticPush.Abstract;
using Java.Util;
using AndroidEvResult = Com.Everlytic.Android.EvResult;
using AndroidEverlyticNotification = Com.Everlytic.Android.Pushnotificationsdk.Models.EverlyticNotification;
using EvResult = Com.EverlyticPush.Abstract.EvResult;
using Object = Java.Lang.Object;

namespace Com.EverlyticPush
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

        public void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            var resultReceiver = new ResultReceiver(onResultReceivedDelegateDelegate);
            Com.Everlytic.Android.EverlyticPush.Subscribe(email, resultReceiver);
        }

        public void Unsubscribe()
        {
            Com.Everlytic.Android.EverlyticPush.Unsubscribe(null);
        }

        public void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            var resultReceiver = new ResultReceiver(onResultReceivedDelegateDelegate);
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

        public void GetNotificationHistory(
            OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegateDelegate)
        {
            var historyReceiver = new NotificationHistoryReceiver(onNotificationHistoryResultsDelegateDelegate);
            Com.Everlytic.Android.EverlyticPush.GetNotificationHistory(historyReceiver);
        }

        public IEverlyticPush SetTestMode(bool mode)
        {
            Com.Everlytic.Android.EverlyticPush.SetInTestMode(mode);
            return this;
        }
    }

    internal class ResultReceiver : Object, IOnResultReceiver
    {
        private readonly OnResultReceivedDelegate _delegate;

        // ReSharper disable once UnusedMember.Global
        public ResultReceiver()
        {
        }

        public ResultReceiver(OnResultReceivedDelegate _delegate)
        {
            this._delegate = _delegate;
        }

        public void OnResult(AndroidEvResult evResult)
        {
            var abstractEvResult = new EvResult {IsSuccessful = evResult.IsSuccessful, Exception = evResult.Exception};


            _delegate.Invoke(abstractEvResult);
        }
    }

    internal class NotificationHistoryReceiver : Object, IOnNotificationHistoryResultListener
    {
        private readonly OnNotificationHistoryResultsDelegate _delegate;

        public NotificationHistoryReceiver()
        {
        }

        public NotificationHistoryReceiver(OnNotificationHistoryResultsDelegate _delegate)
        {
            this._delegate = _delegate;
        }

        public void OnResult(IList<AndroidEverlyticNotification> androidResults)
        {
            var results = androidResults.Select(notification => new EverlyticNotification
            {
                MessageId = notification.MessageId,
                Title = notification.Title,
                Body = notification.Body,
                ReceivedAt = FromJavaDate(notification.Received_at),
                ReadAt = FromJavaDate(notification.Read_at),
                DismissedAt = FromJavaDate(notification.Dismissed_at)
            }).ToList();

            _delegate.Invoke(results);
        }

        private static DateTime FromJavaDate(Date date)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(date.Time).Date;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Com.Everlytic.Android;
using Com.Everlytic.Android.Pushnotificationsdk.Models;
using EverlyticPush.Abstract;
using Java.Util;
using AndroidEvResult = Com.Everlytic.Android.EvResult;
using AndroidEverlyticNotification = Com.Everlytic.Android.Pushnotificationsdk.Models.EverlyticNotification;
using EverlyticNotification = EverlyticPush.Abstract.EverlyticNotification;
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

        public void GetNotificationHistory(OnNotificationHistoryResults onNotificationHistoryResultsDelegate)
        {
            var historyReceiver = new NotificationHistoryReceiver(onNotificationHistoryResultsDelegate);
            Com.Everlytic.Android.EverlyticPush.GetNotificationHistory(historyReceiver);
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

            abstractEvResult.IsSuccessful = evResult.IsSuccessful;
            abstractEvResult.Exception = evResult.Exception;

            _delegate.Invoke(abstractEvResult);
        }
    }

    internal class NotificationHistoryReceiver : Java.Lang.Object, IOnNotificationHistoryResultListener
    {
        private readonly OnNotificationHistoryResults _delegate;
        
        public NotificationHistoryReceiver()
        {
        }

        public NotificationHistoryReceiver(OnNotificationHistoryResults _delegate)
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
                ReceivedAt = fromJavaDate(notification.Received_at),
                ReadAt = fromJavaDate(notification.Read_at),
                DismissedAt = fromJavaDate(notification.Dismissed_at)
            }).ToList();
            
            _delegate.Invoke(results);
        }

        private DateTime fromJavaDate(Date date)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(date.Time).Date;
        }
    }
}
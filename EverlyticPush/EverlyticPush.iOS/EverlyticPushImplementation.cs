using System;
using System.Collections.Generic;
using Com.EverlyticPush.Abstract;
using Foundation;

namespace Com.EverlyticPush
{
    public class EverlyticPushImplementation : IEverlyticPush
    {

        private bool AutoPromptForPermission;

        public void Initialize()
        {
            PrintNotImplementedMessage();
        }

        public void Initialize(string configurationString)
        {
            Console.WriteLine("Initialize()");
            iOS.EverlyticPush.InitializeWithPushConfig(configurationString);

            if (AutoPromptForPermission)
            {
                this.PromptForNotificationPermissions(null);
            }
        }

        public void Subscribe(string email)
        {
            iOS.EverlyticPush.SubscribeUserWithEmail(email, null);
        }

        public void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            Console.WriteLine("Subscribe()");
            iOS.EverlyticPush.SubscribeUserWithEmail(email, (success, error) =>
            {
                var result = new EvResult
                {
                    IsSuccessful = success
                };

                result.Exception = error != null ? new Exception(error.Description) : null;

                if (onResultReceivedDelegateDelegate != null)
                {
                    onResultReceivedDelegateDelegate(result);
                }
            });
        }

        public void Unsubscribe()
        {
            Unsubscribe(null);
        }

        public void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            iOS.EverlyticPush.UnsubscribeUserWithCompletionHandler((success, error) =>
            {

                var result = new EvResult
                {
                    IsSuccessful = success
                };

                result.Exception = error != null ? new Exception(error.Description) : null;
                if (onResultReceivedDelegateDelegate != null)
                {
                    onResultReceivedDelegateDelegate(result);
                }
            });
        }

        public bool IsContactSubscribed()
        {
            PrintNotImplementedMessage();
            return false;
        }

        public bool IsInitialized()
        {
            PrintNotImplementedMessage();
            return false;
        }

        public void GetNotificationHistory(
            OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegateDelegate)
        {
            iOS.EverlyticPush.NotificationHistoryWithCompletionListener((notifications) =>
            {
                var handler = new NotificationHistoryReceiver(onNotificationHistoryResultsDelegateDelegate);
                handler.OnResult(notifications);
            });
        }

        public int GetNotificationHistoryCount()
        {
            return ObjCRuntime.Runtime.GetINativeObject<NSNumber>(iOS.EverlyticPush.NotificationHistoryCount(), false).Int32Value;
        }

        private void PrintNotImplementedMessage()
        {
            Console.WriteLine("[EVERLYTIC PUSH IOS] METHOD NOT IMPLEMENTED. SEE STACK TRACE BELOW");
            Console.WriteLine(new Exception().StackTrace);
        }

        public IEverlyticPush SetTestMode(bool mode)
        {
            // Not implemented in iOS SDK
            return this;
        }

        public IEverlyticPush SetIOSAutoRequestPermissions(bool autoRequest)
        {
            AutoPromptForPermission = true;
            return this;
        }

        public void PromptForNotificationPermissions(OnResultReceivedDelegate onResultReceivedDelegate)
        {
            iOS.EverlyticPush.PromptForNotificationPermissionWithUserResponse((granted) =>
            {
                onResultReceivedDelegate?.Invoke(new EvResult { IsSuccessful = granted });
            });
        }
    }

    internal class NotificationHistoryReceiver : Object
    {
        private readonly OnNotificationHistoryResultsDelegate _delegate;

        public NotificationHistoryReceiver()
        {
        }

        public NotificationHistoryReceiver(OnNotificationHistoryResultsDelegate _delegate)
        {
            this._delegate = _delegate;
        }

        public void OnResult(NSArray iosResults)
        {
            List<EverlyticNotification> list = new List<EverlyticNotification>();

            Console.Out.WriteLine("iosResults count=" + iosResults.Count);
            Console.Out.WriteLine(iosResults);

            for (nuint i = 0; i < iosResults.Count; i++ )
            {                
                iOS.EverlyticNotification notification = ObjCRuntime.Runtime.GetINativeObject<iOS.EverlyticNotification>(iosResults.ValueAt(i), false);

                Console.Out.WriteLine(notification.Title);
                Console.Out.WriteLine(notification.Body);
                Console.Out.WriteLine(notification.ReceivedAt);

                EverlyticNotification nf = new EverlyticNotification
                {
                    MessageId = ((NSNumber)notification.MessageId).LongValue,
                    Title = notification.Title,
                    Body = notification.Body,
                    ReceivedAt = FromFoundationDate(notification.ReceivedAt),
                    ReadAt = FromFoundationDate(notification.ReadAt),
                    DismissedAt = FromFoundationDate(notification.DismissedAt)
                };

                var ca = new Dictionary<string, string>();
                var attributes = ((NSDictionary<NSString, NSString>)notification.CustomAttributes);

                foreach (NSString key in attributes.Keys)
                {
                    ca.Add(key, (NSString) attributes.ValueForKey(key));
                }

                nf.CustomAttributes = ca;

                list.Add(nf);

            }

            _delegate.Invoke(list);
        }

        private static DateTime? FromFoundationDate(NSDate date)
        {
            return null;
            if (date == null) return null;
            //NSDate.Now
            //return DateTimeOffset.FromUnixTimeMilliseconds(date.).LocalDateTime;
        }
    }
}

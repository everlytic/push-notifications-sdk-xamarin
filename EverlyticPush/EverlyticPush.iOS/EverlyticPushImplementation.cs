using System;
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
            iOS.EverlyticPush.SubscribeUserWithEmail(email, (success, error) =>
            {
                var result = new EvResult
                {
                    IsSuccessful = success
                };

                result.Exception = error != null ? new Exception(error.Description) : null;

                onResultReceivedDelegateDelegate(result);
            });
        }

        public void Unsubscribe()
        {
            PrintNotImplementedMessage();
        }

        public void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            PrintNotImplementedMessage();
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
            PrintNotImplementedMessage();
        }

        public int GetNotificationHistoryCount()
        {
            PrintNotImplementedMessage();
            return 0;
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
}

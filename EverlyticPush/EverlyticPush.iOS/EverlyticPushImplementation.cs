using System;
using Com.EverlyticPush.Abstract;
using Foundation;

namespace Com.EverlyticPush
{
    public class EverlyticPushImplementation : IEverlyticPush
    {
        public void Initialize()
        {
            PrintNotImplementedMessage();
        }

        public void Initialize(string configurationString)
        {
            PrintNotImplementedMessage();
        }

        public void Subscribe(string email)
        {
            PrintNotImplementedMessage();
        }

        public void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            PrintNotImplementedMessage();
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

        public IEverlyticPush SetTestMode(bool mode)
        {
            PrintNotImplementedMessage();
            return this;
        }

        private void PrintNotImplementedMessage()
        {
            Console.WriteLine("[EVERLYTIC PUSH IOS] METHOD NOT IMPLEMENTED. SEE STACK TRACE BELOW");
            Console.WriteLine(new Exception().StackTrace);
        }
    }
}
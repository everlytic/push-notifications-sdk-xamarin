using System;
using Com.EverlyticPush.Abstract;
using Foundation;

namespace Com.EverlyticPush
{
    public class EverlyticPushImplementation : IEverlyticPush
    {
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string email)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe()
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            throw new NotImplementedException();
        }

        public bool IsContactSubscribed()
        {
            throw new NotImplementedException();
        }

        public bool IsInitialized()
        {
            throw new NotImplementedException();
        }

        public void GetNotificationHistory(
            OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegateDelegate)
        {
            throw new NotImplementedException();
        }

        public IEverlyticPush SetTestMode(bool mode)
        {
            throw new NotImplementedException();
        }
    }
}
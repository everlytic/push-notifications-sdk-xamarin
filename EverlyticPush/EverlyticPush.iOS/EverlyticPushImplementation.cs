using EverlyticPush.Abstract;

namespace EverlyticPush
{
    public class EverlyticPushImplementation : IEverlyticPush
    {
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe(string email)
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe()
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate)
        {
            throw new System.NotImplementedException();
        }

        public bool IsContactSubscribed()
        {
            throw new System.NotImplementedException();
        }

        public bool IsInitialized()
        {
            throw new System.NotImplementedException();
        }

        public void GetNotificationHistory(OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegateDelegate)
        {
            throw new System.NotImplementedException();
        }
    }
}
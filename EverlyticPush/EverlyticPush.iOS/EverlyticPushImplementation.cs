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

        public void Subscribe(string email, OnResultReceived onResultReceivedDelegate)
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe()
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe(OnResultReceived onResultReceivedDelegate)
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

        public void GetNotificationHistory(OnNotificationHistoryResults onNotificationHistoryResultsDelegate)
        {
            throw new System.NotImplementedException();
        }
    }
}
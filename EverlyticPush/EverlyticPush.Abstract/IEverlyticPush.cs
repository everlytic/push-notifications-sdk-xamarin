namespace EverlyticPush.Abstract
{
    public interface IEverlyticPush
    {
        void Initialize();
        void Subscribe(string email);
        void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate);
        void Unsubscribe();
        void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate);
        bool IsContactSubscribed();
        bool IsInitialized();
        void GetNotificationHistory(OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegateDelegate);
    }
}
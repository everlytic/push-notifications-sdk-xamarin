using System.Diagnostics.CodeAnalysis;

namespace Com.EverlyticPush.Abstract
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface IEverlyticPush
    {
        IEverlyticPush SetTestMode(bool mode);
        void Initialize();
        void Initialize(string configurationString);
        void Subscribe(string email);
        void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate);
        void Unsubscribe();
        void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate);
        bool IsContactSubscribed();
        bool IsInitialized();
        void GetNotificationHistory(OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegateDelegate);
    }
}
using System.Diagnostics.CodeAnalysis;

namespace EverlyticPush.Abstract
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface IEverlyticPush
    {
        IEverlyticPush SetTestMode(bool mode);
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
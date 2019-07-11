using System;
using System.Diagnostics.CodeAnalysis;

namespace Com.EverlyticPush.Abstract
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface IEverlyticPush
    {
        IEverlyticPush SetTestMode(bool mode);
        //IEverlyticPush SetLogLevel(int level);
        [Obsolete("Initialize with no parameters has been deprecated. Please pass in your project config string as a parameter")]
        void Initialize();
        void Initialize(string configurationString);
        void Subscribe(string email);
        void Subscribe(string email, OnResultReceivedDelegate onResultReceivedDelegateDelegate);
        void Unsubscribe();
        void Unsubscribe(OnResultReceivedDelegate onResultReceivedDelegateDelegate);
        bool IsContactSubscribed();
        bool IsInitialized();
        void GetNotificationHistory(OnNotificationHistoryResultsDelegate onNotificationHistoryResultsDelegateDelegate);
        //void GetNotificationHistoryCount(OnNotificationHistoryCountReceivedDelegate onNotificationHistoryCountReceivedDelegate);
    }
}
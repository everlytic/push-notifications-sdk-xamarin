﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EverlyticPush.Abstract
{
    public interface IEverlyticPush
    {        
        void Initialize();
        void Subscribe(string email);
        void Subscribe(string email, OnResultReceived onResultReceivedDelegate);
        void Unsubscribe();
        void Unsubscribe(OnResultReceived onResultReceivedDelegate);
        bool IsContactSubscribed();
        bool IsInitialized();
        void GetNotificationHistory(OnNotificationHistoryResults onNotificationHistoryResultsDelegate);
    }
}
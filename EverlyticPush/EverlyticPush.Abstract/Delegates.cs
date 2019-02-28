using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EverlyticPush.Abstract
{
    public delegate void OnResultReceivedDelegate(EvResult result);
    
    public delegate void OnNotificationHistoryResultsDelegate(List<EverlyticNotification> notifications);
}
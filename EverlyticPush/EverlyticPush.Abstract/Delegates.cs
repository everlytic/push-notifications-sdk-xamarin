using System.Collections.Generic;

namespace Com.EverlyticPush.Abstract
{
    public delegate void OnResultReceivedDelegate(EvResult result);

    public delegate void OnNotificationHistoryResultsDelegate(List<EverlyticNotification> notifications);

    public delegate void OnNotificationHistoryCountReceivedDelegate(int count);
}
using System.Collections.Generic;

namespace EverlyticPush.Abstract
{
    public delegate void OnResultReceivedDelegate(EvResult result);

    public delegate void OnNotificationHistoryResultsDelegate(List<EverlyticNotification> notifications);
}
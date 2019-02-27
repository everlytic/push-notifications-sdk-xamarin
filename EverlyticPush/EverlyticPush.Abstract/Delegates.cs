using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EverlyticPush.Abstract
{
    public delegate void OnResultReceived(EvResult result);
    
    public delegate void OnNotificationHistoryResults(List<EverlyticNotification> notifications);
}
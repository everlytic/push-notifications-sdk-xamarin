using System;

namespace EverlyticPush.Abstract
{
    public class EverlyticNotification
    {
        public string Body;
        public DateTime DismissedAt;
        public long MessageId;
        public DateTime ReadAt;
        public DateTime ReceivedAt;
        public string Title;
    }
}
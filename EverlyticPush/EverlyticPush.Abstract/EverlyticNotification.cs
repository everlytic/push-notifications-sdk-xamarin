using System;

namespace EverlyticPush.Abstract
{
    public class EverlyticNotification
    {
        public long MessageId;
        public string Title;
        public string Body;
        public DateTime ReceivedAt;
        public DateTime ReadAt;
        public DateTime DismissedAt;
    }
}
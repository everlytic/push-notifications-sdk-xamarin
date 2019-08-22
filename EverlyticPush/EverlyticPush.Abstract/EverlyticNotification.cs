using System;
using System.Collections.Generic;

namespace Com.EverlyticPush.Abstract
{
    public class EverlyticNotification
    {
        public string Title;
        public string Body;
        public DateTime? DismissedAt;
        public long MessageId;
        public DateTime? ReadAt;
        public DateTime? ReceivedAt;
        public IDictionary<string, string> CustomAttributes;

        public static explicit operator EverlyticNotification(IntPtr v)
        {
            throw new NotImplementedException();
        }
    }
}
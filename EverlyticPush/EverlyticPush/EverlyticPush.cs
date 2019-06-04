using System;
using System.Diagnostics;
using Com.EverlyticPush.Abstract;

namespace Com.EverlyticPush
{
    public class Everlytic
    {
        private static readonly Lazy<IEverlyticPush> Implementation = new Lazy<IEverlyticPush>(CreateInstance);

        public static IEverlyticPush Instance
        {
            get
            {
                if (Implementation.Value == null) throw NotImplementedInAssemblyException();

                return Implementation.Value;
            }
        }

        private static IEverlyticPush CreateInstance()
        {
#if PORTABLE
            Debug.WriteLine("PORTABLE Reached");
            return null;
#else
            return new EverlyticPushImplementation();
#endif
        }

        internal static NotImplementedException NotImplementedInAssemblyException()
        {
            return new NotImplementedException("Push is not implemented in this Assembly");
        }
    }
}
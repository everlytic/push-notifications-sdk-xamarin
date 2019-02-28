using System;
using EverlyticPush.Abstract;

namespace EverlyticPush
{
    public class EverlyticPush
    {
        private static readonly Lazy<IEverlyticPush> Implementation = new Lazy<IEverlyticPush>(CreateInstance);

        public static IEverlyticPush Current
        {
            get
            {
                if (Implementation.Value == null) throw NotImplementedInAssemblyException();

                return Implementation.Value;
            }
        }

        private static IEverlyticPush CreateInstance()
        {
            return new EverlyticPushImplementation();
        }

        internal static NotImplementedException NotImplementedInAssemblyException()
        {
            return new NotImplementedException("Push is not implemented in this Assembly");
        }
    }
}
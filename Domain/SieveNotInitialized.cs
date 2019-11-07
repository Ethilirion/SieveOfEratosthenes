using System;

namespace SieveDomain
{
    public class SieveNotInitialized : Exception
    {
        public SieveNotInitialized()
        {
        }

        public override string ToString()
        {
            return string.Format($"Le crible n'a pas été initialisé.\r\n{0}", base.ToString());
        }
    }
}

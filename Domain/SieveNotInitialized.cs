using System;
using System.Collections.Generic;
using System.Text;

namespace SieveDomain
{
    public class SieveNotInitialized : Exception
    {
        public SieveNotInitialized()
        {

        }

        public override string ToString()
        {
            return string.Format($"Le crible n'a pas été initializé.\r\n{0}", base.ToString());
        }
    }
}

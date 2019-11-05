using System;
using System.Collections.Generic;
using System.Text;

namespace SieveOfEratosthenesDomain
{
    public class IncorrectValue : Exception
    {
        public IncorrectValue()
        {
        }

        public IncorrectValue(string message) :
            base(message)
        {
        }

        public IncorrectValue(string message, Exception exception) : 
            base(message, exception)
        {
        }

        public override string ToString()
        {
            return string.Format($"La valeur minimum d'une recherche de nombres primaires est {SieveOfEratosthenesImplementation.MinimumCorrectValue}.\r\n{0}", base.ToString());
        }
    }
}

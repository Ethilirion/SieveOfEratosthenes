using System;
using System.Collections.Generic;
using System.Text;

namespace SieveDomain
{
    public class IncorrectValue : Exception
    {
        private uint MinimumCorrectValue;

        public IncorrectValue(uint minimumCorrectValue)
        {
            MinimumCorrectValue = minimumCorrectValue;
        }
        
        public override string ToString()
        {
            return string.Format($"La valeur minimum d'une recherche de nombres primaires est {MinimumCorrectValue}.\r\n{0}", base.ToString());
        }
    }
}

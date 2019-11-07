using System;

namespace SieveDomain
{
    public class NoNumberAvailable : Exception
    {
        public NoNumberAvailable()
        {
        }
        
        public override string ToString()
        {
            return string.Format($"Aucun nombre supprimable n'a pu être trouvé.\r\n{0}", base.ToString());
        }
    }
}
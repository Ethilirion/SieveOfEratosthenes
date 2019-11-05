using System;

namespace SieveOfEratosthenesProject
{
    public class NoNumberAvailable : Exception
    {
        public NoNumberAvailable()
        {
        }

        public NoNumberAvailable(string message) :
            base(message)
        {
        }

        public NoNumberAvailable(string message, Exception exception) : 
            base(message, exception)
        {
        }

        public override string ToString()
        {
            return string.Format($"Aucun nombre supprimable n'a pu être trouvé.\r\n{0}", base.ToString());
        }
    }
}
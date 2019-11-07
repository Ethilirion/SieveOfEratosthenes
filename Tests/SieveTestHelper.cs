using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class SieveTestHelper
    {
        // utility method to check the method's returns
        internal static bool isPrime(uint number)
        {
            if (number == 1)
                return false;
            if (number == 2)
                return true;

            // over this limit, we checked all possible values
            var limit = Math.Ceiling(Math.Sqrt(number));

            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0)
                    return false;
            }
            return true;

        }
    }
}

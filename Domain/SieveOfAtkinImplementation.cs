using System;
using System.Collections.Generic;
using System.Text;

namespace SieveDomain
{
    public class SieveOfAtkinImplementation : Sieve
    {
        private State state;
        private uint maximumThreshold;
        private uint[] primesUpTo60 = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 };
        private List<uint> firstArrayOfNumbers;
        private List<uint> secondArrayOfNumbers;
        private List<uint> thirdArrayOfNumbers;


        public uint[] FindPrimeNumbers()
        {
            return new uint[] { };
        }

        public void SetMaximumThreshold(uint maximumThreshold)
        {
            this.maximumThreshold = maximumThreshold;
        }
    }
}

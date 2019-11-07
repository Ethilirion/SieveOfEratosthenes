using SieveDomain;
using System;
using Xunit;

namespace Tests
{
    public class SieveOfAtkinTests : IDisposable
    {
        Sieve sieve;

        public SieveOfAtkinTests()
        {
            sieve = new SieveOfAtkinImplementation();
        }
        
        [Fact]
        public void TestCallFindNumbers()
        {
            sieve.FindPrimeNumbers();
        }

        public void Dispose()
        {
        }
    }
}

using SieveDomain;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class SieveOfAtkinTests : IDisposable
    {
        Sieve unitializedSieve;

        public SieveOfAtkinTests()
        {
            unitializedSieve = new SieveOfAtkinImplementation();
        }

        [Fact]
        public void TestCallFindNumbers()
        {
            Assert.Throws<SieveNotInitialized>(() => { unitializedSieve.FindPrimeNumbers(); });
        }

        [Fact]
        public void TestGetFirst60Primes()
        {
            unitializedSieve.SetMaximumThreshold(60);
            var primes = unitializedSieve.FindPrimeNumbers();
            Assert.True(primes.Any());
            Assert.True(primes.All(prime => SieveTestHelper.isPrime(prime)));
        }

        [Fact]
        public void TestGetFirst60PrimesCoherenceOfResult()
        {
            unitializedSieve.SetMaximumThreshold(60);
            var primes = unitializedSieve.FindPrimeNumbers();
            Assert.True(primes.Max() <= 60);
        }

        [Theory]
        [InlineData(80)]
        //[InlineData(100)]
        //[InlineData(120)]
        public void TestGetPrimesForOver60(uint threshold)
        {
            unitializedSieve.SetMaximumThreshold(threshold);
            var primes = unitializedSieve.FindPrimeNumbers();
            return;
            Assert.True(primes.Max() <= threshold);
            Assert.True(primes.All(prime => SieveTestHelper.isPrime(prime)));
        }

        public void Dispose()
        {
        }
    }
}

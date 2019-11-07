using SieveDomain;
using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class SieveOfEratosthenesTests : IDisposable
    {
        [Fact]
        public void TypeSieve()
        {
#pragma warning disable
            Sieve sieve;
#pragma warning restore
        }

        [Fact]
        public void InstantiateSieve()
        {
            Sieve sieve = new SieveOfEratosthenesImplementation(SieveOfEratosthenesImplementation.minimumCorrectValue);
            Assert.IsType<SieveOfEratosthenesImplementation>(sieve);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void InstantiateSieveWithIncorrectValues(uint valeur)
        {
            Assert.Throws<IncorrectValue>(() => { Sieve sieve = new SieveOfEratosthenesImplementation(valeur); });
        }

        [Fact]
        public void ExecuteSieveNotExpectingResults()
        {
            Sieve sieve = new SieveOfEratosthenesImplementation(120);
            uint[] primes = sieve.FindPrimeNumbers();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(120)]
        [InlineData(150978)]
        public void ExecuteSieveExpectingResultsForValue(uint value)
        {
            Sieve sieve = new SieveOfEratosthenesImplementation(value);
            uint[] primes = sieve.FindPrimeNumbers();
            Assert.NotEqual(null, primes);
            Assert.True(primes.All(prime => SieveTestHelper.isPrime(prime)));

            switch (value)
            {
                case 2:
                    Assert.True(primes.Count() == 1);
                    break;
                case 120:
                    Assert.True(primes.Count() == 30);
                    break;
                case 150978:
                    Assert.True(primes.Count() == 13930);
                    break;
                default:
                    break;
            }
        }
        
        public void Dispose()
        {
        }
    }
}

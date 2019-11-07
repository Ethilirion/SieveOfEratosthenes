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
            Sieve sieve = new SieveOfEratosthenesImplementation(SieveOfEratosthenesImplementation.MinimumCorrectValue);
            Assert.IsType<SieveOfEratosthenesImplementation>(sieve);
            Assert.IsAssignableFrom<Sieve>(sieve);
        }

        [Fact]
        public void EmptyConstructor()
        {
            Sieve sieve = new SieveOfEratosthenesImplementation();
        }

        [Fact]
        public void ThrowsIfNotInitialized()
        {
            Sieve sieve = new SieveOfEratosthenesImplementation();
            Assert.Throws<SieveNotInitialized>(() => { sieve.FindPrimeNumbers(); });
        }

        [Fact]
        public void DoesNotThrowIfInitialized()
        {
            Sieve sieve = new SieveOfEratosthenesImplementation();
            sieve.SetMaximumThreshold(120);
            
                //Throws<SieveNotInitialized>(() => { sieve.FindPrimeNumbers(); });
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
            Assert.True(primes.All(prime => isPrime(prime)));

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

        // utility method to check the method's returns
        private bool isPrime(uint number)
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

        public void Dispose()
        {
        }
    }
}

using SieveDomain;
using System;
using System.Collections.Generic;
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
            sieve.FindPrimeNumbers();
        }

        [Fact]
        public void MultipleReinitializationDoesNotBreakFlow()
        {
            Sieve sieve = new SieveOfEratosthenesImplementation(120);
            sieve.SetMaximumThreshold(10);
            sieve.SetMaximumThreshold(10);
            sieve.SetMaximumThreshold(10);
            sieve.SetMaximumThreshold(20);
            sieve.SetMaximumThreshold(60);
            var primes = sieve.FindPrimeNumbers();
            Assert.False(primes.Any(prime => prime > 60));
            Assert.True(primes.Any());
        }

        [Fact]
        public void CanBeReusedAfterConstructorInitializedThenReRun()
        {
            var pairThresholdToNumberOfPrimesFor10 = new KeyValuePair<uint, uint>(10, 4);
            Sieve sieve = new SieveOfEratosthenesImplementation(pairThresholdToNumberOfPrimesFor10.Key);
            var primesFirst = sieve.FindPrimeNumbers();
            Assert.True(primesFirst.Count() == pairThresholdToNumberOfPrimesFor10.Value);

            // Il y a 30 nombres primes sous 120, et on veut valider l'exactitude de cette paire
            var pairThresholdToNumberOfPrimesFor120 = new KeyValuePair<uint, uint>(120, 30);
            sieve.SetMaximumThreshold(pairThresholdToNumberOfPrimesFor120.Key);
            var primesSecond = sieve.FindPrimeNumbers();
            Assert.True(primesSecond.Count() == pairThresholdToNumberOfPrimesFor120.Value);
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

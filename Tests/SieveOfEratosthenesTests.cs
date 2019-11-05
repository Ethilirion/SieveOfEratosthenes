using Microsoft.VisualStudio.TestTools.UnitTesting;
using SieveOfEratosthenesDomain;
using SieveOfEratosthenesDomain.PrimaryAdapters;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SieveOfEratosthenesTests
    {
        [TestMethod]
        public void TypeSieve()
        {
#pragma warning disable
            SieveOfEratosthenes sieve;
#pragma warning restore
        }

        [TestMethod]
        public void InstantiateSieve()
        {
            SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(SieveOfEratosthenesImplementation.MinimumCorrectValue);
            Assert.IsInstanceOfType(sieve, typeof(SieveOfEratosthenesImplementation));
            Assert.IsInstanceOfType(sieve, typeof(SieveOfEratosthenes));
        }

        [TestMethod]
        public void InstantiateSieveWithIncorrectValues()
        {
            bool successIfGoingToCatchBlock = false;
            try
            {
                SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(0);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(IncorrectValue));
                successIfGoingToCatchBlock = true;
            }
            Assert.AreEqual(successIfGoingToCatchBlock, true);

            successIfGoingToCatchBlock = false;
            try
            {
                SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(1);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(IncorrectValue));
                successIfGoingToCatchBlock = true;
            }
            Assert.AreEqual(successIfGoingToCatchBlock, true);
        }

        [TestMethod]
        public void ExecuteSieveNotExpectingResults()
        {
            try
            {
                SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(120);
                uint[] primes = sieve.FindPrimeNumbers();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ExecuteSieveExpectingResultsForValue3()
        {
            try
            {
                SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(3);
                uint[] primes = sieve.FindPrimeNumbers();
                Assert.AreNotEqual(primes, null);
                Assert.IsTrue(primes.All(prime => isPrime(prime)));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ExecuteSieveExpectingResultsForValue10()
        {
            try
            {
                SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(10);
                uint[] primes = sieve.FindPrimeNumbers();
                Assert.AreNotEqual(primes, null);
                Assert.IsTrue(primes.All(prime => isPrime(prime)));
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ExecuteSieveExpectingResultsForValue120()
        {
            try
            {
                SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(120);
                uint[] primes = sieve.FindPrimeNumbers();
                Assert.AreNotEqual(primes, null);
                Assert.IsTrue(primes.All(prime => isPrime(prime)));
                Assert.IsTrue(primes.Count() == 30);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ExecuteSieveExpectingResultsForValue2()
        {
            SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(2);
            uint[] primes = sieve.FindPrimeNumbers();
            Assert.AreNotEqual(primes, null);
            Assert.IsTrue(primes.All(prime => isPrime(prime)));
            Assert.IsTrue(primes.Count() == 1);
        }

        [TestMethod]
        public void ExecuteSieveExpectingResultForValue150978()
        {
            SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(150978);
            uint[] primes = sieve.FindPrimeNumbers();
            Assert.AreNotEqual(primes, null);
            Assert.IsTrue(primes.All(prime => isPrime(prime)));
        }

        [TestMethod]
        public void TypeConsoleAdapter()
        {
#pragma warning disable
            ConsoleAdapter console;
#pragma
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
    }
}

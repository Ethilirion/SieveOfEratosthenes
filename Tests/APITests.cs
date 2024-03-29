﻿using System;
using API_Controllers = API.Controllers;
using Xunit;
using System.Linq;

namespace Tests
{
    public class APITests : IDisposable
    {
        private API_Controllers.Sieve sieveAPI;

        public APITests()
        {
            sieveAPI = new API_Controllers.Sieve();
        }

        [Theory]
        [InlineData(656578)]
        [InlineData(2)]
        [InlineData(80)]
        public void GetResultsFromValidInput(uint number)
        {
            var results = sieveAPI.GetSieveListOfResult(number)?.Value;
            Assert.True(results.All(prime => SieveTestHelper.isPrime(prime) == true));
            Assert.True(results.Count() > 0);
        }

        [Fact]
        public void GetNoResultsFromInvalidInput()
        {
            var results = sieveAPI.GetSieveListOfResult(1)?.Result;
        }

        public void Dispose()
        {
        }
    }
}

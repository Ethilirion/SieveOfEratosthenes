using PrimaryPorts;
using SieveOfEratosthenesDomain.PrimaryAdapters;
using System;
using Xunit;

namespace Tests
{
    public class ConsoleAdapteurTests
    {
        private ConsoleAdapter console;

        public ConsoleAdapteurTests()
        {
            console = new ConsoleImplementation();
        }

        [Fact]
        public void GetNumberShouldWork()
        {
            var value = console.GetNumberFromInput("54");
            Assert.Equal<uint>(54, value);
        }

        [Fact]
        public void GetNumberFromIncorrectValueShouldNotWork()
        {
            Assert.Throws<FormatException>(() => { console.GetNumberFromInput("-54"); });    
        }
    }
}

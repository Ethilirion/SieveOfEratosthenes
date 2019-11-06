using PrimaryPorts;
using SieveDomain.PrimaryAdapters;
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
        public void GetNumberFromIncorrectValueShouldNotWork_Underflow()
        {
            Assert.Throws<OverflowException>(() => { console.GetNumberFromInput("-54"); });
        }

        [Fact]
        public void GetNumberFromIncorrectValueShouldNotWork_Format()
        {
            Assert.Throws<FormatException>(() => { console.GetNumberFromInput("-dd"); });
        }

        [Fact]
        public void GetNumberFromIncorrectValueShouldNotWork_NullString()
        {
            Assert.Throws<FormatException>(() => { console.GetNumberFromInput(""); });
        }
    }
}

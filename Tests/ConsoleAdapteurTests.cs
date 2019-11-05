using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimaryPorts;
using SieveOfEratosthenesDomain.PrimaryAdapters;

namespace Tests
{
    [TestClass]
    public class ConsoleAdapteurTests
    {
        [TestMethod]
        public void TypeConsoleAdapter()
        {
#pragma warning disable
            ConsoleAdapter console;
#pragma
        }

        [TestMethod]
        public void InstantiateTypeConsoleAdapter()
        {
            ConsoleAdapter console = new ConsoleImplementation();
        }

        [TestMethod]
        public void ValidateNumber()
        {
            ConsoleAdapter console = new ConsoleImplementation();
        }

    }
}

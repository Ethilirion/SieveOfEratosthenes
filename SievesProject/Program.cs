using PrimaryPorts;
using SieveDomain;
using SieveDomain.PrimaryAdapters;

namespace SieveOfEratosthenesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePort console = new ConsoleImplementation();
            bool shouldExit = false;
            while (!shouldExit)
            {
                try
                {
                    console.RequestNumber();
                    string userInput = console.GetInput();
                    if (userInput == null)
                        continue;
                    uint numberToSieve = console.GetNumberFromInput(userInput);
                    var sieve = new SieveOfEratosthenesImplementation(numberToSieve);
                    var primes = sieve.FindPrimeNumbers();
                    console.DisplayPrimesFound(primes);
                }
                catch
                {
                    shouldExit = true;
                }
            }
        }
    }
}

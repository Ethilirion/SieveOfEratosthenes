using SieveOfEratosthenesDomain.PrimaryAdapters;
using System;

namespace PrimaryPorts
{
    public class ConsoleImplementation : ConsoleAdapter
    {
        public void DisplayPrimesFound(uint[] primes)
        {
            Console.WriteLine($"Liste des entiers trouvés : {string.Join(", ", primes)}");
        }

        public string GetInput()
        {
            var userInput = Console.ReadLine();
            if (userInput == "exit")
                throw new Exception();

            uint numberToSieve = 0;
            if (uint.TryParse(userInput, out numberToSieve) == false)
            {
                Console.WriteLine("Merci d'entrer une valeur numérique correcte.");
                return null;
            }
            return userInput;
        }

        public uint GetNumberFromInput(string input)
        {
            return uint.Parse(input);
        }

        public void RequestNumber()
        {
            Console.WriteLine("Entrez un nombre valide ou 'exit' pour quitter.");
        }
    }
}

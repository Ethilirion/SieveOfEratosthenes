using System;

namespace SieveOfEratosthenesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez un nombre valide ou 'exit' pour quitter.");
            do
            {
                string numberRequested = Console.ReadLine();
                if (numberRequested == "exit")
                    return;

                uint numberToSieve = 0;
                if (uint.TryParse(numberRequested, out numberToSieve) == false)
                {
                    Console.WriteLine("Merci d'entrer une valeur numérique correcte.");
                    continue;
                }
                try
                {
                    var sieve = new SieveOfEratosthenesImplementation(numberToSieve);
                    var primes = sieve.FindPrimeNumbers();
                    Console.WriteLine($"Liste des entiers trouvés : {string.Join(", ", primes)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} : {ex.ToString()}");
                }
            } while (true);
        }
    }
}

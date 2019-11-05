namespace SieveOfEratosthenesDomain.PrimaryAdapters
{
    public interface ConsoleAdapter
    {
        uint GetNumberFromInput(string input);
        string GetInput();
        void RequestNumber();
        void DisplayPrimesFound(uint[] primes);
    }
}

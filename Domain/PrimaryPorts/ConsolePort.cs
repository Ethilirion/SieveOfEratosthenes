namespace SieveDomain.PrimaryAdapters
{
    public interface ConsolePort
    {
        uint GetNumberFromInput(string input);
        string GetInput();
        void RequestNumber();
        void DisplayPrimesFound(uint[] primes);
    }
}

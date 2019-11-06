using System;
using System.Collections.Generic;

namespace SieveDomain
{
    /*
     * Le crible d'ératosthènes : pour toute valeur N supérieure ou égale à 2 ;
     * dans un tableau d'entiers jusqu'à une valeur N, supprimer les multiples de
     * chaque entier I non préalablement supprimé, jusqu'à ce que le carré de I soit supérieur à N
     */
    public class SieveOfEratosthenesImplementation : Sieve
    {
        public static UInt32 MinimumCorrectValue = 2;
        private uint sieveThreshold = 0;
        private bool[] sieve;
        private uint[] primesFound;


        public SieveOfEratosthenesImplementation(UInt32 maximumNumber)
        {
            if (maximumNumber < MinimumCorrectValue)
                throw new IncorrectValue(MinimumCorrectValue);
            this.sieveThreshold = maximumNumber;
            this.sieve = new bool[this.sieveThreshold + 1];
        }

        private SieveOfEratosthenesImplementation() { }

        public uint[] FindPrimeNumbers()
        {
            InitializeArrayOfNumbersToReRun();

            ProcessSieve(MinimumCorrectValue);
            primesFound = FilterPrimesFromSieveArray();
            return primesFound;
        }

        private void ProcessSieve(uint currentNumberToSieve)
        {
            if (ThresholdIsMinimumValue())
                return;
            if (NumberSquaredHigherThanThreshold(currentNumberToSieve))
                return ;
            uint currentMultiple = 1;
            uint multiplicationResultForCurrentMultiple;
            do
            {
                multiplicationResultForCurrentMultiple = GetNextMultipleToSieve(currentMultiple, currentNumberToSieve);
                if (MultipleHigherThanSieveThreshold(multiplicationResultForCurrentMultiple))
                    break;
                if (IsNotFirstMultiple(currentMultiple))
                    DeleteNumberFromPrimeCandidates(multiplicationResultForCurrentMultiple);
                currentMultiple++;
            } while (MultipleHigherThanSieveThreshold(currentMultiple) == false);
            ProcessSieve(FirstNumberAvailable(currentNumberToSieve));
        }

        private bool ThresholdIsMinimumValue()
        {
            if (sieveThreshold == MinimumCorrectValue)
                return true;
            return false;
        }

        private bool MultipleHigherThanSieveThreshold(uint multiplicationResultOfCurrentNumberToSieve)
        {
            if (multiplicationResultOfCurrentNumberToSieve > sieveThreshold)
                return true;
            return false;
        }

        private uint GetNextMultipleToSieve(uint currentMultipleOfNumberToSieve, uint currentNumberToSieve)
        {
            return currentMultipleOfNumberToSieve * currentNumberToSieve;
        }

        private void DeleteNumberFromPrimeCandidates(uint multiplicationResultOfCurrentNumberToSieve)
        {
            sieve[multiplicationResultOfCurrentNumberToSieve] = false;
        }

        private bool IsNotFirstMultiple(uint currentMultipleOfNumberToSieve)
        {
            if (currentMultipleOfNumberToSieve > 1)
                return true;
            return false;
        }

        private uint[] FilterPrimesFromSieveArray()
        {
            List<uint> primes = new List<uint>();
            for (uint indexInSieveArray = 0; NumberInferiorOrEqualToThreshold(indexInSieveArray); indexInSieveArray++)
            {
                if (sieve[indexInSieveArray] == true)
                    primes.Add(indexInSieveArray);
            }
            return primes.ToArray();
        }

        private bool NumberSquaredHigherThanThreshold(uint currentNumberToSieve)
        {
            if ((currentNumberToSieve * currentNumberToSieve) > sieveThreshold)
                return true;
            return false;
        }

        private uint FirstNumberAvailable(uint currentNumber)
        {
            for (uint indexForFindingFirstAvailableNumber = currentNumber + 1; NumberInferiorOrEqualToThreshold(indexForFindingFirstAvailableNumber); indexForFindingFirstAvailableNumber++)
            {
                if (NumberIsAvailable(indexForFindingFirstAvailableNumber))
                    return indexForFindingFirstAvailableNumber;
            }
            throw new NoNumberAvailable();
        }
            
        private bool NumberIsAvailable(uint indexForFindingFirstAvailableNumber)
        {
            if (sieve[indexForFindingFirstAvailableNumber] == true)
                return true;
            return false;
        }

        private void InitializeArrayOfNumbersToReRun()
        {
            for (uint indexForReinitializing = 0; NumberInferiorOrEqualToThreshold(indexForReinitializing); indexForReinitializing++)
            {
                sieve[indexForReinitializing] = true;
            }
            for (uint indexForUnsettingAlwaysFalseNumbers = 0; indexForUnsettingAlwaysFalseNumbers < MinimumCorrectValue; indexForUnsettingAlwaysFalseNumbers++)
            {
                sieve[indexForUnsettingAlwaysFalseNumbers] = false;
            }
        }

        private bool NumberInferiorOrEqualToThreshold(uint number)
        {
            return number <= sieveThreshold;
        }
    }
}

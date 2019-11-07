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
        public static UInt32 minimumCorrectValue = 2;
        private uint sieveThreshold = 0;
        private bool[] correctValuesInSieve;
        private uint[] primesFound;


        public SieveOfEratosthenesImplementation(UInt32 maximumNumber)
        {
            if (maximumNumber < minimumCorrectValue)
                throw new IncorrectValue(minimumCorrectValue);
            this.sieveThreshold = maximumNumber;
            this.correctValuesInSieve = new bool[this.sieveThreshold + 1];
        }

        private SieveOfEratosthenesImplementation() { }

        public uint[] FindPrimeNumbers()
        {
            InitializeCorrectValuesInSieve();

            ProcessSieve(minimumCorrectValue);
            primesFound = GetPrimesFromSieve();
            return primesFound;
        }

        private void ProcessSieve(uint currentNumberInSieve)
        {
            if (NumberSquaredHigherThanThreshold(currentNumberInSieve) || ThresholdIsMinimumValue())
                return;
            RemoveCurrentNumberMultiples(currentNumberInSieve);
            ProcessSieve(FirstNumberAvailable(currentNumberInSieve));
        }

        private void RemoveCurrentNumberMultiples(uint currentNumberInSieve)
        {
            uint currentMultiple = 1;
            uint multiplicationResultForCurrentMultiple;
            do
            {
                multiplicationResultForCurrentMultiple = GetNextMultipleToSieve(currentMultiple, currentNumberInSieve);
                if (MultipleHigherThanSieveThreshold(multiplicationResultForCurrentMultiple))
                    break;
                if (IsNotFirstMultiple(currentMultiple))
                    DeleteNumberFromPrimeCandidates(multiplicationResultForCurrentMultiple);
                currentMultiple++;
            } while (MultipleHigherThanSieveThreshold(currentMultiple) == false);
        }

        private bool ThresholdIsMinimumValue()
        {
            if (sieveThreshold == minimumCorrectValue)
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
            correctValuesInSieve[multiplicationResultOfCurrentNumberToSieve] = false;
        }

        private bool IsNotFirstMultiple(uint currentMultipleOfNumberToSieve)
        {
            if (currentMultipleOfNumberToSieve > 1)
                return true;
            return false;
        }

        private uint[] GetPrimesFromSieve()
        {
            List<uint> primes = new List<uint>();
            for (uint indexInSieveArray = 0; NumberInferiorOrEqualToThreshold(indexInSieveArray); indexInSieveArray++)
            {
                if (correctValuesInSieve[indexInSieveArray] == true)
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
            if (correctValuesInSieve[indexForFindingFirstAvailableNumber] == true)
                return true;
            return false;
        }

        private void InitializeCorrectValuesInSieve()
        {
            for (uint indexForReinitializing = 0; NumberInferiorOrEqualToThreshold(indexForReinitializing); indexForReinitializing++)
            {
                correctValuesInSieve[indexForReinitializing] = true;
            }
            for (uint indexForUnsettingAlwaysFalseNumbers = 0; indexForUnsettingAlwaysFalseNumbers < minimumCorrectValue; indexForUnsettingAlwaysFalseNumbers++)
            {
                correctValuesInSieve[indexForUnsettingAlwaysFalseNumbers] = false;
            }
        }

        private bool NumberInferiorOrEqualToThreshold(uint number)
        {
            return number <= sieveThreshold;
        }
    }
}

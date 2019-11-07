using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SieveDomain
{
    public class SieveOfAtkinImplementation : Sieve
    {
        /*
         * Le crible d'atkin se base sur un triple tableau et un tableau de résultats contenant les 
         * 60 premiers nombres premiers (d'où le 'magic 60' partout dans cette classe, l'algorithme 
         * mathématique veut ça).
         */
        private State State;
        private uint maximumThreshold;
        private uint[] primesUpTo60 = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 };
        private bool[] sieve;
        private Dictionary<uint, bool> firstArrayOfNumbers;
        private Dictionary<uint, bool> secondArrayOfNumbers;
        private Dictionary<uint, bool> thirdArrayOfNumbers;

        public SieveOfAtkinImplementation()
        {
            State = State.NotInitialized;
        }

        public SieveOfAtkinImplementation(uint maximumThreshold)
        {
            State = State.NotInitialized;
            SetMaximumThreshold(maximumThreshold);
        }

        public uint[] FindPrimeNumbers()
        {
            if (SieveNotInitialized())
                throw new SieveNotInitialized();
            if (MaximumThresholdBelow60())
                return PrimesUpToThresholdFromEarlyArray();

            InitializeSieveArray();
            return new uint[] { };
        }

        private void InitializeSieveArray()
        {
            InitializeBooleanArray();
            InitializeSecondaryArrays();
            RemoveNumbersFromSecondaryArrays();
        }

        private bool SolveEquationForFirstArray(uint x, uint y, uint currentNumberToProcess)
        {
            if ((4 * Math.Pow(x, 2) + Math.Pow(y, 2)) == currentNumberToProcess)
                return true;
            return false;
        }

        private void RemoveNumbersFromSecondaryArrays()
        {
            UnsetNumbersFromArray(firstArrayOfNumbers, SolveEquationForFirstArray);
            UnsetNumbersFromArray(secondArrayOfNumbers, SolveEquationForSecondArray);
            UnsetNumbersFromArray(thirdArrayOfNumbers, SolveEquationForThirdArray);
        }

        private bool SolveEquationForThirdArray(uint x, uint y, uint currentNumberToProcess)
        {
            if ((3 * Math.Pow(x, 2) + Math.Pow(y, 2) == currentNumberToProcess))
                return true;
            return false;
        }

        private bool SolveEquationForSecondArray(uint x, uint y, uint currentNumberToProcess)
        {
            if ((3 * Math.Pow(x, 2) - Math.Pow(y, 2) == currentNumberToProcess))
                return true;
            return false;
        }

        private void UnsetNumbersFromArray(Dictionary<uint, bool> array, Func<uint, uint, uint, bool> equationSolver)
        {
            var equationsToProcess = PrepareCouplesForArray(array);
            UnsetNumbersInArray(equationsToProcess, array, equationSolver);
        }

        private void UnsetNumbersInArray(List<KeyValuePair<uint, uint>> equationsToProcess, Dictionary<uint, bool> firstArrayOfNumbers, Func<uint, uint, uint, bool> equationSolver)
        {
            Dictionary<uint, uint> countOfCouplesForEachNumber = new Dictionary<uint, uint>();
            foreach (var tuple in firstArrayOfNumbers)
            {
                var currentNumberToSolve = tuple.Key;

                countOfCouplesForEachNumber[currentNumberToSolve] = CountMatchingEquationsForArray(currentNumberToSolve, equationsToProcess, equationSolver);
                if (NumberShouldBeUnset(countOfCouplesForEachNumber[currentNumberToSolve]))
                    UnsetNumber(currentNumberToSolve, firstArrayOfNumbers);
            }
        }

        private void UnsetNumber(uint currentNumber, Dictionary<uint, bool> arrayOfNumbers)
        {
            if (arrayOfNumbers.Keys.Contains(currentNumber) == false)
                throw new Exception();
            arrayOfNumbers[currentNumber] = false;
        }

        private bool NumberShouldBeUnset(uint numberToCheck)
        {
            if (numberToCheck % 2 == 0 && numberToCheck > 0)
                return true;
            return false;
        }

        private uint CountMatchingEquationsForArray(uint currentNumberToSolve, List<KeyValuePair<uint, uint>> equationsToProcess, Func<uint, uint, uint, bool> equationToResolve)
        {
            uint counterOfMatchingEquations = 0;

            foreach (var equation in equationsToProcess)
            {
                if (equationToResolve(equation.Key, equation.Value, currentNumberToSolve))
                    counterOfMatchingEquations++;
            }
            return counterOfMatchingEquations;
        }

        private List<KeyValuePair<uint, uint>> PrepareCouplesForArray(Dictionary<uint, bool> array)
        {
            List<KeyValuePair<uint, uint>> equationsToProcess = new List<KeyValuePair<uint, uint>>();

            foreach (uint value in array.Keys)
            {
                foreach (uint secondValue in array.Keys)
                {
                    if (value == secondValue)
                        continue;
                    if (TupleDoesNotExistInEquationsToProcess(equationsToProcess, value, secondValue))
                        equationsToProcess.Add(new KeyValuePair<uint, uint>(value, secondValue));
                }
            }
            return equationsToProcess;
        }

        private bool TupleDoesNotExistInEquationsToProcess(List<KeyValuePair<uint, uint>> equationsToProcess, uint value, uint secondValue)
        {
            if (equationsToProcess.Any(a => (a.Key == value && a.Value == secondValue) || (a.Key == secondValue && a.Value == value)) == false)
                return true;
            return false;
        }

        private void InitializeBooleanArray()
        {
            sieve = new bool[maximumThreshold + 1];
            for (uint indexInSieve = 0; indexInSieve <= maximumThreshold; indexInSieve++)
            {
                if (indexInSieve > 60)
                    sieve[indexInSieve] = true;
                else if (NumberIsPrimeUnder60(indexInSieve) == false)
                    sieve[indexInSieve] = false;
            }
        }

        private bool NumberIsPrimeUnder60(uint indexInSieve)
        {
            if (primesUpTo60.Contains(indexInSieve))
                return true;
            return false;
        }

        private void InitializeSecondaryArrays()
        {
            /*
             * L'algorithme du crible indique que sont placés dans les tableaux secondaires
             * les nombres supérieurs à 60
             */
            firstArrayOfNumbers = new Dictionary<uint, bool>();
            secondArrayOfNumbers = new Dictionary<uint, bool>();
            thirdArrayOfNumbers = new Dictionary<uint, bool>();
            for (uint indexInSieve = 61; indexInSieve <= maximumThreshold; indexInSieve++)
            {
                PopulateSecondaryArrays(indexInSieve);
            }
        }

        private void PopulateSecondaryArrays(uint indexInSieve)
        {
            if (ShouldGoInFirstArray(indexInSieve))
                firstArrayOfNumbers[indexInSieve] = true;
            else if (ShouldGoInSecondArray(indexInSieve))
                secondArrayOfNumbers[indexInSieve] = true;
            else if (ShouldGoInThirdArray(indexInSieve))
                thirdArrayOfNumbers[indexInSieve] = true;
        }

        private bool ShouldGoInThirdArray(uint indexInSieve)
        {
            var modulo = indexInSieve % 60;
            if (new uint[] { 11, 23, 47, 59 }.Contains(modulo))
                return true;
            return false;
        }

        private bool ShouldGoInSecondArray(uint indexInSieve)
        {
            var modulo = indexInSieve % 60;
            if (new uint[] { 7, 19, 31, 43 }.Contains(modulo))
                return true;
            return false;
        }

        private bool ShouldGoInFirstArray(uint indexInSieve)
        {
            var modulo = indexInSieve % 60;
            if (new uint[] { 1, 13, 17, 29, 37, 41, 49, 53 }.Contains(modulo))
                return true;
            return false;
        }

        private uint[] PrimesUpToThresholdFromEarlyArray()
        {
            IList<uint> results = primesUpTo60;
            return (from prime in results
                    where prime <= maximumThreshold
                    select prime).ToArray();
        }

        private bool MaximumThresholdBelow60()
        {
            if (maximumThreshold <= 60)
                return true;
            return false;
        }

        private bool SieveNotInitialized()
        {
            if (State == State.NotInitialized)
                return true;
            return false;
        }

        public void SetMaximumThreshold(uint maximumThreshold)
        {
            State = State.Ready;
            this.maximumThreshold = maximumThreshold;
        }
    }
}

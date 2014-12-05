using System;
using System.Collections.Generic;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke5 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var numArr = GetNumbersWithAllUniqueDigits();
            var maxNum = Math.Sqrt(987654321);
            var primesArray = Utils.FindPrimesBelow((int) maxNum);

            var lowestHighest = int.MaxValue;
            foreach (var i in numArr)
            {
                var largestPrimeFactor = FindLargestPrimeFactor(i, lowestHighest, primesArray);
                if (largestPrimeFactor < lowestHighest)
                {
                    lowestHighest = largestPrimeFactor;
                }
            }

            return lowestHighest;
        }

        private int FindLargestPrimeFactor(int number, int previousMax, List<int> primesArray)
        {
            var allPrimes = Utils.FindPrimeFactors(number, previousMax, primesArray);
            return allPrimes.Max();
        }

        private int[] GetNumbersWithAllUniqueDigits()
        {
            var perms = Utils.FindAllPermutations(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9});
            return perms.Select(x => int.Parse(string.Concat(x))).ToArray();
        }

        protected override int GetNummer()
        {
            return 5;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Julekalender
{
    public static class Utils
    {
        public static IEnumerable<T> SkipAndTakeFromBehind<T>(this IEnumerable<T> list, int skip, int take)
        {
            var enumerable = list as T[] ?? list.ToArray();
            return enumerable.Skip(Math.Max(0, enumerable.Count() - (skip + take))).Take(take);
        }

        public static bool IsPalindrom(int num)
        {
            var str = num.ToString();

            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static int GetHighest8Pow(int integer)
        {
            var i = 0;
            while (true)
            {
                var pow = (int)Math.Pow(8, i);
                var nextPow = (int)Math.Pow(8, i + 1);
                if (pow == integer)
                {
                    break;
                }
                if (pow < integer && nextPow > integer)
                {
                    break;
                }
                i++;
            }
            return i;
        }

        public static int GetOctalRep(int integer)
        {
            var highest = GetHighest8Pow(integer);
            string answer = String.Empty;

            for (int i = highest; i >= 0; i--)
            {
                var pow = (int)Math.Pow(8, i);
                var num = 0;
                while (num <= 8)
                {
                    if (pow * num == integer)
                    {
                        answer += num.ToString();
                        break;
                    }
                    if (pow * num > integer)
                    {
                        num = num - 1;
                        answer += num.ToString();
                        break;
                    }
                    num++;
                }
                integer = (int)(integer % Math.Pow(8, i));
            }

            return Int32.Parse(answer);
        }

        /// <summary>
        /// Using the Sieve of Eratosthenes 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<long> FindPrimesBelowLong(int number)
        {
            bool[] A = FindPrimesBoolArray(number);
            var returnList = new List<long>();

            for (int j = 2; j < A.Length; j++)
            {
                if (A[j])
                {
                    returnList.Add(j);
                }
            }
            return returnList;
        }

        /// <summary>
        /// Using the Sieve of Eratosthenes 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<int> FindPrimesBelow(int number)
        {
            bool[] A = FindPrimesBoolArray(number);
            var returnList = new List<int>();

            for (int j = 2; j < A.Length; j++)
            {
                if (A[j])
                {
                    returnList.Add(j);
                }
            }
            return returnList;
        }

        public static bool[] FindPrimesBoolArray(int number)
        {
            int i = 2;
            bool[] A = new bool[number + 1];

            for (int index = 0; index < A.Length; index++)
            {
                A[index] = true;
            }

            while (i * i <= number)
            {
                if (A[i])
                {
                    int j = i * i;
                    while (j <= number)
                    {
                        A[j] = false;
                        j += i;
                    }
                }
                i++;
            }
            return A;
        }

        public static int ComputeFactorial(int number)
        {
            int factorial = 1;
            while (number > 1)
            {
                factorial *= number;
                number--;
            }
            return factorial;
        }

        public static int[] FindDivisors(int number)
        {
            List<int> divisors = new List<int>();

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors.ToArray();
        }

        public static int[] FindPrimeFactors(int number, int previousMax, List<int> primesArray = null)
        {
            var factors = new List<int>();
            var root = Math.Sqrt(number);
            var primes = primesArray ?? FindPrimesBelow((int) root);
            var index = 0;
            while (true)
            {
                if (index >= primes.Count - 1)
                {
                    break;
                }
                var i = primes[index];
                if (i >= (number/2))
                {
                    break;
                }
                while (number % i == 0)
                {
                    if (i > previousMax)
                    {
                        return new[] { Int32.MaxValue };
                    }
                    if (!factors.Contains(i))
                    {
                        factors.Add(i);
                    }
                    number /= i;
                }
                index++;
            }

            factors.Add(number);

            return factors.ToArray();
        }

        public static List<int[]> FindAllPermutations(IList<int> sequence, int nThPermutation = 0, bool returnOnlyLastSequence = false)
        {
            int limit = nThPermutation != 0 ? nThPermutation : ComputeFactorial(sequence.Count);
            List<int[]> permutations = new List<int[]>();
            int i;
            int k;
            int tmp;
            // find all permutations
            for (int j = 0; j < limit; j++)
            {
                i = 0;
                k = 0;
                // Step 1: find K
                for (int l = sequence.Count - 1; l >= 0; l--)
                {
                    if (l + 1 >= sequence.Count)
                    {
                        continue;
                    }
                    if (sequence[l] < sequence[l + 1])
                    {
                        k = l;
                        break;
                    }
                }

                // Step 2: Find i
                for (int l = k; l < sequence.Count; l++)
                {
                    if (sequence[k] < sequence[l])
                    {
                        i = l;
                    }
                }

                // Step 3: Swap k and i
                // Swap
                tmp = sequence[i];
                sequence[i] = sequence[k];
                sequence[k] = tmp;

                // Step 4: Reverse from k+1 to n
                if (k + 1 < sequence.Count - 1)
                {
                    int count = 1;
                    int[] reversedSequence = (int[])sequence.ToArray().Clone();

                    for (int l = k + 1; l < sequence.Count; l++)
                    {
                        reversedSequence[l] = sequence[sequence.Count - count];
                        count++;
                    }

                    sequence = reversedSequence;
                }
                if (!returnOnlyLastSequence)
                {
                    permutations.Add(sequence.ToArray().Clone() as int[]);
                }
            }
            if (returnOnlyLastSequence)
            {
                return new List<int[]> { sequence.ToArray() };
            }
            return permutations;
        }
    }
}
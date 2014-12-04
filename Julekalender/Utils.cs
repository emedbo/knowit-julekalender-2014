using System;
using System.Collections.Generic;

namespace Julekalender
{
    public class Utils
    {
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
        public static List<int> FindPrimesBelow(int number)
        {
            bool[] A = FindPrimesBoolArray(number);
            List<int> returnList = new List<int>();

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
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke15 : JulekalenderLukeBase<int>
    {


        public override int Solve()
        {
            var count = 0;
            for (int i = 10; i < 100; i++)
            {
                for (int j = 10; j < 100; j++)
                {
                    if (i % 10 == 0 && j % 10 == 0)
                    {
                        continue;
                    }
                    var prod = i * j;
                    if (GetDigits(prod).Length < 4)
                    {
                        continue;
                    }
                    if (IsMatch(prod, i, j))
                    {
                        count++;
                    }
                }
            }
            return count / 2;
        }

        private bool IsMatch(int prod, int fac1, int fac2)
        {
            var prodArr = new List<int>(GetDigits(prod));
            var fac1Arr = new List<int>(GetDigits(fac1));
            var fac2Arr = new List<int>(GetDigits(fac2));
            foreach (var i in prodArr)
            {
                var match1 = fac1Arr.Any(x => x == i);
                if (match1)
                {
                    fac1Arr.Remove(i);
                    continue;
                }
                var match2 = fac2Arr.Any(x => x == i);
                if (match2)
                {
                    fac2Arr.Remove(i);
                    continue;
                }
                return false;
            }
            return true;
        }

        private int[] GetDigits(int num)
        {
            var numbers = new Stack<int>();
            for (; num > 0; num /= 10)
            {
                numbers.Push(num % 10);
            }
            return numbers.ToArray();
        }

        protected override int GetNummer()
        {
            return 15;
        }
    }
}
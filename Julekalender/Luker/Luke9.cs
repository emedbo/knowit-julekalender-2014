using System;
using System.Collections.Generic;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke9 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var allNums = Utils.FindAllPermutations(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0});
            var smallestNum = 1000;
            var regne = new List<Tuple<int, int, int>>();
            foreach (var allNum in allNums)
            {
                var l1 = int.Parse(string.Join("", allNum.Take(3)));
                var l2 = int.Parse(string.Join("", allNum.Skip(3).Take(3)));
                var l3 = int.Parse(string.Join("", allNum.Skip(6).Take(4)));
                var sum = l1 + l2;

                if (l3 > 1000 && sum == l3)
                {
                    regne.Add(new Tuple<int, int, int>(l1, l2, sum));
                    if(l1 < smallestNum)
                    {
                        smallestNum = l1;
                    }
                    if (l2 < smallestNum)
                    {
                        smallestNum = l2;
                    }
                }
            }

            return smallestNum;
        }

        protected override int GetNummer()
        {
            return 9;
        }
    }
}
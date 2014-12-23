using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke22 : JulekalenderLukeBase<string>
    {
        public override string Solve()
        {
            return string.Join(",", GetNumbers());
        }

        private IEnumerable<int> GetNumbers(
            )
        {
            for (int i = 1; i < 51; i++)
            {
                if (RunNumber(i))
                {
                    yield return i;
                }
            }
        }

        private bool RunNumber(int num)
        {
            var count = 0;
            while (num != 1 && count <= 1000)
            {
                var digits = Utils.GetDigits(num);
                num = digits.Select(x => x*x).Sum();
                count++;
            }
            return num == 1;
        }

        protected override int GetNummer()
        {
            return 22;
        }
    }
}
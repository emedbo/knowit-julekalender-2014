using System;
using System.Globalization;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke13 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            int count = 0;
            var primes = Utils.FindPrimesBoolArray(1000);
            for(int i =0; i < primes.Length; i++)
            {
                if (!primes[i])
                {
                    continue;
                }
                var str = i.ToString(CultureInfo.InvariantCulture).ToCharArray();
                Array.Reverse(str);
                var revstr = new string(str);

                var reverse = int.Parse(revstr);
                if (primes[reverse] && !Utils.IsPalindrom(i))
                {
                    count++;
                }
            }

            return count;
        }

        protected override int GetNummer()
        {
            return 13;
        }
    }
}
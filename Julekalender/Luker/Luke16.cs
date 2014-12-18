using System;
using System.Numerics;

namespace Julekalender.Luker
{
    public class Luke16 : JulekalenderLukeBase<int>
    {
        public override int Solve()

        {
            var potens = "1";
            for (int i = 1; i < 10000; i++)
            {
                potens = BigInteger.Pow(2, i).ToString();
                if (potens.IndexOf("472047", StringComparison.Ordinal) != -1)
                {
                    return i;
                }
            }
            return 0;
        }

        protected override int GetNummer()
        {
            return 16;
        }
    }
}
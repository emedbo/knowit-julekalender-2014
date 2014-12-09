using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Julekalender.Luker
{
    public class Luke8 : JulekalenderLukeBase<string>
    {
        public override string Solve()
        {
            var retString = new StringBuilder();

            for (int i = 1; i < 10000; i++)
            {
                var facts = Utils.FindDivisors(i);
                var sum = facts.Where(x => x != i).Sum();
                if (sum == i)
                {
                    retString.Append(i + ",");
                }
            }
            retString.Remove(retString.Length - 1, 1);
            return retString.ToString();
        }
        
        protected override int GetNummer()
        {
            return 8;
        }
    }
}
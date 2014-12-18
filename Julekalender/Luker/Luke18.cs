using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke18 : JulekalenderLukeBase<string>
    {
        public override string Solve()
        {
            var arr = new List<string>();
            var stream = new StreamReader(@"Luker\Data\Luke18.txt");
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine().ToLower();
                var charArr = line.ToCharArray();
                Array.Sort(charArr);
                arr.Add(new string(charArr));
            }

            var max = arr.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            return max;
        }

        protected override int GetNummer()
        {
            return 18;
        }
    }
}
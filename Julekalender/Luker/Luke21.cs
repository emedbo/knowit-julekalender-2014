using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Julekalender.Luker
{
    public class Luke21 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var arr = new List<string>();
            var stream = new StreamReader(@"Luker\Data\Luke21.txt");
            var list = new List<int>();
            while (!stream.EndOfStream)
            {
                var sumAscii = Encoding.ASCII.GetBytes(stream.ReadLine()).Sum(x => x);
                list.Add(sumAscii);
            }

            return list.OrderByDescending(x => x).Take(42).Sum();
        }

        protected override int GetNummer()
        {
            return 21;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;

namespace Julekalender.Luker
{
    public class Luke7 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var a2 = new Dictionary<string, int>();
            var bmp = new Bitmap(@"Luker\Data\Luke7.png");

            for (var i = 0; i < bmp.Height; i++)
            {
                for (var j = 0; j < bmp.Width; j++)
                {
                    var color = bmp.GetPixel(j, i);
                    var s = color.Name;
                    if (a2.ContainsKey(s))
                    {
                        a2[s] += 1;
                    }
                    else
                    {
                        a2[s] = 1;
                    }
                }
            }
            var tenth = a2.OrderByDescending(x => x.Value).Take(10).Select(x => x.Value).ToArray();
            return tenth.Last();
        }

        protected override int GetNummer()
        {
            return 7;
        }
    }
}
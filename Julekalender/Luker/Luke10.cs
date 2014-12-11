using System.Collections.Generic;

namespace Julekalender.Luker
{
    public class Luke10 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
    var julebord = new List<int>();
    for (int j = 1; j < 1500 + 1; j++)
    {
        julebord.Add(j);
    }

    var index = 0;
    while (julebord.Count > 1)
    {
        julebord.RemoveAt((index + 1 ) % julebord.Count);
        index = (index + 1) >= julebord.Count? 0: index +1;
    }
    return julebord[0];
        }

        protected override int GetNummer()
        {
            return 10;
        }
    }
}
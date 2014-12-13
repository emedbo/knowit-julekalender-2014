using System;

namespace Julekalender.Luker
{
    public class Luke12 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var friCount = 0;
            for (int i = 1337; i <= 2014; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    var date = new DateTime(i, j, 13);
                    if (date.DayOfWeek == DayOfWeek.Friday)
                    {
                        friCount++;
                    }
                }
            }
            return friCount;
        }

        protected override int GetNummer()
        {
            return 12;
        }
    }
}
namespace Julekalender.Luker
{
    public class Luke1 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var numPalin = 0;

            for (int i = 1; i < 1000000; i++)
            {
                if (Utils.IsPalindrom(i))
                {
                    var octal = Utils.GetOctalRep(i);
                    if (Utils.IsPalindrom(octal))
                    {
                        numPalin++;
                    }
                }
            }

            return numPalin;
        }


        protected override int GetNummer()
        {
            return 1;
        }
    }
}
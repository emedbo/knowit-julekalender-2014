using System.Collections;

namespace Julekalender.Luker
{
    public class Luke6 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var num = 8000;
            var answer = CountUniqueProducts(num);
            return answer;
        }

        private int CountUniqueProducts(int num)
        {
            var table = new Hashtable();
            for (int i = 1; i <= num; i++)
            {
                for (int j = i; j <= num; j++)
                {
                    var product = i*j;
                    table[product] = 1;
                }
            }
            return table.Count;
        }

        protected override int GetNummer()
        {
            return 6;
        }
    }
}
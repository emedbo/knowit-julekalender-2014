using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            var table = new bool[num * num + 1];
            for (int i = 1; i <= num; i++)
            {
                for (int j = i; j <= num; j++)
                {
                    var product = i*j;
                    table[product] = true;
                }
            }
            return table.Count(x => x);
        }

        protected override int GetNummer()
        {
            return 6;
        }
    }
}
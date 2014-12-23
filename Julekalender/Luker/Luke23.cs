using System.Linq;

namespace Julekalender.Luker
{
    public class Luke23 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            //var t1 = TestNum(100);
            //var t2 = TestNum(101);
            //var t3 = TestNum(88209);

            var count = 0;
            for (int i = 10; i < 1000000; i++)
            {
                if (TestNum(i))
                {
                    count++;
                }
            }
            
            return count;
        }

        private bool TestNum(int num)
        {
            var digits = Utils.GetDigits(num);
            for (int i = 1; i < digits.Length; i++)
            {
                var num1 = int.Parse(string.Join("", digits.Take(i)));
                var num2 = int.Parse(string.Join("", digits.Skip(i).Take(digits.Length - i)));
                var sum = num1 + num2;
                if (sum*sum == num)
                {
                    return true;
                }
            }
            return false;
        }

        protected override int GetNummer()
        {
            return 23;
        }
    }
}
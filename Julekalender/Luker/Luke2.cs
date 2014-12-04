using System.Linq;

namespace Julekalender.Luker
{
    public class Luke2 : JulekalenderLukeBase<int>
    {
        public override int Solve()
        {
            var solution = SolveFor(9);

            return solution;
        }

        private int SolveFor(int n)
        {
            var primes = Utils.FindPrimesBelow(100).Where(x => x.ToString().Length > 1).ToList();

            // First number: next prime above n
            var firstTwoDigits = primes.First(x => int.Parse(x.ToString().Substring(0, 1)) >= n);
            
            var digitArr = new int[n -1];
            digitArr[0] = firstTwoDigits;
            var m = digitArr[0].ToString();
            for (int i = 1; i < n - 1; i++)
            {
                var last = digitArr[i - 1].ToString();
                digitArr[i] = primes.First(x => int.Parse(x.ToString().Substring(0, 1)) >= int.Parse(last.Substring(last.Length - 1, 1)) && !digitArr.Contains(x));
                m += digitArr[i].ToString().Substring(1, 1);
            }

            return int.Parse(m);
        }

        protected override int GetNummer()
        {
            return 2;
        }
    }
}
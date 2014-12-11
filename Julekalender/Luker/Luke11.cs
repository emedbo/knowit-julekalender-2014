using System;
using System.Collections.Generic;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke11 : JulekalenderLukeBase<int>
    {
        private List<int> _primes;

        public override int Solve()
        {
            _primes = Utils.FindPrimesBelow(8000000);

            // Compute all possible sums
            var sumArr1 = ComputeSumArray(_primes, 541).ToArray();
            var sumArr2 = ComputeSumArray(_primes, 7).ToArray();
            var sumArr3 = ComputeSumArray(_primes, 41).ToArray();
            var sumArr4 = ComputeSumArray(_primes, 17).ToArray();

            return sumArr1.First(x => Array.IndexOf(sumArr2, x) != -1 && Array.IndexOf(sumArr3, x) != -1 && Array.IndexOf(sumArr4, x) != -1);
        }

        private IEnumerable<int> ComputeSumArray(List<int> primes, int take)
        {
            var index = 0;
            var tmp = primes.Take(take).Sum();
            yield return tmp;
            while (index + take < primes.Count)
            {
                var first = primes[index];
                var next = primes[take + index];
                tmp = tmp - first + next;
                yield return tmp;
                index++;
            }
        }
        
        protected override int GetNummer()
        {
            return 11;
        }
    }
}
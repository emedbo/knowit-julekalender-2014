using System;
using System.Collections.Generic;

namespace Julekalender.Luker
{
    public class Luke17 : JulekalenderLukeBase<int>
    {
        private List<int[]> _possibleMoves;

        public override int Solve()
        {
            _possibleMoves = new List<int[]>
            {
                new[] {4, 6},
                new[] {6, 8},
                new[] {7, 9},
                new[] {4, 8},
                new[] {0, 3, 9},
                new int[0],
                new[] {1, 7, 0},
                new[] {2, 6},
                new[] {1, 3},
                new[] {2, 4},
            };

            var count = Traverse(1, 0);
            return count;
        }

        private int Traverse(int curr, int n)
        {
            int sum = 0;
            if (n == 9)
            {
                return 1;
            }
            for (int i = 0; i < _possibleMoves[curr].Length; i++)
            {
                sum += Traverse(_possibleMoves[curr][i], n + 1);
            }
            return sum;
        }

        protected override int GetNummer()
        {
            return 17;
        }
    }
}
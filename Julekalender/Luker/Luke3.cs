using System;
using System.Collections.Generic;
using System.Linq;

namespace Julekalender.Luker
{
    public class Luke3 : JulekalenderLukeBase<int>
    {
        public bool[] Board { get; set; }

        public override int Solve()
        {
            var board = new bool[100];
            var start = 0;

            for (int i = 0; i < 200; i++)
            {
                var moveTo = MoveTo(start, board, PossibleMoves(start).OrderBy(x => x).ToArray());
                board[start] = !board[start];
                start = moveTo;
            }
            return board.Count(b => b);

            //return 32;
        }

        public void Init()
        {
            Board = new bool[100];

        }

        public int MoveTo(int start, bool[] board, int[] possibleMoves)
        {
            var startColor = board[start];
            if(possibleMoves.Any(x => board[x] == startColor))
            {
                return possibleMoves.First(x => board[x] == startColor);
            }
                return possibleMoves.Last();
        }

        public IEnumerable<int> PossibleMoves(int start)
        {
            var m1Allowed = true; //  +1
            var m2Allowed = true; //  +2
            var j1Allowed = true; //  +10
            var j2Allowed = true; //  +20
            var m1Ballowed = true; // -1
            var m2Ballowed = true; // -2
            var j1Ballowed = true; // -10
            var j2Ballowed = true; // -20

            if (start%10 == 0) // står på venstre kant
            {
                m1Ballowed = false;
                m2Ballowed = false;
            }
            if (start % 10 == 9) // står på høyre kant
            {
                m1Allowed = false;
                m2Allowed = false;
            }
            if(start % 10 == 8) // står på nest til høyre
            {
                m2Allowed = false;
            }
            if (start % 10 == 1)// står på nest til venstre
            {
                m2Ballowed = false;
            }
            if (start < 10) // Står på nederste rad
            {
                j1Ballowed = false;
                j2Ballowed = false;
            }
            if (10 <= start && start < 20)
            {
                j2Ballowed = false;
            }
            if (80 <= start && start < 90)
            {
                j2Allowed = false;
            }
            if (start >= 90)
            {
                j1Allowed = false;
                j2Allowed = false;
            }

            if (m1Allowed && j2Allowed)
            {
                yield return start + 21;
            }
            if (m2Allowed && j1Allowed)
            {
                yield return start + 12;
            }
            if (m1Ballowed && j2Allowed)
            {
                yield return start + 19;
            }
            if (m2Ballowed && j1Allowed)
            {
                yield return start + 8;
            }
            if (m2Ballowed && j1Ballowed)
            {
                yield return start - 12;
            }
            if (m1Ballowed && j2Ballowed)
            {
                yield return start - 21;
            }
            if (m1Allowed && j2Ballowed)
            {
                yield return start - 19;
            }
            if (m2Allowed && j1Ballowed)
            {
                yield return start - 8;
            }
        } 

        protected override int GetNummer()
        {
            return 3;
        }
    }
}
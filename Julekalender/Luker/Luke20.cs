using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Julekalender.Luker
{
    public class SuperComp : IEqualityComparer<Tuple<int, int>>
    {
        public bool Equals(Tuple<int, int> x, Tuple<int, int> y)
        {
            return x.Item1 == y.Item1 && x.Item2 == y.Item2;
        }

        public int GetHashCode(Tuple<int, int> obj)
        {
            return obj.Item1 ^ obj.Item2;
        }
    }

    public class Luke20 : JulekalenderLukeBase<int>
    {
        Dictionary<Point, bool> _dict = new Dictionary<Point, bool>();

        public override int Solve()
        {

            Traverse(new Point(0, 0));
            var faster = solveFaster();
            

            return faster;
        }


        private bool[,] _lesBools = new bool[300, 300];
        private int solveFaster()
        {
            traverseFaster(0, 0);
            var count = 0;
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++)
                {
                    if (_lesBools[i, j])
                    {
                        count++;
                    }
                }
            }

            count *= 4;
            count -= (4*298); // not count edges of quadrant 4 times
            count += 1; // 0 is not counted;
            return count;
        }

        private void traverseFaster(int x, int y)
        {
            if (NoCanGo(x, y))
            {
                return;
            }
            if (canGoRight(x, y))
            {
                _lesBools[x + 1, y] = true;
                traverseFaster(x + 1, y);
            } 
            if(canGoUp(x, y))
            {
                _lesBools[x, y + 1] = true;
                traverseFaster(x, y + 1);
            }
        }

        private bool canGoRight(int x, int y)
        {
            return (Utils.FinnTverrsum(x + 1) + Utils.FinnTverrsum(y) <= 19);
        }

        private bool canGoUp(int x, int y)
        {
            return Utils.FinnTverrsum(x) + Utils.FinnTverrsum(y + 1) <= 19;
        }

        private bool NoCanGo(int x, int y)
        {
            var hasBeenRight = _lesBools[x + 1, y];
            var hasBeenTop = _lesBools[x, y + 1];
            var canRight = canGoRight(x, y);
            var canTop = canGoUp(x, y);

            if (hasBeenRight && hasBeenTop)
            {
                return true;
            }
            if (!canRight && ! canTop)
            {
                return true;
            }
            return false;
        }


        private void Traverse(Point p)
        {
            var possible = findPossibleMoves(p).ToArray();
            if (possible.Count() == 0)
            {
                return;
            }
            foreach (var newPos in possible)
            {
                _dict[newPos] = true;
                Traverse(newPos);
            }
        }

        private IEnumerable<Point> findPossibleMoves(Point p)
        {
            int x = p.X;
            int y = p.Y;
            var høy = new Point(x + 1, y);
            var ven = new Point(x - 1, y);
            var opp = new Point(x, y + 1);
            var ned = new Point(x, y - 1);
            if (Utils.FinnTverrsum(høy.X) + Utils.FinnTverrsum(høy.Y) < 20 && !HasBeen(høy))
            {
                // Høyre
                yield return høy;
            }
            if (Utils.FinnTverrsum(ven.X) + Utils.FinnTverrsum(ven.Y) < 20 && !HasBeen(ven))
            {
                // Venstre
                yield return ven;
            }
            if (Utils.FinnTverrsum(opp.X) + Utils.FinnTverrsum(opp.Y) < 20 && !HasBeen(opp))
            {
                // Opp
                yield return opp;
            }
            if (Utils.FinnTverrsum(ned.X) + Utils.FinnTverrsum(ned.Y) < 20 && !HasBeen(ned))
            {
                // Ned
                yield return ned;
            }
        }

        private bool HasBeen(Point p)
        {
            if (!_dict.ContainsKey(p))
            {
                return false;
            }
            return _dict[p];
        }

        protected override int GetNummer()
        {
            return 20;
        }
    }
}
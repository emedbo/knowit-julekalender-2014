using System;
using System.Collections.Generic;

namespace Julekalender.Luker
{
    public class Luke14:JulekalenderLukeBase<int>
    {
        private Dictionary<char, char> _dict;

        public override int Solve()
        {
            _dict = new Dictionary<char, char>
            {
                {'1','1'},
                {'0', '0'},
                {'6', '9'},
                {'9', '6'},
                {'8', '8'},
            };


            var can = CanRead180(12);
            var can2 = CanRead180(916);
            int count = 0;
            for (int i = 0; i < 100000; i++)
            {
                if (CanRead180(i))
                {
                    count++;
                }
            }

            return count;
        }

        private bool CanRead180(int num)
        {
            var strnum = num.ToString();
            double ceiling = Math.Ceiling((double) strnum.Length/2);
            for (int i = 0; i < Math.Ceiling((double)strnum.Length / 2); i++)
            {
                char key = strnum[i];
                if (!_dict.ContainsKey(key))
                {
                    return false;
                }
               
                if(strnum[strnum.Length - 1 - i] != _dict[key] )
                {
                    return false;
                }
            }
            return true;

            return false;
        }

        protected override int GetNummer()
        {
            return 14;
        }
    }
}
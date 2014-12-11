using System;
using System.Diagnostics;
using Julekalender.Luker;

namespace Julekalender
{
    class Program
    {
        static void Main(string[] args)
        {
            var swatch = Stopwatch.StartNew();
            //Console.WriteLine(new Luke1().SolveAndPrint());
            //Console.WriteLine(new Luke2().SolveAndPrint());
            //Console.WriteLine(new Luke3().SolveAndPrint());
            //Console.WriteLine(new Luke4().SolveAndPrint());
            //Console.WriteLine(new Luke5().SolveAndPrint());
            //Console.WriteLine(new Luke6().SolveAndPrint());
            //Console.WriteLine(new Luke7().SolveAndPrint());
            //Console.WriteLine(new Luke8().SolveAndPrint());
            //Console.WriteLine(new Luke9().SolveAndPrint());
            //Console.WriteLine(new Luke10().SolveAndPrint());
            Console.WriteLine(new Luke11().SolveAndPrint());

            if (swatch.Elapsed.TotalMilliseconds < 1000)
            {
                Console.WriteLine("Completed in " + swatch.ElapsedMilliseconds + "ms");
            }
            else if (swatch.Elapsed.TotalSeconds < 60)
            {
                Console.WriteLine("Completed in " + swatch.Elapsed.TotalSeconds + "s");
            }
            else
            {
                Console.WriteLine("Completed in " + swatch.Elapsed.Minutes + ":" + swatch.Elapsed.Seconds.ToString().PadLeft(2, '0'));
            }
            

            Console.ReadLine();
        }
    }
}

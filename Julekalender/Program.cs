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
            //Console.WriteLine(new Luke11().SolveAndPrint());
            //Console.WriteLine(new Luke12().SolveAndPrint());
            //Console.WriteLine(new Luke13().SolveAndPrint());
            //Console.WriteLine(new Luke14().SolveAndPrint());
            //Console.WriteLine(new Luke15().SolveAndPrint());
            //Console.WriteLine(new Luke16().SolveAndPrint());
            //Console.WriteLine(new Luke17().SolveAndPrint());
            //Console.WriteLine(new Luke18().SolveAndPrint());
            //Console.WriteLine(new Luke19().SolveAndPrint());
            Console.WriteLine(new Luke20().SolveAndPrint());


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

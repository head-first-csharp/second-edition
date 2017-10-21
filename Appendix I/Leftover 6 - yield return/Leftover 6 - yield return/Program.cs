using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leftover_6___yield_return
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            Console.WriteLine("ManualSportCollection contents:");
            ManualSportCollection manualSportCollection = new ManualSportCollection();
            foreach (Sport sport in manualSportCollection)
                Console.WriteLine(sport.ToString());

            Console.WriteLine();

            Console.WriteLine("SportCollection contents:");
            SportCollection sportCollection = new SportCollection();
            foreach (Sport sport in sportCollection)
                Console.WriteLine(sport.ToString());

            Console.WriteLine();

            Console.WriteLine(sportCollection[3]);

            Console.WriteLine();

            IEnumerable<string> names = NameEnumerator(); // Put a breakpoint here
            foreach (string name in names)
                Console.WriteLine(name);

            Console.WriteLine();

            Console.WriteLine("Adding two guys and modifying one guy");
            GuyCollection guyCollection = new GuyCollection();
            guyCollection["Bob"] = guyCollection["Joe"] + 3;
            guyCollection["Bill"] = 57;
            guyCollection["Harry"] = 31;
            foreach (Guy guy in guyCollection)
                Console.WriteLine(guy.ToString());

            Console.ReadKey();
        }

        static IEnumerable<string> NameEnumerator()
        {
            yield return "Bob";   // The method exits after this statement ...
            yield return "Harry"; // ... and resumes here the next time through
            yield return "Joe";
            yield return "Frank";
        }

    }
}
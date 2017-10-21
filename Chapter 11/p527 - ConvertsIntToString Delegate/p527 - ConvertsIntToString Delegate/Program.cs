using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p527___ConvertsIntToString_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertsIntToString someMethod = new ConvertsIntToString(HiThere);
            string message = someMethod(5);
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private static string HiThere(int i)
        {
            return "Hi there! #" + (i * 100);
        }

    }
}

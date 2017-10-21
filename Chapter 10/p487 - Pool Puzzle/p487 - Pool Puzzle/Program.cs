using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p487___Pool_Puzzle
{
    class Program
    {
        public static void Main()
        {
            Kangaroo joey = new Kangaroo();
            int koala = joey.Wombat(joey.Wombat(joey.Wombat(1)));
            try
            {
                Console.WriteLine((15 / koala) + " eggs per pound");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("G’Day Mate!");
            }
        }
    }
}
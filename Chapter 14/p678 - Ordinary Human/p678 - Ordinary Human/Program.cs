using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p678___Ordinary_Human
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdinaryHuman steve = new OrdinaryHuman(185);
            Console.WriteLine(steve.BreakWalls(89.2));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p678___Ordinary_Human
{
    static class SuperSoldierSerum
    {
        public static string BreakWalls(this OrdinaryHuman h, double wallDensity)
        {
            return ("I broke through a wall of " + wallDensity + " density.");
        }
    }
}
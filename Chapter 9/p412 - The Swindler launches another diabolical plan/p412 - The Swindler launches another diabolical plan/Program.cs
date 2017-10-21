using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace p412___The_Swindler_launches_another_diabolical_plan
{
    class Program
    {
        static void Main(string[] args)
        {
            // It’s probably not a good idea to write to your root folder, and your OS
            // might not even let you do it. So we picked another directory to write to. 
            StreamWriter sw = new StreamWriter(@"C:\temp\secret_plan.txt");
            sw.WriteLine("How I’ll defeat Captain Amazing");
            sw.WriteLine("Another genius secret plan by The Swindler");
            sw.Write("I’ll create an army of clones and ");
            sw.WriteLine("unleash them upon the citizens of Objectville.");
            string location = "the mall";
            for (int number = 0; number <= 6; number++)
            {
                sw.WriteLine("Clone #{0} attacks {1}", number, location);
                if (location == "the mall") { location = "downtown"; }
                else { location = "the mall"; }
            }
            sw.Close();

        }
    }
}
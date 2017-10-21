using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p356___Upcast_an_entire_list
{
    class Penguin : Bird
    {
        public void Fly()
        {
            Console.WriteLine("Penguins can’t fly!");
        }
        public override string ToString()
        {
            return "A penguin named " + base.Name;
        }
    }
}
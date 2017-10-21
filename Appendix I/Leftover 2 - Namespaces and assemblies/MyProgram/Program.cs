using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Headfirst.Csharp.Leftover2;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy guy = new Guy("Joe", 43, 125);
            HiThereWriter.HiThere(guy.Name);
        }
    }
}
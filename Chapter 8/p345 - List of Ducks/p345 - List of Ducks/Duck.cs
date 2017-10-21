using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p345___List_of_Ducks
{
    class Duck : IComparable<Duck>
    {
        public int Size;
        public KindOfDuck Kind;

        public int CompareTo(Duck duckToCompare)
        {
            if (this.Size > duckToCompare.Size)
                return 1;
            else if (this.Size < duckToCompare.Size)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return "A " + Size + " inch " + Kind.ToString();
        }

        // We didn't show the body of these methods on page 345
        public void Quack() { Console.WriteLine("Quack!"); }
        public void Swim() { Console.WriteLine("Splash!"); }
        public void Eat() { Console.WriteLine("Yum!"); }
        public void Walk() { Console.WriteLine("Waddle waddle!"); }
    }
}
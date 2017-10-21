using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pool_Puzzle
{
    class Boat
    {
        private int length;
        public void setLength(int len)
        {
            length = len;
        }
        public int getLength()
        {
            return length;
        }
        public virtual string move()
        {
            return "   drift   ";
        }
    }
}
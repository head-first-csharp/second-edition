using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p240___Mixed_Messages
{
    class C : B
    {
        public override string m3()
        {
            return "C’s m3, " + (ivar + 6);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p275___Implement_the_IStingPatrol_interface
{
    class Bee : IStingPatrol
    {
        public int AlertLevel { get; private set; }
        public int StingerLength { get; set; }
        public bool LookForEnemies()
        {
            return true;
        }
        public int SharpenStinger(int length)
        {
            return 0;
        }
    }
}

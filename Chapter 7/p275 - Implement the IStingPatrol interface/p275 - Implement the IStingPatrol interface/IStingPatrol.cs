using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p275___Implement_the_IStingPatrol_interface
{
    interface IStingPatrol
    {
        int AlertLevel { get; }
        int StingerLength { get; set; }
        bool LookForEnemies();
        int SharpenStinger(int length);
    }
}

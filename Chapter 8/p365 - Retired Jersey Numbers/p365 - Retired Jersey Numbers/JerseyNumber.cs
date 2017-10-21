using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p365___Retired_Jersey_Numbers
{
    class JerseyNumber
    {
        public string Player { get; private set; }
        public int YearRetired { get; private set; }

        public JerseyNumber(string player, int numberRetired)
        {
            Player = player;
            YearRetired = numberRetired;
        }
    }
}

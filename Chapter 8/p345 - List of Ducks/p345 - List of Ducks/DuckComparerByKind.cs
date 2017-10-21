using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p345___List_of_Ducks
{
    class DuckComparerByKind : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Kind < y.Kind)
                return -1;
            if (x.Kind > y.Kind)
                return 1;
            else
                return 0;
        }
    }
}

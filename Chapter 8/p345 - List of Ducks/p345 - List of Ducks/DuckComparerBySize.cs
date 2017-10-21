using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p345___List_of_Ducks
{
    class DuckComparerBySize : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Size < y.Size)
                return -1;
            if (x.Size > y.Size)
                return 1;
            return 0;
        }
    }
}

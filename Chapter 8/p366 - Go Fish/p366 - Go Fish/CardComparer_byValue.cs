using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p366___Go_Fish
{
    class CardComparer_byValue : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.Value < y.Value)
            {
                return -1;
            }
            if (x.Value > y.Value)
            {
                return 1;
            }
            if (x.Suit < y.Suit)
            {
                return -1;
            }
            if (x.Suit > y.Suit)
            {
                return 1;
            }
            return 0;
        }
    }
}

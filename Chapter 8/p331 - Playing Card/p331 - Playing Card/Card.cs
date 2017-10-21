using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p331___Playing_Card
{

    class Card
    {
        public Suits Suit { get; set; }
        public Values Value { get; set; }

        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public string Name
        {
            get { return Value.ToString() + " of " + Suit.ToString(); }
        }
    }
}
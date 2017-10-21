using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lets_Build_a_House
{
    class Outside : Location
    {
        private bool hot;
        public bool Hot { get { return hot; } }

        public Outside(string name, bool hot)
            : base(name)
        {
            this.hot = hot;
        }

        public override string Description
        {
            get
            {
                string NewDescription = base.Description;
                if (hot)
                    NewDescription += " It’s very hot.";
                return NewDescription;
            }
        }
    }
}
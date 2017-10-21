using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leftover_6___yield_return
{
    class SportCollection : IEnumerable<Sport>
    {
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Sport> GetEnumerator()
        {
            int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
            for (int i = 0; i < maxEnumValue; i++)
            {
                yield return (Sport)i;
            }
        }

        public Sport this[int index]
        {
            get { return (Sport)index; }
        }
    }
}

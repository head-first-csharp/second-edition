using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyBaseClass
{
    class MySubclass : MyBaseClass
    {
        public MySubclass(string baseClassNeedsThis, int anotherValue)
            : base(baseClassNeedsThis)
        {
            MessageBox.Show("This is the subclass: " + baseClassNeedsThis
                 + " and " + anotherValue);
        }
    }
}
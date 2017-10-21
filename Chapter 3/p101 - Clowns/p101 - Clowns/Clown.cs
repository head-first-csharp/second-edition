using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// If you don't add this using directive then your program won't compile, 
// because the MessageBox class is in the System.Windows.Forms namespace.
//      ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓
using System.Windows.Forms;

namespace Clowns
{
    class Clown
    {
        public string Name;
        public int Height;

        public void TalkAboutYourself()
        {
            MessageBox.Show("My name is "
               + Name + " and I’m "
               + Height + " inches tall.");
        }
    }
}
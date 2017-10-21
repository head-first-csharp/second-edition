using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// If you don't add this using directive then your program won't compile, 
// because the MessageBox class is in the System.Windows.Forms namespace.
//      ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓
using System.Windows.Forms;


namespace Talker_Tester
{
    class Talker
    {
        public static int BlahBlahBlah(string thingToSay, int numberOfTimes)
        {
            string finalString = "";
            for (int count = 1; count <= numberOfTimes; count++)
            {
                finalString = finalString + thingToSay + "\n";
            }
            MessageBox.Show(finalString);
            return finalString.Length;
        }
    }
}
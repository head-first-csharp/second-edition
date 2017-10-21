using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Swapping_elephants
{
    class Elephant
    {
        public int EarSize;
        public string Name;
        public void WhoAmI()
        {
            MessageBox.Show("My ears are " + EarSize + " inches tall.",
               Name + " says...");
        }


        /* Here are the TellMe() and SpeakTo() methods from p154 */

        public void TellMe(string message, Elephant whoSaidIt) {
            MessageBox.Show(whoSaidIt.Name + " says: " + message);
        }

        public void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.TellMe(message, this);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p278___TallGuy
{
    class TallGuy : IClown
    {
        public string Name;
        public int Height;

        public void TalkAboutYourself()
        {
            MessageBox.Show("My name is " + Name + " and I’m "
               + Height + " inches tall.");
        }

        public string FunnyThingIHave
        {
            get { return "big shoes"; }
        }

        public void Honk()
        {
            MessageBox.Show("Honk honk!");
        }
    }
}
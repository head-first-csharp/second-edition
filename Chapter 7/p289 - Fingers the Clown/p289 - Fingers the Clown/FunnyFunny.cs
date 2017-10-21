using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class FunnyFunny : IClown
    {
        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }
        private string funnyThingIHave;
        public string FunnyThingIHave
        {
            get { return "Honk honk! I have " + funnyThingIHave; }
        }

        public void Honk()
        {
            MessageBox.Show(this.FunnyThingIHave);
        }
    }
}
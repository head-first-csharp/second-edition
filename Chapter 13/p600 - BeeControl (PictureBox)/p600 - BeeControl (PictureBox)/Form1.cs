using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeeControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BeeControl control = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (control == null)
            {
                control = new BeeControl() { Location = new Point(100, 100) };
                Controls.Add(control);
            }
            else
            {
                using (control)
                {
                    Controls.Remove(control);
                }
                control = null;
            }
        }
    }
}

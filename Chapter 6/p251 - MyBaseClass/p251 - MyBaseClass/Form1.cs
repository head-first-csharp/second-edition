using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyBaseClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MyBaseClass("some string");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MySubclass("string for the base class", 12345);
        }
    }
}

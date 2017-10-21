using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CableBill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CableBill january = new CableBill(4);
            MessageBox.Show(january.CalculateAmount(7).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // CableBill february = new CableBill(7);
            // february.payPerViewDiscount = 1;   <-- This line won't compile!
            // MessageBox.Show(february.CalculateAmount(3).ToString());
            MessageBox.Show("won't compile");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CableBill march = new CableBill(9);
            march.Discount = true;
            MessageBox.Show(march.CalculateAmount(6).ToString());
        }
    }
}

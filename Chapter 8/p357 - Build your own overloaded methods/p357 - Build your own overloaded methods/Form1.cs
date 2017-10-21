using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p357___Build_your_own_overloaded_methods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Card cardToCheck = new Card(Suits.Clubs, Values.Three);
            bool doesItMatch = Card.DoesCardMatch(cardToCheck, Suits.Hearts);
            MessageBox.Show(doesItMatch.ToString());
        }
    }
}

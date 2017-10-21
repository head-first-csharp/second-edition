using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p538___Whack_a_mole
{
    public partial class Form1 : Form
    {
        Mole mole;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            mole = new Mole(random, new Mole.PopUp(MoleCallBack));
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            ToggleMole();
        }
        private void ToggleMole()
        {
            if (mole.Hidden == true)
                mole.Show();
            else
                mole.HideAgain();
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }
        private void MoleCallBack(int moleNumber, bool show)
        {
            if (moleNumber < 0)
            {
                timer1.Stop();
                return;
            }
            Button button;
            switch (moleNumber)
            {
                case 0: button = button1; break;
                case 1: button = button2; break;
                case 2: button = button3; break;
                case 3: button = button4; break;
                default: button = button5; break;
            }
            if (show == true)
            {
                button.Text = "HIT ME!";
                button.BackColor = Color.Red;
            }
            else
            {
                button.Text = "";
                button.BackColor = SystemColors.Control;
            }
            timer1.Interval = random.Next(500, 1000);
            timer1.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mole.Smacked(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            mole.Smacked(1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            mole.Smacked(2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            mole.Smacked(3);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            mole.Smacked(4);
        }
    }
}
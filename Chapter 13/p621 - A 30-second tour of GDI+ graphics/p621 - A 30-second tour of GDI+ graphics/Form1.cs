using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p621___A_30_second_tour_of_GDI__graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.DrawLine(Pens.Blue, 30, 10, 100, 45);
                g.DrawLine(Pens.Blue, new Point(30, 45), new Point(100, 10));
                g.FillRectangle(Brushes.SlateGray, new Rectangle(150, 15, 140, 90));
                g.DrawRectangle(Pens.SkyBlue, new Rectangle(150, 15, 140, 90));
                g.FillEllipse(Brushes.DarkGray, new Rectangle(45, 65, 200, 100));
                g.FillEllipse(Brushes.Silver, new Rectangle(40, 60, 200, 100));
                using (Font arial24Bold = new Font("Arial", 24, FontStyle.Bold))
                {
                    g.DrawString("Hi there!", arial24Bold, Brushes.Red, 50, 75);
                }
            }
        }
    }
}
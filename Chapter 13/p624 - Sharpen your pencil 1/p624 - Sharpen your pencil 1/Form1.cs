using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p624___Sharpen_your_pencil_1
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
            using (Font f = new Font("Arial", 6, FontStyle.Regular))
            {
                for (int x = 0; x < this.Width; x += 20)
                {
                    g.DrawLine(Pens.Black, x, 0, x, this.Height);
                    g.DrawString(x.ToString(), f, Brushes.Black, x, 0);
                }
                for (int y = 0; y < this.Height; y += 20)
                {
                    g.DrawLine(Pens.Black, 0, y, this.Width, y);
                    g.DrawString(y.ToString(), f, Brushes.Black, 0, y);
                }


                using (Pen pen =
             new Pen(Brushes.Black, 3.0F))
                {
                    g.DrawCurve(pen, new Point[] {
                      new Point(80, 60), 
                      new Point(200,40), 
                      new Point(180, 60), 
                      new Point(300,40),
                   });
                    g.DrawCurve(pen, new Point[] {
                      new Point(300,180), new Point(180, 200), 
                      new Point(200,180), new Point(80, 200),
                   });
                    g.DrawLine(pen, 300, 40, 300, 180);
                    g.DrawLine(pen, 80, 60, 80, 200);
                    g.DrawEllipse(pen, 40, 40, 20, 20);
                    g.DrawRectangle(pen, 40, 60, 20, 300);
                    g.DrawLine(pen, 60, 60, 80, 60);
                    g.DrawLine(pen, 60, 200, 80, 200);
                }
            }
        }
    }
}
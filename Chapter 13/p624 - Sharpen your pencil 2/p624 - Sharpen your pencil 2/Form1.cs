using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p624___Sharpen_your_pencil_2
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

                g.FillPolygon(Brushes.Black, new Point[] {
                        new Point(60,40), new Point(140,80), new Point(200,40),
                        new Point(300,80), new Point(380,60), new Point(340,140),
                        new Point(320,180), new Point(380,240), new Point(320,300),
                        new Point(340,340), new Point(240,320), new Point(180,340),
                        new Point(20,320), new Point(60, 280), new Point(100, 240), 
                        new Point(40, 220), new Point(80,160),
                    });

                using (Font big = new Font("Times New Roman", 24, FontStyle.Italic)) {
                    g.DrawString("Pow!", big, Brushes.White, new Point(80, 80));
                    g.DrawString("Pow!", big, Brushes.White, new Point(120, 120));
                    g.DrawString("Pow!", big, Brushes.White, new Point(160, 160));
                    g.DrawString("Pow!", big, Brushes.White, new Point(200, 200));
                    g.DrawString("Pow!", big, Brushes.White, new Point(240, 240));
                }
            }
        }
    }
}
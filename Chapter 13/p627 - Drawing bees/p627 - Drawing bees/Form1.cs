using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p627___Drawing_bees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DrawBee(Graphics g, Rectangle rect)
        {
            g.DrawImage(Properties.Resources.Bee_animation_1, rect);
        }

        // If we use the Click event instead of the Paint event, 
        // the picture doesn't "stick"
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = CreateGraphics())
            {
                g.DrawImage(Properties.Resources.Hive__inside_,
                        -Width, -Height, Width * 2, Height * 2);
                Size size = new Size(Width / 5, Height / 5);
                DrawBee(g, new Rectangle(
                         new Point(Width / 2 - 50, Height / 2 - 40), size));
                DrawBee(g, new Rectangle(
                         new Point(Width / 2 - 20, Height / 2 - 60), size));
                DrawBee(g, new Rectangle(
                         new Point(Width / 2 - 80, Height / 2 - 30), size));
                DrawBee(g, new Rectangle(
                         new Point(Width / 2 - 90, Height / 2 - 80), size));
            }
        }
    }
}
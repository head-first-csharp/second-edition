using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p618___Image_resizing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox beePicture = new PictureBox();
            beePicture.Location = new Point(10, 10);
            beePicture.Size = new Size(100, 100);
            beePicture.BorderStyle = BorderStyle.FixedSingle;
            beePicture.Image = Renderer.ResizeImage(
                 Properties.Resources.Bee_animation_1, 80, 40);
            Controls.Add(beePicture);
        }
    }
}

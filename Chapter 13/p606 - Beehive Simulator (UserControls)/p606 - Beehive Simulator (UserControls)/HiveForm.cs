using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeehiveSimulator
{
    public partial class HiveForm : Form
    {
        public HiveForm()
        {
            InitializeComponent();
            BackgroundImage = Renderer.ResizeImage(
                    Properties.Resources.Hive__inside_,
                    ClientRectangle.Width, ClientRectangle.Height);
        }

        private void HiveForm_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p297___PlanetMission
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object s, EventArgs e)
        {
            Mars mars = new Mars();
            MessageBox.Show(mars.FuelNeeded());
        }

        private void button2_Click(object s, EventArgs e)
        {
            Venus venus = new Venus();
            MessageBox.Show(venus.FuelNeeded());
        }

        // This will throw an exception, which is the whole point!
        private void button3_Click(object s, EventArgs e)
        {
            PlanetMission planet = new PlanetMission();
            MessageBox.Show(planet.FuelNeeded());
        }
    }
}

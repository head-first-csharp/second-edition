using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baseball
{
    public partial class Form1 : Form
    {
        Ball ball = new Ball();
        Pitcher pitcher;
        Fan fan;

        public Form1()
        {
            InitializeComponent();
            pitcher = new Pitcher(ball);
            fan = new Fan(ball);
        }

        private void playBallButton_Click(object sender, EventArgs e)
        {
            BallEventArgs ballEventArgs = new BallEventArgs(
                (int)trajectory.Value, (int)distance.Value);
            ball.OnBallInPlay(ballEventArgs);
        }
    }
}

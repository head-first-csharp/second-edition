using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeeControl
{
    class BeeControl : PictureBox
    {
        private Timer animationTimer = new Timer();
        public BeeControl()
        {
            animationTimer.Tick += new EventHandler(animationTimer_Tick);
            animationTimer.Interval = 150;
            animationTimer.Start();
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private int cell = 0;
        void animationTimer_Tick(object sender, EventArgs e)
        {
            cell++;
            switch (cell)
            {
                case 1: BackgroundImage = Properties.Resources.Bee_animation_1; break;
                case 2: BackgroundImage = Properties.Resources.Bee_animation_2; break;
                case 3: BackgroundImage = Properties.Resources.Bee_animation_3; break;
                case 4: BackgroundImage = Properties.Resources.Bee_animation_4; break;
                case 5: BackgroundImage = Properties.Resources.Bee_animation_3; break;
                default: BackgroundImage = Properties.Resources.Bee_animation_2;
                    cell = 0; break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                animationTimer.Dispose();
            }
        }
    }
}

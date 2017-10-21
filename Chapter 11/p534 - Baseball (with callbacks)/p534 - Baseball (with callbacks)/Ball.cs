using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baseball
{
    class Ball
    {
        public event EventHandler<BallEventArgs> BallInPlay;

        protected void OnBallInPlay(BallEventArgs e)
        {
            EventHandler<BallEventArgs> ballInPlay = BallInPlay;
            if (ballInPlay != null)
                ballInPlay(this, e);
        }

        public Bat GetNewBat()
        {
            return new Bat(new BatCallback(OnBallInPlay));
        }
    }
}

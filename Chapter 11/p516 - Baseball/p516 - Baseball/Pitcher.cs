using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baseball
{
    class Pitcher
    {
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += ball_BallInPlay;
        }

        void ball_BallInPlay(object sender, EventArgs e)
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
                    CatchBall();
                else
                    CoverFirstBase();
            }
        }

        private void CatchBall()
        {
            Console.WriteLine("Pitcher: I caught the ball");
        }

        private void CoverFirstBase()
        {
            Console.WriteLine("Pitcher: I covered first base");
        }
    }

}
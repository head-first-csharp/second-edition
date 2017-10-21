using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BeehiveSimulator
{
    public class Renderer
    {
        private World world;
        private HiveForm hiveForm;
        private FieldForm fieldForm;

        public Renderer(World TheWorld, HiveForm hiveForm, FieldForm fieldForm)
        {
            this.world = TheWorld;
            this.hiveForm = hiveForm;
            this.fieldForm = fieldForm;
            fieldForm.Renderer = this;
            hiveForm.Renderer = this;
            InitializeImages();
        }

        public static Bitmap ResizeImage(Image ImageToResize, int Width, int Height)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(ImageToResize, 0, 0, Width, Height);
            }
            return bitmap;
        }

        Bitmap HiveInside;
        Bitmap HiveOutside;
        Bitmap Flower;
        Bitmap[] BeeAnimationSmall;
        Bitmap[] BeeAnimationLarge;
        private void InitializeImages()
        {
            HiveOutside = ResizeImage(Properties.Resources.Hive__outside_, 85, 100);
            Flower = ResizeImage(Properties.Resources.Flower, 75, 75);
            HiveInside = ResizeImage(Properties.Resources.Hive__inside_,
                hiveForm.ClientRectangle.Width, hiveForm.ClientRectangle.Height);
            BeeAnimationLarge = new Bitmap[4];
            BeeAnimationLarge[0] = ResizeImage(Properties.Resources.Bee_animation_1, 40, 40);
            BeeAnimationLarge[1] = ResizeImage(Properties.Resources.Bee_animation_2, 40, 40);
            BeeAnimationLarge[2] = ResizeImage(Properties.Resources.Bee_animation_3, 40, 40);
            BeeAnimationLarge[3] = ResizeImage(Properties.Resources.Bee_animation_4, 40, 40);
            BeeAnimationSmall = new Bitmap[4];
            BeeAnimationSmall[0] = ResizeImage(Properties.Resources.Bee_animation_1, 20, 20);
            BeeAnimationSmall[1] = ResizeImage(Properties.Resources.Bee_animation_2, 20, 20);
            BeeAnimationSmall[2] = ResizeImage(Properties.Resources.Bee_animation_3, 20, 20);
            BeeAnimationSmall[3] = ResizeImage(Properties.Resources.Bee_animation_4, 20, 20);
        }

        public void PaintHive(Graphics g)
        {
            g.FillRectangle(Brushes.SkyBlue, hiveForm.ClientRectangle);
            g.DrawImageUnscaled(HiveInside, 0, 0);
            foreach (Bee bee in world.Bees)
            {
                if (bee.InsideHive)
                    g.DrawImageUnscaled(BeeAnimationLarge[cell],
                                        bee.Location.X, bee.Location.Y);
            }
        }

        public void PaintField(Graphics g)
        {
            using (Pen brownPen = new Pen(Color.Brown, 6.0F))
            {
                g.FillRectangle(Brushes.SkyBlue, 0, 0,
                         fieldForm.ClientSize.Width, fieldForm.ClientSize.Height / 2);
                g.FillEllipse(Brushes.Yellow, new RectangleF(50, 15, 70, 70));
                g.FillRectangle(Brushes.Green, 0, fieldForm.ClientSize.Height / 2,
                         fieldForm.ClientSize.Width, fieldForm.ClientSize.Height / 2);
                g.DrawLine(brownPen, new Point(593, 0), new Point(593, 30));
                g.DrawImageUnscaled(HiveOutside, 550, 20);
                foreach (Flower flower in world.Flowers)
                {
                    g.DrawImageUnscaled(Flower, flower.Location.X, flower.Location.Y);
                }
                foreach (Bee bee in world.Bees)
                {
                    if (!bee.InsideHive)
                        g.DrawImageUnscaled(BeeAnimationSmall[cell],
                                            bee.Location.X, bee.Location.Y);
                }
            }
        }

        private int cell = 0;
        private int frame = 0;
        public void AnimateBees()
        {
            frame++;
            if (frame >= 6)
                frame = 0;
            switch (frame)
            {
                case 0: cell = 0; break;
                case 1: cell = 1; break;
                case 2: cell = 2; break;
                case 3: cell = 3; break;
                case 4: cell = 2; break;
                case 5: cell = 1; break;
                default: cell = 0; break;
            }
            hiveForm.Invalidate();
            fieldForm.Invalidate();
        }

    }
}
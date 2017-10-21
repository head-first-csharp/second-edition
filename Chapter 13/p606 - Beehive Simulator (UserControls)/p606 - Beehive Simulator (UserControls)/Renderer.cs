using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BeehiveSimulator
{
    class Renderer
    {
        private World world;
        private HiveForm hiveForm;
        private FieldForm fieldForm;

        private Dictionary<Flower, PictureBox> flowerLookup =
             new Dictionary<Flower, PictureBox>();
        private List<Flower> deadFlowers = new List<Flower>();

        private Dictionary<Bee, BeeControl> beeLookup =
             new Dictionary<Bee, BeeControl>();
        private List<Bee> retiredBees = new List<Bee>();

        public Renderer(World world, HiveForm hiveForm, FieldForm fieldForm)
        {
            this.world = world;
            this.hiveForm = hiveForm;
            this.fieldForm = fieldForm;
        }

        public void Render()
        {
            DrawBees();
            DrawFlowers();
            RemoveRetiredBeesAndDeadFlowers();
        }

        public void Reset()
        {
            foreach (PictureBox flower in flowerLookup.Values)
            {
                fieldForm.Controls.Remove(flower);
                flower.Dispose();
            }
            foreach (BeeControl bee in beeLookup.Values)
            {
                hiveForm.Controls.Remove(bee);
                fieldForm.Controls.Remove(bee);
                bee.Dispose();
            }
            flowerLookup.Clear();
            beeLookup.Clear();
        }

        private void DrawFlowers()
        {
            foreach (Flower flower in world.Flowers)
                if (!flowerLookup.ContainsKey(flower))
                {
                    PictureBox flowerControl = new PictureBox()
                    {
                        Width = 45,
                        Height = 55,
                        Image = Properties.Resources.Flower,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = flower.Location
                    };
                    flowerLookup.Add(flower, flowerControl);
                    fieldForm.Controls.Add(flowerControl);
                }

            foreach (Flower flower in flowerLookup.Keys)
            {
                if (!world.Flowers.Contains(flower))
                {
                    PictureBox flowerControlToRemove = flowerLookup[flower];
                    fieldForm.Controls.Remove(flowerControlToRemove);
                    flowerControlToRemove.Dispose();
                    deadFlowers.Add(flower);
                }
            }
        }

        private void DrawBees()
        {
            BeeControl beeControl;
            foreach (Bee bee in world.Bees)
            {
                beeControl = GetBeeControl(bee);
                if (bee.InsideHive)
                {
                    if (fieldForm.Controls.Contains(beeControl))
                        MoveBeeFromFieldToHive(beeControl);
                }
                else if (hiveForm.Controls.Contains(beeControl))
                    MoveBeeFromHiveToField(beeControl);
                beeControl.Location = bee.Location;
            }

            foreach (Bee bee in beeLookup.Keys)
            {
                if (!world.Bees.Contains(bee))
                {
                    beeControl = beeLookup[bee];
                    if (fieldForm.Controls.Contains(beeControl))
                        fieldForm.Controls.Remove(beeControl);
                    if (hiveForm.Controls.Contains(beeControl))
                        hiveForm.Controls.Remove(beeControl);
                    beeControl.Dispose();
                    retiredBees.Add(bee);
                }
            }
        }

        private BeeControl GetBeeControl(Bee bee)
        {
            BeeControl beeControl;
            if (!beeLookup.ContainsKey(bee))
            {
                beeControl = new BeeControl() { Width = 40, Height = 40 };
                beeLookup.Add(bee, beeControl);
                hiveForm.Controls.Add(beeControl);
                beeControl.BringToFront();
            }
            else
                beeControl = beeLookup[bee];
            return beeControl;
        }


        private void MoveBeeFromHiveToField(BeeControl beeControl)
        {
            hiveForm.Controls.Remove(beeControl);
            beeControl.Size = new Size(20, 20);
            fieldForm.Controls.Add(beeControl);
            beeControl.BringToFront();
        }


        private void MoveBeeFromFieldToHive(BeeControl beeControl)
        {
            fieldForm.Controls.Remove(beeControl);
            beeControl.Size = new Size(40, 40);
            hiveForm.Controls.Add(beeControl);
            beeControl.BringToFront();
        }


        private void RemoveRetiredBeesAndDeadFlowers()
        {
            foreach (Bee bee in retiredBees)
                beeLookup.Remove(bee);
            retiredBees.Clear();
            foreach (Flower flower in deadFlowers)
                flowerLookup.Remove(flower);
            deadFlowers.Clear();
        }

        public static Bitmap ResizeImage(Bitmap picture, int width, int height)
        {
            Bitmap resizedPicture = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedPicture))
            {
                graphics.DrawImage(picture, 0, 0, width, height);
            }
            return resizedPicture;
        }
    }
}
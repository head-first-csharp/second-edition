using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Printing;

namespace BeehiveSimulator
{
    public partial class Form1 : Form
    {
        private HiveForm hiveForm = new HiveForm();
        private FieldForm fieldForm = new FieldForm();
        private Renderer renderer;
        private World world;
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;

        public Form1()
        {
            InitializeComponent();

            MoveChildForms();
            hiveForm.Show(this);
            fieldForm.Show(this);
            ResetSimulator();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());
        }

        private void UpdateStats(TimeSpan frameDuration)
        {
            Bees.Text = world.Bees.Count.ToString();
            Flowers.Text = world.Flowers.Count.ToString();
            HoneyInHive.Text = String.Format("{0:f3}", world.Hive.Honey);
            double nectar = 0;
            foreach (Flower flower in world.Flowers)
                nectar += flower.Nectar;
            NectarInFlowers.Text = String.Format("{0:f3}", nectar);
            FramesRun.Text = framesRun.ToString();
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
                FrameRate.Text = string.Format("{0:f0} ({1:f1}ms)",
                                         1000 / milliSeconds, milliSeconds);
            else
                FrameRate.Text = "N/A";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
        private void toggleEnabled_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }
        private void startTimer_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Console.WriteLine("Enabled = " + timer1.Enabled);
        }
        private void stopTimer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Console.WriteLine("Enabled = " + timer1.Enabled);
        }

        public void RunFrame(object sender, EventArgs e)
        {
            framesRun++;
            world.Go(random);
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateStats(frameDuration);
            hiveForm.Invalidate();
            fieldForm.Invalidate();
        }

        private void startSimulation_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                toolStrip1.Items[0].Text = "Resume simulation";
                timer1.Stop();
            }
            else
            {
                toolStrip1.Items[0].Text = "Pause simulation";
                timer1.Start();
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            ResetSimulator();
            if (!timer1.Enabled)
                toolStrip1.Items[0].Text = "Start simulation";
        }


        private void SendMessage(int ID, string Message)
        {
            statusStrip1.Items[0].Text = "Bee #" + ID + ": " + Message;
            var beeGroups =
              from bee in world.Bees
              group bee by bee.CurrentState into beeGroup
              orderby beeGroup.Key
              select beeGroup;
            listBox1.Items.Clear();
            foreach (var group in beeGroups)
            {
                string s;
                if (group.Count() == 1)
                    s = "";
                else
                    s = "s";
                listBox1.Items.Add(group.Key.ToString() + ": "
                                 + group.Count() + " bee" + s);
                if (group.Key == BeeState.Idle
                 && group.Count() == world.Bees.Count()
                 && framesRun > 0)
                {
                    listBox1.Items.Add("Simulation ended: all bees are idle");
                    toolStrip1.Items[0].Text = "Simulation ended";
                    statusStrip1.Items[0].Text = "Simulation ended";
                    timer1.Enabled = false;
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Simulator File (*.bees)|*.bees";
            saveDialog.CheckPathExists = true;
            saveDialog.Title = "Choose a file to save the current simulation";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream output = File.OpenWrite(saveDialog.FileName))
                    {
                        bf.Serialize(output, world);
                        bf.Serialize(output, framesRun);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save the simulator file\r\n" + ex.Message,
                      "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (enabled)
                timer1.Start();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            World currentWorld = world;
            int currentFramesRun = framesRun;

            bool enabled = timer1.Enabled;
            if (enabled)
                timer1.Stop();

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Simulator File (*.bees)|*.bees";
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;
            openDialog.Title = "Choose a file with a simulation to load";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream input = File.OpenRead(openDialog.FileName))
                    {
                        world = (World)bf.Deserialize(input);
                        framesRun = (int)bf.Deserialize(input);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to read the simulator file\r\n" + ex.Message,
                    "Bee Simulator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    world = currentWorld;
                    framesRun = currentFramesRun;
                }
            }

            world.Hive.MessageSender = new BeeMessage(SendMessage);
            foreach (Bee bee in world.Bees)
                bee.MessageSender = new BeeMessage(SendMessage);
            if (enabled)
                timer1.Start();

            renderer = new Renderer(world, hiveForm, fieldForm);
        }

        private void MoveChildForms()
        {
            hiveForm.Location = new Point(Location.X + Width + 10, Location.Y);
            fieldForm.Location = new Point(Location.X,
              Location.Y + Math.Max(Height, hiveForm.Height) + 10);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            MoveChildForms();
        }

        private void ResetSimulator()
        {
            framesRun = 0;
            world = new World(new BeeMessage(SendMessage));
            renderer = new Renderer(world, hiveForm, fieldForm);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            renderer.AnimateBees();
        }

        private void printToolStripButton1_Click(object sender, EventArgs e)
        {
            bool stoppedTimer = false;
            if (timer1.Enabled)
            {
                timer1.Stop();
                stoppedTimer = true;
            }
            PrintPreviewDialog preview = new PrintPreviewDialog();
            PrintDocument document = new PrintDocument();
            preview.Document = document;
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            preview.ShowDialog(this);
            if (stoppedTimer)
                timer1.Start();
        }

        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Size stringSize;
            using (Font arial24bold = new Font("Arial", 24, FontStyle.Bold))
            {
                stringSize = Size.Ceiling(
                      g.MeasureString("Bee Simulator", arial24bold));
                g.FillEllipse(Brushes.Gray,
                    new Rectangle(e.MarginBounds.X + 2, e.MarginBounds.Y + 2,
                    stringSize.Width + 30, stringSize.Height + 30));
                g.FillEllipse(Brushes.Black,
                    new Rectangle(e.MarginBounds.X, e.MarginBounds.Y,
                    stringSize.Width + 30, stringSize.Height + 30));
                g.DrawString("Bee Simulator", arial24bold,
                    Brushes.Gray, e.MarginBounds.X + 17, e.MarginBounds.Y + 17);
                g.DrawString("Bee Simulator", arial24bold,
                    Brushes.White, e.MarginBounds.X + 15, e.MarginBounds.Y + 15);
            }

            int tableX = e.MarginBounds.X + (int)stringSize.Width + 50;
            int tableWidth = e.MarginBounds.X + e.MarginBounds.Width - tableX - 20;
            int firstColumnX = tableX + 2;
            int secondColumnX = tableX + (tableWidth / 2) + 5;
            int tableY = e.MarginBounds.Y;

            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX,
                 secondColumnX, tableY, "Bees", Bees.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX,
                 secondColumnX, tableY, "Flowers", Flowers.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX,
                  secondColumnX, tableY, "Honey in Hive", HoneyInHive.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX,
                 secondColumnX, tableY, "Nectar in Flowers", NectarInFlowers.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX,
                 secondColumnX, tableY, "Frames Run", FramesRun.Text);
            tableY = PrintTableRow(g, tableX, tableWidth, firstColumnX,
                 secondColumnX, tableY, "Frame Rate", FrameRate.Text);

            g.DrawRectangle(Pens.Black, tableX, e.MarginBounds.Y,
                 tableWidth, tableY - e.MarginBounds.Y);
            g.DrawLine(Pens.Black, secondColumnX, e.MarginBounds.Y,
                 secondColumnX, tableY);

            using (Pen blackPen = new Pen(Brushes.Black, 2))
            using (Bitmap hiveBitmap = new Bitmap(hiveForm.ClientSize.Width,
                                                  hiveForm.ClientSize.Height))
            using (Bitmap fieldBitmap = new Bitmap(fieldForm.ClientSize.Width,
                                                  fieldForm.ClientSize.Height))
            {
                using (Graphics hiveGraphics = Graphics.FromImage(hiveBitmap))
                {
                    renderer.PaintHive(hiveGraphics);
                }

                int hiveWidth = e.MarginBounds.Width / 2;
                float ratio = (float)hiveBitmap.Height / (float)hiveBitmap.Width;
                int hiveHeight = (int)(hiveWidth * ratio);
                int hiveX = e.MarginBounds.X + (e.MarginBounds.Width - hiveWidth) / 2;
                int hiveY = e.MarginBounds.Height / 3;
                g.DrawImage(hiveBitmap, hiveX, hiveY, hiveWidth, hiveHeight);
                g.DrawRectangle(blackPen, hiveX, hiveY, hiveWidth, hiveHeight);

                using (Graphics fieldGraphics = Graphics.FromImage(fieldBitmap))
                {
                    renderer.PaintField(fieldGraphics);
                }
                int fieldWidth = e.MarginBounds.Width;
                ratio = (float)fieldBitmap.Height / (float)fieldBitmap.Width;
                int fieldHeight = (int)(fieldWidth * ratio);
                int fieldX = e.MarginBounds.X;
                int fieldY = e.MarginBounds.Y + e.MarginBounds.Height - fieldHeight;
                g.DrawImage(fieldBitmap, fieldX, fieldY, fieldWidth, fieldHeight);
                g.DrawRectangle(blackPen, fieldX, fieldY, fieldWidth, fieldHeight);
            }
        }

        private int PrintTableRow(Graphics printGraphics, int tableX,
                 int tableWidth, int firstColumnX, int secondColumnX,
                 int tableY, string firstColumn, string secondColumn)
        {
            Font arial12 = new Font("Arial", 12);
            Size stringSize = Size.Ceiling(printGraphics.MeasureString(firstColumn, arial12));
            tableY += 2;
            printGraphics.DrawString(firstColumn, arial12, Brushes.Black,
                           firstColumnX, tableY);
            printGraphics.DrawString(secondColumn, arial12, Brushes.Black,
                           secondColumnX, tableY);
            tableY += (int)stringSize.Height + 2;
            printGraphics.DrawLine(Pens.Black, tableX, tableY, tableX + tableWidth, tableY);
            arial12.Dispose();
            return tableY;
        }
    }
}
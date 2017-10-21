using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace p381___Breakfast_for_Lumberjacks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();

        private void addLumberjack_Click(object sender, EventArgs e)
        {
            breakfastLine.Enqueue(new Lumberjack(name.Text));
            name.Text = "";
            RedrawList();
        }

        private void RedrawList()
        {
            int number = 1;
            line.Items.Clear();
            foreach (Lumberjack lumberjack in breakfastLine)
            {
                line.Items.Add(number + ". " + lumberjack.Name);
                number++;
            }
            if (breakfastLine.Count == 0)
            {
                groupBox1.Enabled = false;
                nextInLine.Text = "";
            }
            else
            {
                groupBox1.Enabled = true;
                Lumberjack currentLumberjack = breakfastLine.Peek();
                nextInLine.Text = currentLumberjack.Name + " has "
                    + currentLumberjack.FlapjackCount + " flapjacks";
            }
        }

        private void nextLumberjack_Click(object sender, EventArgs e)
        {
            Lumberjack nextLumberjack = breakfastLine.Dequeue();
            nextLumberjack.EatFlapjacks();
            nextInLine.Text = "";
            RedrawList();
        }

        private void addFlapjacks_Click(object sender, EventArgs e)
        {
            Flapjack food;
            if (crispy.Checked == true)
                food = Flapjack.Crispy;
            else if (soggy.Checked == true)
                food = Flapjack.Soggy;
            else if (browned.Checked == true)
                food = Flapjack.Browned;
            else
                food = Flapjack.Banana;

            Lumberjack currentLumberjack = breakfastLine.Peek();
            currentLumberjack.TakeFlapjacks(food,
                             (int)howMany.Value);
            RedrawList();
        }
    }
}
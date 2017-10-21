using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Familiar_math_symbols
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Here's a great way to use the IDE to see how this code works! 
            //
            // First, create a new project in the IDE add a button. Next, double-click on the 
            // button so the IDE adds a button1_Click method to your program. Fill in that 
            // method with all of the code, starting with "int number = 15;".
            //
            // Now put a breakpoint on the first line by right-clicking on it and choosing 
            // "Breakpoint >> Insert Breakpoint". The line should turn red.
            //
            // Next, start debugging your program. You'll see it break on the line where you 
            // inserted the breakpoint. Your program's just paused! If you click the Run 
            // toolbar button (or hit F5), it will continue. Right-click on "number" and 
            // choose "Expression: 'number' >> Add Watch" from the menu. The bottom panel in 
            // the IDE should change to the Watches window, and there should be a line in that 
            // window for "number". Step through the program line by line using Step Over (F10).
            // You can see the value of the "number" variable change as you go!
            // 
            // Do the same for the count, result, yesNo, and anotherBool variables.                                       

            int number = 15;
            number = number + 10;
            number = 36 * 15;
            number = 12 - (42 / 7);
            number += 10;
            number *= 3;
            number = 71 / 3;

            int count = 0;
            count++;
            count--;

            string result = "hello";
            result += " again " + result;
            MessageBox.Show(result);
            result = "the value is: " + count;
            result = "";

            bool yesNo = false;
            bool anotherBool = true;
            yesNo = !anotherBool;
        }
    }
}

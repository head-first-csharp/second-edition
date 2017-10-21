using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace p621___A_30_second_tour_of_GDI__graphics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

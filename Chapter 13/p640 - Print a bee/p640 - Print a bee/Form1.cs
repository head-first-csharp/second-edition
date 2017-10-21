using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace p640___Print_a_bee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = document;
            preview.ShowDialog(this);
        }

        bool firstPage = true;
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            DrawBee(e.Graphics, new Rectangle(0, 0, 300, 300));
            using (Font font = new Font("Arial", 36, FontStyle.Bold))
            {
                if (firstPage)
                {
                    e.Graphics.DrawString("First page", Font, Brushes.Black, 0, 0);
                    e.HasMorePages = true;
                    firstPage = false;
                }
                else
                {
                    e.Graphics.DrawString("Second page", Font, Brushes.Black, 0, 0);
                    firstPage = true;
                }
            }
        }

        public void DrawBee(Graphics g, Rectangle rect)
        {
            g.DrawImage(Properties.Resources.Bee_animation_1, rect);
        }
    }
}
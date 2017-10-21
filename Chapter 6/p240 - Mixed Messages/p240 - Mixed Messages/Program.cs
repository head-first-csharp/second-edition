using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p240___Mixed_Messages
{
    class Program
    {
        public static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            A a2 = new C();
            string q = "";


            // Code candidates

            q += b.m1();
            q += c.m2();
            q += a.m3();
            System.Windows.Forms.MessageBox.Show(q);

            q = ""; // Reset q for the next code candidate

            q += c.m1();
            q += c.m2();
            q += c.m3();
            System.Windows.Forms.MessageBox.Show(q);

            q = ""; // Reset q for the next code candidate

            q += a.m1();
            q += b.m2();
            q += c.m3();
            System.Windows.Forms.MessageBox.Show(q);

            q = ""; // Reset q for the next code candidate

            q += a2.m1();
            q += a2.m2();
            q += a2.m3();
            System.Windows.Forms.MessageBox.Show(q);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace p415___Reading_and_writing_using_two_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            // It’s probably not a good idea to write to your root folder, and your OS
            // might not even let you do it. So we picked another directory to write to. 
            StreamReader reader =
               new StreamReader(@"c:\temp\secret_plan.txt");
            StreamWriter writer =
               new StreamWriter(@"c:\temp\emailToCaptainAmazing.txt");


            writer.WriteLine("To: CaptainAmazing@objectville.net");
            writer.WriteLine("From: Commissioner@objectiville.net");
            writer.WriteLine("Subject: Can you save the day... again?");
            writer.WriteLine();
            writer.WriteLine("We’ve discovered the Swindler’s plan:");
            while (!reader.EndOfStream)
            {
                string lineFromThePlan = reader.ReadLine();
                writer.WriteLine("The plan -> " + lineFromThePlan);
            }
            writer.WriteLine();
            writer.WriteLine("Can you help us?");
            writer.Close();
            reader.Close();
        }
    }
}
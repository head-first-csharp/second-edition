using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace p435___Body_Parts
{
    class Program
    {
        enum BodyPart
        {
            Head,
            Shoulders,
            Knees,
            Toes,
        }

        private void WritePartInfo(BodyPart part, StreamWriter writer)
        {
            switch (part)
            {
                case BodyPart.Head:
                    writer.WriteLine("the head is hairy");
                    break;
                case BodyPart.Shoulders:
                    writer.WriteLine("the shoulders are broad");
                    break;
                case BodyPart.Knees:
                    writer.WriteLine("the knees are knobby");
                    break;
                case BodyPart.Toes:
                    writer.WriteLine("the toes are teeny");
                    break;
                default:
                    writer.WriteLine("some unknown part is unknown");
                    break;
            }
        }

        // We added a simple Main() method to write some body parts
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("bodyparts.txt"))
            {
                new Program().WritePartInfo(BodyPart.Head, writer);
                new Program().WritePartInfo(BodyPart.Shoulders, writer);
                new Program().WritePartInfo(BodyPart.Knees, writer);
                new Program().WritePartInfo(BodyPart.Toes, writer);
            }
        }
    }
}
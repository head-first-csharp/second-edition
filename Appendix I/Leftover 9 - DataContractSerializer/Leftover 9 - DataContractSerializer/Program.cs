using System;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace Leftover_9___DataContractSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Data contract serialization typically reads and writes XML data. You use a
             * DataContractSerializer object for data contract serialization. Its 
             * WriteObject() method can write to a stream, or it can write to an object that
             * extends XmlDictionaryWriter, an abstract class that controls XML output and 
             * can be extended to change the way the XML output is written. Objects are
             * deserialized using the ReadObject() method, which can read XML data from
             * a stream or an XmlDictionaryReader.
             */
            DataContractSerializer serializer = new DataContractSerializer(typeof(SerializableGuy));

            // We’ll create a new SerializableGuy object and serialize it using a FileStream.
            SerializableGuy guyToWrite = new SerializableGuy("Joe", 37, 150);
            using (FileStream writer = new FileStream("serialized_guy.xml", FileMode.Create))
            {
                serializer.WriteObject(writer, guyToWrite);
            }

            // We can open the file we just wrote and deserialize it into a new guy using ReadObject().
            // We’ll use the XmlDictionaryReader.CreateTextReader() method to create an object that
            // reads XML data from a stream. 
            SerializableGuy guyToRead = null;
            using (FileStream inputStream = new FileStream("serialized_guy.xml", FileMode.Open))
            using (XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(inputStream, new XmlDictionaryReaderQuotas()))
            {
                guyToRead = serializer.ReadObject(reader, true) as SerializableGuy;
            }
            Console.WriteLine(guyToRead);
            // Output: Joe is 37 years old and has 150 bucks [1461194451,0]


            string xmlGuy = @"
<Guy xmlns=""http://www.headfirstlabs.com"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
   <Age>43</Age> 
   <Cash>225</Cash> 
   <Name>Bob</Name> 
   <secretNumberOne>54321</secretNumberOne>
</Guy>";
            byte[] buffer = UnicodeEncoding.UTF8.GetBytes(xmlGuy);

            using (XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(buffer, new XmlDictionaryReaderQuotas()))
            {
                guyToRead = serializer.ReadObject(reader, true) as SerializableGuy;
            }
            Console.WriteLine(guyToRead);
            // Output: Bob is 43 years old and has 225 bucks [54321,0]

            Console.ReadKey();
        }
    }
}
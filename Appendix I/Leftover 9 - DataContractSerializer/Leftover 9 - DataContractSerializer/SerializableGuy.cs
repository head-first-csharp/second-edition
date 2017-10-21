using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Leftover_9___DataContractSerializer
{
    /* Before you can serialize an object using the Data Contract Serializer, you need
     * to set up a data contract. The easiest way to do this is by marking the class with
     * the [Serializable] attribute. By default, the DataContractSerializer will write all
     * public read/write properties and fields. But what’s really useful about the Data 
     * Contract Serializer is that you can be a lot more specific about exactly what does
     * and doesn’t get serialized. You can associate data with this particular class by 
     * giving the contact a name and a namespace using named parameters.
     */
    [DataContract(Name = "Guy", Namespace = "http://www.headfirstlabs.com")]
    class SerializableGuy
    {
        // When you set up a specific data contract for a type -- like our
        // Guy class -- you mark each field or property that you want to
        // serialize with the [DataMember] attribute.
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public int Age { get; private set; }
        [DataMember]
        public int Cash { get; private set; }

        // You can decide what members you want to serialize. We added two private int fields
        // called secretNumberOne and secretNumberTwo to our SerliazableGuy and initialized
        // them both to random numbers. secretNumberOne is marked with the [DataMember] 
        // attribute, so it will be serialized as part of the data contract. But we didn’t 
        // mark secretNumberTwo, so it won’t be. They’re both returned as part of ToString(). 
        [DataMember]
        private int secretNumberOne = new Random().Next();
        // Since the secretNumberTwo field isn’t marked with the [DataMember]
        // attribute, it’s not part of the contract and won’t be serialized.
        private int secretNumberTwo = new Random().Next();

        public SerializableGuy(string name, int age, int cash)
        {
            Name = name;
            Age = age;
            Cash = cash;
        }

        public override string ToString()
        {
            return String.Format("{0} is {1} years old and has {2} bucks [{3},{4}]",
                Name, Age, Cash, secretNumberOne, secretNumberTwo);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p694___LINQ_is_versatile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Modify every item returned from the query\n");

            string[] sandwiches = { "ham and cheese", "salami with mayo", 
                        "turkey and swiss", "chicken cutlet" };
            var sandwichesOnRye =
                from sandwich in sandwiches
                select sandwich + " on rye";

            foreach (var sandwich in sandwichesOnRye)
                Console.WriteLine(sandwich);


            Console.WriteLine("\nPerform calculations on collectons\n");

            Random random = new Random();
            List<int> listOfNumbers = new List<int>();
            int length = random.Next(50, 150);
            for (int i = 0; i < length; i++)
                listOfNumbers.Add(random.Next(100));

            Console.WriteLine("There are {0} numbers",
                                  listOfNumbers.Count());
            Console.WriteLine("The smallest is {0}",
                                  listOfNumbers.Min());
            Console.WriteLine("The biggest is {0}",
                                  listOfNumbers.Max());
            Console.WriteLine("The sum is {0}",
                                  listOfNumbers.Sum());
            Console.WriteLine("The average is {0:F2}",
                                  listOfNumbers.Average());


            Console.WriteLine("\nStore all or part of your results in a new sequence\n");

            var under50sorted =
              from number in listOfNumbers
              where number < 50
              orderby number descending
              select number;

            List<int> newList = under50sorted.ToList();

            var firstFive = under50sorted.Take(6);

            List<int> shortList = firstFive.ToList();
            foreach (int n in shortList)
                Console.WriteLine(n);

            Console.ReadKey();
        }
    }
}
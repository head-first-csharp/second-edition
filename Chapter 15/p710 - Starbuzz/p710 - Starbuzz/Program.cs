using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p710___Starbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<StarbuzzData> starbuzzList = GetStarbuzzData();

            string connectionString =
                 "Data Source=|DataDirectory|\\ContactDB.sdf";
            ContactDB context = new ContactDB(connectionString);

            var results =
               from starbuzzCustomer in starbuzzList
               where starbuzzCustomer.MoneySpent > 90
               join person in context.People
               on starbuzzCustomer.Name equals person.Name
               select new
               {
                   person.Name,
                   person.Company,
                   starbuzzCustomer.FavoriteDrink
               };

            foreach (var row in results)
                Console.WriteLine("{0} at {1} likes {2}",
                           row.Name, row.Company, row.FavoriteDrink);

            Console.ReadKey();
        }

        static IEnumerable<StarbuzzData> GetStarbuzzData()
        {
            return new List<StarbuzzData> {
                new StarbuzzData {
                    Name = "Janet Venutian", FavoriteDrink = Drink.ChocoMacchiato,
                    MoneySpent = 255, Visits = 50 },
                new StarbuzzData {
                    Name = "Liz Nelson", FavoriteDrink = Drink.DoubleCappuccino,
                    MoneySpent = 150, Visits = 35 },
                new StarbuzzData {
                    Name = "Matt Franks", FavoriteDrink = Drink.ZestyLemonChai,
                    MoneySpent = 75, Visits = 15 },
                new StarbuzzData {
                    Name = "Joe Ng", FavoriteDrink = Drink.BananaSplitInACup,
                    MoneySpent = 60, Visits = 10 },
                new StarbuzzData {
                    Name = "Sarah Kalter", FavoriteDrink = Drink.BoringCoffee,
                    MoneySpent = 110, Visits = 15 }
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JimmysComics
{
    class Program
    {
        private static IEnumerable<Comic> BuildCatalog()
        {
            return new List<Comic> {
                new Comic { Name = "Johnny America vs. the Pinko", Issue = 6 },
                new Comic { Name = "Rock and Roll (limited edition)", Issue = 19 },
                new Comic { Name = "Woman’s Work", Issue = 36 },
                new Comic { Name = "Hippie Madness (misprinted)", Issue = 57 },
                new Comic { Name = "Revenge of the New Wave Freak (damaged)", Issue = 68 },
                new Comic { Name = "Black Monday", Issue = 74 },
                new Comic { Name = "Tribal Tattoo Madness", Issue = 83 },
                new Comic { Name = "The Death of an Object", Issue = 97 },
            };
        }

        private static Dictionary<int, decimal> GetPrices()
        {
            return new Dictionary<int, decimal> {
                { 6, 3600M },
                { 19, 500M },
                { 36, 650M },
                { 57, 13525M },
                { 68, 250M },
                { 74, 75M },
                { 83, 25.75M },
                { 97, 35.25M },
            };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Running the queries on pages 690 to 692...\n");

            IEnumerable<Comic> comics = BuildCatalog();
            Dictionary<int, decimal> values = GetPrices();

            var mostExpensive =
                from comic in comics
                where values[comic.Issue] > 500
                orderby values[comic.Issue] descending
                select comic;

            foreach (Comic comic in mostExpensive)
                Console.WriteLine("{0} is worth {1:c}",
                                  comic.Name, values[comic.Issue]);

            Console.WriteLine("\nRunning the queries on pages 699 to 700...\n");

            var priceGroups =
                from pair in values
                group pair.Key by EvaluatePrice(pair.Value)
                    into priceGroup
                    orderby priceGroup.Key descending
                    select priceGroup;

            foreach (var group in priceGroups)
            {
                Console.Write("I found {0} {1} comics: issues ", group.Count(), group.Key);
                foreach (var price in group)
                    Console.Write(price.ToString() + " ");
                Console.WriteLine();
            }


            Console.WriteLine("\nRunning the queries on pages 703 to 704...\n");

            IEnumerable<Purchase> purchases = FindPurchases();

            var results =
                from comic in comics
                join purchase in purchases
                on comic.Issue equals purchase.Issue
                orderby comic.Issue ascending
                select new { comic.Name, comic.Issue, purchase.Price };

            decimal gregsListValue = 0;
            decimal totalSpent = 0;
            foreach (var result in results)
            {
                gregsListValue += values[result.Issue];
                totalSpent += result.Price;
                Console.WriteLine("Issue #{0} ({1}) bought for {2:c}",
                         result.Issue, result.Name, result.Price);
            }
            Console.WriteLine("I spent {0:c} on comics worth {1:c}",
                         totalSpent, gregsListValue);

            Console.ReadKey();
        }

        static PriceRange EvaluatePrice(decimal price)
        {
            if (price < 100M) return PriceRange.Cheap;
            else if (price < 1000M) return PriceRange.Midrange;
            else return PriceRange.Expensive;
        }

        static IEnumerable<Purchase> FindPurchases()
        {
            List<Purchase> purchases = new List<Purchase>() {
                new Purchase() { Issue = 68, Price = 225M },
                new Purchase() { Issue = 19, Price = 375M },
                new Purchase() { Issue = 6, Price = 3600M },
                new Purchase() { Issue = 57, Price = 13215M },
                new Purchase() { Issue = 36, Price = 660M },
            };
            return purchases;
        }

    }
}
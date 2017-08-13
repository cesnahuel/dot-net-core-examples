using System;
using System.Linq;


namespace DotNetCore.SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var db = new DataStoreContext())
            {
                // Populate Distributors DB
                DataStore.distributors.ForEach(dist => {
                    db.Distributors.Add(dist);
                });
                var count = db.SaveChanges();
                Console.WriteLine($"{count} distributor records saved to database");

                Console.WriteLine();
                Console.WriteLine("show all distributors in database:");
                foreach (var dist in db.Distributors)
                {
                    Console.WriteLine($" - {dist.Name}");
                }

                DataStore.customers.ForEach(cust => {
                    db.Customers.Add(cust);
                });
                count = db.SaveChanges();
                Console.WriteLine($"{count} customer records saved to database");

                Console.WriteLine();
                Console.WriteLine("show all customers in database:");
                foreach (var cust in db.Customers)
                {
                    Console.WriteLine($" - {cust.First} {cust.Last}");
                }

                Console.WriteLine();
                Console.WriteLine("show custom LINQ que in database:");
                var custPurQuery =
                    from c in db.Customers
                    from p in c.Purchases
                    select new { Name = c.Last, Purchase = p.Item };

                foreach (var cust in custPurQuery)
                {
                    Console.WriteLine($"{cust.Name}, {cust.Purchase}");
                }
            }
        }
    }
}

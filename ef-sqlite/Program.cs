using System;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCore.SQLite
{
    class Program
    {
        public static async Task Main()
        {
            using (var db = new DataStoreContext())
            {
                if (! db.Distributors.Any())
                {
                    // Populate Distributors DB
                    DataStore.distributors.ForEach(dist => {
                        db.Distributors.Add(dist);
                    });
                    var count = await db.SaveChangesAsync();
                    Console.WriteLine($"{count} distributor records saved to database");

                    Console.WriteLine();
                }
                Console.WriteLine("show all distributors in database:");
                foreach (var dist in db.Distributors)
                {
                    Console.WriteLine($" - {dist.Name}");
                }

                if (! db.Customers.Any())
                {
                    DataStore.customers.ForEach(cust => {
                        db.Customers.Add(cust);
                    });
                    var count = await db.SaveChangesAsync();
                    Console.WriteLine($"{count} customer records saved to database");

                    Console.WriteLine();
                }
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

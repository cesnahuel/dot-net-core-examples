using System;


namespace DotNetCore.SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var db = new DataStoreContext())
            {
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
            }
        }
    }
}

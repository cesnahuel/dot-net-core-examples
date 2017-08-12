using System.Collections.Generic;


namespace DotNetCore.SQLite
{
    class DataStore
    {
        public static List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                First = "Cailin",
                Last = "Alford",
                State = "GA",
                Price = 930.00,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Panel 625" },
                    new Purchase { Item = "Panel 200" },
                }
            },
            new Customer
            {
                First = "Theodore",
                Last = "Brock",
                State = "AR",
                Price = 2100.00,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "12V Li" }
                }
            },
            new Customer
            {
                First = "Jerry",
                Last = "Gill",
                State = "MI",
                Price = 585.80,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Bulb 23W" },
                    new Purchase { Item = "Panel 625" },
                }
            },
            new Customer
            {
                First = "Owens",
                Last = "Howell",
                State = "GA",
                Price = 512.00,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Panel 200" },
                    new Purchase { Item = "Panel 180" },
                }
            },
            new Customer
            {
                First = "Adena",
                Last = "Jenkins",
                State = "OR",
                Price = 2267.80,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Bulb 23W" },
                    new Purchase { Item = "12V Li" },
                    new Purchase { Item = "Panel 180" },
                }
            },
            new Customer
            {
                First = "Medge",
                Last = "Ratliff",
                State = "GA",
                Price = 1034.00,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Panel 625" }
                }
            },
            new Customer
            {
                First = "Sydney",
                Last = "Bartlett",
                State = "OR",
                Price = 2105.00,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "12V Li" },
                    new Purchase { Item = "AA NiMH" },
                }
            },
            new Customer
            {
                First = "Malik",
                Last = "Faulkner",
                State = "MI",
                Price = 167.80,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Bulb 23W" },
                    new Purchase { Item = "Panel 180" },
                }
            },
            new Customer
            {
                First = "Serena",
                Last = "Malone",
                State = "GA",
                Price = 512.00,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Panel 180" },
                    new Purchase { Item = "Panel 200" }
                }
            },
            new Customer
            {
                First = "Hadley",
                Last = "Sosa",
                State = "OR",
                Price = 590.20,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Panel 625" },
                    new Purchase { Item = "Bulb 23W" },
                    new Purchase { Item = "Bulb 9W" },
                }
            },
            new Customer
            {
                First = "Nash",
                Last = "Vasquez",
                State = "OR",
                Price = 10.20,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Bulb 23W" },
                    new Purchase { Item = "Bulb 9W" }
                }
            },
            new Customer
            {
                First = "Joshua",
                Last = "Delaney",
                State = "WA",
                Price = 350.00,
                Purchases = new List<Purchase>
                {
                    new Purchase { Item = "Panel 200" }
                }
            }
        };

        public static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor { Name = "Edgepulse", State = "UT" },
            new Distributor { Name = "Jabbersphere", State = "GA" },
            new Distributor { Name = "Quaxo", State = "FL" },
            new Distributor { Name = "Yakijo", State = "OR" },
            new Distributor { Name = "Scaboo", State = "GA" },
            new Distributor { Name = "Innojam", State = "WA" },
            new Distributor { Name = "Edgetag", State = "WA" },
            new Distributor { Name = "Leexo", State = "HI" },
            new Distributor { Name = "Abata", State = "OR" },
            new Distributor { Name = "Vidoo", State = "TX" },
        };
    }
}

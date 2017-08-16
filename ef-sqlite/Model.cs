using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore.SQLite
{
    public class DataStoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data-store.db");
        }
    }

    [Table("customers")]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string State { get; set; }
        public double Price { get; set; }
        public List<Purchase> Purchases { get; set; }
    }

    [Table("purchases")]
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Item { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    [Table("distributors")]
    public class Distributor
    {
        public int DistributorId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
    }
}

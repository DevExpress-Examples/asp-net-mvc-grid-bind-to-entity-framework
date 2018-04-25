using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EF.Models {
    public class Order {
        [Key]
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
    }
    
    public class NorthwindContext : DbContext {
        public NorthwindContext() : base("SQLCompact_Northwind_Connection") { }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Order>().Property(p => p.OrderID).HasColumnName("Order ID");
            modelBuilder.Entity<Order>().Property(p => p.CustomerID).HasColumnName("Customer ID");
            modelBuilder.Entity<Order>().Property(p => p.ShipName).HasColumnName("Ship Name");
            modelBuilder.Entity<Order>().Property(p => p.ShipAddress).HasColumnName("Ship Address");
        }
    }
}
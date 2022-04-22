using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Invintore.Models
{
    public class OrderContext :DbContext
    {
        public OrderContext():base("Name=Inventory")
        {

        }
        public DbSet<Order> OrderDB { get; set; }
        public DbSet<Customer> CustomerDB { get; set; }
        public DbSet<Product> ProductDB { get; set; }
    }
}
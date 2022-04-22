using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invintore.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public List<Order> Product_Order { get; set; }
        public List<Customer> Product_Customer { get; set; }
    }
}
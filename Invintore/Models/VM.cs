using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invintore.Models
{
    public class VM
    {
        public List<Order> LIOrderVM { get; set; }
        public Order OrderVM { get; set; }
        public List<Customer> CustomerVM { get; set; }
        public List<Product> ProductVM { get; set; }
    }
}
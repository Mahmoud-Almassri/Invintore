using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace Invintore.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Order> Customer_Order { get; set; }
        [ForeignKey("Customer_Product")]
        public int Product_ID { get; set; }
        public Product Customer_Product { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Invintore.Models
{
    public class Order
    {
        [Required(ErrorMessage ="Enter your ID")]
        public int ID { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Address { get; set; }
        public string Phone { get; set; }
        
        public int Price { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        int _TotalAmount;
        public int TotalAmount {  set { _TotalAmount = Price * Quantity; } get { return _TotalAmount; } }

        [ForeignKey("Order_Customer")]
        public int Customer_ID { get; set; }
        public Customer Order_Customer { get; set; }

        [ForeignKey("Order_Product")]
        public int Product_ID { get; set; }
        public Product Order_Product { get; set; }


    }
}
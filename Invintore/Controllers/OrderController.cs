using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invintore.Models;
using System.Data.Entity;
namespace Invintore.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult NewOrder()
        {
            VM vm = new VM();
            vm.CustomerVM = FillCustomer();
            vm.ProductVM = FillProduct();
            return View("NewOrder",vm);
        }
        public ActionResult New_Order(int id)
        {
            ViewBag.id = id;

            VM vm = new VM();
            vm.CustomerVM = FillCustomer();
            vm.ProductVM = FillProduct();
            return View("NewOrder", vm);
        }
        public List<Customer> FillCustomer()
        {
            OrderContext con = new OrderContext();
            List<Customer> li=new List<Customer>();

            var data = from x in con.CustomerDB
                       select x;
            foreach (var item in data)
            {
                Customer obj = new Customer();
                obj.ID = item.ID;
                obj.Name = item.Name;
                li.Add(obj);
            }
            return li;

        }
        public ActionResult Fill_Customer(int id)
        {
            OrderContext con = new OrderContext();
            List<Customer> li = new List<Customer>();

            var data = from x in con.CustomerDB
                       where x.ID==id
                       select x;
            foreach (var item in data)
            {
                Customer obj = new Customer();
                obj.ID = item.ID;
                obj.Name = item.Name;
                obj.Address = item.Address;
                obj.Phone = item.Phone;
                li.Add(obj);
            }
            return Json(li,JsonRequestBehavior.AllowGet);
        }
        public List<Product> FillProduct()
        {
            OrderContext con = new OrderContext();
            List<Product> li = new List<Product>();

            var data = from x in con.ProductDB
                       select x;
            foreach (var item in data)
            {
                Product obj = new Product();
                obj.ID = item.ID;
                obj.Name = item.Name;
                li.Add(obj);
            }
            return li;

        }

        public ActionResult Fill_Product(int id)
        {
            OrderContext con = new OrderContext();
            List<Product> li = new List<Product>();

            var data = from x in con.ProductDB
                       where x.ID==id
                       select x;
            foreach (var item in data)
            {
                Product obj = new Product();
                obj.ID = item.ID;
                obj.Name = item.Name;
                obj.Price = item.Price;
                obj.Quantity = item.Quantity;
                li.Add(obj);
            }
            return Json(li,JsonRequestBehavior.AllowGet);

        }
        [Submit(Button ="Save")]
        public ActionResult Save(VM vm)
        {
            OrderContext con = new OrderContext();
            con.OrderDB.Add(vm.OrderVM);
            con.SaveChanges();

            vm.CustomerVM = FillCustomer();
            vm.ProductVM = FillProduct();
            return View("NewOrder", vm);
        }
        [Submit(Button ="Update")]
        public ActionResult Update(VM vm)
        {
            OrderContext con = new OrderContext();

            if (ModelState.IsValid)
            {
                con.OrderDB.Attach(vm.OrderVM);
                con.Entry(vm.OrderVM).State = EntityState.Modified;
                con.SaveChanges();
            }
            
            

            vm.CustomerVM = FillCustomer();
            vm.ProductVM = FillProduct();
            return View("NewOrder", vm);
        }
        public ActionResult FillOrder()
        {
            OrderContext con = new OrderContext();
            List<Order> li = new List<Order>();

            var data = from x in con.OrderDB
                       select x;
            foreach (var item in data)
            {
                Order obj = new Order();
                obj.ID = item.ID;
                obj.Date = item.Date;
                obj.Customer_ID = item.Customer_ID;
                obj.Address = item.Address;
                obj.Phone = item.Phone;
                obj.Product_ID = item.Product_ID;
                obj.Price = item.Price;
                obj.Quantity = item.Quantity;
                li.Add(obj);
            }
            return Json(li,JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderList()
        {  
            return View("OrderList");
        }
        public ActionResult Edit(int id)
        {
            OrderContext con = new OrderContext();
            VM vm = new VM();
            vm.OrderVM = con.OrderDB.Find(id);
            vm.CustomerVM = FillCustomer();
            vm.ProductVM = FillProduct();
            return View("NewOrder", vm);
            //var data =from x in con.OrderDB
            //          where x.ID==id
            //          select x;
            //foreach (var item in data)
            //{
            //    Order obj = new Order();
            //    obj.ID = item.ID;
            //    obj.Date = item.Date;
            //    obj.Customer_ID = item.Customer_ID;
            //    obj.Address = item.Address;
            //    obj.Phone = item.Phone;
            //    obj.Product_ID = item.Product_ID;
            //    obj.Price = item.Price;
            //    obj.Quantity = item.Quantity;
            //    li.Add(obj);
            //}


        }
        public ActionResult Delete(int id)
        {
            OrderContext con = new OrderContext();
            Order order= con.OrderDB.Find(id);
            con.OrderDB.Remove(order);
            con.SaveChanges();
            return View("OrderList");
        }
        public ActionResult OrderReporte()
        {
                

                     
        }
    }
}
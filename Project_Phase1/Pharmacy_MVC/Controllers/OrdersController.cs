using Microsoft.Ajax.Utilities;
using Pharmacy_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Pharmacy_MVC.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        PharmacyEntities db = new PharmacyEntities();

        // GET: Orders
        public ActionResult AllOrders()
        {
            List<Order> orderList = db.Orders.Where(o => o.OrderStatus.Equals("NOT_DELEVERED")).ToList();
            //return View(orderList);
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult AssignOrder(int id)
        {
            Order od = db.Orders.Find(id);
            od.OrderStatus = "DELIVERED";
            db.SaveChanges();
            return Redirect("/Orders/AllOrders");
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult ViewOrder(int id)
        {
            OrderDetails orderDetails = new OrderDetails();

            Order od = db.Orders.Find(id);
            //orderDetails.ProductList = db.Products.ToList();
            //orderDetails.OrderList = db.Orders.ToList();
            return View(od);
        }

        // POST: Orders/Edit/5
        public ActionResult AcceptOrder(int id)
        {
            // along with delivery boys list send order object also.

            Order todeliver = db.Orders.Find(id);
            List<User> deliveryBoys = db.Users.Where(u => u.Profile.Equals("DELIVERY_BOY")).ToList();
            var viewModel = new ApproveOrder
            {
                order = todeliver,
                deliveryBoys = deliveryBoys
            };
            return View(viewModel);
        }

        // GET: Orders/Delete/5
        
        public ActionResult CancelOrder(int id)
        {
            Order orderToCancel = db.Orders.Find(id);
            orderToCancel.OrderStatus = "CANCELED";
            db.SaveChanges();
            Order od = new Order();
            od.OrderID = orderToCancel.OrderID;
            od.UserID = orderToCancel.UserID;
            return View(od);
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult CancelOrderMsg(CancelMessage cancelOrder)
        {
            db.CancelMessages.Add(cancelOrder);
            db.SaveChanges();

            return Redirect("/Orders/AllOrders");
        }
    }
}

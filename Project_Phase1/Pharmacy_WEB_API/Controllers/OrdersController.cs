﻿using Pharmacy_WEB_API.DTO;
using Pharmacy_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pharmacy_WEB_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OrdersController : ApiController
    {
        PharmacyEntities db = new PharmacyEntities();
        // GET: api/Orders
        public IHttpActionResult Get()
        {

            return null;
        }

        [Route ("api/DeliveredOrders/{id}")]
        [HttpGet]
        public IHttpActionResult GetDeliveredOrders(int id)
        {
            List<Order> deliveredOrders = db.Orders.Where(o => id == o.UserID && o.OrderStatus.Equals("DELIVERED")).ToList();
            return Ok(deliveredOrders);
        }

        [Route ("api/CanceledOrders/{id}")]
        [HttpGet]
        public IHttpActionResult GetCanceledOrders(int id)
        {
            List<Order> canceledOrders = db.Orders.Where(o => id == o.UserID && o.OrderStatus.Equals("CANCELED")).ToList();
            return Ok(canceledOrders);

        }

        [Route ("api/NotDeliveredOrders/{id}")]
        [HttpGet]
        public IHttpActionResult GetNotDeliveredOrders(int id)
        {
            List<Order> notDeliveredOrders = db.Orders.Where(o => id == o.UserID && o.OrderStatus.Equals("NOT_DELIVERED")).ToList();
            return Ok(notDeliveredOrders);

        }

        [Route ("api/cancelOrder/{userId}/{orderId}")]
        [HttpPut]
        public void cancelOrder(int userId, int orderId)
        {
            Order orderToCancel = db.Orders.Find(orderId);
            orderToCancel.OrderStatus = "CANCELED";
            db.SaveChanges();
        }

        // GET: api/Orders/5
        public IHttpActionResult Get(int id)
        {
            List<Order> allOrders = db.Orders.Where(o => id == o.UserID).ToList();
            return Ok(allOrders);
        }

        //get all orders with all details
        [Route("api/GetAllOrderDetails/{id}")]
        [HttpGet]
        public IHttpActionResult GetAllOrderDetails(int id)
        {
            List<Order> allOrders = db.Orders.Where(o => id == o.UserID).ToList();
            Address userAddress = db.Addresses.Where(a => a.UserID == id).FirstOrDefault(); 
            
            OrderDetails od = new OrderDetails();

            List<Product> list = new List<Product>();

            foreach(var order in allOrders)
            {
                list.Add(order.Product);
            }
            od.prodList = list;
            od.address = userAddress;

            return Ok(od);
        }

        // POST: api/Orders
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Orders/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Orders/5
        public void Delete(int id)
        {
        }
    }
}

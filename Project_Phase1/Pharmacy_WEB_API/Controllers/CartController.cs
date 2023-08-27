using Pharmacy_WEB_API.DTO;
using Pharmacy_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Pharmacy_WEB_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CartController : ApiController
    {
        PharmacyEntities db = new PharmacyEntities();
        // GET: api/Cart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //get all products in cart of specific user
        // GET: api/Cart/5
        public List<Cart> Get(int id)
        {
            List<Cart> userCart = db.Carts.Where(u => u.UserID == id).ToList();

            return userCart;
        }

        // POST: api/Cart
        public void Post([FromBody]string value)
        {
        }

        [Route ("api/AddToCart")]
        [HttpPost]
        public void AddToCart(CartDetails cartItem)
        {
            Cart cart = new Cart();
            cart.ProductID = cartItem.productId;
            cart.UserID = cartItem.customerId;
            cart.Quantity = cartItem.quantity;
            cart.AddedDate = DateTime.UtcNow;
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        [Route ("api/deleteCartItem")]
        [HttpDelete]
        public void deleteCartItem(CartDetails cartItem)
        {
            List<Cart> cartItemToDelete = db.Carts.Where(c => c.UserID == cartItem.customerId && c.ProductID == cartItem.productId).ToList();
            if(cartItemToDelete != null)
            {
                foreach(var c in cartItemToDelete)
                {
                    db.Carts.Remove(c);
                    db.SaveChanges();
                }
            }
        }

        [Route ("api/placeOrder/{userId}")]
        [HttpPost]
        public void placeOrder(int userId)
        {
            List<Cart> cartItems = db.Carts.Where(c => c.UserID == userId).ToList();
            Order order = new Order();
            User u = db.Users.Find(userId);
            Address address = db.Addresses.Where( a => a.UserID == userId).FirstOrDefault();
            decimal price = 0;
            foreach (var c in cartItems)
            {
                Product prod = db.Products.Find(c.ProductID);
                order.UserID = userId;
                order.ProductId = c.ProductID;
                order.OrderDate = DateTime.UtcNow;
                order.AddressID = address.AddressID;
                order.OrderStatus = "NOT_DELIVERED";
                //price += (decimal)order.Product.Price;
                price = price + (decimal)prod.Price;
                order.OrderPrice = price.ToString();
                db.Orders.Add(order);
                db.SaveChanges();
            }
           
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();

        }

        // PUT: api/Cart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cart/5
        public void Delete(int id)
        {
        }
    }
}

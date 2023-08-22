using Pharmacy_WEB_API.DTO;
using Pharmacy_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;


namespace Pharmacy_WEB_API.Controllers
{
    public class CustomersController : ApiController
    {
        PharmacyEntities db = new PharmacyEntities();
        // GET: api/Customers
        public List<User> Get()
        {
            List<User> userList = db.Users.ToList();
            return userList;
        }

        // GET: api/Customers/5
        public IHttpActionResult Get(int id)
        {
            User cust = db.Users.Find(id);
            if(cust != null)
            {
                return Ok(cust);
            }
            return BadRequest();
        }

        // POST: api/Customers
        public void Post([FromBody]User user)
        {
            user.Profile = "CUSTOMER";
            db.Users.Add(user);
            db.SaveChanges();

        }

        [Route ("api/SignIn")]
        [HttpPost]
        public IHttpActionResult SignIn(LoginCredentials login)
        {
            User user = db.Users.FirstOrDefault(u => login.username.Equals(u.Email) && login.password.Equals(u.Password));
            if(user != null) 
            {
                return Ok(user);
            }

            return NotFound();
        }
        
    }
}

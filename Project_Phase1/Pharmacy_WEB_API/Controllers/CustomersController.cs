using Pharmacy_WEB_API.DTO;
using Pharmacy_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;


namespace Pharmacy_WEB_API.Controllers
{
    [EnableCors("*","*","*")]
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

        [Route("api/updateprofile/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateProfile(int id, User user)
        {
            User toUpdate = db.Users.Find(id);
            toUpdate.FirstName = user.FirstName;
            toUpdate.LastName = user.LastName;
            toUpdate.MobileNumber = user.MobileNumber;
            toUpdate.Email = user.Email;
            toUpdate.DateOfBirth = user.DateOfBirth;
            toUpdate.Gender = user.Gender;
            db.SaveChanges();
            return Ok(user);
        }

        [Route("api/changepassword/{id}")]
        [HttpPut]
        public IHttpActionResult ChangePassword(int id, ChangePass cp)
        {
            try
            {
                User user = db.Users.Find(id);
                if (user.Password.Equals(cp.oldPassword))
                {
                    user.Password = cp.newPassword;
                    db.SaveChanges();
                    return Ok("Password Changed Successfully..!");
                }
                return BadRequest("Old password not matched");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
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

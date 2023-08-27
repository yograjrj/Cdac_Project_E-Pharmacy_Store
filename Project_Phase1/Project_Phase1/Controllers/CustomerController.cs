using Project_Phase1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_Phase1.Controllers
{
    public class CustomerController : ApiController
    {
        PharmacyEntities db = new PharmacyEntities();
        // GET api/values
        public List<User> Get()
        {
            
            return db.Users.ToList(); ;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] User cust)
        {
            db.Users.Add(cust);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

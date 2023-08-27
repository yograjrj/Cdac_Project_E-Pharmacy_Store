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
    [EnableCors("*","*","*")]
    public class AddressController : ApiController
    {
        PharmacyEntities db = new PharmacyEntities();

        // GET: api/Address
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Address/5
        public IHttpActionResult Get(int id)
        {
            Address userAddress = db.Addresses.Where(a => a.UserID == id).FirstOrDefault();
            return Ok(userAddress);
        }

        // POST: api/Address
        public IHttpActionResult Post(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
            return Ok();
        }

        // PUT: api/Address/5
        public void Put(int id, Address address)
        {
            //before Edit address make sure to change the model for line1
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
        }
    }
}

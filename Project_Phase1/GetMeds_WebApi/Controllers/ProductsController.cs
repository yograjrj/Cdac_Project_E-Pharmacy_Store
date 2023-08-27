using GetMeds_WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace GetMeds_WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        PharmacyEntities db = new PharmacyEntities();
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            List<Product> allProducts = db.Products.ToList();
            return allProducts;
        }

        [Route ("api/HealthCareProducts")]
        [HttpGet]
        public IEnumerable<Product> HealthCareProducts()
        {
            List<Product> allProducts = db.Products.ToList();
            List<Product> healthcare = new List<Product>(); 
            foreach(var h in allProducts)
            {
                if(h.CategoryID == 1)
                {
                    healthcare.Add(h);
                }
            }
            

            return healthcare;
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}

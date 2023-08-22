using Pharmacy_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pharmacy_WEB_API.Controllers
{
    public class ProductsController : ApiController
    {
        PharmacyEntities db = new PharmacyEntities();
        // GET: api/Products
        public List<Product> GetAllProducts()
        {
            List<Product> allProducts = db.Products.ToList();
            return allProducts;
        }

        // GET: api/HealthCareProducts
        [Route("api/HealthCareProducts")]
        [HttpGet]
        public List<Product> GetHealthCareProducts()
        {
            List<Product> healthCareProducts = db.Products.Where(p => p.CategoryID == 1).ToList();
            return healthCareProducts;
        }

        // GET: api/BeautyProducts
        [Route("api/BeautyProducts")]
        [HttpGet]
        public List<Product> GetBeautyProducts()
        {
            List<Product> healthCareProducts = db.Products.Where(p => p.CategoryID == 2).ToList();
            return healthCareProducts;
        }

        // GET: api/WelnessProducts
        [Route("api/WelnessProducts")]
        [HttpGet]
        public List<Product> GetWelnessProducts()
        {
            List<Product> healthCareProducts = db.Products.Where(p => p.CategoryID == 3).ToList();
            return healthCareProducts;
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product prod = db.Products.Find(id);
            return prod;
        }
        
    }
}

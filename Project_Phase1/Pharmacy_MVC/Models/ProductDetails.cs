using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_MVC.Models
{
    public class ProductDetails
    {
        public List<Product> ProdList { get; set; }

        public List<Manufacturer> ManufactList { get; set; }

        public List<Category> CategoryList { get; set; }
    }
}
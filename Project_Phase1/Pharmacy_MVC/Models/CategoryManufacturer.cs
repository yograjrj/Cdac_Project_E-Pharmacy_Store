using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_MVC.Models
{
    public class CategoryManufacturer
    {
        public List<Manufacturer> ManufacturerList { get; set; }
        public List<Category> CategoryList { get; set; }
    }

}
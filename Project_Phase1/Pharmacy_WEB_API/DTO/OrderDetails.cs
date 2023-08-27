using Pharmacy_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_WEB_API.DTO
{
    public class OrderDetails
    {
        public List<Product> prodList { get; set; }
        public Address address { get; set; }

    }
}
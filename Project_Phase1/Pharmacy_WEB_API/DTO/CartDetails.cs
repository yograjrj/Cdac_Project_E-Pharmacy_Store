using Pharmacy_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_WEB_API.DTO
{
    public class CartDetails
    {
        public int productId { get; set; }

        public int customerId { get; set; }

        public int quantity { get; set; }


    }
}
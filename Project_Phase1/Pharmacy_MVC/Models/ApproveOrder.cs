using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_MVC.Models
{
    public class ApproveOrder
    {
        public Order order { get; set; }
        public List<User> deliveryBoys { get; set; }
    }
}
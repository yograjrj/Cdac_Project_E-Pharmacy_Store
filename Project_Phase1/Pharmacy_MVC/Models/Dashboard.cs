﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy_MVC.Models
{
    public class Dashboard
    {
        public List<User> UserList { get; set; }
        public List<Product> ProductList { get; set; }

        public List<Order> OrderList { get; set; }
    }
}
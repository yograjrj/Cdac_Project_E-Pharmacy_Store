using Pharmacy_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Pharmacy_MVC.Controllers
{

    public class HomeController : Controller
    {
        PharmacyEntities db = new PharmacyEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            Dashboard ds = new Dashboard();
            ds.ProductList = db.Products.ToList();
            ds.OrderList = db.Orders.ToList();
            ds.UserList = db.Users.ToList();

            return View(ds);
        }

        [Authorize]
        public ActionResult AdminProfile()
        {
            User admin = db.Users.FirstOrDefault(u => u.Profile.Equals("ADMIN"));
            
            return View(admin);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

    }
}
using Project_Phase1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Phase1.Controllers
{
    public class HomeController : Controller
    {
        PharmacyEntities db = new PharmacyEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginCredentials login)
        {
            User admin = db.Users.FirstOrDefault(u => u.Email == login.username && u.Password == login.password);

            if (admin != null)
            {
                ViewBag.msg = "Welcome, " + admin.FirstName;
                return Redirect("Dashboard");
            }
            return View("Failed");
        }

        public ActionResult Dashboard()
        {
            List<User> customers = db.Users.
                                    Where(u => u.Profile == "Customers")
                                    .ToList();
            return View(customers);
        }
    }
}

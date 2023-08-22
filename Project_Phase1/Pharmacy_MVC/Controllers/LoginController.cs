using Pharmacy_MVC.Models;
using Project_Phase1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pharmacy_MVC.Controllers
{
    public class LoginController : Controller
    {
        PharmacyEntities db = new PharmacyEntities();
        // GET: Products
        public ActionResult Login()
        {

            return View();
        }

        // GET: Products
        [HttpPost]
        public ActionResult Login(LoginCredentials login)
        {
            User admin = db.Users.FirstOrDefault(u => u.Email.Equals(login.username) && u.Password.Equals(login.password));

            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(login.username, false); 
                ViewBag.msg = "Welcome, " + admin.FirstName;
                return Redirect("/Home/Dashboard");
            }
            return View("Failed");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("/Login/Login");
        }

    }
}

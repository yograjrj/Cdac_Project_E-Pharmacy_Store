using Pharmacy_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy_MVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        PharmacyEntities db = new PharmacyEntities();

        // GET: Products
        public ActionResult AllProducts()
        {
            return View(db.Products.ToList());
        }

        // GET: Products
        public ActionResult HealthCareProducts()
        {
            List<Product> healthcareProducts = db.Products.Where(p => p.CategoryID == 1).ToList();
            return View(healthcareProducts);
        }

        // GET: Products
        public ActionResult BeautyProducts()
        {
            List<Product> beautyProducts = db.Products.Where(p => p.CategoryID == 2).ToList();
            return View(beautyProducts);
        }

        // GET: Products
        public ActionResult WelnessProducts()
        {
            List<Product> welnessProducts = db.Products.Where(p => p.CategoryID == 3).ToList();
            return View(welnessProducts);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult AddProduct()
        
        {
            CategoryManufacturer catman = new CategoryManufacturer();
            catman.ManufacturerList = db.Manufacturers.ToList();
            catman.CategoryList = db.Categories.ToList();

            return View(catman);
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult AddProduct(Product prod)
        {
            CategoryManufacturer catman = new CategoryManufacturer();
            catman.ManufacturerList = db.Manufacturers.ToList();
            catman.CategoryList = db.Categories.ToList();
            db.Products.Add(prod);
            db.SaveChanges();

            return View(catman);
        }

        // GET: Products/Edit/5
        public ActionResult UpdateProduct(int id)
        {
            Product prodToUpdate = db.Products.Find(id);

            return View(prodToUpdate);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult UpdateProduct(Product updatedProd)
        {
            Product prodToUpdate = db.Products.Find(updatedProd.ProductID);
            prodToUpdate.ProductName = updatedProd.ProductName;
            prodToUpdate.ManufacturerID = updatedProd.ManufacturerID;
            prodToUpdate.CategoryID = updatedProd.CategoryID;
            prodToUpdate.Description = updatedProd.Description;
            prodToUpdate.Price = updatedProd.Price;
            prodToUpdate.ExpiryDate = updatedProd.ExpiryDate;
            prodToUpdate.ManufacturingDate = updatedProd.ManufacturingDate;
            db.SaveChanges();
            return Redirect("/Products/AllProducts");
        }

        // GET: Products/Delete/5
        public ActionResult DeleteProduct(int id)
        {
            Product prodToDelete = db.Products.Find(id);
            db.Products.Remove(prodToDelete);   
            db.SaveChanges();
            return Redirect("/Products/AllProducts");
        }


        // GET: Products/Edit/5
        public ActionResult ViewProduct(int id)
        {
            Product p = db.Products.Find(id);

            //ProductDetails pd = new ProductDetails();
            //pd.ProdList = db.Products.ToList();
            //pd.ManufactList = db.Manufacturers.ToList();
            //pd.CategoryList = db.Categories.ToList();

            return View(p);
        }

    }
}

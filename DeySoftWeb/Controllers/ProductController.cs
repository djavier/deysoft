using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Model;
using Domain;
using Domain.Repositories;
using Service;

namespace DeySoftWeb.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult List()
        {
          ProductService service = new ProductService();
            
            return View(service.GetProducts(true));
        }

        public ActionResult Create()
        {
          ProductService service = new ProductService();
          ViewBag.ProductTypes = service.GetProductTypes();
          ViewBag.Manufacturers = service.GetManufacturers();
          ViewBag.Models = service.GetModels();

          return View();
        }
        
        [HttpPost]
        public ActionResult Create(Product Product)
        {
          if (ModelState.IsValid)
          {
            ProductService service = new ProductService();
            service.CreateProduct(Product,User.Identity.Name);
          }

          return RedirectToAction("List");
        }

        public ActionResult Update(string id)
        {
          using (ProductService service = new ProductService())
          {
            ViewBag.ProductTypes = service.GetProductTypes();
            ViewBag.Manufacturers = service.GetManufacturers();
            ViewBag.Models = service.GetModels();
            ViewBag.Conditions = new List<string>() { "New", "Used", "Repaired" };
            return View(service.GetProducts(id));
          }
        }

        [HttpPost]
        public ActionResult Update(Product Product)
        {
          using (ProductService service = new ProductService())
          {
            service.UpdateProduct(Product, User.Identity.Name);
            return RedirectToAction("List");
          }
        }

    }
}

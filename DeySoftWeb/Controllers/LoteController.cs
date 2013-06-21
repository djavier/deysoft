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
    public class LoteController : Controller
    {
        //
        // GET: /Lote/

        public ActionResult List()
        {
          LoteService service = new LoteService();
            
            return View(service.GetLotes(true));
        }

        public ActionResult Create()
        {
          LoteService service = new LoteService();
          ViewBag.Products = new ProductService().GetProducts(false);
          ViewBag.Locations = new LocationService().GetLocation();
          ViewBag.PackageTypes= service.GetPackageTypes();
          

          return View();
        }
        
        [HttpPost]
        public ActionResult Create(Lote Lote)
        {
          if (ModelState.IsValid)
          {
            LoteService service = new LoteService();
            service.CreateLote(Lote,User.Identity.Name);
          }

          return RedirectToAction("List");
        }

        public ActionResult Update(string id)
        {
          using (LoteService service = new LoteService())
          {
            //ViewBag.LoteTypes = service.GetLoteTypes();
            //ViewBag.Manufacturers = service.GetManufacturers();
            //ViewBag.Models = service.GetModels();
            ViewBag.Conditions = new List<string>() { "New", "Used", "Repaired" };
            return View(service.GetLotes(id));
          }
        }

        [HttpPost]
        public ActionResult Update(Lote Lote)
        {
          using (LoteService service = new LoteService())
          {
            service.UpdateLote(Lote, User.Identity.Name);
            return RedirectToAction("List");
          }
        }

    }
}

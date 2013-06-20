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
    public class PriceController : Controller
    {
        //
        // GET: /Price/

        //public ActionResult List()
        //{
        //  LoteService service = new LoteService();

        //    return View(service.GetPrices());
        //}

        //public ActionResult Create()
        //{
        //  LoteService service = new LoteService();
          
        //  return View();
        //}
        
        //[HttpPost]
        //public ActionResult Create(Price Price)
        //{
        //  if (ModelState.IsValid)
        //  {
        //    LoteService service = new LoteService();
        //    service.CreatePrice(Price,User.Identity.Name);
        //  }

        //  return RedirectToAction("List");
        //}

        //public ActionResult Update(string id)
        //{
        //  using (LoteService service = new LoteService())
        //  {

        //    return View(service.GetPrices(id));
        //  }
        //}

        //[HttpPost]
        //public ActionResult Update(Price Price)
        //{
        //  using (LoteService service = new LoteService())
        //  {
        //    service.UpdatePrice(Price, User.Identity.Name);
        //    return RedirectToAction("List");
        //  }
        //}

    }
}

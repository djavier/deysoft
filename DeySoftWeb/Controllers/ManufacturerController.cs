using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Model;
using Domain.Repositories;
using Service;
using System.Web.Security;

namespace DeySoftWeb.Controllers
{  
    [Authorize]
    public class ManufacturerController : Controller
    {
        //
        // GET: /Manufacturer/

        public ActionResult List()
        {
          IRepository<Manufacturer> repo = new ManufacturerRepository();
          return View(repo.GetAll());
        }

  

        //
        // POST: /Manufacturer/Create

        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            try
            {
              using (ProductService service = new ProductService())
              {
                service.CreateManufacturer(manufacturer, User.Identity.Name);
                return RedirectToAction("List");
              }
            }
            catch
            {
              throw;
            }
        }
        
        //
        // POST: /Manufacturer/Edit/5

        [HttpPost]
        public ActionResult Update(string id, FormCollection formCollection)
        {
            try
            {
              using (ProductService service = new Service.ProductService())
              {
                Manufacturer mf = service.GetManufacturers(id);
                mf.Name = formCollection["item.Name"];
                mf.Country = formCollection["item.Country"];
                service.UpdateManufacturer(mf,User.Identity.Name);
              }
 
               return RedirectToAction("List");
            }
            catch
            {
                return View("List");
            }
        }

       
    }
}

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
    public class ModelController : Controller
    {
        //
        // GET: /Model/

        public ActionResult List()
        {
          IRepository<Model> repo = new ModelRepository();
          ViewBag.Manufacturers = new ProductService().GetManufacturers();
          return View(repo.GetAll());
        }

  

        //
        // POST: /Model/Create

        [HttpPost]
        public ActionResult Create(Model model)
        {
            try
            {
              using (ProductService service = new ProductService())
              {
                service.CreateModel(model, User.Identity.Name);
                return RedirectToAction("List");
              }
            }
            catch
            {
              throw;
            }
        }
        
        //
        // POST: /Model/Edit/5

        [HttpPost]
        public ActionResult Update(string id, FormCollection formCollection)
        {
            try
            {
              using (ProductService service = new Service.ProductService())
              {
                Model mf = service.GetModels(id);
                mf.Name = formCollection["item.Name"];
                mf.Id_Manufacturer = Guid.Parse(formCollection["item.Id_Manufacturer"]);
                service.UpdateModel(mf,User.Identity.Name);
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

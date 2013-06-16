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
    public class PackageTypeController : Controller
    {
        //
        // GET: /PackageType/

        public ActionResult List()
        {
          IRepository<PackageType> repo = new PackageTypeRepository();
          return View(repo.GetAll());
        }

  

        //
        // POST: /PackageType/Create

        [HttpPost]
        public ActionResult Create(PackageType packageType)
        {
            try
            {
              using (LoteService service = new LoteService())
              {
                service.CreatePackageType(packageType, User.Identity.Name);
                return RedirectToAction("List");
              }
            }
            catch
            {
              throw;
            }
        }
        
        //
        // POST: /PackageType/Edit/5

        [HttpPost]
        public ActionResult Update(string id, FormCollection formCollection)
        {
            try
            {
              using (var service = new Service.LoteService())
              {
                PackageType pt = service.GetPackageTypes(id);
                pt.Description = formCollection["item.Description"];
                service.UpdatePackageType(pt,User.Identity.Name);
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

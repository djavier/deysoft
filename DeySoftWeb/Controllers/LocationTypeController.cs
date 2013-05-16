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
    public class LocationTypeController : Controller
    {
        //
        // GET: /LocationType/

        public ActionResult List()
        {
          IRepository<LocationType> repo = new LocationTypeRepository();
          return View(repo.GetAll());
        }

  

        //
        // POST: /LocationType/Create

        [HttpPost]
        public ActionResult Create(LocationType locationType)
        {
            try
            {
              using (LocationService service = new LocationService())
              {                
                service.CreateLocationType(User.Identity.Name, locationType.Description);
                return RedirectToAction("List");
              }
            }
            catch
            {
              throw;
            }
        }
        
        //
        // POST: /LocationType/Edit/5

        [HttpPost]
        public ActionResult Update(string id, FormCollection formCollection)
        {
            try
            {
              using (var service = new Service.LocationService())
              {
                service.UpdateLocationType(User.Identity.Name, id, formCollection["item.Description"]);
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

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
    public class LocationController : Controller
    {
        //
        // GET: /Location/

        public ActionResult List()
        {
          LocationService service = new LocationService();

            return View(service.GetLocation());
        }

        public ActionResult Create()
        {
          LocationService service = new LocationService();
          ViewBag.LocationList = service.GetLocation();
          ViewBag.LocationTypeList = service.GetLocationType();
          return View();
        }
        
        [HttpPost]
        public ActionResult Create(Location location)
        {
          if (ModelState.IsValid)
          {
            LocationService service = new LocationService();
            service.CreateLocation(location,User.Identity.Name);
          }

          return RedirectToAction("List");
        }

        public ActionResult Update(string id)
        {
          using (LocationService service = new LocationService())
          {
            ViewBag.LocationList = service.GetLocation().ToList();
            ViewBag.LocationTypeList = service.GetLocationType().ToList();
            return View(service.GetLocation(id));
          }
        }

        [HttpPost]
        public ActionResult Update(Location location)
        {
          using (LocationService service = new LocationService())
          {
            service.UpdateLocation(location, User.Identity.Name);
            return RedirectToAction("List");
          }
        }

    }
}

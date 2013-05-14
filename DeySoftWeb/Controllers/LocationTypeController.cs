using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Model;
using Domain.Repositories;

namespace DeySoftWeb.Controllers
{
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // POST: /LocationType/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}

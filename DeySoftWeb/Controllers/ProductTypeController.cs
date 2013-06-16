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
    public class ProductTypeController : Controller
    {
        //
        // GET: /ProductType/

        public ActionResult List()
        {
          IRepository<ProductType> repo = new ProductTypeRepository();
          return View(repo.GetAll());
        }

  

        //
        // POST: /ProductType/Create

        [HttpPost]
        public ActionResult Create(ProductType productType)
        {
            try
            {
              using (ProductService service = new ProductService())
              {
                service.CreateProductType(productType, User.Identity.Name);
                return RedirectToAction("List");
              }
            }
            catch
            {
              throw;
            }
        }
        
        //
        // POST: /ProductType/Edit/5

        [HttpPost]
        public ActionResult Update(string id, FormCollection formCollection)
        {
            try
            {
              using (ProductService service = new Service.ProductService())
              {
                ProductType pt = service.GetProductTypes(id);
                pt.Description = formCollection["item.Description"];
                service.UpdateProductType(pt,User.Identity.Name);
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

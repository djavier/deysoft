using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Domain.Model;
using Domain.Repositories;

namespace Service
{
  public class ProductService : IDisposable
  {

    public ProductService()
    {
    
    }

    
    public IEnumerable<Model> GetModels()
    {
      IRepository<Model> rep = new ModelRepository();
      return rep.GetAll();
    }


    public Model GetModels(string id)
    {
      IRepository<Model> rep = new ModelRepository();
      return rep.GetById(Guid.Parse(id));
    }

    public IEnumerable<Manufacturer> GetManufacturers()
    {
      IRepository<Manufacturer> rep = new ManufacturerRepository();
      return rep.GetAll();
    }

    public Manufacturer GetManufacturers(string id)
    {
      IRepository<Manufacturer> rep = new ManufacturerRepository();
      return rep.GetById(Guid.Parse(id));
    }



    public void CreateModel(Model model,string username)
    {
      IRepository<Model> rep = new ModelRepository();
      model.Created_by = username;
      model.Modified_by = username;
      model.Created_on = DateTime.Now;
      model.Modified_on = DateTime.Now;
      rep.Save(model);

    }

    public void UpdateModel(Model model,string username)
    {
      IRepository<Model> rep = new ModelRepository();

      model.Modified_by = username;
      model.Modified_on = DateTime.Now;

      rep.Update(model);
    }

    public void CreateManufacturer(Manufacturer Manufacturer, string username)
    {
      IRepository<Manufacturer> rep = new ManufacturerRepository();
      Manufacturer.Created_by = username;
      Manufacturer.Modified_by = username;
      Manufacturer.Created_on = DateTime.Now;
      Manufacturer.Modified_on = DateTime.Now;
      rep.Save(Manufacturer);

    }

    public void UpdateManufacturer(Manufacturer Manufacturer, string username)
    {
      IRepository<Manufacturer> rep = new ManufacturerRepository();

      Manufacturer.Modified_by = username;
      Manufacturer.Modified_on = DateTime.Now;

      rep.Update(Manufacturer);
    }






    
    
    

    #region IDisposable Members

    public void Dispose()
    {
      
    }

    #endregion
  }
}

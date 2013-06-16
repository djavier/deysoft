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

    public IEnumerable<Product> GetProducts()
    {
      IRepository<Product> rep = new ProductRepository();
      return rep.GetAll();
    }


    public Product GetProducts(string id)
    {
      IRepository<Product> rep = new ProductRepository();
      return rep.GetById(Guid.Parse(id));
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


    public IEnumerable<ProductType> GetProductTypes()
    {
      IRepository<ProductType> rep = new ProductTypeRepository();
      return rep.GetAll();
    }


    public ProductType GetProductTypes(string id)
    {
      IRepository<ProductType> rep = new ProductTypeRepository();
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

    public void CreateProductType(ProductType productType, string username)
    {
      IRepository<ProductType> rep = new ProductTypeRepository();
      productType.Created_by = username;
      productType.Modified_by = username;
      productType.Created_on = DateTime.Now;
      productType.Modified_on = DateTime.Now;
      rep.Save(productType);
    }


    public void UpdateProductType(ProductType productType, string username)
    {
      IRepository<ProductType> rep = new ProductTypeRepository();
      productType.Modified_by = username;
      productType.Modified_on = DateTime.Now;
      rep.Update(productType);
    }

    public void CreateProduct(Product product, string username)
    {
      IRepository<Product> rep = new ProductRepository();
      product.Created_by = username;
      product.Modified_by = username;
      product.Created_on = DateTime.Now;
      product.Modified_on = DateTime.Now;
      rep.Save(product);
    }


    public void UpdateProduct(Product product, string username)
    {
      IRepository<Product> rep = new ProductRepository();

      product.Modified_by = username;
      product.Modified_on = DateTime.Now;

      rep.Update(product);
    }


    #region IDisposable Members

    public void Dispose()
    {
      
    }

    #endregion


  }
}

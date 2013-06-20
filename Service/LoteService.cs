using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using Domain;
using Domain.Repositories;

namespace Service
{
  public class LoteService : IDisposable
  {

    #region Lotes
    
    public IEnumerable<Lote> GetLotes()
    {
      IRepository<Lote> rep = new LoteRepository();
      return rep.GetAll();
    }

    public IEnumerable<Lote> GetLotes(bool childs)
    {
      LoteRepository rep = new LoteRepository();
      return rep.GetAll(childs);
    }

    public Lote GetLotes(string id)
    {
      IRepository<Lote> rep = new LoteRepository();
      return rep.GetById(Guid.Parse(id));
    }



    public void CreateLote(Lote Lote, string username)
    {
      IRepository<Lote> rep = new LoteRepository();
      Lote.Created_by = username;
      Lote.Modified_by = username;
      Lote.Created_on = DateTime.Now;
      Lote.Modified_on = DateTime.Now;
      rep.Save(Lote);
    }


    public void UpdateLote(Lote Lote, string username)
    {
      IRepository<Lote> rep = new LoteRepository();

      Lote.Modified_by = username;
      Lote.Modified_on = DateTime.Now;

      rep.Update(Lote);
    }
    #endregion

    #region Packages Types
    

    public IEnumerable<PackageType> GetPackageTypes()
    {
      IRepository<PackageType> rep = new PackageTypeRepository();
      return rep.GetAll();
    }


    public PackageType GetPackageTypes(string id)
    {
      IRepository<PackageType> rep = new PackageTypeRepository();
      return rep.GetById(Guid.Parse(id));
    }



    public void CreatePackageType(PackageType packageType, string username)
    {
      IRepository<PackageType> rep = new PackageTypeRepository();
      packageType.Created_by = username;
      packageType.Modified_by = username;
      packageType.Created_on = DateTime.Now;
      packageType.Modified_on = DateTime.Now;
      rep.Save(packageType);
    }


    public void UpdatePackageType(PackageType packageType, string username)
    {
      IRepository<PackageType> rep = new PackageTypeRepository();

      packageType.Modified_by = username;
      packageType.Modified_on = DateTime.Now;

      rep.Update(packageType);
    }
    #endregion

    #region Prices
    //public IEnumerable<Price> GetPrices()
    //{
    //  IRepository<Price> rep = new PriceRepository();
    //  return rep.GetAll();
    //}


    //public Price GetPrices(string id)
    //{
    //  IRepository<Price> rep = new PriceRepository();
    //  return rep.GetById(Guid.Parse(id));
    //}



    //public void CreatePrice(Price price, string username)
    //{
    //  IRepository<Price> rep = new PriceRepository();
    //  price.Created_by = username;
    //  price.Modified_by = username;
    //  price.Created_on = DateTime.Now;
    //  price.Modified_on = DateTime.Now;
    //  rep.Save(price);
    //}


    //public void UpdatePrice(Price price, string username)
    //{
    //  IRepository<Price> rep = new PriceRepository();

    //  price.Modified_by = username;
    //  price.Modified_on = DateTime.Now;

    //  rep.Update(price);
    //}

    #endregion


    #region Output
    public IEnumerable<Output> GetOutputs()
    {
      IRepository<Output> rep = new OutputRepository();
      return rep.GetAll();
    }


    public Output GetOutputs(string id)
    {
      IRepository<Output> rep = new OutputRepository();
      return rep.GetById(Guid.Parse(id));
    }



    public void CreateOutput(Output output, string username)
    {
      IRepository<Output> rep = new OutputRepository();
      output.Created_by = username;
      output.Modified_by = username;
      output.Created_on = DateTime.Now;
      output.Modified_on = DateTime.Now;
      rep.Save(output);
    }


    public void UpdateOutput(Output output, string username)
    {
      IRepository<Output> rep = new OutputRepository();

      output.Modified_by = username;
      output.Modified_on = DateTime.Now;

      rep.Update(output);
    }

    #endregion



    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;

namespace Domain.Repositories
{
  public class LoteRepository : IRepository<Lote>
  {
    #region ILoteRepository Members

   public void Save(Lote entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          try
          {
            session.Lotes.AddObject(entity);
            session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Added);
            session.SaveChanges();
            tran.Complete();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
    }

   public void Update(Lote entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.Lotes.Attach(entity);
          session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
          session.SaveChanges();
          tran.Complete();
        }
      }
    }



   public Lote GetById(Guid id)
    {
      using (var session = new DEYSoftEntities())
        return session.Lotes.Where(x => x.Id == id).FirstOrDefault();
    }

   public IList<Lote> GetAll()
    {
      using (var session = new DEYSoftEntities())
        return session.Lotes.ToList();
    }

   public IList<Lote> GetAll(bool childs)
   {
     using (var session = new DEYSoftEntities())
       if (childs)
         return session.Lotes.Include("Product").Include("PackageType").Include("Location").Include("Location.LocationType").ToList();
       else
         return session.Lotes.ToList();
   }

   public void Delete(Lote entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.DeleteObject(entity);
          session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Deleted);
          session.SaveChanges();
          tran.Complete();
        }
      }
    }

   public void Delete(Guid id)
   {
     using (var session = new DEYSoftEntities())
     {
       using (var tran = new TransactionScope())
       {
         session.DeleteObject(this.GetById(id));
         session.SaveChanges();
         tran.Complete();
       }
     }
   }

  
    #endregion
  }
}

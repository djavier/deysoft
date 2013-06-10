using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;

namespace Domain.Repositories
{
  public class LocationRepository : IRepository<Location>
  {
    #region ILocationRepository Members

   public void Save(Location entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          try
          {
            session.Locations.AddObject(entity);
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

   public void Update(Location entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.Locations.Attach(entity);
          session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
          session.SaveChanges();
          tran.Complete();
        }
      }
    }



   public Location GetById(Guid id)
    {
      using (var session = new DEYSoftEntities())
        return session.Locations.Where(x => x.Id == id).FirstOrDefault();
    }

   public IList<Location> GetAll()
    {
      using (var session = new DEYSoftEntities())
        return session.Locations.ToList();
    }

   public void Delete(Location entity)
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

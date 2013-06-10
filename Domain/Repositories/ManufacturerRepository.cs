using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;


namespace Domain.Repositories
{
  public class ManufacturerRepository : IRepository<Manufacturer>
  {
    #region IManufacturerRepository Members

    public void Save(Manufacturer entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                     try
                     {
                       session.Manufacturers.AddObject(entity);
                       session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Added);
                       session.SaveChanges();
                       tran.Complete();
                     }
                     catch (Exception ex )
                     {
                       throw ex;
                     }
                   }
               }
           }

         public void Update(Manufacturer entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                 session.Manufacturers.Attach(entity);
                 session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
                 session.SaveChanges();
                 tran.Complete();
                   }
               }
           }



         public Manufacturer GetById(Guid id)
           {
             using (var session = new DEYSoftEntities())
               return session.Manufacturers.Where(x => x.Id == id).FirstOrDefault();
           }

         public IList<Manufacturer> GetAll()
           {
             using (var session = new DEYSoftEntities())
               return session.Manufacturers.ToList();
           }

         public void Delete(Manufacturer entity)
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

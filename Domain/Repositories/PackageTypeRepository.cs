using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;


namespace Domain.Repositories
{
  public class PackageTypeRepository : IRepository<PackageType>
  {
    #region IPackageTypeRepository Members

         public void Save(PackageType entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                     try
                     {
                       session.PackageTypes.AddObject(entity);
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

         public void Update(PackageType entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                 session.PackageTypes.Attach(entity);
                 session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
                 session.SaveChanges();
                 tran.Complete();
                   }
               }
           }



         public PackageType GetById(Guid id)
           {
             using (var session = new DEYSoftEntities())
               return session.PackageTypes.Where(x => x.Id == id).FirstOrDefault();
           }

         public IList<PackageType> GetAll()
           {
             using (var session = new DEYSoftEntities())
               return session.PackageTypes.ToList();
           }

         public void Delete(PackageType entity)
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

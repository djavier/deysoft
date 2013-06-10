using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;


namespace Domain.Repositories
{
  public class ModelRepository : IRepository<Model.Model>

  {
    #region IModelRepository Members

         public void Save(Model.Model entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                     try
                     {
                       session.Models.AddObject(entity);
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

         public void Update(Model.Model entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                 session.Models.Attach(entity);
                 session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
                 session.SaveChanges();
                 tran.Complete();
                   }
               }
           }



         public Model.Model GetById(Guid id)
           {
             using (var session = new DEYSoftEntities())
               return session.Models.Where(x => x.Id == id).FirstOrDefault();
           }

         public IList<Model.Model> GetAll()
           {
             using (var session = new DEYSoftEntities())
               return session.Models.ToList();
           }

         public void Delete(Model.Model entity)
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

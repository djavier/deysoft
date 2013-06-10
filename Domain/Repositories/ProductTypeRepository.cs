using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;


namespace Domain.Repositories
{
  public class ProductTypeRepository : IRepository<ProductType>
  {
    #region IProductTypeRepository Members

         public void Save(ProductType entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                     try
                     {
                       session.ProductTypes.AddObject(entity);
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

         public void Update(ProductType entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                 session.ProductTypes.Attach(entity);
                 session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
                 session.SaveChanges();
                 tran.Complete();
                   }
               }
           }



         public ProductType GetById(Guid id)
           {
             using (var session = new DEYSoftEntities())
               return session.ProductTypes.Where(x => x.Id == id).FirstOrDefault();
           }

         public IList<ProductType> GetAll()
           {
             using (var session = new DEYSoftEntities())
               return session.ProductTypes.ToList();
           }

         public void Delete(ProductType entity)
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

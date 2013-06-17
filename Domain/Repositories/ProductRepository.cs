using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;


namespace Domain.Repositories
{
  public class ProductRepository : IRepository<Product>

  {
    #region IProductRepository Members

         public void Save(Product entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                     try
                     {
                       session.Products.AddObject(entity);
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

         public void Update(Product entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                 session.Products.Attach(entity);
                 session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
                 session.SaveChanges();
                 tran.Complete();
                   }
               }
           }



         public Product GetById(Guid id)
           {
             using (var session = new DEYSoftEntities())
               return session.Products.Where(x => x.Id == id).FirstOrDefault();
           }

         public IList<Product> GetAll()
           {
             using (var session = new DEYSoftEntities())
               return session.Products.ToList();
           }


         public IList<Product> GetAll(bool childs)
         {
           using (var session = new DEYSoftEntities())
           {
             if (childs)
               return session.Products.Include("Manufacturer").Include("Model").Include("ProductType").ToList();
             else
               return session.Products.ToList();
           }
         }

         public void Delete(Product entity)
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

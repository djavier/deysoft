﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;


namespace Domain.Repositories
{
  public class OutputRepository : IRepository<Output>

  {
    #region IOutputRepository Members

         public void Save(Output entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                     try
                     {
                       session.Outputs.AddObject(entity);
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

         public void Update(Output entity)
           {
             using (var session = new DEYSoftEntities())
             {
               using (var tran = new TransactionScope())
               {
                 session.Outputs.Attach(entity);
                 session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
                 session.SaveChanges();
                 tran.Complete();
                   }
               }
           }



         public Output GetById(Guid id)
           {
             using (var session = new DEYSoftEntities())
               return session.Outputs.Where(x => x.Id == id).FirstOrDefault();
           }

         public IList<Output> GetAll()
           {
             using (var session = new DEYSoftEntities())
               return session.Outputs.ToList();
           }

         public void Delete(Output entity)
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

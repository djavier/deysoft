using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using NHibernate;
using NHibernate.Criterion;

namespace Domain.Repositories
{
  public class LocationTypeRepository : IRepository<LocationType>
  {
    #region ILocationTypeRepository Members

           void IRepository<LocationType>.Save(LocationType entity)
           {
               using (ISession session = NHibernateHelper.OpenSession())
               {
                   using (ITransaction transaction = session.BeginTransaction())
                   {
                     try
                     {
                       session.Save(entity);
                       transaction.Commit();
                     }
                     catch (Exception ex )
                     {
                       throw ex;
                     }
                   }
               }
           }
    
           void IRepository<LocationType>.Update(LocationType entity)
           {
               using (ISession session = NHibernateHelper.OpenSession())
               {
                   using (ITransaction transaction = session.BeginTransaction())
                   {
                       session.Update(entity);
                       transaction.Commit();
                   }
               }
           }
    

    
           LocationType IRepository<LocationType>.GetById(Guid id)
           {
               using (ISession session = NHibernateHelper.OpenSession())
                   return session.CreateCriteria<LocationType>().Add(Restrictions.Eq("Id", id)).UniqueResult<LocationType>();
           }

           IList<LocationType> IRepository<LocationType>.GetAll()
           {
             using (ISession session = NHibernateHelper.OpenSession())
               return session.QueryOver<LocationType>().List();
           }
    
           void IRepository<LocationType>.Delete(LocationType entity)
           {
             using (ISession session = NHibernateHelper.OpenSession())
             {
               using (ITransaction transaction = session.BeginTransaction())
               {
                 session.Delete(entity);
                 transaction.Commit();
               }
             }
           }

           void IRepository<LocationType>.Delete(Guid id)
           {
             using (ISession session = NHibernateHelper.OpenSession())
             {
               using (ITransaction transaction = session.BeginTransaction())
               {
                 session.Delete(id);
                 transaction.Commit();
               }
             }
           }

           LocationType IRepository<LocationType>.GetById(int id)
           {
             using (ISession session = NHibernateHelper.OpenSession())
               return session.CreateCriteria<LocationType>().Add(Restrictions.Eq("Id", id)).UniqueResult<LocationType>();
           }

      #endregion






      
  }
}

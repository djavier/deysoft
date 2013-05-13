using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using NHibernate;
using NHibernate.Criterion;

namespace Domain.Repositories
{
  public class UserRepository : IRepository<User>
  {
      #region IRepository<User> Members
    
           void IRepository<User>.Save(User entity)
           {
               using (ISession session = NHibernateHelper.OpenSession())
               {
                   using (ITransaction transaction = session.BeginTransaction())
                   {
                       session.Save(entity);
                       transaction.Commit();
                   }
               }
           }
    
           void IRepository<User>.Update(User entity)
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
    

    
           User IRepository<User>.GetById(Guid id)
           {
               using (ISession session = NHibernateHelper.OpenSession())
                   return session.CreateCriteria<User>().Add(Restrictions.Eq("Id", id)).UniqueResult<User>();
           }

           IList<User> IRepository<User>.GetAll()
           {
             using (ISession session = NHibernateHelper.OpenSession())
               return session.QueryOver<User>().List();
           }
    
           #endregion


           #region IRepository<User> Members


           public void Delete(User entity)
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


           #endregion

           void Delete(Guid id)
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
  }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using NHibernate;
using NHibernate.Criterion;

namespace Domain.Repositories
{
  public class UserRepository : IUserRepository
  {
    #region IUserRepository Members

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
    
           void IRepository<User>.Delete(User entity)
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

           void IRepository<User>.Delete(Guid id)
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


           User IUserRepository.GetByUsername(string username)
           {
             using (ISession session = NHibernateHelper.OpenSession())
               return session.CreateCriteria<User>().Add(Restrictions.Eq("Username", username)).UniqueResult<User>();
           }

      #endregion






           #region IRepository<User> Members


           public User GetById(int id)
           {
             throw new NotImplementedException();
           }

           #endregion
  }
}

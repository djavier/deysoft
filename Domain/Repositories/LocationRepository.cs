using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using NHibernate;
using NHibernate.Criterion;

namespace Domain.Repositories
{
  public class LocationRepository : IRepository<Location>
  {
    #region ILocationRepository Members

    void IRepository<Location>.Save(Location entity)
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
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
    }

    void IRepository<Location>.Update(Location entity)
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



    Location IRepository<Location>.GetById(Guid id)
    {
      using (ISession session = NHibernateHelper.OpenSession())
        return session.CreateCriteria<Location>().Add(Restrictions.Eq("Id", id)).UniqueResult<Location>();
    }

    IList<Location> IRepository<Location>.GetAll()
    {
      using (ISession session = NHibernateHelper.OpenSession())
        return session.QueryOver<Location>().List();
    }

    void IRepository<Location>.Delete(Location entity)
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

    void IRepository<Location>.Delete(Guid id)
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

    Location IRepository<Location>.GetById(int id)
    {
      using (ISession session = NHibernateHelper.OpenSession())
        return session.CreateCriteria<Location>().Add(Restrictions.Eq("Id", id)).UniqueResult<Location>();
    }

    #endregion
  }
}

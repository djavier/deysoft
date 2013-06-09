using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;

namespace Domain.Repositories
{
  public class UserRepository : IUserRepository
  {
    #region IUserRepository Members

    void IRepository<USER>.Save(USER entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.AddObject(entity.EntityKey.EntitySetName, entity);
          session.SaveChanges();
        }
      }
    }

    void IRepository<USER>.Update(USER entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.AddObject(entity.EntityKey.EntitySetName, entity);
          session.SaveChanges();
        }
      }
    }



    USER IRepository<USER>.GetById(Guid id)
    {
      using (var session = new DEYSoftEntities())
        return session.USERs.Where(x => x.Id == id).FirstOrDefault();
    }

    IList<USER> IRepository<USER>.GetAll()
    {
      using (var session = new DEYSoftEntities())
        return session.QueryOver<User>().List();
    }

    void IRepository<User>.Delete(USER entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.DeleteObject(entity);
          session.SaveChanges();
        }
      }
    }

    void IRepository<User>.Delete(Guid id)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.DeleteObject(GetById(id));
          transaction.Commit();
        }
      }
    }


    USER IUserRepository.GetByUsername(string username)
    {
      using (var session = new DEYSoftEntities())
        return session.CreateCriteria<User>().Add(Restrictions.Eq("Username", username)).UniqueResult<User>();
    }

    #endregion






    #region IRepository<USER>Members


    public USER GetById(int id)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}

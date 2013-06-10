using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using System.Transactions;

namespace Domain.Repositories
{
  public class UserRepository : IRepository<User>
  {
    #region IUserRepository Members

    public void Save(User entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.Users.AddObject(entity);
          session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Added);
          session.SaveChanges();
          tran.Complete();
        }
      }
    }

    public void Update(User entity)
    {
      using (var session = new DEYSoftEntities())
      {
        using (var tran = new TransactionScope())
        {
          session.Users.Attach(entity);
          session.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
          session.SaveChanges();
          tran.Complete();
        }
      }
    }



    public User GetById(Guid id)
    {
      using (var session = new DEYSoftEntities())
        return session.Users.Where(x => x.Id == id).FirstOrDefault();
    }

    public IList<User> GetAll()
    {
      using (var session = new DEYSoftEntities())
        return session.Users.ToList();
    }

    public void Delete(User entity)
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


    public User GetByUsername(string username)
    {
      using (var session = new DEYSoftEntities())
        return session.Users.Where(x => x.Username == username).FirstOrDefault();
    }

  }
}

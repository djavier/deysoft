using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;

namespace Domain.Repositories
{
  public class NHibernateHelper
  {
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
      get
      {
        if (_sessionFactory == null)
        {
          try
          {
            var configuration = new Configuration();
            configuration.Configure();
            _sessionFactory = configuration.BuildSessionFactory();
          }
          catch (Exception ex)
          {
            
            throw ex;
          }

        }
        return _sessionFactory;
      }
    }

    public static ISession OpenSession()
    {
      return SessionFactory.OpenSession();
    }
  }
}

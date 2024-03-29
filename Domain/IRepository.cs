﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;

namespace Domain
{
  public interface IRepository<T>
  {
    void Save(T entity);
    void Update(T entity);
    void Delete(T entiy);
    void Delete(Guid id);
    T GetById(Guid id);
    IList<T> GetAll();
  }

}

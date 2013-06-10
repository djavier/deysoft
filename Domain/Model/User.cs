using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
  public partial class User
  {
      public User()
      {
        Id = Guid.NewGuid();
      }
  }
}

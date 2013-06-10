using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
  public partial class Model
  {
    public Model()
    {
      Id = Guid.NewGuid();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
  public partial class Product
  {
    public Product()
    {
      Id = Guid.NewGuid();
    }
  }
}

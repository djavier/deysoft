using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
  public class LocationType
  {
    public LocationType()
    {
      Modified_on = DateTime.Now;
    }
    

    public virtual Guid      Id           { get; set; }
    public virtual string   Description   {get;set;}
    public virtual string   Created_by    {get;set;}
    public virtual DateTime Created_on   {get;set;}
    public virtual string   Modified_by   {get;set;}
    public virtual DateTime Modified_on {get;set;}
  }
}

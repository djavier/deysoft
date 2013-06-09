using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
  partial class LOCATION_TYPE
  {
    public LOCATION_TYPE()
    {
      this.Modified_on = DateTime.No  w;
    }

    public Guid      Id           { get; set; }
    public string   Description   {get;set;}
    public string   Created_by    {get;set;}
    public DateTime Created_on   {get;set;}
    public string   Modified_by   {get;set;}
    public DateTime Modified_on {get;set;}

    //public virtual IEnumerable<LOCATION> Locations { get; set; }
  }
}

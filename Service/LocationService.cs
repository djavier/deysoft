using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Model;
using Domain;
using Domain.Repositories;
using Infraestructure.DataHandle;

namespace Service
{
  public class LocationService : IDisposable
  {
    

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    public LocationService()
    {
    
    }


    public void CreateLocationType(string username, string description)
    {
      IRepository<LocationType> rep = new LocationTypeRepository();
      LocationType locType = new LocationType();
      locType.Description = description;
      locType.Created_by = username; 
      locType.Modified_by = username;
      locType.Created_on = DateTime.Now;
      rep.Save(locType);     
      
    }

    public void UpdateLocationType(string username,string id, string description)
    {
      IRepository<LocationType> rep = new LocationTypeRepository();
      LocationType locType = rep.GetById(Guid.Parse(id));
      locType.Description = description;
      locType.Modified_by = username;
      locType.Modified_on = DateTime.Now;

      rep.Update(locType);     
    }
  
    #region IDisposable Members

    public void  Dispose()
    {

    }

    #endregion


  }
}

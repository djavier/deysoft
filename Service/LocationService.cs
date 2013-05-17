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

    public IEnumerable<LocationType> GetLocationType(){
      IRepository<LocationType> rep = new LocationTypeRepository();
      return rep.GetAll();
    }

    public LocationType GetLocationType(string id){
      IRepository<LocationType> rep = new LocationTypeRepository();
      return rep.GetById(Guid.Parse(id));
    }

    public IEnumerable<Location> GetLocation(){
      IRepository<Location> rep = new LocationRepository();
      return rep.GetAll();
    }

    public Location GetLocation(string id){
      IRepository<Location> rep = new LocationRepository();
      return rep.GetById(Guid.Parse(id));
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

    public void CreateLocation(Location location,string username) 
    {
      IRepository<Location> rep = new LocationRepository();
      location.Created_by = username;
      location.Modified_by = username;
      location.Created_on = DateTime.Now;
      location.Modified_on = DateTime.Now;
      rep.Save(location);     
      
    }
  
    #region IDisposable Members

    public void  Dispose()
    {

    }

    #endregion


  }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Model;
using Domain.Repositories;

namespace Deysoft.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  
  public class UnitTest1
  {
    public UnitTest1()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    private TestContext testContextInstance;
    private string username = "Djavier";

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    public void CanCreateUser()
    {
      UserRepository repo = new UserRepository();
      User User = new User();
      User.Username = "YGonzalez";
      User.Name = "Yeudy";
      User.Lastname = "Gonzalez";
      User.Email = "yeudy87@gmail.com";                    
      User.Password = Infraestructure.DataHandle.Hash.SHA256("ygonzalez");                 
      User.PasswordQuestion = "";         
      User.PasswordAnswer ="";
      User.LastLoginDate = DateTime.Now;
      User.LastPasswordChangeDate = DateTime.Now;
      User.CreationDate = DateTime.Now;
      User.IsOnLine =  false;                
      User.IsLockedOut = false;             
      User.PasswordAttemptsCount = 0;     
      User.PasswordAnswerAttemptsCount = 0;

      repo.Save(User);

    }

    [TestMethod]
    public void CanValidateUser()
    {

        using (var service = new Service.UserService())
        {
          string username = "YGonzalez";
          string password = "gonzalez";
          Assert.IsTrue(service.ValidateUser(username, password));
        }
      
      
    }


    [TestMethod]
    public void CanChangePassword()
    {
      using (var service = new Service.UserService())
      {
        string username = "YGonzalez";
        string oldPassword = "ygonzalez";
        string newPassword = "gonzalez";

        Assert.IsTrue(service.ChangePassword(username, oldPassword, newPassword));
      }
    }

    [TestMethod]
    public void CanCreateLocationType()
    {
      try
      {
        using (var service = new Service.LocationService())
        {
          string username = "Djavier";
          string description = "Caja";

          service.CreateLocationType(username, description);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }

    [TestMethod]
    public void CanGetLocationType()
    {
      IRepository<LocationType> repo = new LocationTypeRepository();

      LocationType locType = repo.GetById(Guid.Parse("14B1E9DD-2F41-4BDB-9AFC-6AA21F63E755"));
      Assert.IsNotNull(locType);
        
    }

    [TestMethod]
    public void CanUpdateLocationType()
    {
      try
      {
        using (var service = new Service.LocationService())
        {
          string username = "Djavier";
          string description = "Cajon";
          string id = "4256C6B2-EE95-4C20-9F3A-C39B3A50C2F0";

          service.UpdateLocationType(username, id, description);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }

    [TestMethod]
    public void CanCreateLocation()
    {
      try
      {
        using (var service = new Service.LocationService())
        {
          Location loc = new Location();
          loc.Description = "Bloque 2";
          loc.ID_Location_Type = service.GetLocationType("C4BC2F24-6B59-4839-8A88-2BBB7DAAC452").Id;

          string username = "Djavier";
          service.CreateLocation(loc,username);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }

    [TestMethod]
    public void CanCreateManufacturer()
    {
      try
      {
        using (var service = new Service.ProductService())
        {
          Manufacturer manu = new Manufacturer();
          manu.Name = "Honda";
          manu.Country = "Japan";

          
          service.CreateManufacturer(manu, username);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }


    [TestMethod]
    public void CanGetManufacturer()
    {
      using (var service = new Service.ProductService())
      {
        Manufacturer manu = service.GetManufacturers("E6D4F4F1-1A03-4676-A347-FD74DBE02ACA");
        Assert.IsNotNull(manu);
      }
    }
        

    [TestMethod]
    public void CanUpdateManufacturer()
    {
      try
      {
        using (var service = new Service.ProductService())
        {
          Manufacturer manu = service.GetManufacturers("E6D4F4F1-1A03-4676-A347-FD74DBE02ACA");
          manu.Country = "China";

          service.UpdateManufacturer(manu,username);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }

    [TestMethod]
    public void CanCreateModel()
    {
      try
      {
        using (var service = new Service.ProductService())
        {
          Model model = new Model();
          model.Id_Manufacturer = service.GetManufacturers("E6D4F4F1-1A03-4676-A347-FD74DBE02ACA").Id; 
          model.Name = "Civic";
          


          service.CreateModel(model, username);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }


    [TestMethod]
    public void CanGetModel()
    {
      using (var service = new Service.ProductService())
      {
        Model model = service.GetModels("B607A568-5313-4CC5-9EEE-461C98991659");
        Assert.IsNotNull(model);
      }
    }

    
    [TestMethod]
    public void CanUpdateModel()
    {
      try
      {
        using (var service = new Service.ProductService())
        {
          Model model = service.GetModels("B607A568-5313-4CC5-9EEE-461C98991659");
          model.Name = "Accord";

          service.UpdateModel(model, username);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }

    [TestMethod]
    public void CanCreateProductType()
    {
      try
      {
        using (var service = new Service.ProductService())
        {
          ProductType obj = new ProductType();
          obj.Description = "Alternador";

          service.CreateProductType(obj, username);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }



    [TestMethod]
    public void CanGetProductType()
    {
      using (var service = new Service.ProductService())
      {
        ProductType model = service.GetProductTypes("17DA86B1-F50A-4E1C-82BB-A1B46C7204E8");
        Assert.IsNotNull(model);
      }
    }


    [TestMethod]
    public void CanUpdateProductType()
    {
      try
      {
        using (var service = new Service.ProductService())
        {
          ProductType model = service.GetProductTypes("17DA86B1-F50A-4E1C-82BB-A1B46C7204E8");
          model.Description = "Alternador 25x36";

          service.UpdateProductType(model, username);
        }
      }
      catch (Exception e)
      {
        Assert.Fail(e.Message + e.InnerException.Message);
      }
    }


  }
}

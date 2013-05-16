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
  public class UserService : IDisposable
  {
    private User user;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    public UserService(){
    
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="user">The user.</param>
    public UserService(User user){
      this.user = user;
    }


    /// <summary>
    /// Validates the user.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns><c>true</c> when the user is valid.</returns>
    public bool ValidateUser(string username, string password){
      try
      {

      
      IUserRepository userRepo = new UserRepository();
      User loginUser =  userRepo.GetByUsername(username);
      string hashedPassword = Infraestructure.DataHandle.Hash.SHA256(password);
      if (loginUser == null)
        return false;

      if (username == loginUser.Username && hashedPassword == loginUser.Password)
      {
        loginUser.LastLoginDate = DateTime.Now;
        loginUser.IsOnLine = true;
        userRepo.Update(loginUser);
        return true;
      }
      else 
        return false ;
      }
      catch (Exception)
      {
        return false;
      }

    }

    /// <summary>
    /// Changes the password.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="oldPassword">The old password.</param>
    /// <param name="newPassword">The new password.</param>
    /// <returns><c>true</c> when the password was succesfully changed.</returns>
    public bool ChangePassword(string username, string oldPassword, string newPassword)
    {
      IUserRepository userRepo = new UserRepository();

      User user = userRepo.GetByUsername(username);

      if (user != null)
      {
        if (Hash.SHA256(oldPassword) == user.Password)
        {
          user.Password = Hash.SHA256(newPassword);
          user.LastPasswordChangeDate = DateTime.Now;
          userRepo.Update(user);
          return true; 
        }
        else return false;
      } 
      return false; 
    }
  
    #region IDisposable Members

    public void  Dispose()
    {
 	    user = null;
    }

    #endregion
}
}

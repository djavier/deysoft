using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
  public class User
  {
      public virtual int  ID {get;set;}
      public virtual string  Username {get;set;}
      public virtual string  Name {get;set;}
      public virtual string  Lastname {get;set;}
      public virtual string  Email {get;set;}
      public virtual string  Password {get;set;}
      public virtual string  PasswordQuestion {get;set;}
      public virtual string  PasswordAnswer {get;set;}
      public virtual DateTime  LastLoginDate {get;set;}
      public virtual DateTime  LastPasswordChangeDate {get;set;}
      public virtual DateTime  CreationDate {get;set;}
      public virtual bool  IsOnLine {get;set;}
      public virtual bool  IsLockedOut {get;set;}
      public virtual int  PasswordAttemptsCount {get;set;}
      public virtual int PasswordAnswerAttemptsCount { get; set; }
  }
}

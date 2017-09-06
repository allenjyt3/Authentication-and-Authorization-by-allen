using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTokens.Models;

namespace WebApiTokens
{
    public class BusinessServices : IBusinessService
    {
      public  UserModel GenerateToken(string username, string password)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddMinutes(5);
            //WebApiToken apitoken = new WebApiToken();
            //call db and update token
            //using (var context = new SchoolEntities())
            //{
            //   apitoken = context.WebApiTokens.Where(p=>p.Username == username & p.Password ==password).FirstOrDefault();
            //}

            var tokendomain = new UserModel
            {
               UserName = username,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiryOn = expiredOn
            };
            WebApiToken tk = new WebApiToken();
            SchoolEntities sc = new SchoolEntities();
            tk = sc.WebApiTokens.Where(x => x.Username == username & x.Password == password).FirstOrDefault();
            if(tk.Username!=null)
            {
                tk.Username = tokendomain.UserName;
                tk.Authtoken = tokendomain.AuthToken;
                tk.IssuedOn = tokendomain.IssuedOn;
                tk.ExpiryOn = tokendomain.ExpiryOn;
            }
            sc.SaveChanges();
            return tokendomain;
          
        }
     public bool ValidateToken(string tokenValue)
        {
            throw new NotImplementedException();
        }
    }
}
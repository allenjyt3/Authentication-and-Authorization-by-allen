using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTokens.Models
{
    public interface IBusinessService
    {
       UserModel GenerateToken(string username, string password);
        bool ValidateToken(string tokenValue);
      
    }
}
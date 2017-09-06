using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTokens.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiryOn { get; set; }
    }
}
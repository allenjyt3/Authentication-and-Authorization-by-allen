using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTokens.Controllers
{
    public class AuthoriseController : ApiController
    {
        BusinessServices _tokenServices = new BusinessServices();
        private HttpResponseMessage GetAuthRoken(string username,string password)
        {
            var token = _tokenServices.GenerateToken(username, password);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", DateTime.Now.AddHours(2).ToString());
            response.Headers.Add("Access-Conrol-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
        [Route("Authenticating")]
        [HttpGet]
       public HttpResponseMessage Authentication(string username,string password)
        {
            return GetAuthRoken(username, password);
        }

        [AuthorizationRequiredFieldAttribute]
        [Route("InvalidUser")]

        public string GetDetails(string username)
        {
            return "Invalid";
        }

    }
}

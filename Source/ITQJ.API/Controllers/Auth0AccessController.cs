using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class Auth0AccessController : BaseController
    {
        public Auth0AccessController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet]
        public ActionResult GetAccessToken()
        {
            var subject = HttpContext.User.Claims.FirstOrDefault(c =>
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            var client = new RestClient("https://pidelo.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=UwxrODP9uHvOmeSebcGs4DsMQg3VhEI0&client_secret=M0JnUo4jGr1rVeNj7ZatqctGQYjWWVukR5Uk-3unav6md9fbfV28kEVp0ts1Dz4H&audience=https%3A%2F%2Fpidelo.auth0.com%2Fapi%2Fv2%2F", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var jsonResponse = JObject.Parse(response.Content);
            var access_token = jsonResponse["access_token"].Value<string>();

            return Ok(new
            {
                Message = "Ok",
                Result = access_token
            });
        }
    }
}

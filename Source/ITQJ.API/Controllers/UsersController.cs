using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
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
    public class UsersController : BaseController
    {
        public UsersController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet]
        public ActionResult GetCurrentlyLoggedInUser()
        {
            var subject = HttpContext.User.Claims.FirstOrDefault(c =>
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            //subject = subject.Split('|').Last();

            var user = this._appDBContext.Users
                .FirstOrDefault(x => x.Subject == subject);

            if (user is null)
            {
                var clientAccess = new RestClient("https://pidelo.auth0.com/oauth/token");
                var requestToken = new RestRequest(Method.POST);
                requestToken.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                requestToken.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=UwxrODP9uHvOmeSebcGs4DsMQg3VhEI0&client_secret=M0JnUo4jGr1rVeNj7ZatqctGQYjWWVukR5Uk-3unav6md9fbfV28kEVp0ts1Dz4H&audience=https%3A%2F%2Fpidelo.auth0.com%2Fapi%2Fv2%2F", ParameterType.RequestBody);
                IRestResponse responseAccess = clientAccess.Execute(requestToken);
                var jsonResponse = JObject.Parse(responseAccess.Content);
                var access_token = jsonResponse["access_token"].Value<string>();

                var clientInfo = new RestClient($"https://pidelo.auth0.com/api/v2/users/{subject}");
                var requestInfo = new RestRequest(Method.GET);
                requestInfo.AddHeader("Content-Type", "application/json");
                requestInfo.AddHeader("Authorization", $"Bearer {access_token}");

                IRestResponse response = clientInfo.Execute(requestInfo);
                var jsonObject = JObject.Parse(response.Content);

                var recivedUser = new UserResponseDTO
                {
                    Id = Guid.NewGuid(),
                    Email = jsonObject["email"].Value<string>(),
                    Role = "Desconosido"
                };

                return Ok(new
                {
                    Message = "El usuario no esta registrado en el API",
                    Result = recivedUser
                });
            }

            var userModel = this._mapper.Map<UserResponseDTO>(user);

            return Ok(new
            {
                Message = "Ok",
                Result = userModel
            });
        }

        [HttpPost]
        public ActionResult RegisterUser([FromBody] UserCreateDTO user)
        {
            var subject = HttpContext.User.Claims.FirstOrDefault(c =>
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            //subject = subject.Split('|').Last();

            if (this._appDBContext.Users.Any(x => x.Subject == subject && x.DeletedFlag == false))
                return Ok(new { Message = "Este usuario ya esta registrado.", Result = new UserResponseDTO() });
            else if (this._appDBContext.Users.Any(x => x.Subject == subject && x.DeletedFlag != false))
                return Ok(new { Message = "Este usuario esta desactivado.", Result = new UserResponseDTO() });

            var newUser = new User
            {
                Subject = subject,
                Email = user.Email,
                Role = user.Role,
            };

            var tempUser = this._appDBContext.Users.Add(newUser);
            this._appDBContext.SaveChanges();

            var userModel = this._mapper.Map<UserResponseDTO>(tempUser.Entity);


            return Ok(new
            {
                Message = "Ok",
                Result = userModel
            });
        }

        [HttpPatch]
        public ActionResult DeactivateUser()
        {
            var subject = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            var user = this._appDBContext.Users
                .FirstOrDefault(x => x.Subject == subject && x.DeletedFlag == false);

            if (user is null)
                return NotFound(new { Error = "El recurso no ha sido encontrado." });

            user.DeletedFlag = true;

            this._appDBContext.Users.Update(user);
            this._appDBContext.SaveChanges();

            return Ok(new
            {
                Message = "Ok"
            });
        }
    }

}

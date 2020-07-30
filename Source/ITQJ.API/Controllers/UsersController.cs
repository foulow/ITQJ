using IdentityModel;
using ITQJ.Domain.DTOs;
using ITQJ.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ITQJ.Domain.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        public UsersController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [Authorize]
        [HttpGet("{userName}")]
        public ActionResult GetUser([FromRoute] string userName)
        {
            var user = this._appDBContext.Users
                .Include(i => i.Role)
                .Include(i => i.Messages)
                .FirstOrDefault(x => x.UserName == userName);

            if (user is null)
                return NotFound(new { Error = "El recurso no ha sido encontrado." });

            var userModel = this._mapper.Map<UserResponseDTO>(user);

            return Ok(new
            {
                Message = "Ok",
                Result = userModel
            });
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserCreateDTO userData)
        {

            if (this._appDBContext.Users.Any(x => x.UserName == userData.UserName))
                return BadRequest(new { Error = $"El nombre de usuario '{userData.UserName}' no esta disponible." });
            userData.Password = userData.Password.ToSha256();

            var newUser = this._mapper.Map<User>(userData);

            var tempUser = this._appDBContext.Users.Add(newUser);
            this._appDBContext.SaveChanges();

            var userModel = this._mapper.Map<UserResponseDTO>(tempUser.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = userModel
            });
        }
        // TODO: CreateUser, UpdateUser, DeleteUser.
    }

}

using ITQJ.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet("{userName}")]
        public ActionResult GetUser([FromRoute] string userName)
        {
            var user = this._appDBContext.Users
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

        // TODO: CreateUser, UpdateUser, DeleteUser.
    }

}

using ITQJ.Domain.DTOs;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [HttpGet]
        public IActionResult Register([FromQuery] string userName)
        {
            var user = new UserVM
            {
                Email = userName,
                Role = "Desconosido"
            };
            user.Roles = new List<string> { "Profesional", "Contratista" };

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserVM user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var newUser = await CallSecuredApiPOSTAsync<UserCreateDTO>("/api/users/", user);

            return RedirectToAction("Index", "Home");
        }

    }
}

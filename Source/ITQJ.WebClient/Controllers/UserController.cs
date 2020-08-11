using ITQJ.Domain.DTOs;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Register()
        {
            var userCredentials = GetUserCredentials();

            var user = new UserVM
            {
                Email = userCredentials.Email,
                Role = userCredentials.Role
            };
            user.Roles = new List<string> { "Profesional", "Contratista" };

            return View(user);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(UserVM user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var newUser = await CallApiPOSTAsync<UserCreateDTO>(uri: "/api/users/", body: user, isSecured: true);

            return RedirectToAction("Register", "PersonalInfo");
        }

    }
}

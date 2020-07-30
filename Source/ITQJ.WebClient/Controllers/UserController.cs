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
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<IActionResult> Register()
        {
            var user = new UserVM();
            user.Roles = await GetRoles();

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserVM user)
        {
            if (!ModelState.IsValid)
            {
                user.Roles = await GetRoles();
                return View(user);
            }

            var newuser = await CallApiPOSTAsync<UserCreateDTO>("/api/users/", user);

            return RedirectToAction("LogIn");
        }

        private async Task<List<RoleDTO>> GetRoles()
        {
            return await CallApiGETAsync<List<RoleDTO>>("/api/roles");
        }
    }
}

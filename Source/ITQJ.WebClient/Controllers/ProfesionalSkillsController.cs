using ITQJ.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class ProfesionalSkillsController : BaseController
    {
        public ProfesionalSkillsController(IServiceProvider serviceProvider) : base(serviceProvider) { }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EdictSkills(string userName)
        {
            var profesionalSkills = await CallApiGETAsync<ProfesionalSkillResponseDTO>(uri: "/api/ProfesionalSkills/" + userName, isSecured: true);

            if (profesionalSkills == null)
                return PageNotFound();

            return View(profesionalSkills);
        }


    }
}
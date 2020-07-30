using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ITQJ.Domain.DTOs;

namespace ITQJ.WebClient.Controllers
{
    public class ProfesionalSkillsController : BaseController
    {
        public ProfesionalSkillsController(IServiceProvider serviceProvider) : base(serviceProvider) { }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EdictSkills()
        {
            var profesionalSkills = await CallApiGETAsync<ProfesionalSkillResponseDTO>("/api/ProfesionalSkills/" + userName);

            if (profesionalSkills == null)
                return PageNotFound();

            return View(profesionalSkills);
        }


    }
}
using ITQJ.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProfesionalSkillsController : BaseController
    {
        public ProfesionalSkillsController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet("{personalInfoId}")]
        public ActionResult GetProfesionalSkills([FromRoute] int personalInfoId)
        {
            var profesionalSkills = this._appDBContext.ProfesionalSkills
                .Where(x => x.PersonalInfoId == personalInfoId)
                .ToList();
            var profesionalSkillModels = this._mapper
                .Map<IEnumerable<ProfesionalSkill>>(profesionalSkills);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = profesionalSkillModels.Count(),
                Result = profesionalSkillModels
            });
        }
    }
}

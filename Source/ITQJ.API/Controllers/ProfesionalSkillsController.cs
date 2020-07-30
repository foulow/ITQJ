using ITQJ.Domain.DTOs;
using ITQJ.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.Domain.Controllers
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

        [HttpPost]
        public ActionResult RegisterProfesionalSkills([FromBody] List<ProfesionalSkillCreateDTO> profesionalSkills)
        {
            var newProfesionalSkills = new List<ProfesionalSkill>();
            this._mapper.Map<List<ProfesionalSkillCreateDTO>, List<ProfesionalSkill>>(
                profesionalSkills, newProfesionalSkills);

            foreach (var profesionalSkill in newProfesionalSkills)
            {
                var tempProfecionalSkills = _appDBContext
                    .ProfesionalSkills.Add(profesionalSkill);
            }
            this._appDBContext.SaveChanges();

            var profesionalSkillModels = this._mapper
                .Map<List<ProfesionalSkillCreateDTO>>(newProfesionalSkills);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = profesionalSkillModels.Count(),
                Result = profesionalSkillModels
            });
        }
    }
}

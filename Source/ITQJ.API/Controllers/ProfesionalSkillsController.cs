using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult GetProfesionalSkills([FromRoute] string personalInfoId)
        {
            var personalInfoIdGuid = Guid.Parse(personalInfoId);

            var profesionalSkills = this._appDBContext.ProfesionalSkills
                .Include(i => i.Skill)
                .Where(x => x.PersonalInfoId == personalInfoIdGuid)
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
        public ActionResult RegisterProfesionalSkill([FromBody] ProfesionalSkillCreateDTO profesionalSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro de skills de usuario invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var newProfesionalSkill = this._mapper.Map<ProfesionalSkill>(profesionalSkill);

            if (newProfesionalSkill == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var temporalProfesionalSkill = this._appDBContext.ProfesionalSkills.Add(newProfesionalSkill);
            this._appDBContext.SaveChanges();

            var profesionalSkillModel = this._mapper.Map<ProfesionalSkillCreateDTO>(temporalProfesionalSkill.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = profesionalSkillModel
            });
        }

        [HttpPost]
        public ActionResult RegisterProfesionalSkills([FromBody] List<ProfesionalSkillCreateDTO> profesionalSkills)
        {
            var newProfesionalSkills = this._mapper.Map<List<ProfesionalSkill>>(profesionalSkills);

            if (newProfesionalSkills == null)
                return BadRequest(new { Error = "No se enviaros los datos esperados." });

            _appDBContext.ProfesionalSkills.AddRange(newProfesionalSkills);
            this._appDBContext.SaveChanges();

            return Ok(new
            {
                Message = "Ok"
            });
        }
    }
}

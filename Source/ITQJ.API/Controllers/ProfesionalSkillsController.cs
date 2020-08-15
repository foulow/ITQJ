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
        public ActionResult GetProfesionalSkills([FromRoute] Guid personalInfoId)
        {
            if (personalInfoId == null || personalInfoId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(personalInfoId)} no puede ser nulo." });

            var profesionalSkills = this._appDBContext.ProfesionalSkills
                .Include(i => i.Skill)
                .Where(x => x.PersonalInfoId == personalInfoId && x.Percentage > 0)
                .ToList();

            if (profesionalSkills != null && profesionalSkills.Count > 0)
            {
                var profesionalSkillModels = this._mapper
                    .Map<List<ProfesionalSkill>>(profesionalSkills);

                return Ok(new
                {
                    Message = "Ok",
                    ResultCount = profesionalSkillModels.Count(),
                    Result = profesionalSkillModels
                });
            }
            else
            {
                return NotFound(new
                {
                    Message = "Error: no se encontro ningun skill registrado para este usuario ."
                });
            }
        }


        [HttpPost]
        public ActionResult RegisterProfesionalSkill([FromBody] ProfesionalSkillCreateDTO profesionalSkillData)
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

            var newProfesionalSkill = this._mapper.Map<ProfesionalSkill>(profesionalSkillData);

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

        [HttpPost("group")]
        public ActionResult RegisterProfesionalSkills([FromBody] List<ProfesionalSkillCreateDTO> profesionalSkillsData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro del proyecto son invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var temp = profesionalSkillsData.FirstOrDefault(x => x.PersonalInfoId != null);

            if (temp == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var skills = this._appDBContext.Skills.Where(x => x.DeletedFlag != true).ToList();

            foreach (var skill in skills)
            {
                if (null != profesionalSkillsData.FirstOrDefault(x => x.SkillId == skill.Id))
                    continue;

                profesionalSkillsData.Add(new ProfesionalSkillCreateDTO
                {
                    SkillId = skill.Id,
                    PersonalInfoId = temp.PersonalInfoId,
                    Percentage = 0
                });
            }

            var newProfesionalSkills = this._mapper.Map<List<ProfesionalSkill>>(profesionalSkillsData);

            this._appDBContext.ProfesionalSkills.AddRange(newProfesionalSkills);
            this._appDBContext.SaveChanges();

            return Ok(new
            {
                Message = "Ok"
            });
        }

        [HttpPut("{profesionalSkillId}")]
        public ActionResult EditProfesionalSkill([FromRoute] Guid profesionalSkillId, [FromBody] ProfesionalSkillUpdateDTO profesionalSkillData)
        {
            if (profesionalSkillId == null || profesionalSkillId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(profesionalSkillId)} no puede ser nulo." });

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro de skills de usuario invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var profesionalSkillToUpdate = this._appDBContext.ProfesionalSkills
                .FirstOrDefault(item => item.Id == profesionalSkillId);

            if (profesionalSkillToUpdate != null)
            {
                this._mapper.Map<ProfesionalSkillUpdateDTO, ProfesionalSkill>(profesionalSkillData, profesionalSkillToUpdate);

                var tempProfesionalSkill = this._appDBContext.ProfesionalSkills.Update(profesionalSkillToUpdate);
                this._appDBContext.SaveChanges();

                var profesionalSkillModel = this._mapper
                    .Map<ProfesionalSkillResponseDTO>(tempProfesionalSkill.Entity);

                return Ok(new
                {
                    Message = "Ok",
                    Result = profesionalSkillModel
                });
            }
            else
            {
                return NotFound(new { Message = "El recurso a actualizar no ha sido encontrado." });
            }
        }

        [HttpPut("group/{personalInfoId}")]
        public ActionResult EditProfesionalSkills([FromRoute] Guid personalInfoId, [FromBody] List<ProfesionalSkillResponseDTO> profesionalSkillsData)
        {
            if (personalInfoId == null || personalInfoId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(personalInfoId)} no puede ser nulo." });

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro del proyecto son invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var profesionalSkillsToUpdate = this._appDBContext.ProfesionalSkills
                .Where(item => item.PersonalInfoId == personalInfoId)
                .ToList();

            if (profesionalSkillsToUpdate != null && profesionalSkillsToUpdate.Count > 0)
            {
                foreach (var profesionalSkill in profesionalSkillsData)
                {
                    var profesionalSkillToUpdate = profesionalSkillsToUpdate.FirstOrDefault(x => x.Id == profesionalSkill.Id);

                    this._mapper.Map<ProfesionalSkillResponseDTO, ProfesionalSkill>(profesionalSkill, profesionalSkillToUpdate);
                }

                //this._mapper.Map<List<ProfesionalSkillUpdateDTO>, List<ProfesionalSkill>>(profesionalSkillsData, profesionalSkillsToUpdate);

                this._appDBContext.UpdateRange(profesionalSkillsToUpdate);
                this._appDBContext.SaveChanges();

                return Ok(new
                {
                    Message = "Ok",
                });
            }
            else
            {
                return NotFound(new { Message = "Los recurso a actualizar no han sido encontrado." });
            }
        }
    }
}

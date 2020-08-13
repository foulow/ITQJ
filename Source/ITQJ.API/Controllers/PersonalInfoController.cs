using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PersonalInfoController : BaseController
    {
        public PersonalInfoController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet("{userId}")]
        public ActionResult GetPersonalInfo([FromRoute] Guid userId)
        {
            if (userId == null)
                return BadRequest(new { Message = $"Error: el parametro {nameof(userId)} no puede ser nulo." });

            var personalInfo = this._appDBContext.PersonalInfos
                .Include(i => i.User)
                .Include(i => i.LegalDocument)
                .Include(i => i.ProfesionalSkills)
                .FirstOrDefault(x => x.UserId == userId);

            if (personalInfo is null)
                return NotFound(new { Error = "El recurso no ha sido encontrado." });

            var personalInfoModel = this._mapper.Map<PersonalInfoResponseDTO>(personalInfo);

            return Ok(new
            {
                Message = "Ok",
                Result = personalInfoModel
            });
        }

        [HttpPost]
        public ActionResult RegisterPersonalInfo([FromBody] PersonalInfoCreateDTO personalInfoData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro de los datos personales son invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var newPersonalInfo = this._mapper.Map<PersonalInfo>(personalInfoData);

            var tempPersonalInfo = this._appDBContext.PersonalInfos.Add(newPersonalInfo);
            this._appDBContext.SaveChanges();

            var personalInfoModel = this._mapper.Map<PersonalInfoResponseDTO>(tempPersonalInfo.Entity);
            
            var tempUser = this._appDBContext.Users.FirstOrDefault(x => x.Id == personalInfoModel.UserId);
            personalInfoModel.User = this._mapper.Map<UserResponseDTO>(tempUser);

            return Ok(new
            {
                Message = "Ok",
                Result = personalInfoModel
            });
        }

        [HttpPut("{personalInfoId}")]
        public ActionResult EditPersonalInfo([FromRoute] Guid personalInfoId, [FromBody] PersonalInfoUpdateDTO personalInfoData)
        {
            var personalInfoToUpdate = this._appDBContext.PersonalInfos
                .FirstOrDefault(item => item.Id == personalInfoId);

            if (personalInfoToUpdate != null)
            {
                this._mapper.Map<PersonalInfoUpdateDTO, PersonalInfo>(personalInfoData, personalInfoToUpdate);

                var tempPersonalInfo = this._appDBContext.PersonalInfos.Update(personalInfoToUpdate);
                this._appDBContext.SaveChanges();

                var personalInfoModel = this._mapper.Map<PersonalInfoCreateDTO>(tempPersonalInfo.Entity);

                return Ok(new
                {
                    Message = "Ok",
                    Result = personalInfoModel
                });
            }
            else
            {
                return NotFound(new { Message = "El recurso a actualizar no ha sido encontrado." });
            }
        }
    }
}

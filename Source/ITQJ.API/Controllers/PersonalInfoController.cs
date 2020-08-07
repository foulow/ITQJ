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
            var newPersonalInfo = this._mapper.Map<PersonalInfo>(personalInfoData);
            if (personalInfoData.UserId != null)
            {
                var subject = HttpContext.User.Claims.FirstOrDefault(c =>
                    c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

                var user = this._appDBContext.Users
                    .FirstOrDefault(x => x.Subject == subject);

                newPersonalInfo.UserId = user.Id;
            }

            var tempPersonalInfo = this._appDBContext.PersonalInfos.Add(newPersonalInfo);
            this._appDBContext.SaveChanges();

            var personalInfoModel = this._mapper.Map<UserResponseDTO>(tempPersonalInfo.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = personalInfoModel
            });
        }
    }
}

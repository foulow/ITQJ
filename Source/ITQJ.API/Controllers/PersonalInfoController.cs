using ITQJ.Domain.DTOs;
using ITQJ.Domain.Models;
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
        public ActionResult GetPersonalInfo([FromRoute] string userId)
        {
            var userIdGuid = Guid.Parse(userId);

            var personalInfo = this._appDBContext.PersonalInfos
                .Include(i => i.User)
                .Include(i => i.LegalDocument)
                .Include(i => i.ProfesionalSkills)
                .FirstOrDefault(x => x.UserId == userIdGuid);
            var personalInfoModel = this._mapper.Map<PersonalInfo>(personalInfo);

            return Ok(new
            {
                Message = "Ok",
                Result = personalInfoModel
            });
        }

        [HttpPost]
        public ActionResult RegisterPersonalInfo([FromBody] PersonalInfoCreateDTO personalInfoData)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var newPersonalInfo = this._mapper.Map<PersonalInfo>(personalInfoData);
            newPersonalInfo.UserId = Guid.Parse(userId);

            var tempPersonalInfo = this._appDBContext.PersonalInfos.Add(newPersonalInfo);
            this._appDBContext.SaveChanges();

            var personalInfoModel = this._mapper.Map<UserResponseDTO>(tempPersonalInfo.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = personalInfoModel
            });
        }

        [HttpPut("{Id}")]
        public ActionResult EditPersonalInfo([FromRoute] string Id, [FromBody] PersonalInfoCreateDTO personalInfoData)
        {

            var newPersonalInfo = this._mapper.Map<PersonalInfo>(personalInfoData);
            newPersonalInfo.UserId = Guid.Parse(Id);

            var entity = this._appDBContext.PersonalInfos.FirstOrDefault(item => item.Id == Guid.Parse(Id));

            if (entity != null)
            {
                var tempPersonalInfo = this._appDBContext.PersonalInfos.Update(newPersonalInfo);
                this._appDBContext.SaveChanges();

                var personalInfoModel = this._mapper.Map<PersonalInfoCreateDTO>(tempPersonalInfo.Entity);

                return Ok(new
                {
                    Message = "Ok",
                    Result = personalInfoModel
                });
            }
            else
                return Ok(new
                {
                    Message = "Ok"
                });


        }

    }
}

using ITQJ.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ITQJ.Domain.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PersonalInfoController : BaseController
    {
        public PersonalInfoController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet("{userId}")]
        public ActionResult GetPersonalInfo([FromRoute] string userName)
        {
            var user = this._appDBContext.Users
                .FirstOrDefault(x => x.UserName == userName);

            var personalInfo = this._appDBContext.PersonalInfos
                .Include(i => i.User)
                .Include(i => i.LegalDocument)
                .Include(i => i.ProfesionalSkills)
                .FirstOrDefault(x => x.UserId == user.Id);
            var personalInfoModel = this._mapper.Map<PersonalInfo>(personalInfo);

            return Ok(new
            {
                Message = "Ok",
                Result = personalInfoModel
            });
        }
    }
}

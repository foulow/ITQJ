using ITQJ.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult GetPersonalInfo([FromRoute] int userId)
        {
            var personalInfo = this._appDBContext.PersonalInfos.FirstOrDefault(x => x.UserId == userId);
            var personalInfoModel = this._mapper.Map<PersonalInfo>(personalInfo);

            return Ok(new
            {
                Message = "Ok",
                Result = personalInfoModel
            });
        }
    }
}

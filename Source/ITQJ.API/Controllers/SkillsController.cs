using ITQJ.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.Domain.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class SkillsController : BaseController
    {
        public SkillsController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet]
        public ActionResult Get()
        {
            var skills = this._appDBContext.Skills
                .Where(x => true)
                .ToList();
            var skillModels = this._mapper.Map<IEnumerable<SkillDTO>>(skills);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = skillModels.Count(),
                Result = skillModels
            });
        }
    }
}

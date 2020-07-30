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
    public class RolesController : BaseController
    {
        public RolesController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet]
        public ActionResult Get()
        {
            var roles = this._appDBContext.Roles
                .Where(x => true)
                .ToList();
            var rolesModels = this._mapper.Map<IEnumerable<RoleDTO>>(roles);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = rolesModels.Count(),
                Result = rolesModels
            });
        }
    }
}

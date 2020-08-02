using ITQJ.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class DocumentTypesController : BaseController
    {
        public DocumentTypesController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet]
        public ActionResult Get()
        {
            var documentTypes = this._appDBContext.DocumentTypes
                .Where(x => true)
                .ToList();
            var documentTypeModels = this._mapper.Map<IEnumerable<DocumentTypeDTO>>(documentTypes);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = documentTypeModels.Count(),
                Result = documentTypeModels
            });
        }
    }
}

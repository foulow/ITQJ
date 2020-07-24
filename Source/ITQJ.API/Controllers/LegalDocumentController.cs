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
    public class LegalDocumentController : BaseController
    {
        public LegalDocumentController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet("{legalDocumentId}")]
        public ActionResult GetPersonalInfo([FromRoute] int legalDocumentId)
        {
            var legalDocument = this._appDBContext.LegalDocuments.FirstOrDefault(x => x.Id == legalDocumentId);
            var legalDocumentModel = this._mapper.Map<LegalDocument>(legalDocument);

            return Ok(new
            {
                Message = "Ok",
                Result = legalDocumentModel
            });
        }
    }
}

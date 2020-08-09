using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
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
        public ActionResult GetPersonalInfo([FromRoute] Guid legalDocumentId)
        {
            var legalDocument = this._appDBContext.LegalDocuments.FirstOrDefault(x => x.Id == legalDocumentId);
            var legalDocumentModel = this._mapper.Map<LegalDocument>(legalDocument);

            return Ok(new
            {
                Message = "Ok",
                Result = legalDocumentModel
            });
        }

        [HttpPost]
        public ActionResult RegisterProfesionalSkill([FromBody] LegalDocumentCreateDTO legalDocument)
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

            var newLegalDocument = this._mapper.Map<LegalDocument>(legalDocument);

            if (newLegalDocument == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var temporalProfesionalSkill = this._appDBContext.LegalDocuments.Add(newLegalDocument);
            this._appDBContext.SaveChanges();

            var legalDocumentModel = this._mapper.Map<LegalDocumentResponseDTO>(temporalProfesionalSkill.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = legalDocumentModel
            });
        }
    }
}

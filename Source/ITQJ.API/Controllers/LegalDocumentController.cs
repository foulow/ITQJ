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
            if (legalDocumentId == null || legalDocumentId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(legalDocumentId)} no puede ser nulo." });

            var legalDocument = this._appDBContext.LegalDocuments.FirstOrDefault(x => x.Id == legalDocumentId);
            var legalDocumentModel = this._mapper.Map<LegalDocument>(legalDocument);

            return Ok(new
            {
                Message = "Ok",
                Result = legalDocumentModel
            });
        }

        [HttpPost]
        public ActionResult RegisterLegalDocument([FromBody] LegalDocumentCreateDTO legalDocument)
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

        [HttpPut("{legalDocumentId}")]
        public ActionResult EditLegalDocument([FromRoute] Guid legalDocumentId, [FromBody] LegalDocumentUpdateDTO lecalDocumentData)
        {
            if (legalDocumentId == null || legalDocumentId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(legalDocumentId)} no puede ser nulo." });

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro de skills de usuario invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var legalDocumentToUpdate = this._appDBContext.LegalDocuments
                .FirstOrDefault(item => item.Id == legalDocumentId);

            if (legalDocumentToUpdate != null)
            {
                this._mapper.Map<LegalDocumentUpdateDTO, LegalDocument>(lecalDocumentData, legalDocumentToUpdate);

                var tempLegalDocument = this._appDBContext.LegalDocuments.Update(legalDocumentToUpdate);
                this._appDBContext.SaveChanges();

                var personalInfoModel = this._mapper.Map<LegalDocumentResponseDTO>(tempLegalDocument.Entity);

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

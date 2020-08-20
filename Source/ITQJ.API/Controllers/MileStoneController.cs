using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MileStoneController : BaseController
    {
                public MileStoneController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [HttpGet("{projectId}")]
        public ActionResult GetMileStones([FromRoute] Guid projectId)
        {
            if (projectId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });
            
            var mileStones = this._appDBContext.MileStones
                .Where(x => x.ProjectId == projectId)
                .ToList();

            if (mileStones is null)
                return NotFound(new { Message = "El recurso no ha sido encontrado."});

            var mileStonesModel = this._mapper
                .Map<List<MileStoneResponseDTO>>(mileStones);

            return Ok(new
            {
                Message = "Ok",
                Result = mileStonesModel
            });
        }

        [HttpPost]
        public ActionResult RegisterMileStone([FromBody] MileStoneCreateDTO mileStoneData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro del proyecto son invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var newMileStone = this._mapper.Map<MileStone>(mileStoneData);

            if (newMileStone == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });
            
            var tempMileStone = this._appDBContext.MileStones.Add(newMileStone);
            this._appDBContext.SaveChanges();

            var mileStoneModel = this._mapper.Map<MileStoneResponseDTO>(tempMileStone.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = mileStoneModel
            });
        }
    }
}
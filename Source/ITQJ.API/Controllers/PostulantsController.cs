
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
    public class PostulantsController:BaseController
    {

        public PostulantsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet("{projectId}")]
        public ActionResult GetPostulants([FromRoute] Guid projectId)
        {
            if(projectId == null || projectId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            var postulants = this._appDBContext.Postulants
                .Include(i => i.User)
                .Where(x => x.ProjectId == projectId)
                .ToList();

            if(postulants != null && postulants.Count > 0)
            {
                var postulantsModel = this._mapper.Map<IEnumerable<PostulantResponseDTO>>(postulants);

                return Ok(new
                {

                    Message = "OK",
                    Result = postulantsModel

                });
            }

            return NotFound(new
            {
                Message = "No existen postulaciones para este proyecto actualmente."
            });
        }

        [HttpGet("mypostulations/{userId}")]
        public ActionResult GetPostulantations([FromRoute] Guid userId, [FromQuery] int pageIndex = 1, [FromQuery] int maxResults = 5)
        {
            if(userId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(userId)} no puede ser nulo." });

            if(pageIndex < 1)
                return BadRequest(new { Error = $"Error: value for pageIndex={pageIndex} is lower than the minimund expected." });

            if(maxResults < 5)
                return BadRequest(new { Error = $"Error: value for maxResults={maxResults} is lower than the minimund expected." });

            var reviews = this._appDBContext.Postulants
                .Include(i => i.Project)
                .Where(x => x.UserId == userId && x.DeletedFlag == false)
                .Skip((pageIndex - 1) * maxResults)
                .Take(maxResults)
                .ToList();

            var postulantsCount = this._appDBContext.Postulants
                .Where(x => x.UserId == userId && x.DeletedFlag == false)
                .Count();

            var pagesCount = Math.Ceiling((float)postulantsCount / (float)maxResults);

            var postulantsModel = this._mapper.Map<IEnumerable<PostulantResponseDTO>>(reviews);

            return Ok(new
            {
                Message = "Ok",
                Result = new
                {
                    TotalCount = postulantsCount,
                    ResultCount = postulantsModel.Count(),
                    TotalPages = pagesCount,
                    PageIndex = pageIndex,
                    Postulants = postulantsModel
                }
            });
        }

        [HttpPost]
        public ActionResult RegisterPostulant([FromBody] PostulantCreateDTO postulantCreateDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro del proyecto son invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var newPostulant = _mapper.Map<Postulant>(postulantCreateDTO);

            if(newPostulant == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var repuesta = this._appDBContext.Postulants.Add(newPostulant);
            this._appDBContext.SaveChanges();

            var postulantsModel = this._mapper.Map<PostulantResponseDTO>(repuesta.Entity);

            return Ok(new
            {

                Message = "OK",
                Result = postulantsModel

            });
        }

        [HttpPut("{postulantId}")]
        public ActionResult UpdatePostulant([FromRoute] Guid postulantId,[FromBody] PostulantUpdateDTO postulantData)
        {
            if(postulantId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(postulantId)} no puede ser nulo." });

            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro del proyecto son invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var postulantToUpdate = _appDBContext.Postulants.FirstOrDefault(x => x.Id == postulantId);
            
            if (postulantToUpdate != null)
            {
                postulantToUpdate.IsSelected = (postulantData.IsSelected) ?
                    postulantData.IsSelected : postulantToUpdate.IsSelected;
                postulantToUpdate.HasWorkReview = (postulantData.HasWorkReview) ?
                    postulantData.HasWorkReview : postulantToUpdate.HasWorkReview;
                postulantToUpdate.HasProyectReview = (postulantData.HasProyectReview) ?
                    postulantData.HasProyectReview : postulantToUpdate.HasProyectReview;
                
                this._appDBContext.Postulants.Update(postulantToUpdate);
                this._appDBContext.SaveChanges();

                var postulantsModel = _mapper.Map<PostulantResponseDTO>(postulantToUpdate);

                return Ok(new
                {
                    Message = "OK",
                    Result = postulantsModel
                });
            }
            else
            {
                return NotFound(new { Error = "No se encontro el postulante a actualizar." });
            }
        }
    }
}

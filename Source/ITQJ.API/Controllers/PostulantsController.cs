
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
    public class PostulantsController : BaseController
    {

        public PostulantsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet("mypostulations/{userId}")]
        public ActionResult GetPostulantations([FromRoute] Guid userId, [FromQuery] int pageIndex = 1, [FromQuery] int maxResults = 10)
        {
            if (userId == null)
                return BadRequest(new { Message = $"Error: el parametro {nameof(userId)} no puede ser nulo." });

            if (pageIndex < 1)
                return BadRequest(new { Error = $"Error: value for pageIndex={pageIndex} is lower than the minimund expected." });

            if (maxResults < 10)
                return BadRequest(new { Error = $"Error: value for maxResults={maxResults} is lower than the minimund expected." });

            var reviews = this._appDBContext.Postulants
                .Include(i => i.Project)
                .Where(x => x.UserId == userId && x.DeletedFlag == false)
                .Skip((pageIndex - 1) * maxResults)
                .Take(maxResults)
                .ToList();

            var reviewsCount = this._appDBContext.Postulants
                .Where(x => x.UserId == userId && x.DeletedFlag == false)
                .Count();

            var pagesCount = Math.Ceiling((float)reviewsCount / (float)maxResults);

            var reviewsModel = this._mapper.Map<IEnumerable<PostulantResponseDTO>>(reviews);

            return Ok(new
            {
                Message = "Ok",
                Result = new
                {
                    TotalCount = reviewsCount,
                    TotalPages = pagesCount,
                    ResultCount = reviewsModel.Count(),
                    Reviews = reviewsModel
                }
            });
        }

        [HttpPost]
        public ActionResult RegisterPostulant([FromBody] PostulantCreateDTO postulantCreateDTO)
        {
            var newPostulant = _mapper.Map<Postulant>(postulantCreateDTO);

            if (newPostulant == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var repuesta = _appDBContext.Postulants.Add(newPostulant);
            _appDBContext.SaveChanges();

            var postulantsModel = _mapper.Map<PostulantResponseDTO>(repuesta.Entity);

            return Ok(new
            {

                Message = "OK",
                Result = postulantsModel

            });
        }
    }
}

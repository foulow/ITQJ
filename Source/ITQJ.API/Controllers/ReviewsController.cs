using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ReviewsController : BaseController
    {
        public ReviewsController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet("{userId}")]
        public ActionResult GetReviews([FromRoute] Guid userId, [FromQuery] int pageIndex = 1, [FromQuery] int maxResults = 10)
        {
            if (userId == null)
                return BadRequest(new { Message = $"Error: el {nameof(userId)} no puede ser nulo." });

            if (pageIndex < 1)
                return BadRequest(new { Message = $"Error: value for pageIndex={pageIndex} is lower than the minimund expected." });

            if (maxResults < 10)
                return BadRequest(new { Message = $"Error: value for maxResults={maxResults} is lower than the minimund expected." });

            var reviews = this._appDBContext.Reviews
                .Where(x => x.UserId == userId && x.DeletedFlag == false)
                .Skip((pageIndex - 1) * maxResults)
                .Take(maxResults)
                .ToList();

            var reviewsCount = this._appDBContext.Reviews
                .Where(x => x.UserId == userId && x.DeletedFlag == false)
                .Count();

            var pagesCount = Math.Ceiling((float)reviewsCount / (float)maxResults);

            var reviewsModel = this._mapper.Map<IEnumerable<ReviewResponseDTO>>(reviews);

            return Ok(new
            {
                Message = "Ok",
                Result = new
                {
                    TotalCount = reviewsCount,
                    ResultCount = reviewsModel.Count(),
                    TotalPages = pagesCount,
                    PageIndex = pageIndex,
                    Reviews = reviewsModel
                }
            });
        }

        [HttpGet("pending/{userId}")]
        public ActionResult GetPendingReviews([FromRoute] Guid userId, [FromQuery] string role)
        {
            if (userId == null)
                return BadRequest(new { Message = $"Error: el valor de {nameof(userId)} no puede ser nulo." });

            if (string.IsNullOrWhiteSpace(role))
                return BadRequest(new { Message = $"Error: el valor de {nameof(role)} no puede ser nulo." });

            var projectsToReview = new List<ProjectResponseDTO>();
            if (role == "Profesional")
            {
                var tempProjectsToReview = _appDBContext.Projects
                    .Include(i => i.User)
                    .Where(x =>
                           x.Postulants.Any(y =>
                                            y.ProjectId == x.Id &&
                                            y.IsSellected == true &&
                                            y.UserId == userId &&
                                            y.HasProyectReview == false) &&
                           x.IsOpen == false);

                projectsToReview = _mapper.Map<List<ProjectResponseDTO>>(tempProjectsToReview);
            }
            else if (role == "Contratista")
            {
                var tempProjectsToReview = _appDBContext.Projects
                    .Include(i => i.User)
                    .Where(x =>
                           x.Postulants.Any(y =>
                                            y.ProjectId == x.Id &&
                                            y.IsSellected == true &&
                                            y.HasWorkReview == false) &&
                           x.UserId == userId);

                projectsToReview = _mapper.Map<List<ProjectResponseDTO>>(tempProjectsToReview);
            }
            else
            {
                return Unauthorized(new
                {
                    Message = "Error: Intento de acceso fallido."
                });
            }

            return Ok(new
            {
                Message = "Ok",
                ResultCount = projectsToReview.Count(),
                ProjectsToReview = projectsToReview
            });
        }

        [HttpPost]
        public ActionResult CreateReview([FromBody] ReviewCreateDTO reviewData)
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

            var newReview = this._mapper.Map<Review>(reviewData);

            if (newReview == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var tempReview = this._appDBContext.Reviews.Add(newReview);
            this._appDBContext.SaveChanges();

            var reviewModel = this._mapper.Map<ReviewResponseDTO>(tempReview.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = reviewModel
            });
        }
    }
}

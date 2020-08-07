using ITQJ.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                    TotalPages = pagesCount,
                    ResultCount = reviewsModel.Count(),
                    Reviews = reviewsModel
                }
            });
        }
    }
}

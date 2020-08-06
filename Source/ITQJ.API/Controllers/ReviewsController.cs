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
    public class ReviewsController : BaseController
    {
        public ReviewsController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet("{userName}")]
        public ActionResult GetReviews([FromRoute] string userName)
        {
            var user = this._appDBContext.Users
                .FirstOrDefault(x => x.Subject == userName);

            if (user is null)
                return NotFound(new { Error = "El recurso no ha sido encontrado." });

            var reviews = this._appDBContext.Reviews
                .Where(x => x.UserId == user.Id)
                .ToList();

            var reviewsModel = this._mapper.Map<IEnumerable<ReviewResponseDTO>>(reviews);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = reviewsModel.Count(),
                Result = reviewsModel
            });
        }
    }
}

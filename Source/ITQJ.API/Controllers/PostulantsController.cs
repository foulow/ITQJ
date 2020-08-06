
using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

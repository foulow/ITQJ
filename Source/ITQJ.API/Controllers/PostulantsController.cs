
using ITQJ.Domain.DTOs;
using ITQJ.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public ActionResult RegisterPostulant(PostulantCreateDTO postulantCreateDTO)
        {
            var newPostulant = _mapper.Map<Postulant>(postulantCreateDTO);

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

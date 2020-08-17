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
    public class MessagesController : BaseController
    {
        public MessagesController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [HttpGet("profesional/{projectId}")]
        public ActionResult GetPostulantMessages([FromRoute] Guid projectId,
            [FromQuery] Guid fromId,
            [FromQuery] Guid toId)
        {
            if (projectId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            if (fromId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(fromId)} no puede ser nulo." });

            if (toId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(toId)} no puede ser nulo." });

            var messages = this._appDBContext.Users
                .Include(i => i.Messages)
                .Where(x => x.Messages.Any(e => e.ProjectId == projectId &&
                                           e.FromUserId == fromId &&
                                           e.ToUserId == toId))
                .ToList();

            var messagesModel = this._mapper
                .Map<List<UserResponseDTO>>(messages);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = messagesModel.Count(),
                Result = messagesModel
            });
        }

        [HttpGet("contratist/{projectId}")]
        public ActionResult GetMessagesByProjectId([FromRoute] Guid projectId)
        {
            if (projectId == null || projectId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            var messages = this._appDBContext.Users
                .Include(i => i.Messages)
                .Where(x => x.Messages.Any(e => e.ProjectId == projectId))
                .ToList();

            var messagesModel = this._mapper
                .Map<List<UserResponseDTO>>(messages);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = messagesModel.Count(),
                Result = messagesModel
            });
        }

        [HttpPost]
        public ActionResult SendMessage([FromBody] MessageCreateDTO messageData)
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

            var newMessage = this._mapper.Map<Message>(messageData);

            if (newMessage == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var tempMessage = this._appDBContext.Messages.Add(newMessage);
            this._appDBContext.SaveChanges();

            var messageModel = this._mapper.Map<MessageResponseDTO>(tempMessage.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = messageModel
            });
        }
    }
}

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

        [HttpGet("{projectId}")]
        public ActionResult GetMessages([FromRoute] Guid projectId,
            [FromQuery] Guid fromId,
            [FromQuery] Guid toId)
        {
            if (projectId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            if (fromId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(fromId)} no puede ser nulo." });

            if (toId == default)
                return BadRequest(new { Message = $"Error: el parametro {nameof(toId)} no puede ser nulo." });

            var userMessages = this._appDBContext.Messages
                .Include(i => i.User)
                .Where(x =>
                       (x.ProjectId == projectId &&
                        x.FromUserId == fromId && 
                        x.ToUserId == toId) ||
                       (x.ProjectId == projectId &&
                        x.FromUserId == toId && 
                        x.ToUserId == fromId))
                .ToList();

            var messagesModel = this._mapper
                .Map<List<MessageResponseDTO>>(userMessages);

            return Ok(new
            {
                Message = "Ok",
                Result = messagesModel
            });
        }

        [HttpPost]
        public ActionResult RegisterMessage([FromBody] MessageCreateDTO messageData)
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

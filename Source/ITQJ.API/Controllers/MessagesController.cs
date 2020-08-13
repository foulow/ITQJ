using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
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
    public class MessagesController : BaseController
    {
        public MessagesController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [HttpGet("{projectId}")]
        public ActionResult GetMessagesByProjectId([FromRoute] Guid projectId)
        {
            var messages = this._appDBContext.Messages.Where(x => x.ProjectId == projectId).ToList();

            var messagesModel = this._mapper
                .Map<List<MessageResponseDTO>>(messages);

            return Ok(new
            {
                Message = "Ok",
                ResultCount = messagesModel.Count(),
                Result = messagesModel
            });
        }

        [HttpGet("{userId}")]
        public ActionResult GetMessagesByUserId([FromRoute] Guid userId)
        {
            var messages = this._appDBContext.Messages.Where(x => x.UserId == userId).ToList();

            var messagesModel = this._mapper
                .Map<List<MessageResponseDTO>>(messages);

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

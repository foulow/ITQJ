using ITQJ.WebClient.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ITQJ.WebClient.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet]
        public IActionResult GetErrorMessages()
        {
            var chatErrors = new Dictionary<string, string>
            {
                {nameof(Resources.InvalidUserName), Resources.InvalidUserName},
                {nameof(Resources.UserIsConnected), Resources.UserIsConnected},
                {nameof(Resources.UserIsDisconnected), Resources.UserIsDisconnected},
                {nameof(Resources.ConnectionLost), Resources.ConnectionLost},
                {nameof(Resources.UnableToSendTheMessage), Resources.UnableToSendTheMessage},
                {nameof(Resources.UnableToGetConnectedUsers), Resources.UnableToGetConnectedUsers},
            };

            return Ok(chatErrors);
        }
    }
}

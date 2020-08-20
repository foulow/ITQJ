using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Hubs
{
    public class ChatHub : Hub
    {
        protected readonly IHttpClientFactory _clientFactory;

        public ChatHub(IServiceProvider serviceProvider)
        {
            this._clientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        }

        #region Fields And Properties

        private static readonly object Locker = new object();

        private static List<UserResponseDTO> _connectedUsers;
        public static List<UserResponseDTO> ConnectedUsers
        {
            get
            {
                lock (Locker)
                {
                    return _connectedUsers ??= new List<UserResponseDTO>();
                }
            }
        }

        private static List<MessageResponseDTO> _currentMessage;
        public static List<MessageResponseDTO> CurrentMessages
        {
            get
            {
                lock (Locker)
                {
                    return _currentMessage ??= new List<MessageResponseDTO>();
                }
            }
        }

        #endregion

        #region Connect Methods

        public IActionResult Connect()
        {
            if (ConnectedUsers.Any(x => x.ConnectionId.Equals(Context.ConnectionId)))
                throw new InvalidOperationException(Resources.UserIsConnected);

            var user = CallApiGET<UserResponseDTO>(uri: "api/users", isSecured: true);
            user.ConnectionId = Context.ConnectionId;

            ConnectedUsers.Add(user);

            return new OkResult();
        }

        public void GetMessages(string projectId, string fromId, string toId)
        {
            if (!Guid.TryParse(projectId, out Guid result))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            if (!Guid.TryParse(fromId, out Guid fromUserGuid))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            if (!Guid.TryParse(toId, out Guid toUserGuid))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            var queryResult = new Dictionary<string, string>
            {
                { nameof(fromId), fromId },
                { nameof(toId), toId }
            };

            var messages = CallApiGET<List<MessageResponseDTO>>(uri: "api/messages/" + projectId + QueryString.Create(queryResult), isSecured: true);

            if (messages is null || messages.Count == 0)
                return;

            var userMessages = messages
                .Select(x => new
                {
                    fromUserId = x.FromUserId,
                    toUserId = x.ToUserId,
                    userName = (x.FromUserId == fromUserGuid)? "Yo" : x.User.UserName,
                    text = x.Text,
                    messageDate = x.MessageDate
                });

            Clients.Caller.SendAsync(ChatHubMethods.ReceiveConversation, userMessages).Wait();           
        }

        public void GetPostulants(string projectId)
        {
            if (!Guid.TryParse(projectId, out Guid result))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            var postulants = CallApiGET<List<PostulantResponseDTO>>(uri: "api/postulants/" + projectId, isSecured: true);
            
            if (postulants is null || postulants.Count == 0)
                return;
            
            var postulantsInfo = postulants
                .Select(x => new
                {
                    id = x.User.Id,
                    userName = x.User.UserName,
                    messageCount = 0
                });
            
            Clients.Caller.SendAsync(ChatHubMethods.UpdateConnectedUsers, postulantsInfo).Wait();           
        }
        #endregion

        #region Message Methods

        public IActionResult SendPrivateMessage(MessageResponseDTO message)
        {
            var newMessage = CallApiPOST<MessageResponseDTO>(uri: "api/messages/", body: message, isSecured: true);

            var toUser = ConnectedUsers.FirstOrDefault(x => x.Id == message.ToUserId);
            if (toUser != null)
            {
                var sendMessage = new {
                    fromUserId = newMessage.FromUserId,
                    toUserId = newMessage.ToUserId,
                    userName = newMessage.User.UserName,
                    text = newMessage.Text,
                    messageDate = newMessage.MessageDate
                };

                Clients.Client(toUser.ConnectionId)
                    .SendAsync(ChatHubMethods.ReceiveMessage, sendMessage).Wait();
                Clients.Client(toUser.ConnectionId)
                    .SendAsync(ChatHubMethods.UpdateUnreadMessages, sendMessage.toUserId).Wait();
            }

            return new OkResult();
        }
        #endregion

        #region Overridden Methods

        public override Task OnConnectedAsync()
        {
            var user = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (user == null)
                return base.OnConnectedAsync();

            ConnectedUsers.Remove(user);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (user == null)
                return base.OnDisconnectedAsync(exception);

            ConnectedUsers.Remove(user);
            return base.OnDisconnectedAsync(exception);
        }

        #endregion

        #region Auxiliary Methods
        private T CallApiGET<T>(string uri, bool isSecured) where T : class
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"]?.ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Problem accessing the API");
            }

            return null;
        }

        private T CallApiPOST<T>(string uri, T body, bool isSecured) where T : class
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"]?.ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Problem accessing the API");
            }

            return null;
        }
        #endregion
    }
}
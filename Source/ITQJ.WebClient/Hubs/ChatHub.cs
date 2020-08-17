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

        public async Task<IActionResult> Connect()
        {
            if (ConnectedUsers.Any(x => x.ConnectionId.Equals(Context.ConnectionId)))
                throw new InvalidOperationException(Resources.UserIsConnected);

            var user = await CallApiGETAsync<UserResponseDTO>(uri: "api/users", isSecured: true);
            user.ConnectionId = Context.ConnectionId;

            ConnectedUsers.Add(user);

            return new OkObjectResult(user.Id);
        }

        public async void GetPostulantsMessages(string projectId, string fromId)
        {
            if (Guid.TryParse(projectId, out Guid result))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            if (Guid.TryParse(fromId, out Guid userId))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            var postulants = await CallApiGETAsync<List<UserResponseDTO>>(uri: "api/messages/contratist/" + projectId, isSecured: true);

            if (postulants.Count == 0)
                return;

            var availableUser = postulants.Where(x => x.Id != userId)
                .Select(x => new
                {
                    id = x.Id,
                    userName = x.Email.Split("@").First(),
                    messageCount = x.Messages.Count,
                    connectionId = ConnectedUsers.FirstOrDefault(s => s.Id == x.Id)?.ConnectionId
                });

            await Clients.Caller.SendAsync(ChatHubMethods.UpdateConnectedUsers, availableUser);
        }

        public async void GetProjectMessages(string projectId, string fromId, string toId)
        {
            if (Guid.TryParse(projectId, out Guid result))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            if (Guid.TryParse(fromId, out Guid fromUserId))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            if (Guid.TryParse(toId, out Guid toUserId))
                throw new InvalidOperationException(Resources.UnableToGetMessages);

            var queryResult = new Dictionary<string, string>
            {
                { nameof(fromId), fromId },
                { nameof(toId), toId }
            };

            var postulants = await CallApiGETAsync<List<UserResponseDTO>>(uri: "api/messages/profesional/" + projectId + QueryString.Create(queryResult), isSecured: true);

            if (postulants.Count == 0)
                return;

            var availableUser = postulants
                .Select(x => new
                {
                    id = x.Id,
                    userName = x.Email.Split("@").First(),
                    messageCount = x.Messages.Count,
                    connectionId = ConnectedUsers.FirstOrDefault(s => s.Id == x.Id)?.ConnectionId
                });

            await Clients.Caller.SendAsync(ChatHubMethods.UpdateConnectedUsers, availableUser);
        }

        #endregion

        #region Message Methods

        public async Task<IActionResult> SendPrivateMessage(MessageResponseDTO message)
        {
            await CallApiPOSTAsync<MessageResponseDTO>(uri: "api/messages/", body: message, isSecured: true);

            var toUser = ConnectedUsers.FirstOrDefault(x => x.Id == message.ToUserId);
            if (toUser != null)
            {
                await Clients.Client(toUser.ConnectionId)
                    .SendAsync(ChatHubMethods.ReceiveMessage, message);
                await Clients.Client(toUser.ConnectionId)
                    .SendAsync(ChatHubMethods.UpdateUnreadMessages, message.ToUserId);
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
        private async Task<T> CallApiGETAsync<T>(string uri, bool isSecured) where T : class
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"]?.ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Problem accessing the API");
            }

            return null;
        }

        private async Task<T> CallApiPOSTAsync<T>(string uri, T body, bool isSecured) where T : class
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
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
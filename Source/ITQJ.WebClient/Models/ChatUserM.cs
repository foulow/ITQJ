using System;

namespace ITQJ.WebClient.ViewModels
{
    public class ChatUserM
    {
        public Guid UserId { get; set; }
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public bool IsOnHold { get; set; }
        public Guid ConnectedWith { get; set; }
    }
}

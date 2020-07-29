using Newtonsoft.Json;
using System.Collections.Generic;

namespace ITQJ.WebClient.ViewModels
{
    public class UserVM
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RolId { get; set; }

        [JsonIgnore]
        public RolVM Rol { get; set; }

        [JsonIgnore]
        public List<RolVM> Roles { get; set; }
    }
}

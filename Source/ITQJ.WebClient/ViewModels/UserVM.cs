using ITQJ.Domain.DTOs;
using System.Collections.Generic;

namespace ITQJ.WebClient.ViewModels
{
    public class UserVM : UserCreateDTO
    {
        public ICollection<string> Roles { get; set; }
    }
}

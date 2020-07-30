using ITQJ.Domain.DTOs;
using System.Collections.Generic;

namespace ITQJ.WebClient.ViewModels
{
    public class UserVM : UserResponseDTO
    {
        public ICollection<RoleDTO> Roles { get; set; }
    }
}

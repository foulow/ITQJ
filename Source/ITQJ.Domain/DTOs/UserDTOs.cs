using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ITQJ.Domain.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }

    }

    public class UserResponseDTO : UserCreateDTO
    {
        public Guid Id { get; set; }

        public virtual string ConnectionId { get; set; }

        public virtual string UserName { get => Email.Split("@").First(); }

    }
}

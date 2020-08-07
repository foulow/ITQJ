using System;

namespace ITQJ.Domain.DTOs
{
    public class UserCreateDTO
    {
        public string Email { get; set; }
        public string Role { get; set; }

    }

    public class UserResponseDTO : UserCreateDTO
    {
        public Guid Id { get; set; }
    }
}

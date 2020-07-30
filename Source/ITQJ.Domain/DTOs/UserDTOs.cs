using System;

namespace ITQJ.Domain.DTOs
{
    public class UserCreateDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }

    }

    public class UserUpdateDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UserResponseDTO : UserCreateDTO
    {
        public Guid Id { get; set; }

        public RoleDTO Role { get; set; }
    }
}

namespace ITQJ.Domain.DTOs
{
    public class UserCreateDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }

    }

    public class UserUpdateDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UserResponseDTO : UserCreateDTO
    {
        public int Id { get; set; }

        public RolDTO Rol { get; set; }
    }
}

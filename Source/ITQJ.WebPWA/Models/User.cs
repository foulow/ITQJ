namespace ITQJ.WebPWA.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }
    }
}

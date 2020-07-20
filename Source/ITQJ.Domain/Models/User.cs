namespace ITQJ.Domain.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [ForeignKey(nameof(Rol))]
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Postulant> Postulants { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}

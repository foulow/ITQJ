namespace ITQJ.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Users")]
    public class User : BaseEntity
    {
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

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public Guid RoleId { get; set; }

        [JsonIgnore]
        public virtual PersonalInfo PersonalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Project> Projects { get; set; }

        [JsonIgnore]
        public virtual ICollection<Postulant> Postulants { get; set; }

        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }

        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

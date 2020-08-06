namespace ITQJ.Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Role { get; set; }

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

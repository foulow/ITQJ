namespace ITQJ.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Reviews")]
    public class Review : BaseEntity
    {
        [Required]
        public int Points { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}

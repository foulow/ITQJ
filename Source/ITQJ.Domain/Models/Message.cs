namespace ITQJ.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Messages")]
    public class Message : BaseEntity
    {
        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}

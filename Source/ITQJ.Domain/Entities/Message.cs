namespace ITQJ.Domain.Entities
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

        [Required]
        public DateTime MessageDate { get; set; }

        [JsonIgnore]
        [ForeignKey("FromUserId")]
        public virtual User User { get; set; }
        public Guid FromUserId { get; set; }

        [JsonIgnore]
        [ForeignKey("ToUserId")]
        public Guid ToUserId { get; set; }

        [JsonIgnore]
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}

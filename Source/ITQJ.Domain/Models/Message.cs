namespace ITQJ.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Messages")]
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}

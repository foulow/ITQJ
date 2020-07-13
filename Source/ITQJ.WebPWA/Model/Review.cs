namespace ITQJ.WebPWA.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}

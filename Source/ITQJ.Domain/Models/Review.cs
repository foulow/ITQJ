using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITQJ.Domain.Models
{
    [Table("Reviews")]
    class Review
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
    }
}

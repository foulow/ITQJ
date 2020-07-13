﻿namespace ITQJ.Domain.Models
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
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public virtual User User { get; set; }

        public virtual Project Project { get; set; }
    }
}

namespace ITQJ.WebPWA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CloseDate { get; set; }

        [Required]
        public int PostulantsLimit { get; set; }

        [Required]
        public bool IsOpen { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Postulant> Postulants { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}

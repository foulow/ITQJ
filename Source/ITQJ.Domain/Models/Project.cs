namespace ITQJ.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Projects")]
    public class Project : BaseEntity
    {
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

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        public virtual ICollection<Postulant> Postulants { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}

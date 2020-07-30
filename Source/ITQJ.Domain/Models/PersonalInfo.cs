namespace ITQJ.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PersonalInfos")]
    public class PersonalInfo : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [StringLength(25)]
        public string PagLink { get; set; }

        [ForeignKey("LegalDocumentId")]
        public virtual LegalDocument LegalDocument { get; set; }
        public Guid LegalDocumentId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        public virtual ICollection<ProfesionalSkill> ProfesionalSkills { get; set; }

    }
}

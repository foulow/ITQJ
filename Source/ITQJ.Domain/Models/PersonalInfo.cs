namespace ITQJ.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PersonalInfos")]
    public class PersonalInfo
    {
        [Key]
        public int Id { get; set; }

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


        [Required]
        [ForeignKey(nameof(LegalDocument))]
        public int LegalDocumentId { get; set; }
        public virtual LegalDocument LegalDocument { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<ProfesionalSkill> ProfesionalSkills { get; set; }

    }
}

namespace ITQJ.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProfesionalSkills")]
    public class ProfesionalSkill : BaseEntity
    {
        [Required]
        public int Percentage { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInfo PersonalInfo { get; set; }
        public Guid PersonalInfoId { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }
        public Guid SkillId { get; set; }
    }
}

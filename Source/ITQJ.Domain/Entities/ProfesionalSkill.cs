namespace ITQJ.Domain.Entities
{
    using ITQJ.Domain.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("ProfesionalSkills")]
    public class ProfesionalSkill : BaseEntity
    {
        [Required]
        public int Percentage { get; set; }

        [JsonIgnore]
        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInfo PersonalInfo { get; set; }
        public Guid PersonalInfoId { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }
        public Guid SkillId { get; set; }
    }
}

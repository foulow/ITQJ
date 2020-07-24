namespace ITQJ.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProfesionalSkills")]
    public class ProfesionalSkill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Percentage { get; set; }

        [Required]
        [ForeignKey(nameof(PersonalInfo))]
        public int PersonalInfoId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }

        [Required]
        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}

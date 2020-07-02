using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITQJ.Domain.Models
{
    [Table("ProfesionalSkills")]
    class ProfesionalSkill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(PersonalInfo))]
        public int PersonalInfoId { get; set; }

        [Required]
        [ForeignKey(nameof(Skill))]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}

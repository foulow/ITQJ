namespace ITQJ.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Skills")]
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public string Path { get; set; }

        public virtual ProfesionalSkill ProfesionalSkill { get; set; }
    }
}

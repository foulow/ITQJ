namespace ITQJ.Domain.Entities
{
    using ITQJ.Domain.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Skills")]
    public class Skill : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public string Path { get; set; }

        [JsonIgnore]
        public virtual ProfesionalSkill ProfesionalSkill { get; set; }
    }
}

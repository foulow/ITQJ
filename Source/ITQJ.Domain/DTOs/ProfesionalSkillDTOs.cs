using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class ProfesionalSkillCreateDTO : ProfesionalSkillUpdateDTO
    {
        [Required]
        public Guid PersonalInfoId { get; set; }

        [Required]
        public Guid SkillId { get; set; }
    }


    public class ProfesionalSkillUpdateDTO
    {
        [Required]
        public int Percentage { get; set; }

    }


    public class ProfesionalSkillResponseDTO : ProfesionalSkillCreateDTO
    {
        public Guid Id { get; set; }

        public SkillDTO Skill { get; set; }

    }
}

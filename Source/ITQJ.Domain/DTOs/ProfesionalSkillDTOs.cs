using System;

namespace ITQJ.Domain.DTOs
{
    public class ProfesionalSkillCreateDTO : ProfesionalSkillUpdateDTO
    {
        public Guid PersonalInfoId { get; set; }

        public Guid SkillId { get; set; }
    }


    public class ProfesionalSkillUpdateDTO
    {
        public int Percentage { get; set; }

    }


    public class ProfesionalSkillResponseDTO : ProfesionalSkillCreateDTO
    {
        public Guid Id { get; set; }

        public SkillDTO Skill { get; set; }

    }
}

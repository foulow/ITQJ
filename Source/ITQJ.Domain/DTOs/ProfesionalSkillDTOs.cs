using ITQJ.Domain.DTOs;

namespace ITQJ.Domain.DTOs
{
    public class ProfesionalSkillCreateDTO : ProfesionalSkillUpdateDTO
    {
        public int PersonalInfoId { get; set; }
    }
    public class ProfesionalSkillUpdateDTO
    {
        public int Percentage { get; set; }

        public int SkillId { get; set; }
    }

    public class ProfesionalSkillResponseDTO : ProfesionalSkillCreateDTO
    {
        public int Id { get; set; }

        public SkillDTO Skill { get; set; }
    }
}

namespace ITQJ.API.DTOs
{
    public class ProfesionalSkillCreateDTO
    {
        public int PersonalInfoId { get; set; }

        public int SkillId { get; set; }
    }

    public class ProfesionalSkillResponseDTO : ProfesionalSkillCreateDTO
    {
        public SkillDTO Skill { get; set; }
    }
}

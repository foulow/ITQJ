namespace ITQJ.API.DTOs
{
    public class ProfesionalSkillCreateDTO
    {
        public int Percentage { get; set; }

        public int PersonalInfoId { get; set; }

        public int SkillId { get; set; }
    }

    public class ProfesionalSkillResponseDTO : ProfesionalSkillCreateDTO
    {
        public int Id { get; set; }

        public SkillDTO Skill { get; set; }
    }
}

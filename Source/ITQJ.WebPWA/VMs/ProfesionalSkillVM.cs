namespace ITQJ.WebPWA.VMs
{
    public class ProfesionalSkillVM
    {
        public int PersonalInfoId { get; set; }

        public string Name { get; set; }
        public int SkillId { get; set; }
        public SkillVM Skill { get; set; }

        public string Path { get; set; }
        public int Percentage { get; set; } = 10;

        public bool Active { get; set; } = false;
    }
}

using ITQJ.Domain.DTOs;

namespace ITQJ.WebClient.Models
{
    public class SkillM : SkillDTO
    {
        public int SkillId { get { return Id; } set { Id = value; } }

        public int PersonalInfoId { get; set; }

        public int Percentage { get; set; }

        public bool Active { get; set; }
    }
}

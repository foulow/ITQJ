using ITQJ.Domain.DTOs;
using System;

namespace ITQJ.WebClient.Models
{
    public class SkillM : SkillDTO
    {
        public Guid PersonalInfoId { get; set; }

        public Guid ProfesionalSkillId { get; set; }

        public Guid SkillId { get { return Id; } set { Id = value; } }

        public int Percentage { get; set; }

        public bool Active { get; set; }
    }
}

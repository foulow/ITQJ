using System;
using System.Collections.Generic;

namespace ITQJ.Domain.DTOs
{
    public class PersonalInfoCreateDTO : PersonalInfoUpdateDTO
    {
        public Guid UserId { get; set; }

        public Guid LegalDocumentId { get; set; }
    }

    public class PersonalInfoUpdateDTO
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string PagLink { get; set; }
    }

    public class PersonalInfoResponseDTO : PersonalInfoCreateDTO
    {
        public Guid Id { get; set; }

        public UserResponseDTO User { get; set; }

        public LegalDocumentResponseDTO LegalDocument { get; set; }

        public ICollection<ProfesionalSkillResponseDTO> ProfesionalSkills { get; set; }
    }
}

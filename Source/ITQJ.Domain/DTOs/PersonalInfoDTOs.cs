using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class PersonalInfoCreateDTO : PersonalInfoUpdateDTO
    {
        [Required]
        public Guid UserId { get; set; }

        public Guid LegalDocumentId { get; set; }
    }

    public class PersonalInfoUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
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

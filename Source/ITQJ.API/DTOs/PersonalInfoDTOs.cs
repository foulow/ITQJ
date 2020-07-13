using System.Collections.Generic;

namespace ITQJ.API.DTOs
{
    public class PersonalInfoCreateDTOs
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string PagLink { get; set; }

        public int UserId { get; set; }
    }

    public class PersonalInfoUpdateDTOs : PersonalInfoCreateDTOs
    {
        public int LegalDocumentId { get; set; }
    }

    public class PersonalInfoResponseDTOs : PersonalInfoUpdateDTOs
    {
        public LegalDocumentResponseDTO LegalDocument { get; set; }

        public ICollection<ProfesionalSkillResponseDTO> ProfesionalSkills { get; set; }
    }
}

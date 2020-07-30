using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Models;
using System.Collections.Generic;

namespace ITQJ.WebClient.ViewModels
{
    public class PersonalInfoVM : PersonalInfoResponseDTO
    {
        public List<SkillM> Skills { get; set; }

        public List<DocumentTypeDTO> DocumentTypes { get; set; }
    }
}

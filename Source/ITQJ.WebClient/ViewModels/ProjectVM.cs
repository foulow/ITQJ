using ITQJ.Domain.DTOs;
using System.Collections.Generic;

namespace ITQJ.WebClient.ViewModels
{
    public class ProjectVM
    {
        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int ResultCount { get; set; }

        public ICollection<ProjectResponseDTO> Projects { get; set; }
    }
}

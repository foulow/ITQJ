using ITQJ.Domain.DTOs;
using System.Collections.Generic;

namespace ITQJ.WebClient.ViewModels
{
    public class ReviewsToMakeVM
    {
        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int ResultCount { get; set; }

        public int PageIndex { get; set; }

        public ReviewCreateDTO Review { get; set; }

        public ICollection<ProjectResponseDTO> ProjectsToReview { get; set; }
    }
}

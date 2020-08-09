using ITQJ.Domain.DTOs;
using System.Collections.Generic;

namespace ITQJ.WebClient.ViewModels
{
    public class ReviewListVM
    {
        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int ResultCount { get; set; }

        public int PageIndex { get; set; }

        public ICollection<ReviewResponseDTO> Reviews { get; set; }
    }
}

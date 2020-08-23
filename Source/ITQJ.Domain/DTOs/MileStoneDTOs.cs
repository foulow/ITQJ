using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class MileStoneCreateDTO
    {
        [Required]
        public string Description { get; set; }

        public string FileName { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }

    public class MileStoneResponseDTO : MileStoneCreateDTO
    {
        public Guid Id { get; set; }
    }
}
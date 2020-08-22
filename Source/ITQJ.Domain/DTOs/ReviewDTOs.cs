using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class ReviewCreateDTO
    {
        [Required]
        public int Points { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }

    public class ReviewResponseDTO : ReviewCreateDTO
    {
        public Guid Id { get; set; }

    }
}

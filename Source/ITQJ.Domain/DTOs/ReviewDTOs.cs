using System;

namespace ITQJ.Domain.DTOs
{
    public class ReviewCreateDTO
    {
        public int Points { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }

    public class ReviewResponseDTO : ReviewCreateDTO
    {
        public Guid Id { get; set; }

    }
}

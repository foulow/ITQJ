using System;

namespace ITQJ.Domain.DTOs
{
    public class MileStoneCreateDTO
    {
        public string Description { get; set; }

        public string FileName { get; set; }

        public DateTime UploadDate { get; set; }

        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }
    }

    public class MileStoneResponseDTO : MileStoneCreateDTO
    {
        public Guid Id { get; set; }
    }
}
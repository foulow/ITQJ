using System;

namespace ITQJ.Domain.DTOs
{
    public class PostulantCreateDTO
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class PostulantResponseDTO : PostulantCreateDTO
    {
        public Guid Id { get; set; }
    }
}

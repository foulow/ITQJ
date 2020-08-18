using System;

namespace ITQJ.Domain.DTOs
{
    public class PostulantCreateDTO
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }

    public class PostulantUpdateDTO
    {
        public bool IsSellected { get; set; }

        public bool HasWorkReview { get; set; }

        public bool HasProyectReview { get; set; }
    }

    public class PostulantResponseDTO : PostulantCreateDTO
    {
        public Guid Id { get; set; }

        public ProjectCreateDTO Project { get; set; }

        public UserResponseDTO User { get; set; }
    }
}

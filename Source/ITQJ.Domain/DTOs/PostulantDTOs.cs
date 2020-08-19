using System;

namespace ITQJ.Domain.DTOs
{
    public class PostulantCreateDTO : PostulantUpdateDTO
    {
        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }
    }

    public class PostulantUpdateDTO
    {
        public bool IsSellected { get; set; } = false;

        public bool HasWorkReview { get; set; } = false;

        public bool HasProyectReview { get; set; } = false;
    }

    public class PostulantResponseDTO : PostulantCreateDTO
    {
        public Guid Id { get; set; }

        public virtual ProjectCreateDTO Project { get; set; }

        public virtual UserResponseDTO User { get; set; }
    }
}

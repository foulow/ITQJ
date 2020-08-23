using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class PostulantCreateDTO : PostulantUpdateDTO
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }
    }

    public class PostulantUpdateDTO
    {
        [Required]
        public bool IsSelected { get; set; } = false;

        [Required]
        public bool HasWorkReview { get; set; } = false;

        [Required]
        public bool HasProyectReview { get; set; } = false;
    }

    public class PostulantResponseDTO : PostulantCreateDTO
    {
        public Guid Id { get; set; }

        public virtual ProjectCreateDTO Project { get; set; }

        public virtual UserResponseDTO User { get; set; }
    }
}

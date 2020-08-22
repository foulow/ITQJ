using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class MessageCreateDTO
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime MessageDate { get; set; }

        [Required]
        public Guid FromUserId { get; set; }

        [Required]
        public Guid ToUserId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }
    }

    public class MessageResponseDTO : MessageCreateDTO
    {
        public Guid Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual UserResponseDTO User { get; set; }
    }
}

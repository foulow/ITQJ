using System;

namespace ITQJ.Domain.DTOs
{
    public class MessageCreateDTO
    {
        public string Text { get; set; }

        public DateTime MessageDate { get; set; }

        public Guid FromUserId { get; set; }

        public Guid ToUserId { get; set; }

        public Guid ProjectId { get; set; }
    }

    public class MessageResponseDTO : MessageCreateDTO
    {
        public Guid Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual UserResponseDTO User { get; set; }
    }
}

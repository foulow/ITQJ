using System;

namespace ITQJ.Domain.DTOs
{
    public class MessageCreateDTO
    {
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }
    public class MessageResponseDTO : MessageCreateDTO
    {
        public Guid Id { get; set; }
    }
}

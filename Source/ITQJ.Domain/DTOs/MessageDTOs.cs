namespace ITQJ.Domain.DTOs
{
    public class MessageCreateDTO
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
    public class MessageResponseDTO : MessageCreateDTO
    {
        public int Id { get; set; }
    }
}

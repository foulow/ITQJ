namespace ITQJ.Domain.DTOs
{
    public class ReviewCreateDTO
    {
        public int Points { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }

    public class ReviewResponseDTO : ReviewCreateDTO
    {
        public int Id { get; set; }

    }
}

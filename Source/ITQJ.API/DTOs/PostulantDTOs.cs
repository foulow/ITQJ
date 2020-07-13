namespace ITQJ.API.DTOs
{
    public class PostulantCreateDTO
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }

    public class PostulantResponseDTO : PostulantCreateDTO
    {
        public int Id { get; set; }
    }
}

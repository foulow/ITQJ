using System;
using System.Collections.Generic;

namespace ITQJ.API.DTOs
{
    public class ProjectCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int PostulantsLimit { get; set; }
        public int UserId { get; set; }
    }

    public class ProjectUpdateDTO : ProjectCreateDTO
    {
        public DateTime CloseDate { get; set; }
        public bool IsOpen { get; set; }

    }

    public class ProjectResponseDTO : ProjectUpdateDTO
    {
        public int Id { get; set; }
        public ICollection<PostulantResponseDTO> Postulants { get; set; }
        public ICollection<MessageResponseDTO> Messages { get; set; }


    }
}

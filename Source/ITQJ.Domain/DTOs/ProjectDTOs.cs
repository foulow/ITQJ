using System;
using System.Collections.Generic;

namespace ITQJ.Domain.DTOs
{
    public class ProjectCreateDTO : ProjectUpdateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public Guid UserId { get; set; }
    }

    public class ProjectUpdateDTO
    {
        public int PostulantsLimit { get; set; }

        public DateTime CloseDate { get; set; }

        public bool IsOpen { get; set; }
    }

    public class ProjectResponseDTO : ProjectCreateDTO
    {
        public Guid Id { get; set; }

        // TODO: implementar lista de skills requeridos.
        //public ICollection<SkillDTO> Skills { get; set; }

        public bool NotCloseDate { get; set; }

        public virtual ICollection<PostulantResponseDTO> Postulants { get; set; }

        public virtual ICollection<MileStoneResponseDTO> MileStones { get; set; }
    }
}

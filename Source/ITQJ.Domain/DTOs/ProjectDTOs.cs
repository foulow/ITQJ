using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class ProjectCreateDTO : ProjectUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public Guid UserId { get; set; }
    }

    public class ProjectUpdateDTO
    {
        [Required]
        public int PostulantsLimit { get; set; }

        [Required]
        public DateTime CloseDate { get; set; }

        public bool IsOpen { get; set; }
    }

    public class ProjectResponseDTO : ProjectCreateDTO
    {
        public Guid Id { get; set; }

        // TODO: implementar lista de skills requeridos.
        //public ICollection<SkillDTO> Skills { get; set; }

        public bool NotCloseDate { get; set; }

        public bool MaxPostulants { get; set; }

        public virtual ICollection<PostulantResponseDTO> Postulants { get; set; }

        public virtual ICollection<MileStoneResponseDTO> MileStones { get; set; }
    }
}

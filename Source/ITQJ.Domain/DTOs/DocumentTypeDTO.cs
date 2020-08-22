using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class DocumentTypeDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class LegalDocumentCreateDTO : LegalDocumentUpdateDTO
    {
        [Required]
        public Guid DocumentTypeId { get; set; }
    }

    public class LegalDocumentUpdateDTO
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public string FileName { get; set; }
    }

    public class LegalDocumentResponseDTO : LegalDocumentCreateDTO
    {
        public Guid Id { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }
    }
}

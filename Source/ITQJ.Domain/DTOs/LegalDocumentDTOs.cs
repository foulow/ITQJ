using System;

namespace ITQJ.Domain.DTOs
{
    public class LegalDocumentCreateDTO : LegalDocumentUpdateDTO
    {
        public Guid DocumentTypeId { get; set; }
    }

    public class LegalDocumentUpdateDTO
    {
        public string Number { get; set; }

        public string FileName { get; set; }
    }

    public class LegalDocumentResponseDTO : LegalDocumentCreateDTO
    {
        public Guid Id { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }
    }
}

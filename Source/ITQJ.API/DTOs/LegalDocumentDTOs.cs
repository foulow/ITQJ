using ITQJ.Domain.Models;

namespace ITQJ.API.DTOs
{
    public class LegalDocumentCreateDTO
    {
        public string Number { get; set; }

        public byte[] Image { get; set; }

        public int DocumentTypeId { get; set; }
    }

    public class LegalDocumentUpdateDTO : LegalDocumentCreateDTO { }

    public class LegalDocumentResponseDTO : LegalDocumentCreateDTO
    {
        public DocumentType DocumentType { get; set; }
    }
}

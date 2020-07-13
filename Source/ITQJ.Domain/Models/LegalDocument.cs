namespace ITQJ.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LegalDocuments")]
    public class LegalDocument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Number { get; set; }

        [Required]
        [MaxLength(2097152)]
        public byte[] Image { get; set; }

        [Required]
        [ForeignKey(nameof(DocumentType))]
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}

namespace ITQJ.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LegalDocuments")]
    public class LegalDocument : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Number { get; set; }

        [Required]
        [MaxLength(2097152)]
        public byte[] Image { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }
        public Guid DocumentTypeId { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}

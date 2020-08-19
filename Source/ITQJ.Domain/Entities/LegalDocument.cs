namespace ITQJ.Domain.Entities
{
    using ITQJ.Domain.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("LegalDocuments")]
    public class LegalDocument : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Number { get; set; }

        [Required]
        [StringLength(200)]
        public string FileName { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }
        public Guid DocumentTypeId { get; set; }

        [JsonIgnore]
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}

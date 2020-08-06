using ITQJ.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ITQJ.Domain.Entities
{

    [Table("DocumentTypes")]
    public class DocumentType : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<LegalDocument> LegalDocuments { get; set; }
    }
}

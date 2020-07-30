using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITQJ.Domain.Models
{

    [Table("DocumentTypes")]
    public class DocumentType : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<LegalDocument> LegalDocuments { get; set; }
    }
}

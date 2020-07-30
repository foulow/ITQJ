namespace ITQJ.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

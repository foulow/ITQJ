using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool DeletedFlag { get; set; }
    }
}

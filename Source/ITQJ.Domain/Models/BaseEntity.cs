using System;

namespace ITQJ.Domain.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public bool DeletedFlag { get; set; }
    }
}

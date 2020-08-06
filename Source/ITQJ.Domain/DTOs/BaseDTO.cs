using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ITQJ.Domain.DTOs
{
    public class BaseDTO
    {
        [Required]
        [NotNull]
        public Guid Value { get; set; }
    }
}

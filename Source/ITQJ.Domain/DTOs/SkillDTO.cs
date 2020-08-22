using System;
using System.ComponentModel.DataAnnotations;

namespace ITQJ.Domain.DTOs
{
    public class SkillDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}

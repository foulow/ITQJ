﻿namespace ITQJ.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Postulants")]
    public class Postulant : BaseEntity
    {
        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public bool IsSelected { get; set; }

        public bool HasWorkReview { get; set; }

        public bool HasProyectReview { get; set; }

    }
}

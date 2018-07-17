using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioAdmin.API.Data.Entities
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Column("CreatedBy", TypeName = "varchar(50)")]
        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Column("UpdateBy", TypeName = "varchar(50)")]
        public string UpdatedBy { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    [Table("AuditFiles")]
    public class AuditAttchment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LineId { get; set; }
        public string OriginalName { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
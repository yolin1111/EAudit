using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    [Table("AuditSources")]
    public class AuditSource
    {
        [Key]
        public int Id { get; set; }
        public string SourceCode { get; set; }
        public string SourceValue { get; set; }
    }
}
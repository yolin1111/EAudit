using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    [Table("AuditFiles")]
    public class AuditAttchment
    {
        [Key]
        public int LineId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        [Column(TypeName = "datetime")]
        public string CreationDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
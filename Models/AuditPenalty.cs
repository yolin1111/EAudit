using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    [Table("AuditPenaltys")]
    public class AuditPenalty
    {
        [Key]
        public int Id { get; set; }
        public string PenaltyCode { get; set; }
        public string PenaltyStatus { get; set; }
    }
}
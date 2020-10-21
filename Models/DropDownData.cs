using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    public class DropDownData
    {
        [Table("AuditPenaltys")]
        public class AuditPenalty
        {
            [Key]
            public int Id { get; set; }
            public string PenaltyCode { get; set; }
            public string PenaltyStatus { get; set; }
        }

        [Table("AuditSources")]
        public class AuditSource
        {
            [Key]
            public int Id { get; set; }
            public string SourceCode { get; set; }
            public string SourceValue { get; set; }
        }

        [Table("AuditViolations")]
        public class AuditViolation
        {
            [Key]
            public int Id { get; set; }
            public string ViolationCode { get; set; }
            public string ViolationStatus { get; set; }
        }
        [Table("AuditItemViews")]
        public class AuditItemView
        {
            public string OrgID { get; set; }
            public string OrgName { get; set; }
            public string AuditItemCode { get; set; }
            public string AuditItemName { get; set; }

        }

    }
}
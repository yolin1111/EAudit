using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EAudit.Models
{
    public partial class AuditLineAll
    {
        [Key]
        public int LineId { get; set; }
        public int HeaderId { get; set; }
        public string CaseLineId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ApplyDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AuditTime { get; set; }
        public string Auditor { get; set; }
        public string AuditAddress { get; set; }
        public string Area { get; set; }
        public string Auditee { get; set; }
        public string CurrentViolation { get; set; }
        public string CurrentPenalty { get; set; }
        public string OtherOrg { get; set; }
        public string Idn { get; set; }
        [StringLength(10)]
        public string Preclosed { get; set; }
        [StringLength(10)]
        public string Closed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(HeaderId))]
        [InverseProperty(nameof(AuditHeaderAll.AuditLineAlls))]
        public virtual AuditHeaderAll Header { get; set; }
    }
}
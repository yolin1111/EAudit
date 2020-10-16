using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EAudit.Models
{
    public partial class AuditHeaderAll
    {
        public AuditHeaderAll()
        {
            AuditLineAlls = new HashSet<AuditLineAll>();
        }

        [Key]
        public int HeaderId { get; set; }
        public string AuditItem { get; set; }
        public string ApplyOrg { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ApplyDate { get; set; }
        public string ApplyPerson { get; set; }
        public string Source { get; set; }
        public string SourceOthers { get; set; }
        public string AuditReason { get; set; }
        public string Others { get; set; }
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

        [InverseProperty(nameof(AuditLineAll.Header))]
        public virtual ICollection<AuditLineAll> AuditLineAlls { get; set; }
    }
}
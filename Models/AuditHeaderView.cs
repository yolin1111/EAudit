using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EAudit.Models
{
    [Table("AuditHeaderViews")]
    public partial class AuditHeaderView
    {
        public AuditHeaderView()
        {
            AuditLineViews = new HashSet<AuditLineView>();
        }

        [Key]
        public int HeaderId { get; set; }
        public string AuditItem { get; set; }
        public string AuditItemName { get; set; }
        public string ApplyOrg { get; set; }
        public string ApplyOrgName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ApplyDate { get; set; }
        public string ApplyPerson { get; set; }
        public string ApplyPersonName { get; set; }
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
        [InverseProperty(nameof(AuditLineView.HeaderView))]
        public virtual ICollection<AuditLineView> AuditLineViews { get; set; }
    }
}
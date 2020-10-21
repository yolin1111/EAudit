using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    public class GetSEQ
    {
        public string ApplyOrgID { get; set; }
        public string ApplyAuditItem { get; set; }
    }

    public class GetSEQResult
    {
        public string CaseLineId { get; set; }
    }
}
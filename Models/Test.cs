using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    [Table("TestFlow")]
    public class TestViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string IDN { get; set; }
    }
}
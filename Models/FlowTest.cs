using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAudit.Models
{
    public class TestFlow
    {
        [Table("TestFlow")]
        public class TestViewModel
        {
            [Key]
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Mail { get; set; }
            public string IDN { get; set; }
        }
        [Table("TestFlow2")]
        public class TestViewModel2
        {
            [Key]
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Mail { get; set; }
            public string IDN { get; set; }
        }

        [Table("TestFlow3")]
        public class TestViewModel3
        {
            [Key]
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Mail { get; set; }
            public string IDN { get; set; }
        }
    }
}
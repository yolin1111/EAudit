using System.Collections.Generic;
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
            public string SN { get; set; }
            public string SMS { get; set; }
            public string FormNo { get; set; }
            public string Applicant { get; set; }
            public string ApplicantDate { get; set; }
            public string ApplicantUnit { get; set; }
            public string ApproveAPI { get; set; }
            public string RejectAPI { get; set; }



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
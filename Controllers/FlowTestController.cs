using Microsoft.AspNetCore.Mvc;
using EAudit.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EAudit.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class FlowTestController : ControllerBase
    {
        private readonly AuditContext _context;
        private readonly ILogger _logger;

        public FlowTestController(AuditContext context, ILogger<FlowTestController> logger)
        {
            _logger = logger;
            _context = context;
        }
        // [HttpPost("TT")]
        // public async Task<ActionResult<TestFlow.TestViewModel>> PostTEST(Root jsonResult)
        // {
        //     Console.WriteLine("===========================");
        //     // _logger.LogInformation(jsonResult);
        //     string json = JsonConvert.SerializeObject(jsonResult);
        //     Console.WriteLine(json);
        //     Console.WriteLine("===========================");
        //     return Ok("OK");
        // }
        // [HttpPost("TTT")]
        // public IActionResult PostTEST2([FromBody] string jsonResult)
        // {
        //     Console.WriteLine("===========================");
        //     var aa = Request.BodyReader;
        //     string json = JsonConvert.SerializeObject(jsonResult);
        //     Console.WriteLine(json);
        //     Console.WriteLine("===========================12");
        //     return Ok("OK");
        // }


        [HttpPost]
        public async Task<ActionResult<TestFlow.TestViewModel>> Post1(Root jsonResult)
        {
            _context.TestViewModels.Add(new TestFlow.TestViewModel
            {
                UserName = jsonResult.FormData.UserName,
                Mail = jsonResult.FormData.Mail,
                IDN = jsonResult.FormData.IDN,
                SN = jsonResult.FormInfo.SN,
                SMS = jsonResult.FormInfo.SMS,
                FormNo = jsonResult.FormInfo.FormNo,
                Applicant = jsonResult.FormInfo.Applicant,
                ApplicantDate = jsonResult.FormInfo.ApplicantDate,
                ApplicantUnit = jsonResult.FormInfo.ApplicantUnit,
                ApproveAPI = System.Web.HttpUtility.UrlDecode(jsonResult.ApproveAPI),
                RejectAPI = System.Web.HttpUtility.UrlDecode(jsonResult.RejectAPI)
            });
            await _context.SaveChangesAsync();
            return Ok("OK");

        }

        // 舊版功能
        // [HttpPost]
        // public async Task<ActionResult<TestFlow.TestViewModel>> Post1(TestFlow.TestViewModel testViewModels)
        // {
        //     _context.TestViewModels.Add(testViewModels);
        //     await _context.SaveChangesAsync();
        //     return Ok("Successful");
        // }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestFlow.TestViewModel>>> Get1()
        {
            // return await _context.AuditHeaderAlls.ToListAsync();
            // return await _context.TestViewModels.ToListAsync();
            int maxId = _context.TestViewModels.MaxAsync(X => X.Id).Id;
            return await _context.TestViewModels.Where(x => x.Id == maxId).ToListAsync();
        }

        public class FormData
        {
            public string UserName { get; set; }
            public string Mail { get; set; }
            public string IDN { get; set; }
        }

        public class FormInfo
        {
            public string SN { get; set; }
            public string SMS { get; set; }
            public string FormNo { get; set; }
            public string Applicant { get; set; }
            public string ApplicantDate { get; set; }
            public string ApplicantUnit { get; set; }
        }

        public class Root
        {
            public FormData FormData { get; set; }
            public FormInfo FormInfo { get; set; }
            public string ApproveAPI { get; set; }
            public string RejectAPI { get; set; }
        }
    }
}

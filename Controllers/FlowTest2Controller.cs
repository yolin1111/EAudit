using Microsoft.AspNetCore.Mvc;
using EAudit.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using JwtAuthDemo.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace EAudit.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class FlowTest2Controller : ControllerBase
    {
        private readonly AuditContext _context;

        public FlowTest2Controller(AuditContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TestFlow.TestViewModel2>> Post2(TestFlow.TestViewModel2 testViewModels)
        {
            _context.TestViewModels2.Add(testViewModels);
            await _context.SaveChangesAsync();
            return Ok("Successful");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestFlow.TestViewModel2>>> Get2()
        {
            // return await _context.AuditHeaderAlls.ToListAsync();
            return await _context.TestViewModels2.ToListAsync();
        }
    }
}

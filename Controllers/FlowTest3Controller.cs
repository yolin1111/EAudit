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
    public class FlowTest3Controller : ControllerBase
    {
        private readonly AuditContext _context;

        public FlowTest3Controller(AuditContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TestFlow.TestViewModel3>> Post3(TestFlow.TestViewModel3 testViewModels)
        {
            _context.TestViewModels3.Add(testViewModels);
            await _context.SaveChangesAsync();
            return Ok("Successful");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestFlow.TestViewModel3>>> Get3()
        {
            // return await _context.AuditHeaderAlls.ToListAsync();
            return await _context.TestViewModels3.ToListAsync();
        }
    }
}

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
    public class FlowTestController : ControllerBase
    {
        private readonly AuditContext _context;

        public FlowTestController(AuditContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TestFlow.TestViewModel>> Post1(TestFlow.TestViewModel testViewModels)
        {
            _context.TestViewModels.Add(testViewModels);
            await _context.SaveChangesAsync();
            return Ok("Successful");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestFlow.TestViewModel>>> Get1()
        {
            // return await _context.AuditHeaderAlls.ToListAsync();
            return await _context.TestViewModels.ToListAsync();
        }
    }
}

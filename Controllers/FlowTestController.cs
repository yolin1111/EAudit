using Microsoft.AspNetCore.Mvc;
using EAudit.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using JwtAuthDemo.Helpers;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<TestViewModel>> Post1(TestViewModel testViewModels)
        {
            _context.TestViewModels.Add(testViewModels);
            await _context.SaveChangesAsync();
            return Ok("Successful");
        }
        [HttpGet]
        public async Task<ActionResult<TestViewModel>> Get1(int id)
        {
            var AuditData = await _context.TestViewModels.FirstOrDefaultAsync(x => x.Id == id);

            if (AuditData == null)
            {
                return NotFound();
            }

            return AuditData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EAudit.Models;
using Microsoft.EntityFrameworkCore;

namespace EAudit.Controllers
{


    [Route("v1/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly AuditContext _context;
        public DropDownController(AuditContext context)
        {
            _context = context;
        }

        [HttpGet("Penaltys")]
        public async Task<ActionResult<IEnumerable<DropDownData.AuditPenalty>>> GetAuditPenaltys()
        {
            return await _context.AuditPenaltys.ToListAsync();
        }

        [HttpGet("Sources")]
        public async Task<ActionResult<IEnumerable<DropDownData.AuditSource>>> GetAuditSources()
        {
            return await _context.AuditSources.ToListAsync();
        }

        [HttpGet("Violations")]
        public async Task<ActionResult<IEnumerable<DropDownData.AuditViolation>>> GetAuditViolations()
        {
            return await _context.AuditViolations.ToListAsync();
        }

        [HttpGet("AuditItems")]
        public async Task<ActionResult<IEnumerable<DropDownData.AuditItemView>>> GetAuditItem()
        {
            return await _context.GetItemViews.ToListAsync();
        }

        [HttpGet("AuditItems/{OrgID}")]
        public async Task<ActionResult<IEnumerable<DropDownData.AuditItemView>>> GetAuditItem(string OrgID)
        {
            return await _context.GetItemViews.Where(a => a.OrgID == OrgID).ToListAsync();
        }

    }
}
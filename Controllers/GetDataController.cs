using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAudit.Models;

namespace EAudit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        private readonly AuditContext _context;

        public GetDataController(AuditContext context)
        {
            _context = context;
        }

        // GET: api/GetData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditHeaderAll>>> GetAuditHeaderAlls()
        {
            return await _context.AuditHeaderAlls.ToListAsync();
        }

        // GET: api/GetData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditHeaderAll>> GetAuditHeaderAll(int id)
        {
            // var auditHeaderAll = await _context.AuditHeaderAlls.FindAsync(id);
            var AuditData = await _context.AuditHeaderAlls.Include(a => a.AuditLineAlls).FirstOrDefaultAsync(x => x.HeaderId == id);

            if (AuditData == null)
            {
                return NotFound();
            }

            return AuditData;
        }

        // PUT: api/GetData/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditHeaderAll(int id, AuditHeaderAll auditHeaderAll)
        {
            if (id != auditHeaderAll.HeaderId)
            {
                return BadRequest();
            }

            _context.Entry(auditHeaderAll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditHeaderAllExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GetData
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuditHeaderAll>> PostAuditHeaderAll(AuditHeaderAll auditHeaderAll)
        {
            _context.AuditHeaderAlls.Add(auditHeaderAll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditHeaderAll", new { id = auditHeaderAll.HeaderId }, auditHeaderAll);
        }

        // DELETE: api/GetData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuditHeaderAll>> DeleteAuditHeaderAll(int id)
        {
            var auditHeaderAll = await _context.AuditHeaderAlls.FindAsync(id);
            if (auditHeaderAll == null)
            {
                return NotFound();
            }

            _context.AuditHeaderAlls.Remove(auditHeaderAll);
            await _context.SaveChangesAsync();

            return auditHeaderAll;
        }

        private bool AuditHeaderAllExists(int id)
        {
            return _context.AuditHeaderAlls.Any(e => e.HeaderId == id);
        }
    }
}

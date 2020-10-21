using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAudit.Models;
using Microsoft.Data.SqlClient;

namespace EAudit.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EAuditController : ControllerBase
    {
        private readonly AuditContext _context;

        public EAuditController(AuditContext context)
        {
            _context = context;
        }

        // GET: api/GetData
        // http://172.18.40.4:5000/api/GetData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditHeaderView>>> GetAuditHeaderAlls()
        {
            // return await _context.AuditHeaderAlls.ToListAsync();
            return await _context.AuditHeaderViews.Include(a => a.AuditLineViews).ToListAsync();
        }

        // GET: api/GetData/5
        // http://172.18.40.4:5000/api/GetData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuditHeaderView>> GetAuditHeaderAll(int id)
        {
            // var auditHeaderAll = await _context.AuditHeaderAlls.FindAsync(id);
            var AuditData = await _context.AuditHeaderViews.Include(a => a.AuditLineViews).FirstOrDefaultAsync(x => x.HeaderId == id);

            if (AuditData == null)
            {
                return NotFound();
            }

            return AuditData;
        }

        // GET: api/GetData/AGAA
        // http://172.18.40.4:5000/api/GetData/orgID/ABAA
        [HttpGet("OrgID/{Org}")]
        public async Task<ActionResult<AuditHeaderView>> GetAuditOrg(string Org)
        {
            // var auditHeaderAll = await _context.AuditHeaderAlls.FindAsync(id);
            var AuditData = await _context.AuditHeaderViews.Include(a => a.AuditLineViews).FirstOrDefaultAsync(x => x.ApplyOrg == Org);

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
            if (auditHeaderAll.AuditLineAlls != null)
            {
                foreach (object item in auditHeaderAll.AuditLineAlls)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
            }
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
        [HttpPost("MD")]
        public async Task<ActionResult<AuditHeaderAll>> PostAuditHL(AuditHeaderAll auditHeaderAll)
        {
            _context.AuditHeaderAlls.Add(auditHeaderAll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditHeaderAll", new { id = auditHeaderAll.HeaderId }, auditHeaderAll);
        }
        [HttpPost("M")]
        public async Task<ActionResult<AuditHeaderAll>> PostAuditMaster(AuditHeaderAll auditHeaderAll)
        {
            _context.AuditHeaderAlls.Add(auditHeaderAll);
            await _context.SaveChangesAsync();


            // return Ok("Successful");
            return CreatedAtAction("PostAuditMaster", new { id = auditHeaderAll.HeaderId }, auditHeaderAll);
        }
        // https://172.18.40.4:5000/api/Create/D
        // 新增 AuditLineAll
        [HttpPost("D")]
        public async Task<ActionResult<AuditLineAll>> PostAuditDetail(AuditLineAll auditLineAll)
        {
            _context.AuditLineAlls.Add(auditLineAll);
            await _context.SaveChangesAsync();

            // return Ok("Successful");
            return CreatedAtAction("PostAuditDetail", new { id = auditLineAll.LineId }, auditLineAll);
        }

        //TODO:GetSEQ




        // DELETE: api/GetData/5
        [HttpDelete("M/{id}")]
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

        [HttpDelete("D/{id}")]
        public async Task<ActionResult<AuditLineAll>> DeleteAuditLineAll(int id)
        {
            var AuditLineAll = await _context.AuditLineAlls.FindAsync(id);
            if (AuditLineAll == null)
            {
                return NotFound();
            }

            _context.AuditLineAlls.Remove(AuditLineAll);
            await _context.SaveChangesAsync();

            return AuditLineAll;
        }

        private bool AuditHeaderAllExists(int id)
        {
            return _context.AuditHeaderAlls.Any(e => e.HeaderId == id);
        }

        // //TODO:測試中
        // public class SEQ
        // {
        //     public string ApplyOrgID { get; set; }
        //     public string ApplyAuditItem { get; set; }

        // }
        // [HttpPost("SEQ")]
        // public void PostSEQ(SEQ seq)
        // {
        //     // var sql = "ApplySEQ @usuario, @OrgID, @AudtiItem";
        //     // string[] param = new[] {
        //     // _context.Database.ExecuteSqlCommand(
        //     //     sql,
        //     //     (new SqlParameter("@OrgID", seq.ApplyOrgID,
        //     //     new SqlParameter("@AudtiItem", seq.ApplyAuditItem));
        //     // // return seq;
        //     var posts = _context
        // }

    }
}

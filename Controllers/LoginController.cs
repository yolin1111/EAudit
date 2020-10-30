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
    public class LoginController : ControllerBase
    {
        private readonly AuditContext _context;

        public LoginController(AuditContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Org>> Post1([FromBody] LoginViewModel login)
        {
            var LoginData = await _context.Orgs.FirstOrDefaultAsync(x => x.LoginId == login.UserName);
            if (ValidateUser(login))
            {
                return Ok(LoginData);
            }
            return NotFound();

        }
        private bool ValidateUser(LoginViewModel login)
        {
            if (login.PassWord == "1234")
            {
                return true; //TODO: 登入功能需要呼叫webService
            }
            return false;
        }
    }

    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        // public string Status { get; set; }
        // public string Permission { get; set; }

    }
}

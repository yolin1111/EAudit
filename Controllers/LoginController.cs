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
        // private readonly AuditContext _context;

        // public LoginController(AuditContext context)
        // {
        //     _context = context;
        // }

        private readonly JwtHelpers jwt;

        public LoginController(JwtHelpers jwt)
        {
            this.jwt = jwt;
        }
        //TODO: 登入功能需要呼叫webService
        // [HttpPost]
        // public async Task<ActionResult<Org>> Post1([FromBody] LoginViewModel login)
        // {
        //     var LoginData = await _context.Orgs.FirstOrDefaultAsync(x => x.LoginId == login.UserName);
        //     if (login.PassWord == "1234")
        //     {
        //         return Ok(LoginData);
        //     }
        //     return NotFound();

        // }



        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> SignIn(LoginViewModel login)
        {
            if (ValidateUser(login))
            {
                return jwt.GenerateToken(login.UserName);
            }
            else
            {
                return BadRequest();
            }
        }
        private bool ValidateUser(LoginViewModel login)
        {
            if (login.PassWord == "1234")
            {
                return true; // TODO
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

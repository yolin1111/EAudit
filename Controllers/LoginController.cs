﻿using Microsoft.AspNetCore.Mvc;
using EAudit.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EAudit.Controllers
{
    public class Login
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    [Route("v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuditContext _context;

        public LoginController(AuditContext context)
        {
            _context = context;
        }
        //TODO: 登入功能需要呼叫webService
        [HttpPost]
        public async Task<ActionResult<Org>> Post1([FromBody] Login login)
        {
            var LoginData = await _context.Orgs.FirstOrDefaultAsync(x => x.LoginId == login.UserName);
            if (login.PassWord == "1234")
            {
                return Ok(LoginData);
            }
            return NotFound();

        }
    }
}

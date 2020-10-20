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
    public class JwtLoginController : ControllerBase
    {


        private readonly JwtHelpers jwt;

        public JwtLoginController(JwtHelpers jwt)
        {
            this.jwt = jwt;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> SignIn(JwtLoginViewModel login)
        {
            if (ValidateUser(login))
            {
                return jwt.GenerateToken(login.UserName);
                // return new ContentResult() { Content = jwt.GenerateToken(login.UserName) };
            }
            else
            {
                return BadRequest();
            }
        }
        private bool ValidateUser(JwtLoginViewModel login)
        {
            if (login.PassWord == "1234")
            {
                return true; //TODO: 登入功能需要呼叫webService
            }
            return false;

        }
    }

    public class JwtLoginViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        // public string Status { get; set; }
        // public string Permission { get; set; }

    }
}

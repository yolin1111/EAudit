using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EAudit.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAudit.Controllers
{

    [Route("v1/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly AuditContext _context;
        public UploadController(AuditContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files, string id)
        {
            string _folder = Environment.CurrentDirectory + "\\file";
            var size = files.Sum(f => f.Length);
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var path = $@"{_folder}\{file.FileName}";
                    var path_checked = CheckFileExistRename(path);
                    using (var stream = new FileStream(path_checked, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        await stream.FlushAsync();
                    };

                }
            }

            return Ok(new { count = files.Count, size, aa = id });
        }
        //TODO:尚未測試
        [HttpPost("A")]
        public async Task<ActionResult<AuditAttchment>> PostAuditAttchment(AuditAttchment auditAttchment)
        {
            _context.AuditAttchments.Add(auditAttchment);
            await _context.SaveChangesAsync();
            return auditAttchment;
        }
        private string CheckFileExistRename(string filePath, int seq = 0)
        {
            string checkPath = filePath;
            seq++;
            if (System.IO.File.Exists(checkPath))
            {
                string ext = Path.GetExtension(checkPath);
                string fileName = Path.GetFileNameWithoutExtension(checkPath);
                string saveFolder = Path.GetDirectoryName(checkPath);
                if (seq == 1)
                    checkPath = Path.Combine(saveFolder, fileName + "(" + seq + ")" + ext);
                else
                    checkPath = Path.Combine(saveFolder, fileName.Replace("(" + (seq - 1) + ")", "(" + seq + ")") + ext);
                string backPath = CheckFileExistRename(checkPath, seq);
                return backPath;
            }
            else
                return checkPath;

        }
    }
}
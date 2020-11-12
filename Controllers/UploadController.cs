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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EAudit.Controllers
{

    [Route("v1/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        // private IConfiguration _configuration;
        // public UploadController(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        // }

        private readonly AuditContext _context;
        public UploadController(AuditContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        // public async Task<ActionResult<AuditLineAttView>> GetAuditLineAtt(int id)
        public async Task<ActionResult<IEnumerable<AuditLineAttView>>> GetAuditLineAtt(int id)
        {
            // var AuditLineAttData = await _context.AuditLineAttViews.FindAsync(id);
            // var AuditLineAttData = await _context.AuditLineAttViews.FirstOrDefaultAsync(x => x.LineId == id);
            var AuditLineAttData = await _context.AuditLineAttViews.Where(a => a.LineId == id).ToListAsync();

            if (AuditLineAttData == null)
            {
                return NotFound();
            }

            return AuditLineAttData;
        }


        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files, [FromForm] Int32 LineID, [FromForm] string OriginalName, [FromForm] DateTime CreationDate, [FromForm] string CreatedBy, [FromForm] string Extension)
        {
            // string _root = "D:\\Projects\\EAudit\\";
            string _root = "D:\\NewFlowTest\\App\\";
            // string _root = _configuration["UploadRootPathProd"];
            string _folder = _root + "\\Files\\" + LineID + "\\";
            Directory.CreateDirectory(_folder);

            var size = files.Sum(f => f.Length);
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    string guidNumber = Guid.NewGuid().ToString();
                    // var path1 = $@"{_folder}\{file.FileName}";
                    var path = $@"{_folder}\{guidNumber}.{Extension}";
                    var path_checked = CheckFileExistRename(path);
                    using (var stream = new FileStream(path_checked, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        await stream.FlushAsync();
                    };



                    _context.AuditAttchments.Add(new AuditAttchment
                    {
                        LineId = LineID,
                        OriginalName = file.FileName,
                        Name = $@"{guidNumber}.{Extension}",
                        Path = _folder,
                        CreationDate = CreationDate,
                        CreatedBy = CreatedBy
                    });

                    await _context.SaveChangesAsync();
                }
            }



            return Ok(new
            {
                count = files.Count,
                size,
                aa = LineID
            });
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
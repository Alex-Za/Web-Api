using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Api.Services;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        IFileManager fileManager;
        public FileController(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        [HttpGet("{pathExtension}")]
        public IActionResult Get(string pathExtension)
        {
            return new JsonResult(fileManager.GetID(pathExtension));
        }

        [HttpPost("{id}/{lastChank}")]
        public void Post(int id, [FromBody]byte[] data, bool flag)
        {
            fileManager.Write(id, data);
            if (flag)
            {
                fileManager.Close(id);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weable.TMS.Model.ServiceModel;
using Weable.TMS.BO.Web.Models;
using Weable.TMS.Model.Data;
using File = Weable.TMS.Model.Data.File;

namespace Weable.TMS.BO.Web.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        private readonly IFileService _service;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<FileController> _logger;
        public static readonly string Name = "UploadFiles";
        public static readonly string ActionUpload = "Index";

        public FileController(IFileService service, IHostingEnvironment env, ILogger<FileController> logger)
        {
            _service = service;
            _env = env;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IList<IFormFile> files)
        {
            const string func = "Upload";
            try
            {
                var list = new List<File>();
                foreach (IFormFile source in files)
                {
                    string random = new Random().Next(0,99999999).ToString();
                    string fileGuid = Guid.NewGuid().ToString();
                    string filename = DateTime.Now.ToString("yyyyMMdd") + "_trainingTimelineImg_" + random;

                    filename = this.EnsureCorrectFilename(filename);

                    using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename)))
                        await source.CopyToAsync(output);

                    var file = new File() {
                        FileGuid = fileGuid,
                        FileName = GetPathAndFilename(filename),
                        MimeType = source.ContentType,
                        FileSize = (int)source.Length,
                        IsTemp = 1,
                        CreateDate = DateTime.Now
                    };
                    await _service.SaveData(file);
                    list.Add(file);
                }

                // process uploaded files
                // Don't rely on or trust the FileName property without validation.

                return Json(list.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError("{0}: Exception caught.", func, ex);
                throw ex;
            }
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return _env.WebRootPath + "\\uploads\\" + filename;
        }

    }
}
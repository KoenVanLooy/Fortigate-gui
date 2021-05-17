using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fortigate_Gui.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Fortigate_Gui.Controllers
{
    public class UploadController : Controller
    {
        public UploadController()
        {
            
        }
        // GET: UploadController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SecurityProfiles()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SecurityProfiles(UploadViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var file = viewModel.ConfigFile;
                await UploadFile(file, "FortiGate_Security_Profiles.txt");
                TempData["msg"] = "File Uploaded successfully.";
                return View();
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Download()
        {
            var path = @"wwwroot/files/FortiGate_Security_Profiles.txt";
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], filename);
        }

        public Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt","text/plain"},
                {".pdf","application/pdf"},
                {".doc","application/vnd.ms-word"}
            };
        }
        public ActionResult ReadConfig()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReadConfig(UploadViewModel viewModel)
        {
            var file = viewModel.ConfigFile;
            await UploadFile(file, "UploadConffile.txt");
            TempData["msg"] = "File Uploaded successfully.";
            return View();
        }

        public async Task<bool> UploadFile(IFormFile file, string name)
        {
            string path = "";
            bool iscopied = false;
            try
            {
                if (file.Length > 0)
                {
                    string filename = name /*+ Path.GetExtension(file.FileName)*/;
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    iscopied = true;
                }
                else
                {
                    iscopied = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return iscopied;
        }
        
    }
}
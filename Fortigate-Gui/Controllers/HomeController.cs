using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Fortigate_Gui.ViewModels;
using Fortigate_Gui.Data;
using Fortigate_Gui.Helper;

namespace Fortigate_Gui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //httpGet
        public IActionResult Index()
        {
            var sessionInterfaces = SessionHelper.GetObjectFromJson<List<Interface>>(HttpContext.Session, "sessionInterfaces");
            if (sessionInterfaces == null)
            {
                sessionInterfaces = new List<Interface>();
            }

            CreateConfViewModel viewModel = new CreateConfViewModel
            {
                
                Interfaces = sessionInterfaces
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CreateConfViewModel viewModel)
        {
            using (StreamWriter writer = new StreamWriter(@"wwwroot/files/conffile.txt"))
            {
                writer.WriteLine("hello conffile");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CrudPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult AddInterface(int? id)
        {
            //if (Aantal <= 0)
            // {
            //     return Redirect(HttpContext.Request.Headers["Referer"]);
            // }
            if (SessionHelper.GetObjectFromJson<List<Interface>>(HttpContext.Session, "sessionInterfaces") == null)
            {
                var sessionInterfaces = new List<Interface>();
                sessionInterfaces.Add(_context.Interfaces.Find(id));
                SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionInterfaces", sessionInterfaces);
            }
            else
            {
                var sessionInterfaces = SessionHelper.GetObjectFromJson<List<Interface>>(HttpContext.Session, "sessionInterfaces");
                int index = Exists(sessionInterfaces, id);
                if (index == -1)
                {
                    sessionInterfaces.Add(_context.Interfaces.Find(id));
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionInterfaces", sessionInterfaces);
            }
            return RedirectToAction("Index");
        }
        private int Exists(List<Interface> sessionInterfaces, int? id)
        {
            for (int i = 0; i < sessionInterfaces.Count; i++)
            {
                if (sessionInterfaces[i].InterfaceID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult DelInterface(int id)
        {
            var sessionInterfaces = SessionHelper.GetObjectFromJson<List<Interface>>(HttpContext.Session, "sessionInterfaces");
            sessionInterfaces.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionInterfaces", sessionInterfaces);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Download()
        {
            var path = @"wwwroot/files/Conffile.txt";
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(path));
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
    }
}


       
     
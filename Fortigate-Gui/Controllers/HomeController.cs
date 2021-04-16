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
using Microsoft.EntityFrameworkCore;

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
            var sessionZones = SessionHelper.GetObjectFromJson<List<Zone>>(HttpContext.Session, "sessionZone");
            var sessionFwAddresses = SessionHelper.GetObjectFromJson<List<FirewallAddress>>(HttpContext.Session, "sessionFwAddresses");
            if (sessionInterfaces == null)
            {
                sessionInterfaces = new List<Interface>();
            }
            if (sessionZones == null)
            {
                sessionZones = new List<Zone>();
            }
            if (sessionFwAddresses == null)
            {
                sessionFwAddresses = new List<FirewallAddress>();
            }

            CreateConfViewModel viewModel = new CreateConfViewModel
            {
                Zones = sessionZones,
                Interfaces = sessionInterfaces,
                FirewallAddresses = sessionFwAddresses
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
        public IActionResult AddZone(int? id)
        {
            //if (Aantal <= 0)
            // {
            //     return Redirect(HttpContext.Request.Headers["Referer"]);
            // }
            if (SessionHelper.GetObjectFromJson<List<Zone>>(HttpContext.Session, "sessionZone") == null)
            {
                var sessionZone = new List<Zone>();
                sessionZone.Add(_context.Zones.Find(id));
                SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionZone", sessionZone);
            }
            else
            {
                var sessionZone = SessionHelper.GetObjectFromJson<List<Zone>>(HttpContext.Session, "sessionZone");
                int index = Exists(sessionZone, id);
                if (index == -1)
                {
                    sessionZone.Add(_context.Zones.Find(id));
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionZone", sessionZone);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddFirewallAddress(int? id)
        {
            //if (Aantal <= 0)
            // {
            //     return Redirect(HttpContext.Request.Headers["Referer"]);
            // }
            if (SessionHelper.GetObjectFromJson<List<FirewallAddress>>(HttpContext.Session, "sessionFwAddresses") == null)
            {
                var sessionFwAddresses = new List<FirewallAddress>();
                sessionFwAddresses.Add(_context.FirewallAddresses.Find(id));
                SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionFwAddresses", sessionFwAddresses);
            }
            else
            {
                var sessionFwAddresses = SessionHelper.GetObjectFromJson<List<FirewallAddress>>(HttpContext.Session, "sessionFwAddresses");
                int index = Exists(sessionFwAddresses, id);
                if (index == -1)
                {
                    sessionFwAddresses.Add(_context.FirewallAddresses.Find(id));
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionFwAddresses", sessionFwAddresses);
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
        private int Exists(List<Zone> sessionZone, int? id)
        {
            for (int i = 0; i < sessionZone.Count; i++)
            {
                if (sessionZone[i].ZoneID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        private int Exists(List<FirewallAddress> sessionFwAddresses, int? id)
        {
            for (int i = 0; i < sessionFwAddresses.Count; i++)
            {
                if (sessionFwAddresses[i].FirewallAddressID == id)
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
        public IActionResult DelZone(int id)
        {
            var sessionZone = SessionHelper.GetObjectFromJson<List<Zone>>(HttpContext.Session, "sessionZone");
            sessionZone.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionZone", sessionZone);
            return RedirectToAction("Index");
        }

        public IActionResult DelFWAdress(int id)
        {
            var sessionFwAddresses = SessionHelper.GetObjectFromJson<List<FirewallAddress>>(HttpContext.Session, "sessionFwAddresses");
            sessionFwAddresses.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionFwAddresses", sessionFwAddresses);
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
        public async Task<IActionResult> StreamConf()
        {
            var connInfo = new Renci.SshNet.PasswordConnectionInfo("10.10.10.1", 221, "admin", "admin");
            var sshClient = new Renci.SshNet.SshClient(connInfo);

            sshClient.Connect();
            var stream = sshClient.CreateShellStream("", 0, 0, 0, 0, 0);
            var sessionInterfaces = SessionHelper.GetObjectFromJson<List<Interface>>(HttpContext.Session, "sessionInterfaces");
            var sessionZones = SessionHelper.GetObjectFromJson<List<Zone>>(HttpContext.Session, "sessionZone");
            var sessionFwAddresses = SessionHelper.GetObjectFromJson<List<FirewallAddress>>(HttpContext.Session, "sessionFwAddresses");

            // Send the command
            stream.WriteLine("config system interface");
            foreach (var item in sessionInterfaces)
            {
                stream.WriteLine("edit " + item.Name);
                stream.WriteLine("set vdom root");
                stream.WriteLine("set mode static " + item.EnumMode);
                stream.WriteLine("set ip " + item.Ip + " " + item.Subnet);
                stream.WriteLine("set allowaccess ping https ssh");
                stream.WriteLine("next");
            }

            stream.WriteLine("end");
            stream.WriteLine("config system zone");
            string lineZone = "";
            foreach (var item in sessionZones)
            {
                Zone zone = await _context.Zones.Include(x => x.ZoneInterfaces).ThenInclude(zi => zi.Interface)
                    .SingleOrDefaultAsync(y => y.ZoneID == item.ZoneID);
                stream.WriteLine("edit " + item.Name);
                foreach (ZoneInterface zi in zone.ZoneInterfaces)
                {
                    lineZone += zi.Interface.Name + " ";

                }
                stream.WriteLine("set interface " + lineZone);
                stream.WriteLine("next");
            }
            stream.WriteLine("end");

            foreach (var item in sessionFwAddresses)
            {
                stream.WriteLine("config firewall address");
                stream.WriteLine("edit " + item.Name);
                stream.WriteLine("set associated-interface " + item.AssociatedZone);
                stream.WriteLine("set subnet " + item.Subnet);
                stream.WriteLine("next");
            }
            stream.WriteLine("end");
            // Read with a suitable timeout to avoid hanging

            string line;
            while ((line = stream.ReadLine(TimeSpan.FromSeconds(2))) != null)
            {
                ViewBag.line = line;
                // if a termination pattern is known, check it here and break to exit immediately
            }
            // ...
            stream.Close();
            // ...
            sshClient.Disconnect();
            return View();
        }
    }
}




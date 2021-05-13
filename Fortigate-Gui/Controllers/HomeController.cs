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
using Fortigate_Gui.Script;

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
            var sessionIp4Policies = SessionHelper.GetObjectFromJson<List<Ip4Policy>>(HttpContext.Session, "sessionIp4policies");
            var sessionStaticRoutes = SessionHelper.GetObjectFromJson<List<StaticRoute>>(HttpContext.Session, "sessionStaticRoutes");
            var sessionGroups = SessionHelper.GetObjectFromJson<List<Group>>(HttpContext.Session, "sessionGroups");
            var sessionVpnSettings = SessionHelper.GetObjectFromJson<List<VpnSetting>>(HttpContext.Session, "sessionVpnSettings");
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
            if (sessionIp4Policies == null)
            {
                sessionIp4Policies = new List<Ip4Policy>();
            }
            if (sessionStaticRoutes == null)
            {
                sessionStaticRoutes = new List<StaticRoute>();
            }
            if (sessionGroups == null)
            {
                sessionGroups = new List<Group>();
            }
            if (sessionVpnSettings == null)
            {
                sessionVpnSettings = new List<VpnSetting>();
            }
            CreateConfViewModel viewModel = new CreateConfViewModel
            {
                Zones = sessionZones,
                Interfaces = sessionInterfaces,
                FirewallAddresses = sessionFwAddresses,
                Ip4Policies = sessionIp4Policies,
                StaticRoutes = sessionStaticRoutes,
                Groups = sessionGroups,
                VpnSettings = sessionVpnSettings
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int? id,CreateConfViewModel viewModel)
        {
            if (id == 1)
            {
                using (StreamWriter writer = new StreamWriter(@"wwwroot/files/conffile.txt"))
                {
                    writer.WriteLine("hello conffile");
                }
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
            bool test = viewModel.DnsFilter;
             return RedirectToAction(nameof(Index));
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

        // Add Objects to SessionAttibuteLists
        public async Task<IActionResult> AddInterface(int? id)
        {
            await AddObjectAsync(id, "sessionInterfaces", "Interface");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddZone(int? id)
        {
            await AddObjectAsync(id, "sessionZone", "Zone");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddIp4Policy(int? id)
        {
            await AddObjectAsync(id, "sessionIp4policies", "Ip4Policy");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddFirewallAddress(int? id)
        {
            await AddObjectAsync(id, "sessionFwAddresses", "FWAddress");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddStaticRoute(int? id)
        {
            await AddObjectAsync(id, "sessionStaticRoutes", "StaticRoute");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddGroup(int? id)
        {
            await AddObjectAsync(id, "sessionGroups", "Group");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddVpnSetting (int? id)
        {
            await AddObjectAsync(id, "sessionVpnSettings", "VpnSetting");
            return RedirectToAction("Index");
        }

        //General AddObject Method Defined by switch case on string Type
        public async Task AddObjectAsync(int? id, string name, string Type)
        {
            List<Interface> interfaces = new List<Interface>();
            List<Zone> zones = new List<Zone>();
            List<Ip4Policy> ip4Policies = new List<Ip4Policy>();
            List<FirewallAddress> firewallAddresses = new List<FirewallAddress>();
            List<StaticRoute> staticRoutes = new List<StaticRoute>();
            List<Group> groups = new List<Group>();
            List<VpnSetting> vpnSettings = new List<VpnSetting>();
            if (SessionHelper.GetObjectFromJson<object>(HttpContext.Session,name)==null)
            {
                switch (Type)
                {
                    case "Interface":
                        interfaces.Add(await _context.Interfaces.FindAsync(id));
                        SessionHelper.SetObjectAsJson(HttpContext.Session, name, interfaces);
                        break;

                    case "Zone":
                        zones.Add(_context.Zones.Find(id));
                        SessionHelper.SetObjectAsJson(HttpContext.Session, name, zones);
                        break;

                    case "Ip4Policy":
                        ip4Policies.Add(_context.Ip4Policies.Find(id));
                        SessionHelper.SetObjectAsJson(HttpContext.Session, name, ip4Policies);
                        break;

                    case "FWAddress":
                        firewallAddresses.Add(_context.FirewallAddresses.Find(id));
                        SessionHelper.SetObjectAsJson(HttpContext.Session, name, firewallAddresses);
                        break;
                    case "StaticRoute":
                        staticRoutes.Add(_context.StaticRoutes.Find(id));
                        SessionHelper.SetObjectAsJson(HttpContext.Session, name, staticRoutes);
                        break;
                    case "Group":
                        groups.Add(_context.Groups.Find(id));
                        SessionHelper.SetObjectAsJson(HttpContext.Session, name, groups);
                        break;
                    case "VpnSetting":
                        vpnSettings.Add(await _context.VpnSettings
                            .Include(x => x.Group)
                            .Include(y => y.VpnPortal)
                            .FirstOrDefaultAsync(x => x.VpnSettingID == id));
                        SessionHelper.SetObjectAsJson(HttpContext.Session, name, vpnSettings);
                        break;
                    default:
                        break;
                }
                
            }
            else
            {
                    switch (Type)
                    {
                        case "Interface":
                            interfaces = SessionHelper.GetObjectFromJson<List<Interface>>(HttpContext.Session, name);
                            int index = Exists(interfaces, id, Type);
                            if (index == -1)
                            {
                                interfaces.Add(_context.Interfaces.Find(id));
                                SessionHelper.SetObjectAsJson(HttpContext.Session, name, interfaces);
                            }
                            break;
                        case "Zone":
                            zones = SessionHelper.GetObjectFromJson<List<Zone>>(HttpContext.Session, name);
                            int zoneIndex = Exists(zones, id, Type);
                            if (zoneIndex == -1)
                            {
                                zones.Add(_context.Zones.Find(id));
                                SessionHelper.SetObjectAsJson(HttpContext.Session, name, zones);
                            }
                        break;
                        case "Ip4Policy":
                        ip4Policies = SessionHelper.GetObjectFromJson<List<Ip4Policy>>(HttpContext.Session, name);
                        int ip4policyindex = Exists(ip4Policies, id, Type);
                        if (ip4policyindex == -1)
                        {
                            ip4Policies.Add(_context.Ip4Policies.Find(id));
                            SessionHelper.SetObjectAsJson(HttpContext.Session, name, ip4Policies);
                        }
                        break;
                        case "FWAddress":
                        firewallAddresses = SessionHelper.GetObjectFromJson<List<FirewallAddress>>(HttpContext.Session, name);
                        int fwIndex = Exists(firewallAddresses, id, Type);
                        if (fwIndex == -1)
                        {
                            firewallAddresses.Add(_context.FirewallAddresses.Find(id));
                            SessionHelper.SetObjectAsJson(HttpContext.Session, name, firewallAddresses);
                        }
                        break;
                        case "StaticRoute":
                        staticRoutes = SessionHelper.GetObjectFromJson<List<StaticRoute>>(HttpContext.Session, name);
                        int SRIndex = Exists(staticRoutes, id, Type);
                        if (SRIndex == -1)
                        {
                            staticRoutes.Add(_context.StaticRoutes.Find(id));
                            SessionHelper.SetObjectAsJson(HttpContext.Session, name, staticRoutes);
                        }
                        break;
                        case "Group":
                        groups = SessionHelper.GetObjectFromJson<List<Group>>(HttpContext.Session, name);
                        int GIndex = Exists(groups, id, Type);
                        if (GIndex == -1)
                        {
                            groups.Add(_context.Groups.Find(id));
                            SessionHelper.SetObjectAsJson(HttpContext.Session, name, groups);
                        }
                        break;
                    case "VpnSetting":
                        vpnSettings = SessionHelper.GetObjectFromJson<List<VpnSetting>>(HttpContext.Session, name);
                        int VIndex = Exists(vpnSettings, id, Type);
                        if (VIndex == -1)
                        {
                            vpnSettings.Add(_context.VpnSettings.Find(id));
                            SessionHelper.SetObjectAsJson(HttpContext.Session, name, vpnSettings);
                        }
                        break;
                    default:
                            break;
                    }
            }  
            
            
        }
  
        //General validation of object already exists in sessionattibutes
        private int Exists(object objectList,int? id, string type)
        {
            switch (type)
            {
                case "Ip4Policy": List<Ip4Policy> ip4Policies = (List<Ip4Policy>)objectList;
                    for (int i = 0; i < ip4Policies.Count; i++)
                    {
                        if (ip4Policies[i].Ip4PolicyID == id)
                        {
                            return i;
                        }
                    }
                    return -1;
                    
                case "Interface": List<Interface> interfaces = (List<Interface>)objectList;
                    for (int i = 0; i < interfaces.Count; i++)
                    {
                        if (interfaces[i].InterfaceID == id)
                        {
                            return i;
                        }
                    }
                    return -1;
                    
                case "Zone": List<Zone> zones = (List<Zone>)objectList;
                    for (int i = 0; i < zones.Count; i++)
                    {
                        if (zones[i].ZoneID == id)
                        {
                            return i;
                        }
                    }
                    return -1;
                    
                case "FWAddress": List<FirewallAddress> firewallAddresses = (List<FirewallAddress>)objectList;
                    for (int i = 0; i < firewallAddresses.Count; i++)
                    {
                        if (firewallAddresses[i].FirewallAddressID == id)
                        {
                            return i;
                        }
                    }
                    return -1;
                case "StaticRoute":
                    List<StaticRoute> staticRoutes = (List<StaticRoute>)objectList;
                    for (int i = 0; i < staticRoutes.Count; i++)
                    {
                        if (staticRoutes[i].StaticRouteID == id)
                        {
                            return i;
                        }
                    }
                    return -1;
                case "Group":
                    List<Group> groups = (List<Group>)objectList;
                    for (int i = 0; i < groups.Count; i++)
                    {
                        if (groups[i].GroupID == id)
                        {
                            return i;
                        }
                    }
                    return -1;
                case "VpnSetting":
                    List<VpnSetting> vpnSettings = (List<VpnSetting>)objectList;
                    for (int i = 0; i < vpnSettings.Count; i++)
                    {
                        if (vpnSettings[i].VpnSettingID == id)
                        {
                            return i;
                        }
                    }
                    return -1;

                default:
                    break;
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

        public IActionResult DelIp4Policy(int id)
        {
            var sessionIp4policies = SessionHelper.GetObjectFromJson<List<Ip4Policy>>(HttpContext.Session, "sessionIp4policies");
            sessionIp4policies.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionIp4policies", sessionIp4policies);
            return RedirectToAction("Index");
        }

        public IActionResult DelStaticRoute(int id)
        {
            var sessionStaticRoutes = SessionHelper.GetObjectFromJson<List<StaticRoute>>(HttpContext.Session, "sessionStaticRoutes");
            sessionStaticRoutes.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionStaticRoutes", sessionStaticRoutes);
            return RedirectToAction("Index");
        }
        public IActionResult DelGroup(int id)
        {
            var sessionGroups = SessionHelper.GetObjectFromJson<List<Group>>(HttpContext.Session, "sessionGroups");
            sessionGroups.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionGroups", sessionGroups);
            return RedirectToAction("Index");
        }
        public IActionResult DelVpnSetting(int id)
        {
            var sessionVpnSettings = SessionHelper.GetObjectFromJson<List<VpnSetting>>(HttpContext.Session, "sessionVpnSettings");
            sessionVpnSettings.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionVpnSettings", sessionVpnSettings);
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


        public async Task<IActionResult> StreamConf ()
        {
            var sessionInterfaces = SessionHelper.GetObjectFromJson<List<Interface>>(HttpContext.Session, "sessionInterfaces");
            var sessionZones = SessionHelper.GetObjectFromJson<List<Zone>>(HttpContext.Session, "sessionZone");
            var sessionFwAddresses = SessionHelper.GetObjectFromJson<List<FirewallAddress>>(HttpContext.Session, "sessionFwAddresses");
            var ip4policies = SessionHelper.GetObjectFromJson<List<Ip4Policy>>(HttpContext.Session, "sessionIp4policies");
            var sessionStaticRoutes = SessionHelper.GetObjectFromJson<List<StaticRoute>>(HttpContext.Session, "sessionStaticRoutes");
            var sessionGroups = SessionHelper.GetObjectFromJson<List<Group>>(HttpContext.Session, "sessionGroups");
            var sessionVpnSettings = SessionHelper.GetObjectFromJson<List<VpnSetting>>(HttpContext.Session, "sessionVpnSetting");
            StreamScript Script = new StreamScript(sessionInterfaces, sessionFwAddresses, sessionZones,  ip4policies, sessionStaticRoutes, sessionGroups, sessionVpnSettings, _context);
            await Script.StreamScriptAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TestStream()
        {
            TestConnectionViewModel viewModel = new TestConnectionViewModel
            {
                IpAddress = "",
                PassWord = "",
                UserName = ""

            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestStream(TestConnectionViewModel viewModel)
        {
            string UserName = viewModel.UserName;
            string Password = viewModel.PassWord;
            string IpAddress = viewModel.IpAddress;

           

            var connInfo = new Renci.SshNet.PasswordConnectionInfo(IpAddress, 221, UserName, Password);
            var sshClient = new Renci.SshNet.SshClient(connInfo);
            try
            {
                sshClient.Connect();
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Index", viewModel) });
            }
            var sessionIpAddress = IpAddress;
            var sessionUserName = UserName;
            var sessionPassword = Password;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionIpAddress", sessionIpAddress);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionUserName", sessionUserName);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "sessionPassword", sessionPassword);
            sshClient.Disconnect();
            return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "Index", viewModel) });

        }
    }
}




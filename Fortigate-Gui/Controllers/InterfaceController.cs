using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Fortigate_Gui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fortigate_Gui.Controllers
{
    public class InterfaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InterfaceController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get Create:index
        public IActionResult Index()
        {
            CreateInterfaceViewModel viewModel = new CreateInterfaceViewModel
            {
                Interface = new Interface(),
                Modes = new SelectList(_context.EnumModes,"EnumModeID","Name"),
                AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name")
            };
            return View(viewModel);
        }

        // POST: Create:index
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateInterfaceViewModel viewModel)
        {
           
            if (ModelState.IsValid)
        
            {
                _context.Add(viewModel.Interface);
                await _context.SaveChangesAsync();

                Interface @interface = await  _context.Interfaces
                    .Where(x=>x.InterfaceID == viewModel.Interface.InterfaceID)
                    .Include(y => y.EnumAcces)
                    .Include(z => z.EnumMode)
                    .SingleOrDefaultAsync();
                    
                using (StreamWriter writer = new StreamWriter("InterfaceScript.txt"))
                { 
                    writer.WriteLine("config system interface");
                    writer.WriteLine("edit "+@interface.Name);
                    writer.WriteLine("set vdom "+@interface.Vdom);
                    writer.WriteLine("set mode "+@interface.EnumMode.Name);
                    writer.WriteLine("set ip "+ viewModel.IpAddress +" "+@interface.Subnet);
                    writer.WriteLine("set allowaccess "+@interface.EnumAcces.Name);
                    writer.WriteLine("set vlanid 1");
                    writer.WriteLine("set interface internal");
                    writer.WriteLine("next");
                    writer.WriteLine("end");
                }
                return RedirectToAction(nameof(Index));
                
           }
            viewModel.Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name",viewModel.Interface.EnumModeID);
            viewModel.AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name",viewModel.Interface.EnumAccesID);
            return View(viewModel);
        }

        public IActionResult Stream()
        {
            var connInfo = new Renci.SshNet.PasswordConnectionInfo("10.10.10.1", 221, "admin", "admin");
            var sshClient = new Renci.SshNet.SshClient(connInfo);

            sshClient.Connect();
            var stream = sshClient.CreateShellStream("", 0, 0, 0, 0, 0);

            // Send the command
            stream.WriteLine("config system interface");
            stream.WriteLine("edit Koen");
            stream.WriteLine("set vdom root");
            stream.WriteLine("set mode static");
            stream.WriteLine("set ip 192.168.65.5 255.255.255.0");
            stream.WriteLine("set allowaccess ping");
            stream.WriteLine("set vlanid 1");
            stream.WriteLine("set interface internal");
            stream.WriteLine("next");
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

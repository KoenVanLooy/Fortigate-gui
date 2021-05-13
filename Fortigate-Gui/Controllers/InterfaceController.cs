using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fortigate_Gui.Data;
using Fortigate_Gui.Helper;
using Fortigate_Gui.Models;
using Fortigate_Gui.ValidationAttributes;
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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interfaces.Include(x => x.EnumType)
                .Include(x => x.EnumPhysical) 
                .Include(x => x.EnumMode)
                .ToListAsync());
        }

        // GET: Interfacess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @interface = await _context.Interfaces
                .Include(x => x.AccessInterfaces)
                .Include(y => y.EnumMode)
                .FirstOrDefaultAsync(m => m.InterfaceID == id);
            if (@interface == null)
            {
                return NotFound();
            }

            return View(@interface);
        }
        [NoDirectAccessAttribute]
        public IActionResult Create()
        {
            CreateInterfaceViewModel viewModel = new CreateInterfaceViewModel
            {
                Interface = new Interface(),
                Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name"),
                Types = new SelectList(_context.EnumTypes,"EnumTypeID","Name"),
                Physicals = new SelectList(_context.EnumPhysicals,"EnumPhysicalID","Name"),
                SelectedEnumAcces = new List<int>(),
                AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name")
            };

            return View(viewModel);
        }

        // POST: Create:index
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateInterfaceViewModel viewModel)
        {
            viewModel.Interface.Ip = viewModel.IpAddress;
            EnumPhysical physical = _context.EnumPhysicals.SingleOrDefault(x => x.EnumPhysicalID == viewModel.Interface.EnumPhysicalID);
            if (viewModel.VlanName == "NO_VLAN")
            {
                viewModel.Interface.Name = physical.Name;
            }
            else
            {
                viewModel.Interface.Name = viewModel.Interface.Name;
            }

            if (ModelState.IsValid)

            {
                List<AccessInterface> newLines = new List<AccessInterface>();
                foreach (int enumAccesID in viewModel.SelectedEnumAcces)
                {
                    AccessInterface accessInterface = new AccessInterface();
                    accessInterface.EnumAccesID = enumAccesID;
                    accessInterface.InterfaceID = viewModel.Interface.InterfaceID;

                    newLines.Add(accessInterface);
                }
                _context.Add(viewModel.Interface);
                await _context.SaveChangesAsync();
                Interface @interface = await _context.Interfaces
                  .Where(x => x.InterfaceID == viewModel.Interface.InterfaceID)
                  .Include(y => y.AccessInterfaces)
                  .Include(t => t.EnumPhysical)
                  .Include(z => z.EnumMode)
                  .SingleOrDefaultAsync();


                foreach (AccessInterface accessInterface1 in newLines)
                {
                    @interface.AccessInterfaces.Add(accessInterface1);
                }
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.Interfaces.Include(x => x.EnumType)
                .Include(x => x.EnumPhysical)
                .Include(x => x.EnumMode)
                .ToListAsync())});

            }
            viewModel.Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name", viewModel.Interface.EnumModeID);
            viewModel.AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name");
            viewModel.Types = new SelectList(_context.EnumTypes, "EnumTypeID", "Name");
            viewModel.Physicals = new SelectList(_context.EnumPhysicals, "EnumPhysicalID", "Name");
          return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", viewModel)}); 
        }

        public IActionResult Stream()
        {
            var connInfo = new Renci.SshNet.PasswordConnectionInfo("10.10.10.1", 221, "admin", "admin");
            var sshClient = new Renci.SshNet.SshClient(connInfo);

            sshClient.Connect();
            var stream = sshClient.CreateShellStream("", 0, 0, 0, 0, 0);

            // Send the command
            stream.WriteLine("config system interface");
            stream.WriteLine("edit internal1");
            stream.WriteLine("set vdom root");
            stream.WriteLine("set mode static");
            stream.WriteLine("set ip 192.168.65.5 255.255.255.0");
            stream.WriteLine("set allowaccess ping https ssh");
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

        [NoDirectAccessAttribute]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @interface = await _context.Interfaces.Include(x => x.AccessInterfaces).
                SingleOrDefaultAsync(y => y.InterfaceID == id);
            if (@interface == null)
            {
                return NotFound();
            }
            EditInterfaceViewModel viewModel = new EditInterfaceViewModel
            {
                Interface = @interface,
                IpAddress = @interface.Ip,
                Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name", @interface.EnumModeID),
                AccessList = new SelectList(_context.EnumAcces, "EnumAccesID", "Name"),
                SelectedEnumAcces = @interface.AccessInterfaces.Select(ai => ai.EnumAccesID)
            };
            ////ViewData["EnumAccesID"] = new SelectList(_context.EnumAcces, "EnumAccesID", "Name", @interface.EnumAccesID);
            //ViewData["EnumModeID"] = new SelectList(_context.EnumModes, "EnumModeID", "Name", @interface.EnumModeID);
            return View(viewModel);
        }

        // POST: Interfacess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditInterfaceViewModel viewModel)
        {
            Interface @interface = await _context.Interfaces.Include(i => i.AccessInterfaces)
               .SingleOrDefaultAsync(x => x.InterfaceID == id);
            if (id != viewModel.Interface.InterfaceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                @interface.Alias = viewModel.Interface.Alias;
                @interface.Name = viewModel.Interface.Name;
                @interface.Ip = viewModel.IpAddress;
                @interface.Subnet = viewModel.Interface.Subnet;
                @interface.EnumTypeID = viewModel.Interface.EnumTypeID;
                @interface.EnumModeID = viewModel.Interface.EnumModeID;

                List<AccessInterface> accessInterfaces = new List<AccessInterface>();
                if (viewModel.SelectedEnumAcces == null)
                {
                    return View(viewModel);
                }
                foreach (int enumAccessID in viewModel.SelectedEnumAcces)
                {
                    accessInterfaces.Add(
                    new AccessInterface
                    {
                        EnumAccesID = enumAccessID,
                        InterfaceID = viewModel.Interface.InterfaceID
                    }
                  );
                }
                @interface.AccessInterfaces.RemoveAll(ai => !accessInterfaces.Contains(ai));
                @interface.AccessInterfaces.AddRange(accessInterfaces.Where(zi => !@interface.AccessInterfaces.Contains(zi)));
                
                    _context.Update(@interface);
                    await _context.SaveChangesAsync();
                
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.Interfaces.ToListAsync()) });
            }
            viewModel.AccessList = new SelectList(_context.Interfaces, "InterfaceID", "Name");
            viewModel.SelectedEnumAcces = @interface.AccessInterfaces.Select(ai => ai.EnumAccesID);
            viewModel.Modes = new SelectList(_context.EnumModes, "EnumModeID", "Name", @interface.EnumModeID);

            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", viewModel) });
        }

       

        // POST: Interfacess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @interface = await _context.Interfaces.FindAsync(id);
            _context.Interfaces.Remove(@interface);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.Interfaces.ToListAsync()) });
        }

        private bool InterfaceExists(int id)
        {
            return _context.Interfaces.Any(e => e.InterfaceID == id);
        }
    }
}

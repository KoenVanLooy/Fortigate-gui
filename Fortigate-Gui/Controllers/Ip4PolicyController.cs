using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Fortigate_Gui.ViewModels;
using Fortigate_Gui.Helper;
using Fortigate_Gui.ValidationAttributes;

namespace Fortigate_Gui.Controllers
{
    public class Ip4PolicyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Ip4PolicyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ip4Policy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ip4Policies.ToListAsync());
        }

        // GET: Ip4Policy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ip4Policy = await _context.Ip4Policies
                .FirstOrDefaultAsync(m => m.Ip4PolicyID == id);
            if (ip4Policy == null)
            {
                return NotFound();
            }

            return View(ip4Policy);
        }

        // GET: Ip4Policy/Create
        [HttpGet]
        public async Task<JsonResult> FetchSourceAddress(int ID)
        {
            Zone zone = await _context.Zones.SingleOrDefaultAsync(x => x.ZoneID == ID);
            var data = _context.FirewallAddresses
                .Where(fw => fw.AssociatedZone == zone.Name)
                .Select(l => new { Value = l.Name, Text = l.Name });
            return Json(data, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        public async Task<JsonResult> FetchDestinationAddress(int ID)
        {
            Zone zone = await _context.Zones.SingleOrDefaultAsync(x => x.ZoneID == ID);
            var data = _context.FirewallAddresses
                .Where(fw => fw.AssociatedZone == zone.Name)
                .Select(l => new { Value = l.Name, Text = l.Name });
            return Json(data, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [NoDirectAccessAttribute]
        public async Task<IActionResult> Create()
        {
            Zone zone = await _context.Zones.FirstOrDefaultAsync();
            List<FirewallAddress> firewallAddresses = await _context.FirewallAddresses
                .Where(fw => fw.AssociatedZone == zone.Name).ToListAsync();


            CreateIp4PolicyViewModel viewModel = new CreateIp4PolicyViewModel
            {
                ip4Policy = new Ip4Policy(),
                SourceInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name"),
                DestinationInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name"),
                SourceAddress = new SelectList(firewallAddresses, "Name", "Name"),
                DestinationAddress = new SelectList(firewallAddresses, "Name", "Name"),
                Actions = new SelectList(await _context.Actions.ToListAsync(), "ActionID", "Name"),
                Nat = new SelectList(await _context.Nat.ToArrayAsync(), "NatID", "Name"),
                SelectedService = new List<int>(),
                ServiceList = new SelectList(_context.Services, "ServiceID", "Name")
            };
            return View(viewModel);
        }

        // POST: Ip4Policy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateIp4PolicyViewModel viewModel)
        {
            Ip4Policy policy = viewModel.ip4Policy;
            if (ModelState.IsValid)
            {
                List<Ip4PolicyService> newLines = new List<Ip4PolicyService>();
                if (viewModel.SelectedService != null)
                {


                    foreach (int serviceID in viewModel.SelectedService)
                    {
                        Ip4PolicyService ip4PolicyService = new Ip4PolicyService();
                        ip4PolicyService.ServiceID = serviceID;
                        ip4PolicyService.Ip4PolicyID = viewModel.ip4Policy.Ip4PolicyID;

                        newLines.Add(ip4PolicyService);
                    }
                }
                _context.Add(viewModel.ip4Policy);
                await _context.SaveChangesAsync();


                Ip4Policy ip4Policy = await _context.Ip4Policies
                    .Where(x => x.Ip4PolicyID == viewModel.ip4Policy.Ip4PolicyID)
                    .Include(y => y.Ip4PolicyServices)
                    .SingleOrDefaultAsync();
                foreach (Ip4PolicyService ip4PolicyService1 in newLines)
                {
                    ip4Policy.Ip4PolicyServices.Add(ip4PolicyService1);
                }

                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.Ip4Policies.ToListAsync()) });
            }
            viewModel.SourceInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name");
            viewModel.DestinationInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name");
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", viewModel) }); 
        }

        // GET: Ip4Policy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ip4Policy ip4Policy = await _context.Ip4Policies
                .Include(x => x.Ip4PolicyServices)
                .SingleOrDefaultAsync(y => y.Ip4PolicyID == id);

            EditIp4PolicyViewModel viewModel = new EditIp4PolicyViewModel
            {
                ip4Policy = ip4Policy,
                SourceInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name", ip4Policy.SourceInterfaceID),
                DestinationInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name", ip4Policy.DestinationInterfaceID),
                Actions = new SelectList(await _context.Actions.ToListAsync(), "ActionID", "Name", ip4Policy.ActionID),
                Nat = new SelectList(await _context.Nat.ToArrayAsync(), "NatID", "Name", ip4Policy.NatID),
                ServiceList = new SelectList(_context.Services, "ServiceID", "Name"),
                SelectedService = ip4Policy.Ip4PolicyServices.Select(x => x.ServiceID)
            };

            if (ip4Policy == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: Ip4Policy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditIp4PolicyViewModel viewModel)
        {
            Ip4Policy ip4Policy = await _context.Ip4Policies
                .Include(i => i.Ip4PolicyServices)
                .SingleOrDefaultAsync(x => x.Ip4PolicyID == id);
            if (id != viewModel.ip4Policy.Ip4PolicyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ip4Policy.NatID = viewModel.ip4Policy.NatID;
                ip4Policy.SourceInterfaceID = viewModel.ip4Policy.SourceInterfaceID;
                ip4Policy.DestinationInterfaceID = viewModel.ip4Policy.DestinationInterfaceID;
                ip4Policy.SourceAddress = viewModel.ip4Policy.SourceAddress;
                ip4Policy.DestinationAddress = viewModel.ip4Policy.DestinationAddress;
                ip4Policy.ActionID = viewModel.ip4Policy.ActionID;
                ip4Policy.NatID = viewModel.ip4Policy.NatID;
                ip4Policy.DnsFilter = viewModel.ip4Policy.DnsFilter;
                ip4Policy.AppFilter = viewModel.ip4Policy.AppFilter;
                ip4Policy.AvFilter = viewModel.ip4Policy.AvFilter;
                ip4Policy.IpsFilter = viewModel.ip4Policy.IpsFilter;
                ip4Policy.ProxyFilter = viewModel.ip4Policy.ProxyFilter;
                ip4Policy.SslFilter = viewModel.ip4Policy.SslFilter;
                ip4Policy.WebFilter = viewModel.ip4Policy.WebFilter;

                List<Ip4PolicyService> ip4PolicyServices = new List<Ip4PolicyService>();
                if (viewModel.SelectedService == null)
                {
                    viewModel.SelectedService = new List<int>();
                }
                foreach (int serviceID in viewModel.SelectedService)
                {
                    ip4PolicyServices.Add(
                    new Ip4PolicyService
                    {
                        ServiceID = serviceID,
                        Ip4PolicyID = viewModel.ip4Policy.Ip4PolicyID
                    }
                  );
                }
                ip4Policy.Ip4PolicyServices.RemoveAll(x => !ip4PolicyServices.Contains(x));
                ip4Policy.Ip4PolicyServices.AddRange(ip4PolicyServices.Where(x => !ip4Policy.Ip4PolicyServices.Contains(x)));

                _context.Update(ip4Policy);
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.Ip4Policies.ToListAsync()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", viewModel) });
        }

        // GET: Ip4Policy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ip4Policy = await _context.Ip4Policies
                .FirstOrDefaultAsync(m => m.Ip4PolicyID == id);
            if (ip4Policy == null)
            {
                return NotFound();
            }

            return View(ip4Policy);
        }

        // POST: Ip4Policy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ip4Policy = await _context.Ip4Policies.FindAsync(id);
            _context.Ip4Policies.Remove(ip4Policy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Ip4PolicyExists(int id)
        {
            return _context.Ip4Policies.Any(e => e.Ip4PolicyID == id);
        }
    }
}
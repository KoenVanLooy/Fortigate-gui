


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

        [NoDirectAccessAttribute]
        public async Task<IActionResult> Create()
        {
            CreateIp4PolicyViewModel viewModel = new CreateIp4PolicyViewModel
            {
                ip4Policy = new Ip4Policy(),
                SourceInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name"),
                DestinationInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name"),
                Actions = new SelectList(await _context.Actions.ToListAsync(), "ActionID", "Name"),
                Nat = new SelectList(await _context.Nat.ToArrayAsync(),"NatID","Name"),
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
                foreach (int serviceID in viewModel.SelectedService)
                {
                    Ip4PolicyService ip4PolicyService = new Ip4PolicyService();
                    ip4PolicyService.ServiceID = serviceID;
                    ip4PolicyService.Ip4PolicyID = viewModel.ip4Policy.Ip4PolicyID;

                    newLines.Add(ip4PolicyService);
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
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "Index", await _context.Ip4Policies.ToListAsync()) });
            }
            viewModel.SourceInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name");
            viewModel.DestinationInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name");
            return View(viewModel);
        }

        // GET: Ip4Policy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ip4Policy ip4Policy = await _context.Ip4Policies.FindAsync(id);
            EditIp4PolicyViewModel viewModel = new EditIp4PolicyViewModel
            {
                ip4Policy = ip4Policy,
                SourceInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name",ip4Policy.SourceInterfaceID),
                DestinationInterface = new SelectList(await _context.Zones.ToListAsync(), "ZoneID", "Name",ip4Policy.DestinationInterfaceID)
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
            if (id != viewModel.ip4Policy.Ip4PolicyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.ip4Policy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ip4PolicyExists(viewModel.ip4Policy.Ip4PolicyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel.ip4Policy);
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

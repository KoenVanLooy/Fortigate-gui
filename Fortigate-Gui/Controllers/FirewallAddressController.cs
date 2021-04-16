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

namespace Fortigate_Gui.Controllers
{
    public class FirewallAddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FirewallAddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FirewallAddress
        public async Task<IActionResult> Index()
        {
            return View(await _context.FirewallAddresses.ToListAsync());
        }

        // GET: FirewallAddress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firewallAddress = await _context.FirewallAddresses
                .FirstOrDefaultAsync(m => m.FirewallAddressID == id);
            if (firewallAddress == null)
            {
                return NotFound();
            }

            return View(firewallAddress);
        }

        // GET: FirewallAddress/Create
        public async Task<IActionResult> Create()
        {
            List<string> zones = new List<string>();
            List<Zone> zonesObjects = await _context.Zones.ToListAsync();
            foreach (Zone zone in zonesObjects)
            {
                zones.Add(zone.Name);
            }
            CreateFWViewModel viewModel = new CreateFWViewModel
            {
                FirewallAddress = new FirewallAddress(),
                Zones = new SelectList(zones)
            };
            return View(viewModel);
        }

        // POST: FirewallAddress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFWViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.FirewallAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: FirewallAddress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<string> zones = new List<string>();
            List<Zone> zonesObjects = await _context.Zones.ToListAsync();
            foreach (Zone zone in zonesObjects)
            {
                zones.Add(zone.Name);
            }

            var firewallAddress = await _context.FirewallAddresses.FindAsync(id);
            EditFWViewModel viewModel = new EditFWViewModel
            {
                FirewallAddress = firewallAddress,
                Zones = new SelectList(zones,firewallAddress.AssociatedZone)
            };
          
            if (firewallAddress == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: FirewallAddress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditFWViewModel viewModel)
        {
            if (id != viewModel.FirewallAddress.FirewallAddressID)
        
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.FirewallAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirewallAddressExists(viewModel.FirewallAddress.FirewallAddressID))
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
            return View(viewModel);
        }

        // GET: FirewallAddress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firewallAddress = await _context.FirewallAddresses
                .FirstOrDefaultAsync(m => m.FirewallAddressID == id);
            if (firewallAddress == null)
            {
                return NotFound();
            }

            return View(firewallAddress);
        }

        // POST: FirewallAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firewallAddress = await _context.FirewallAddresses.FindAsync(id);
            _context.FirewallAddresses.Remove(firewallAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirewallAddressExists(int id)
        {
            return _context.FirewallAddresses.Any(e => e.FirewallAddressID == id);
        }
    }
}

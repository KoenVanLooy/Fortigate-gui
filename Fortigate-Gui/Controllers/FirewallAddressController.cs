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
            //List of FirewallAddresses
            return View(await _context.FirewallAddresses.ToListAsync());
        }

        // GET: FirewallAddress/Create
        public async Task<IActionResult> Create()
        {

            List<string> zones = new List<string>();
            List<Zone> zonesObjects = await _context.Zones.ToListAsync();
            //Making from zones(object) => zones.Name List to make a selectlist
            foreach (Zone zone in zonesObjects)
            {
                zones.Add(zone.Name);
            }
            CreateFWViewModel viewModel = new CreateFWViewModel //viewModel cause more than one object is given to View
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
                //Update the current view with data from database, to have live refresh we add JSON
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.FirewallAddresses.ToListAsync()) });
            }
            //Update the current view with isValid: false when an error happens in our validation
            List<string> zones = new List<string>();
            List<Zone> zonesObjects = await _context.Zones.ToListAsync();
            foreach (Zone zone in zonesObjects)
            {
                zones.Add(zone.Name);
            }
            viewModel.Zones = new SelectList(zones);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", viewModel) });
        }

        // GET: FirewallAddress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Making from zones(object) => zones.Name List to make a selectlist
            List<string> zones = new List<string>();
            List<Zone> zonesObjects = await _context.Zones.ToListAsync();
            foreach (Zone zone in zonesObjects)
            {
                zones.Add(zone.Name);
            }

            var firewallAddress = await _context.FirewallAddresses.FindAsync(id);
            EditFWViewModel viewModel = new EditFWViewModel //viewModel cause More than one object is given to View
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
            //check if firewalladdress is found
            if (id != viewModel.FirewallAddress.FirewallAddressID)
        
            {
                return NotFound();
            }
            // ModelState isValid => we can update
            if (ModelState.IsValid)
            {
                _context.Update(viewModel.FirewallAddress);
                await _context.SaveChangesAsync();
               
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.FirewallAddresses.ToListAsync()) });
            }
            List<string> zones = new List<string>();
            List<Zone> zonesObjects = await _context.Zones.ToListAsync();
            foreach (Zone zone in zonesObjects)
            {
                zones.Add(zone.Name);
            }
            viewModel.Zones = new SelectList(zones);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", viewModel) });
        }
   

        // POST: FirewallAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firewallAddress = await _context.FirewallAddresses.FindAsync(id);
            _context.FirewallAddresses.Remove(firewallAddress);
            await _context.SaveChangesAsync();
            return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.FirewallAddresses.ToListAsync()) });
        }

        private bool FirewallAddressExists(int id)
        {
            return _context.FirewallAddresses.Any(e => e.FirewallAddressID == id);
        }
    }
}

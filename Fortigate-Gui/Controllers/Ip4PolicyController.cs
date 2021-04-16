using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;

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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ip4Policy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ip4PolicyID,SourceInterface,DestinationInterface,SourceAddress,DestinationAddress,Type")] Ip4Policy ip4Policy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ip4Policy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ip4Policy);
        }

        // GET: Ip4Policy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ip4Policy = await _context.Ip4Policies.FindAsync(id);
            if (ip4Policy == null)
            {
                return NotFound();
            }
            return View(ip4Policy);
        }

        // POST: Ip4Policy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ip4PolicyID,SourceInterface,DestinationInterface,SourceAddress,DestinationAddress,Type")] Ip4Policy ip4Policy)
        {
            if (id != ip4Policy.Ip4PolicyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ip4Policy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ip4PolicyExists(ip4Policy.Ip4PolicyID))
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
            return View(ip4Policy);
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

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
    public class EnumModeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnumModeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnumMode
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnumModes.ToListAsync());
        }

        // GET: EnumMode/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumMode = await _context.EnumModes
                .FirstOrDefaultAsync(m => m.EnumModeID == id);
            if (enumMode == null)
            {
                return NotFound();
            }

            return View(enumMode);
        }

        // GET: EnumMode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnumMode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnumModeID,Name")] EnumMode enumMode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enumMode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enumMode);
        }

        // GET: EnumMode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumMode = await _context.EnumModes.FindAsync(id);
            if (enumMode == null)
            {
                return NotFound();
            }
            return View(enumMode);
        }

        // POST: EnumMode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnumModeID,Name")] EnumMode enumMode)
        {
            if (id != enumMode.EnumModeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enumMode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnumModeExists(enumMode.EnumModeID))
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
            return View(enumMode);
        }

        // GET: EnumMode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumMode = await _context.EnumModes
                .FirstOrDefaultAsync(m => m.EnumModeID == id);
            if (enumMode == null)
            {
                return NotFound();
            }

            return View(enumMode);
        }

        // POST: EnumMode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enumMode = await _context.EnumModes.FindAsync(id);
            _context.EnumModes.Remove(enumMode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnumModeExists(int id)
        {
            return _context.EnumModes.Any(e => e.EnumModeID == id);
        }
    }
}

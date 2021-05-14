using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Fortigate_Gui.Helper;

namespace Fortigate_Gui.Controllers
{
    public class EnumPhysicalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnumPhysicalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnumPhysical
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnumPhysicals.ToListAsync());
        }

        // GET: EnumPhysical/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnumPhysical/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnumPhysicalID,Name")] EnumPhysical enumPhysical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enumPhysical);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.EnumPhysicals.ToListAsync()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", enumPhysical) });
        }

        // GET: EnumPhysical/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumPhysical = await _context.EnumPhysicals.FindAsync(id);
            if (enumPhysical == null)
            {
                return NotFound();
            }
            return View(enumPhysical);
        }

        // POST: EnumPhysical/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnumPhysicalID,Name")] EnumPhysical enumPhysical)
        {
            if (id != enumPhysical.EnumPhysicalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(enumPhysical);
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumPhysicals.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", enumPhysical) });
        }

        // POST: EnumPhysical/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enumPhysical = await _context.EnumPhysicals.FindAsync(id);
            _context.EnumPhysicals.Remove(enumPhysical);
            await _context.SaveChangesAsync();
            return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumPhysicals.ToList()) });
        }

        private bool EnumPhysicalExists(int id)
        {
            return _context.EnumPhysicals.Any(e => e.EnumPhysicalID == id);
        }
    }
}

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
using Microsoft.AspNetCore.Authorization;

namespace Fortigate_Gui.Controllers
{

    [Authorize(Roles = "Admin")]
    public class EnumModeController : Controller
    {
        //Default generated Controller with entity frameworkcore for Admin adjustments
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
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.EnumModes.ToListAsync()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", enumMode) });
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
                _context.Update(enumMode);
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumModes.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", enumMode) });
        }

        // POST: EnumMode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enumMode = await _context.EnumModes.FindAsync(id);
            _context.EnumModes.Remove(enumMode);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumModes.ToList()) });
        }

        private bool EnumModeExists(int id)
        {
            return _context.EnumModes.Any(e => e.EnumModeID == id);
        }
    }
}

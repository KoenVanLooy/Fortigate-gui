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
    public class EnumAccesController : Controller
    {
        //Default generated Controller with entity frameworkcore for Admin adjustments
        private readonly ApplicationDbContext _context;
        
        public EnumAccesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnumAcces
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnumAcces.ToListAsync());
        }

        // GET: EnumAcces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnumAcces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnumAccesID,Name")] EnumAcces enumAcces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enumAcces);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.EnumAcces.ToListAsync()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", enumAcces) });
        }

        // GET: EnumAcces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumAcces = await _context.EnumAcces.FindAsync(id);
            if (enumAcces == null)
            {
                return NotFound();
            }
            return View(enumAcces);
        }

        // POST: EnumAcces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnumAccesID,Name")] EnumAcces enumAcces)
        {
            if (id != enumAcces.EnumAccesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(enumAcces);
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumAcces.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", enumAcces) });
        }

        // POST: EnumAcces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enumAcces = await _context.EnumAcces.FindAsync(id);
            _context.EnumAcces.Remove(enumAcces);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumAcces.ToList()) });
        }

        private bool EnumAccesExists(int id)
        {
            return _context.EnumAcces.Any(e => e.EnumAccesID == id);
        }
    }
}

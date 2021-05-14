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
    public class EnumTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnumTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnumType
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnumTypes.ToListAsync());
        }

        // GET: EnumType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnumType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnumTypeID,Name")] EnumType enumType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enumType);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.EnumTypes.ToListAsync()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", enumType) });
        }

        // GET: EnumType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumType = await _context.EnumTypes.FindAsync(id);
            if (enumType == null)
            {
                return NotFound();
            }
            return View(enumType);
        }

        // POST: EnumType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnumTypeID,Name")] EnumType enumType)
        {
            if (id != enumType.EnumTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(enumType);
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumTypes.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", enumType) });
        }

        // POST: EnumType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enumType = await _context.EnumTypes.FindAsync(id);
            _context.EnumTypes.Remove(enumType);
            await _context.SaveChangesAsync();
            return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.EnumTypes.ToList()) });
        }

        private bool EnumTypeExists(int id)
        {
            return _context.EnumTypes.Any(e => e.EnumTypeID == id);
        }
    }
}

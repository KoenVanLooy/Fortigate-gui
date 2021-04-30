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
using Fortigate_Gui.ValidationAttributes;

namespace Fortigate_Gui.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groups.Include(c => c.configFile);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Group/AddOrEdit
        // GET: Group/AddOrEdit/5
        [NoDirectAccessAttribute]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID");
                return View(new Group());
            }
            else
            {
                Group group = await _context.Groups.FindAsync(id);
                if (group == null)
                {
                    return NotFound();
                }
                ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID", group.ConfigFileID);
                return View(group);
            }
        }

        // POST: Group/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("GroupID,Name,ConfigFileID")] Group group)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(group);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(group);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GroupExists(group.GroupID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.Groups.ToList()) });
            }
                
            ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID", group.ConfigFileID);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", group) });
        }


        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.Groups.ToList()) });
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupID == id);
        }
    }
}

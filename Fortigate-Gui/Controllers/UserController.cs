using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Fortigate_Gui.ValidationAttributes;
using Fortigate_Gui.Helper;

namespace Fortigate_Gui.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.FortiUsers.ToListAsync());
        }


        // GET: User/Create
        // GET: User/Create/5
        [NoDirectAccessAttribute]
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new FortiUser());
            }
            else
            {
                FortiUser fortiUser = await _context.FortiUsers.FindAsync(id);
                if (fortiUser == null)
                {
                    return NotFound();
                }
                return View(fortiUser);
            }
        }

        // POST: User/AddOrEdit
        // POST: User/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("FortiUserID,Name,Password")] FortiUser fortiUser)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(fortiUser);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(fortiUser);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FortiUserExists(fortiUser.FortiUserID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.FortiUsers.ToList()) });
            }
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", fortiUser) });
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fortiUser = await _context.FortiUsers.FindAsync(id);
            _context.FortiUsers.Remove(fortiUser);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.FortiUsers.ToList()) });
        }

        private bool FortiUserExists(int id)
        {
            return _context.FortiUsers.Any(e => e.FortiUserID == id);
        }
    }
}

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
    public class StaticRouteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaticRouteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaticRoute
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaticRoutes.Include(s => s.Interface);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StaticRoute/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticRoute = await _context.StaticRoutes
                .Include(s => s.Interface)
                .FirstOrDefaultAsync(m => m.StaticRouteID == id);
            if (staticRoute == null)
            {
                return NotFound();
            }

            return View(staticRoute);
        }

        // GET: StaticRoute/Create
        public IActionResult Create()
        {
            ViewData["InterfaceID"] = new SelectList(_context.Interfaces, "InterfaceID", "Name");
            return View();
        }

        // POST: StaticRoute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaticRouteID,InterfaceID,DestinationSubnet,Gateway")] StaticRoute staticRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staticRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InterfaceID"] = new SelectList(_context.Interfaces, "InterfaceID", "Alias", staticRoute.InterfaceID);
            return View(staticRoute);
        }

        // GET: StaticRoute/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticRoute = await _context.StaticRoutes.FindAsync(id);
            if (staticRoute == null)
            {
                return NotFound();
            }
            ViewData["InterfaceID"] = new SelectList(_context.Interfaces, "InterfaceID", "Alias", staticRoute.InterfaceID);
            return View(staticRoute);
        }

        // POST: StaticRoute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaticRouteID,InterfaceID,DestinationSubnet,Gateway")] StaticRoute staticRoute)
        {
            if (id != staticRoute.StaticRouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staticRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaticRouteExists(staticRoute.StaticRouteID))
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
            ViewData["InterfaceID"] = new SelectList(_context.Interfaces, "InterfaceID", "Alias", staticRoute.InterfaceID);
            return View(staticRoute);
        }

        // GET: StaticRoute/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticRoute = await _context.StaticRoutes
                .Include(s => s.Interface)
                .FirstOrDefaultAsync(m => m.StaticRouteID == id);
            if (staticRoute == null)
            {
                return NotFound();
            }

            return View(staticRoute);
        }

        // POST: StaticRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staticRoute = await _context.StaticRoutes.FindAsync(id);
            _context.StaticRoutes.Remove(staticRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaticRouteExists(int id)
        {
            return _context.StaticRoutes.Any(e => e.StaticRouteID == id);
        }
    }
}

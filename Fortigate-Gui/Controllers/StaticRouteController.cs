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
using Fortigate_Gui.ViewModels;

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

        // GET: StaticRoute/Create
        public IActionResult Create()
        {
            CreateStaticRouteViewModel viewModel = new CreateStaticRouteViewModel
            {
                StaticRoute = new StaticRoute(),
                Interfaces = new SelectList(_context.Interfaces, "InterfaceID", "Name")
            };
            return View(viewModel);
        }

        // POST: StaticRoute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStaticRouteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.StaticRoute);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", await _context.StaticRoutes.Include(s => s.Interface).ToListAsync()) });
            }
            viewModel.Interfaces = new SelectList(_context.Interfaces, "InterfaceID", "Name", viewModel.StaticRoute.InterfaceID);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Create", viewModel.StaticRoute) });
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
            EditStaticRouteViewModel viewModel = new EditStaticRouteViewModel
            {
                StaticRoute = staticRoute,
                Interfaces = new SelectList(_context.Interfaces, "InterfaceID", "Name", staticRoute.InterfaceID)
            };
            return View(viewModel);
        }

        // POST: StaticRoute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditStaticRouteViewModel viewModel)
        {
            if (id != viewModel.StaticRoute.StaticRouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(viewModel.StaticRoute);
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.StaticRoutes.Include(s => s.Interface).ToList()) });
            }
            viewModel.Interfaces = new SelectList(_context.Interfaces, "InterfaceID", "Name", viewModel.StaticRoute.InterfaceID);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "Edit", viewModel.StaticRoute) });
        }

        // POST: StaticRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staticRoute = await _context.StaticRoutes.FindAsync(id);
            _context.StaticRoutes.Remove(staticRoute);
            await _context.SaveChangesAsync();
            return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this, "_ViewAll", _context.StaticRoutes.Include(s => s.Interface).ToList()) });
        }

        private bool StaticRouteExists(int id)
        {
            return _context.StaticRoutes.Any(e => e.StaticRouteID == id);
        }
    }
}

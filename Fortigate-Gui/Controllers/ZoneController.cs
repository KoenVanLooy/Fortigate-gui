using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fortigate_Gui.Data;
using Fortigate_Gui.Helper;
using Fortigate_Gui.Models;
using Fortigate_Gui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fortigate_Gui.Controllers
{
        public class ZoneController : Controller
        {
            private readonly ApplicationDbContext _context;

            public ZoneController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Zone
            public async Task<IActionResult> Index()
            {
                return View(await _context.Zones.ToListAsync());
            }

            // GET: Zone/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var zone = await _context.Zones
                    .FirstOrDefaultAsync(m => m.ZoneID == id);
                if (zone == null)
                {
                    return NotFound();
                }

                return View(zone);
            }

            // GET: Zone/Create
            public IActionResult Create()
            {

                CreateZoneViewModel viewModel = new CreateZoneViewModel
                {
                    Zone = new Zone(),
                    InterfaceList = new SelectList(_context.Interfaces, "InterfaceID", "Name"),
                    SelectedInterface = new List<int>()
                };

                return View(viewModel);
            }

            // POST: Zone/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CreateZoneViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    List<ZoneInterface> nieuweRegels = new List<ZoneInterface>();
                    foreach (int InterfaceID in viewModel.SelectedInterface)
                    {
                        ZoneInterface zoneInterface = new ZoneInterface();
                        zoneInterface.InterfaceID = InterfaceID;
                        zoneInterface.ZoneID = viewModel.Zone.ZoneID;

                        nieuweRegels.Add(zoneInterface);
                    }

                    _context.Add(viewModel.Zone);
                    await _context.SaveChangesAsync();
                    Zone zone = await _context.Zones.Include(z => z.ZoneInterfaces)
                        .SingleOrDefaultAsync(x => x.ZoneID == viewModel.Zone.ZoneID);

                    foreach (ZoneInterface zoneinterf in nieuweRegels)
                    {
                        zone.ZoneInterfaces.Add(zoneinterf);
                    }
                    await _context.SaveChangesAsync();

                return Json(new{isValid = true,html = RenderRazorHelper.RenderRazorViewToString(this, "Index", await _context.Zones.ToListAsync())});
                }
                viewModel.InterfaceList = new SelectList(_context.Interfaces, "InterfaceID", "Name");
                return View(viewModel);
            }

            // GET: Zone/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var zone = await _context.Zones.Include(z => z.ZoneInterfaces).
                    SingleOrDefaultAsync(x => x.ZoneID == id);
                if (zone == null)
                {
                    return NotFound();
                }

                EditZoneViewModel viewModel = new EditZoneViewModel
                {
                    Zone = zone,
                    InterfaceList = new SelectList(_context.Interfaces, "InterfaceID", "Name"),
                    SelectedInterface = zone.ZoneInterfaces.Select(zi => zi.InterfaceID)
                };

                return View(viewModel);
            }


            // POST: Zone/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, EditZoneViewModel viewModel)
            {
                Zone zone = await _context.Zones.Include(z => z.ZoneInterfaces)
                .SingleOrDefaultAsync(x => x.ZoneID == id);

                if (id != viewModel.Zone.ZoneID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {

                    zone.Name = viewModel.Zone.Name;


                    List<ZoneInterface> zoneInterfaces = new List<ZoneInterface>();
                    if (viewModel.SelectedInterface == null)
                    {
                        return View(viewModel);
                    }
                    foreach (int interfaceid in viewModel.SelectedInterface)
                    {
                        zoneInterfaces.Add(
                        new ZoneInterface
                        {
                            InterfaceID = interfaceid,
                            ZoneID = viewModel.Zone.ZoneID
                        }
                      );
                    }
                    zone.ZoneInterfaces.RemoveAll(zi => !zoneInterfaces.Contains(zi));
                    zone.ZoneInterfaces.AddRange(zoneInterfaces.Where(zi => !zone.ZoneInterfaces.Contains(zi)));

                    _context.Update(zone);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                viewModel.InterfaceList = new SelectList(_context.Interfaces, "InterfaceID", "Name");
                viewModel.SelectedInterface = zone.ZoneInterfaces.Select(zi => zi.InterfaceID);
                return View(viewModel);
            }

            // GET: Zone/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var zone = await _context.Zones
                    .FirstOrDefaultAsync(m => m.ZoneID == id);
                if (zone == null)
                {
                    return NotFound();
                }

                return View(zone);
            }

            // POST: Zone/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var zone = await _context.Zones.FindAsync(id);
                _context.Zones.Remove(zone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ZoneExists(int id)
            {
                return _context.Zones.Any(e => e.ZoneID == id);
            }
        }
 }


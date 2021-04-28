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
    public class VpnPortalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VpnPortalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VpnPortal
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VpnPortals.Include(v => v.configFile);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VpnPortal/AddOrEdit
        // GET: VpnPortal/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id==0)
            {
                ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID");
                return View(new VpnPortal());
            }
            else
            {
                VpnPortal vpnPortal = await _context.VpnPortals.FindAsync(id);
                if (vpnPortal == null)
                {
                    return NotFound();
                }
                ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID", vpnPortal.ConfigFileID);
                return View(vpnPortal);
            }
            
        }

        // POST: VpnPortal/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("VpnPortalID,PortalName,TunnelMode,SplitTunneling,WebMode,AutoConnect,KeepAlive,SavePassword,IpPool,SplitTunnelingRoute,ConfigFileID")] VpnPortal vpnPortal)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(vpnPortal);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(vpnPortal);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VpnPortalExists(vpnPortal.VpnPortalID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = RenderRazorHelper.RenderRazorViewToString(this,"_ViewAll",_context.VpnPortals.ToList())});
            }
            ViewData["ConfigFileID"] = new SelectList(_context.ConfigFiles, "ConfigfileID", "ConfigfileID", vpnPortal.ConfigFileID);
            return Json(new { isValid = false, html = RenderRazorHelper.RenderRazorViewToString(this, "AddOrEdit", vpnPortal) });
        }

        // GET: VpnPortal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vpnPortal = await _context.VpnPortals
                .Include(v => v.configFile)
                .FirstOrDefaultAsync(m => m.VpnPortalID == id);
            if (vpnPortal == null)
            {
                return NotFound();
            }

            return View(vpnPortal);
        }

        // POST: VpnPortal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vpnPortal = await _context.VpnPortals.FindAsync(id);
            _context.VpnPortals.Remove(vpnPortal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VpnPortalExists(int id)
        {
            return _context.VpnPortals.Any(e => e.VpnPortalID == id);
        }
    }
}
